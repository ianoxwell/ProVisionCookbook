using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Pcb.Configuration;
using System;
using System.Data;
using System.Transactions;

namespace Pcb.Database
{
	public class ServiceBase<T>
		where T : DbContext, new()
	{
		protected const CommandType CtProc = CommandType.StoredProcedure;
		protected const int DbStringMaxSize = -1;

		protected IPcbConfiguration Configuration { get; private set; }

		protected ILogger Logger { get; private set; }

		public ServiceBase(IPcbConfiguration configurationService, ILogger logger)
		{
			Configuration = configurationService;
			Logger = logger;
		}

		/// <summary>
		/// Retries the execution.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		protected IExecutionStrategy RetryExecution(T context)
		{
			return context.Database.CreateExecutionStrategy();
		}

		/// <summary>
		/// Gets a DbContext for EF Core Read-only access.
		/// </summary>
		/// <returns></returns>
		protected T GetReadOnlyDbContext()
		{
			var optionsBuilder = new DbContextOptionsBuilder<T>();
			optionsBuilder
				.UseSqlServer(Configuration.PcbAppSettings.ConnectionStrings.Query, t =>
				{
					t.EnableRetryOnFailure(3);
					t.CommandTimeout(10);
				});

			var dbcontext = Activator.CreateInstance(typeof(T), optionsBuilder.Options) as T;

			return dbcontext;
		}

		/// <summary>
		/// Gets a DbContext for EF Core Read/Write access.
		/// </summary>
		/// <returns></returns>
		protected T GetReadWriteDbContext()
		{
			var optionsBuilder = new DbContextOptionsBuilder<T>();
			optionsBuilder
				.UseSqlServer(Configuration.PcbAppSettings.ConnectionStrings.Command, t =>
				{
					t.EnableRetryOnFailure(3);
					t.CommandTimeout(10);
				});

			var dbcontext = Activator.CreateInstance(typeof(T), optionsBuilder.Options) as T;

			return dbcontext;
		}

		/// <summary>
		/// Creates a new transaction scope using default options.
		/// Use this if you need to wrap db calls in a transaction and don't need any special behaviour.
		/// </summary>
		/// <returns></returns>
		protected static TransactionScope GetTransactionScope(
			System.Transactions.IsolationLevel? preferredIsolationLevel = null,
			int? timeoutOverrideSecs = null) => TransactionScopeFactory.Required(
				preferredIsolationLevel, timeoutOverrideSecs);

		/// <summary>
		/// Creates a new transaction scope that will ensure wrapped commands are
		/// excluded from parent transactions.
		/// Try to use suppressed scopes when writing config/helper services
		/// that may be called from within other transactions but shouldn't compete
		/// with them for resources.
		/// </summary>
		/// <returns></returns>
		protected TransactionScope GetSuppressedTransactionScope(System.Transactions.IsolationLevel? preferredIsolationLevel = null,
			int? timeoutOverrideSecs = null) => TransactionScopeFactory.Suppressed(
				preferredIsolationLevel, timeoutOverrideSecs);

		/// <summary>
		/// Gets an IDbConnection Dapper read-only access.
		/// </summary>
		/// <returns></returns>
		protected IDbConnection GetReadOnlyDbConnection()
		{
			var connString = Configuration.PcbAppSettings.ConnectionStrings.Query;
			var conn = new SqlConnection(connString);
			return conn;
		}

		/// <summary>
		/// Gets an IDbConnection Dapper read/write access.
		/// </summary>
		/// <returns></returns>
		protected IDbConnection GetReadWriteDbConnection()
		{
			var connString = Configuration.PcbAppSettings.ConnectionStrings.Command;
			var conn = new SqlConnection(connString);
			return conn;
		}

		/// <summary>
		/// Returns true if the exception has been handled and doesn't require rethrow.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		protected bool HandleSqlException(SqlException e)
		{
			if (e == null)
			{
				return true;
			}

			var isHandled = false;
			try
			{
				if (e.Number == (int)SqlExceptionNumber.UserConcurrencyException)
				{
					throw new DBConcurrencyException(e.Message, e);
				}
			}
			finally
			{
				// Log if we successfully handled an exception.
				// If the exception wasn't handled stay silent- it'll bubble and be handled elsewhere.
				if (isHandled)
				{
					Logger.LogWarning(e, "SqlException successfully handled by Pcb services.");
				}
			}

			return isHandled;
		}
	}

	public enum SqlExceptionNumber
	{
		UserException = 50000,
		UserConcurrencyException = 50409,
		UserLockException = 50423,
		UserBadRequest = 50400
	}
}
