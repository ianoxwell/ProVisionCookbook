using System;
using System.Transactions;

namespace Pcb.Database
{
    /// <summary>
    /// Factory to create TransactionScope
    /// </summary>
    public static class TransactionScopeFactory
    {
		/**
		 * CPT is not to use Snapshot Isolation because it is not big, and should not have all the overhead that comes with Snapshot.
		 * Use ReadCommitted instead!
		 */
        private const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadCommitted;
        private const int DefaultTimeoutSecs = 30;

        /// <summary>
        /// Creates a new transaction scope using default CIMHA options.
        /// Use this if you need to wrap db calls in a transaction and don't need any special behaviour.
        /// </summary>
        /// <returns></returns>
        public static TransactionScope Required(
            IsolationLevel? preferredIsolationLevel = null, int? timeoutOverrideSecs = null)
        {
            var isolationLevel = preferredIsolationLevel ?? DefaultIsolationLevel;
            var timeoutSeconds = timeoutOverrideSecs ?? DefaultTimeoutSecs;

            var options = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = new TimeSpan(0, 0, timeoutSeconds)
            };

            var scope = new TransactionScope(TransactionScopeOption.Required,
                options, TransactionScopeAsyncFlowOption.Enabled);

            return scope;
        }

        /// <summary>
        /// Creates a new transaction scope that will ensure wrapped commands are
        /// excluded from parent transactions.
        /// Try to use suppressed scopes when writing config/helper services
        /// that may be called from within other transactions but shouldn't compete
        /// with them for resources.
        /// </summary>
        /// <returns></returns>
        public static TransactionScope Suppressed(
            IsolationLevel? preferredIsolationLevel = null, int? timeoutOverrideSecs = null)
        {
            var isolationLevel = preferredIsolationLevel ?? DefaultIsolationLevel;
            var timeoutSeconds = timeoutOverrideSecs ?? DefaultTimeoutSecs;

            var options = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = new TimeSpan(0, 0, timeoutSeconds)
            };

            var scope = new TransactionScope(TransactionScopeOption.Suppress,
                options, TransactionScopeAsyncFlowOption.Enabled);

            return scope;
        }
    }
}
