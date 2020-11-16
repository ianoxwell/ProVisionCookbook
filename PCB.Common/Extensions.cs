using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;

namespace Pcb.Common
{
	/// <summary>
	/// Globally useful extension methods go here.
	/// If the extension method is for web or db context or another specialized class, put it in the appropriate layer, not here.
	/// </summary>
	public static class Extensions
	{
		#region IList<T>

		/// <summary>
		/// Binaries the search.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list">The list.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparer">The comparer.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">list</exception>
		public static int BinarySearch<T>(
			this IList<T> list,
			T value,
			IComparer<T> comparer = null)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			comparer ??= Comparer<T>.Default;

			// Use native implementation where possible.
			if (list is List<T> nativeList)
			{
				return nativeList.BinarySearch(value, comparer);
			}

			// Perform custom binary search, see:
			// https://stackoverflow.com/a/967098
			var lower = 0;
			var upper = list.Count - 1;

			while (lower <= upper)
			{
				var middle = lower + (upper - lower) / 2;
				var comparisonResult = comparer.Compare(value, list[middle]);
				if (comparisonResult == 0)
				{
					return middle;
				}
				else if (comparisonResult < 0)
				{
					upper = middle - 1;
				}
				else
				{
					lower = middle + 1;
				}
			}

			return ~lower;
		}

		/// <summary>
		/// Implementation of List.GetRange for IList.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="fromIndex">From index.</param>
		/// <param name="toIndex">To index.</param>
		/// <returns></returns>
		public static IEnumerable<T> GetRange<T>(
			this IList<T> source,
			int fromIndex,
			int toIndex)
		{
			var currIndex = fromIndex;
			while (currIndex <= toIndex)
			{
				yield return source[currIndex];
				currIndex++;
			}
		}

		#endregion

		#region ISet<T>

		/// <summary>
		/// Shortcut to loop on hashset values.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		public static void ForEach<T>(this ISet<T> source, Action<T> action)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			foreach (var item in source)
			{
				action(item);
			}
		}

		#endregion

		#region Nullable<T>

		/// <summary>
		/// Equivalent of T-SQL nullif() - Returns null if the nullIfValue matches the existing value, else just returns the value.
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="nullable">The nullable.</param>
		/// <param name="nullIfValue">The null if value.</param>
		/// <returns></returns>
		public static T? NullIf<T>(this T? nullable, T nullIfValue)
			where T : struct
		{
			return nullable?.NullIf(nullIfValue);
		}

		/// <summary>
		/// Equivalent of T-SQL nullif() - Returns null if the nullIfValue matches the existing value, else just returns the value.
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="nullIfValue">The null if value.</param>
		/// <returns></returns>
		public static T? NullIf<T>(this T value, T nullIfValue)
			where T : struct
		{
			return value.Equals(nullIfValue)
				? (T?)null
				: value;
		}

		/// <summary>
		/// Returns null where the passed struct has its default value,
		/// e.g. for an int, 0; for a DateTime, MinValue;
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T? NullIfDefault<T>(this T value)
			where T : struct
		{
			return value.NullIf(default(T));
		}

		/// <summary>
		/// Returns null where the passed struct has its default value,
		/// e.g. for an int, 0; for a DateTime, MinValue;
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="nullable">The nullable.</param>
		/// <returns></returns>
		public static T? NullIfDefault<T>(this T? nullable)
			where T : struct
		{
			return nullable.NullIf(default(T));
		}

		/// <summary>
		/// Equivalent of T-SQL nullif() - Returns null if the nullIfValue matches the existing value, else just returns the value.
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="nullIfValue">The null if value.</param>
		/// <returns></returns>
		public static T NullIfObj<T>(this T value, T nullIfValue)
			where T : class
		{
			return value.Equals(nullIfValue)
				? null
				: value;
		}

		/// <summary>
		/// Returns the enumerable where it has values, else null.
		/// </summary>
		/// <typeparam name="T">T</typeparam>
		/// <param name="enumerable">The enumerable.</param>
		/// <returns></returns>
		public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> enumerable)
		{
			// ReSharper disable once PossibleMultipleEnumeration
			return (enumerable?.Any() ?? false)
				? enumerable
				: null;
		}

		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable)
		{
			return enumerable ?? Enumerable.Empty<T>();
		}

		/// <summary>
		/// One-liner for nulling out a string if it's empty.
		/// </summary>
		/// <param name="source">T</param>
		/// <returns></returns>
		public static string NullIfEmpty(this string source)
		{
			return string.IsNullOrEmpty(source)
				? null
				: source;
		}

		/// <summary>
		/// Returns null if the string is empty or whitespace.
		/// </summary>
		/// <param name="value">T</param>
		/// <returns></returns>
		public static string NullIfWhiteSpace(this string value)
		{
			return !string.IsNullOrWhiteSpace(value) ? value : null;
		}

		#endregion Nullable<T>

		#region byte[]

		/// <summary>
		/// Accepts the 8 bytes from a SQL Server rowversion type and converts
		/// it to the ulong it represents.
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static ulong FromSqlRowVersion(this byte[] bytes)
		{
			var number = BitConverter.ToUInt64(bytes.Reverse().ToArray(), 0);
			return number;
		}

		/// <summary>
		/// Converts an object to any common type.
		/// The type must have a converter defined in the TypeDescriptor class, else
		/// the extension method customised for the user-defined-type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static T? ToNullable<T>(this object obj)
			where T : struct
		{
			try
			{
				// Sanity
				if (obj == null)
				{
					return null;
				}

				// Sanity special case for reading in database data
				if (obj == DBNull.Value)
				{
					return null;
				}

				// Sanity special case- we don't want to convert empty strings to anything
				var str = obj as string;
				if (str != null && string.IsNullOrWhiteSpace(str))
				{
					return null;
				}

				// Convert from passed type if possible
				var conv = TypeDescriptor.GetConverter(typeof(T));
				if (conv.CanConvertFrom(obj.GetType()))
				{
					return (T?)conv.ConvertFrom(obj);
				}

				// Else convert from string representation of passed object
				return (T?)conv.ConvertFrom(obj.ToString());
			}
			catch
			{
				// Catch all exceptions and return null
				return null;
			}
		}

		#endregion

		#region OrderBy Helpers

		public static IOrderedQueryable<T> OrderByMember<T>(this IQueryable<T> source, string memberPath)
		{
			return source.OrderByMemberUsing(memberPath, "OrderBy");
		}

		public static IOrderedQueryable<T> OrderByMemberDescending<T>(this IQueryable<T> source, string memberPath)
		{
			return source.OrderByMemberUsing(memberPath, "OrderByDescending");
		}

		public static IOrderedQueryable<T> ThenByMember<T>(this IOrderedQueryable<T> source, string memberPath)
		{
			return source.OrderByMemberUsing(memberPath, "ThenBy");
		}

		public static IOrderedQueryable<T> ThenByMemberDescending<T>(this IOrderedQueryable<T> source, string memberPath)
		{
			return source.OrderByMemberUsing(memberPath, "ThenByDescending");
		}

		private static IOrderedQueryable<T> OrderByMemberUsing<T>(this IQueryable<T> source, string memberPath, string method)
		{
			var parameter = Expression.Parameter(typeof(T), "item");
			var member = memberPath.Split('.')
				.Aggregate((Expression)parameter, Expression.PropertyOrField);
			var keySelector = Expression.Lambda(member, parameter);
			var methodCall = Expression.Call(
				typeof(Queryable), method, new[] { parameter.Type, member.Type },
				source.Expression, Expression.Quote(keySelector));
			return (IOrderedQueryable<T>)source.Provider.CreateQuery(methodCall);
		}

		#endregion

		#region Datetime Helpers
		public static bool IsSameDateValue(this DateTime source, DateTime compareValue)
		{
			if (source.Year == compareValue.Year &&
				source.Month == compareValue.Month &&
				source.Day == compareValue.Day)
			{
				return true;
			}

			return false;
		}

		public static string GetFormattedDateString(this DateTime? source)
		{
			if (!source.HasValue)
			{
				return string.Empty;
			}

			return source.Value.ToString("dd/MM/yyyy");
		}

		public static string GetFormattedDateTimeString(this DateTime? source)
		{
			if (!source.HasValue)
			{
				return string.Empty;
			}

			return source.Value.ToString("dd/MM/yyyy hh:mm tt");
		}

		public static string GetFormattedDateString(this DateTime source)
		{
			return source.ToString("dd/MM/yyyy");
		}

		public static string GetFormattedDateTimeString(this DateTime source)
		{
			return source.ToString("dd/MM/yyyy hh:mm tt");
		}

		public static string GetFormatted24HrTimeString(this DateTime? source)
		{
			return source?.ToString("HH:mm") ?? string.Empty;
		}

		public static string GetFormatted12HrTimeString(this DateTime? source)
		{
			return source?.ToString("hh:mm tt") ?? string.Empty;
		}
		#endregion

		#region String Helpers

		public static string ToQueryString(this NameValueCollection source, bool removeEmptyEntries)
		{
			return source != null ? "?" + string.Join("&", source.AllKeys
				.Where(key => !removeEmptyEntries || source.GetValues(key).Any(value => !string.IsNullOrEmpty(value)))
				.SelectMany(key => source.GetValues(key)
					.Where(value => !removeEmptyEntries || !string.IsNullOrEmpty(value))
					.Select(value => string.Format("{0}={1}", HttpUtility.UrlEncode(key), value != null ? HttpUtility.UrlEncode(value) : string.Empty)))
				.ToArray())
				: string.Empty;
		}

		/// <summary>
		/// Changes camel case text to more friendly display text
		/// </summary>
		/// <param name="text">The camel case string</param>
		/// <returns>The display string</returns>
		public static string CamelToDisplay(this string text)
		{
			return Regex.Replace(
				Regex.Replace(
					text,
					@"(\P{Ll})(\P{Ll}\p{Ll})",
					"$1 $2"),
				@"(\p{Ll})(\P{Ll})",
				"$1 $2");
		}

		#endregion String Helpers
	}
}
