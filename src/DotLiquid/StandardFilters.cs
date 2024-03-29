﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using DotLiquid.Util;

namespace DotLiquid
{
    /// <summary>
    /// Standard Liquid filters
    /// </summary>
    public static class StandardFilters
    {
        /// <summary>
        /// Return the size of an array or of an string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Size(object input)
        {
            if (input is string stringInput)
            {
                return stringInput.Length;
            }
            if (input is IEnumerable enumerableInput)
            {
                return enumerableInput.Cast<object>().Count();
            }
            return 0;
        }

        /// <summary>
        /// Return a Part of a String
        /// </summary>
        /// <param name="input"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Slice(string input, int start, int len = 1)
        {
            if (input == null || start > input.Length)
                return null;

            if (start < 0)
            { 
                start += input.Length;
            }
            if (start + len > input.Length)
            { 
                len = input.Length - start;
            }
            return input.Substring(start, len);
        }

        /// <summary>
        /// convert a input string to DOWNCASE
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Downcase(string input)
        {
            return input == null ? input : input.ToLower();
        }

        /// <summary>
        /// convert a input string to UPCASE
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Upcase(string input)
        {
            return input == null
                ? input
                : input.ToUpper();
        }

        /// <summary>
        /// convert a input string to URLENCODE
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlEncode(string input)
        {
            return input == null
                ? input
                : Uri.EscapeDataString(input);
        }

        /// <summary>
        /// capitalize words in the input sentence
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Capitalize(string input)
        {
            if (input.IsNullOrWhiteSpace())
                return input;

            return string.IsNullOrEmpty(input)
                ? input
#if CORE
                : Regex.Replace(input, @"\b(\w)", m => m.Value.ToUpper(), RegexOptions.None, Template.RegexTimeOut);
#else
                : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
#endif
        }

        /// <summary>
        /// Escape html chars
        /// </summary>
        /// <param name="input">String to escape</param>
        /// <returns>Escaped string</returns>
        /// <remarks>Alias of H</remarks>
        public static string Escape(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            try
            {
                return WebUtility.HtmlEncode(input);
            }
            catch
            {
                return input;
            }
        }

        /// <summary>
        /// Escape html chars
        /// </summary>
        /// <param name="input">String to escape</param>
        /// <returns>Escaped string</returns>
        /// <remarks>Alias of Escape</remarks>
        public static string H(string input)
        {
            return Escape(input);
        }

        /// <summary>
        /// Truncates a string down to x characters
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <param name="truncateString"></param>
        /// <returns></returns>
        public static string Truncate(string input, int length = 50, string truncateString = "...")
        {
            if (string.IsNullOrEmpty(input))
                return input;

            int l = length - truncateString.Length;

            return input.Length > length
                ? input.Substring(0, l < 0 ? 0 : l) + truncateString
                : input;
        }

        /// <summary>
        /// Truncate a string down to x words
        /// </summary>
        /// <param name="input"></param>
        /// <param name="words"></param>
        /// <param name="truncateString"></param>
        /// <returns></returns>
        public static string TruncateWords(string input, int words = 15, string truncateString = "...")
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var wordList = input.Split(' ').ToList();
            int l = words < 0 ? 0 : words;

            return wordList.Count > l
                ? string.Join(" ", wordList.Take(l).ToArray()) + truncateString
                : input;
        }

        /// <summary>
        /// Split input string into an array of substrings separated by given pattern.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string[] Split(string input, string pattern)
        {
            return input.IsNullOrWhiteSpace()
                ? new[] { input }
                : input.Split(new[] { pattern }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Strip all html nodes from input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripHtml(string input)
        {
            return input.IsNullOrWhiteSpace()
                ? input
                : Regex.Replace(input, @"<.*?>", string.Empty, RegexOptions.None, Template.RegexTimeOut);
        }

        /// <summary>
        /// Converts the input object into a formatted currency as specified by the culture info.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string Currency(object input, string cultureInfo = null)
        {

            if (decimal.TryParse(input.ToString(), out decimal amount))
            {
                if (cultureInfo.IsNullOrWhiteSpace())
                {
                    cultureInfo = CultureInfo.CurrentCulture.Name;
                }

                var culture = new CultureInfo(cultureInfo);

                return amount.ToString("C", culture);
            }

            return input.ToString();
        }

        /// <summary>
        /// Remove all newlines from the string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripNewlines(string input)
        {
            return input.IsNullOrWhiteSpace()
                ? input
                : Regex.Replace(input, @"(\r?\n)", string.Empty, RegexOptions.None, Template.RegexTimeOut);
        }

        /// <summary>
        /// Join elements of the array with a certain character between them
        /// </summary>
        /// <param name="input"></param>
        /// <param name="glue"></param>
        /// <returns></returns>
        public static string Join(IEnumerable input, string glue = " ")
        {
            if (input == null)
                return null;

            IEnumerable<object> castInput = input.Cast<object>();

            return string.Join(glue, castInput);
        }

        /// <summary>
        /// Sort elements of the array
        /// provide optional property with which to sort an array of hashes or drops
        /// </summary>
        /// <param name="input"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IEnumerable Sort(object input, string property = null)
        {
            List<object> ary;
            if (input is IEnumerable enumerableInput)
            { 
                ary = enumerableInput.Flatten().Cast<object>().ToList();
            }
            else
            { 
                ary = new List<object>(new[] { input });
            }

            if (!ary.Any())
                return ary;

            if (string.IsNullOrEmpty(property))
            { 
                ary.Sort();
            }
            else if ((ary.All(o => o is IDictionary)) && ((IDictionary)ary.First()).Contains(property))
            { 
                ary.Sort((a, b) => Comparer<object>.Default.Compare(((IDictionary)a)[property], ((IDictionary)b)[property]));
            }
            else if (ary.All(o => o.RespondTo(property)))
            { 
                ary.Sort((a, b) => Comparer<object>.Default.Compare(a.Send(property), b.Send(property)));
            }

            return ary;
        }

        /// <summary>
        /// Map/collect on a given property
        /// </summary>
        /// <param name="input"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IEnumerable Map(IEnumerable input, string property)
        {
            List<object> ary = input.Cast<object>().ToList();
            if (!ary.Any())
                return ary;

            if ((ary.All(o => o is IDictionary)) && ((IDictionary)ary.First()).Contains(property))
                return ary.Select(e => ((IDictionary)e)[property]);
            if (ary.All(o => o.RespondTo(property)))
                return ary.Select(e => e.Send(property));

            return ary;
        }

        /// <summary>
        /// Replace occurrences of a string with another
        /// </summary>
        /// <param name="input"></param>
        /// <param name="string"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string Replace(string input, string @string, string replacement = "")
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(@string))
                return input;

            return string.IsNullOrEmpty(input)
                ? input
                : Regex.Replace(input, @string, replacement, RegexOptions.None, Template.RegexTimeOut);
        }

        /// <summary>
        /// Replace the first occurence of a string with another
        /// </summary>
        /// <param name="input"></param>
        /// <param name="string"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string ReplaceFirst(string input, string @string, string replacement = "")
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(@string))
                return input;

            bool doneReplacement = false;
            return Regex.Replace(input, @string, m =>
            {
                if (doneReplacement)
                    return m.Value;

                doneReplacement = true;
                return replacement;
            }, RegexOptions.None, Template.RegexTimeOut);
        }

        /// <summary>
        /// Remove a substring
        /// </summary>
        /// <param name="input"></param>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string Remove(string input, string @string)
        {
            return input.IsNullOrWhiteSpace()
                ? input
                : input.Replace(@string, string.Empty);
        }

        /// <summary>
        /// Remove the first occurrence of a substring
        /// </summary>
        /// <param name="input"></param>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string RemoveFirst(string input, string @string)
        {
            return input.IsNullOrWhiteSpace()
                ? input
                : ReplaceFirst(input, @string, string.Empty);
        }

        /// <summary>
        /// Add one string to another
        /// </summary>
        /// <param name="input"></param>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string Append(string input, string @string)
        {
            return input == null
                ? input
                : input + @string;
        }

        /// <summary>
        /// Prepend a string to another
        /// </summary>
        /// <param name="input"></param>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string Prepend(string input, string @string)
        {
            return input == null
                ? input
                : @string + input;
        }

        /// <summary>
        /// Add <br /> tags in front of all newlines in input string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string NewlineToBr(string input)
        {
            return input.IsNullOrWhiteSpace()
                    ? input
                    : Regex.Replace(input, @"(\r?\n)", "<br />$1", RegexOptions.None, Template.RegexTimeOut);
        }

        /// <summary>
        /// Formats a date using a .NET date format string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Date(object input, string format)
        {
            string value;

            if (input == null)
                return null;

            value = input.ToString();

            if (format.IsNullOrWhiteSpace())
                return value;

            DateTime date;

            if (string.Equals(value, "now", StringComparison.OrdinalIgnoreCase) || string.Equals(value, "today", StringComparison.OrdinalIgnoreCase))
            {
                date = DateTime.Now;
            }
            else if (!DateTime.TryParse(value, out date))
            {
                return value;
            }

            return Liquid.UseRubyDateFormat ? date.ToStrFTime(format) : date.ToString(format);
        }

        /// <summary>
        /// Get the first element of the passed in array
        ///
        /// Example:
        ///   {{ product.images | first | to_img }}
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static object First(IEnumerable array)
        {
            if (array == null)
                return null;

            return array.Cast<object>().FirstOrDefault();
        }

        /// <summary>
        /// Get the last element of the passed in array
        ///
        /// Example:
        ///   {{ product.images | last | to_img }}
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static object Last(IEnumerable array)
        {
            if (array == null)
                return null;

            return array.Cast<object>().LastOrDefault();
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="input"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static object Plus(object input, object operand)
        {
            return input is string
                ? string.Concat(input, operand)
                : DoMathsOperation(input, operand, Expression.Add);
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        /// <param name="input"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static object Minus(object input, object operand)
        {
            return DoMathsOperation(input, operand, Expression.Subtract);
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="input"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static object Times(object input, object operand)
        {
            return input is string && operand is int
                ? Enumerable.Repeat((string)input, (int)operand)
                : DoMathsOperation(input, operand, Expression.Multiply);
        }

        /// <summary>
        /// Rounds a decimal value to the specified places
        /// </summary>
        /// <param name="input"></param>
        /// <param name="places"></param>
        /// <returns>The rounded value; null if an exception have occured</returns>
        public static object Round(object input, object places = null)
        {
            try
            {
                var p = places == null ? 0 : Convert.ToInt32(places);
                var i = Convert.ToDecimal(input);
                return Math.Round(i, p);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Division
        /// </summary>
        /// <param name="input"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static object DividedBy(object input, object operand)
        {
            return DoMathsOperation(input, operand, Expression.Divide);
        }

        /// <summary>
        /// Performs an arithmetic remainder operation on the input
        /// </summary>
        /// <param name="input"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static object Modulo(object input, object operand)
        {
            return DoMathsOperation(input, operand, Expression.Modulo);
        }

        /// <summary>
        /// If a value isn't set for a variable in the template, allow the user to specify a default value for that variable
        /// </summary>
        /// <param name="input"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string Default(string input, string @defaultValue)
        {
            return !string.IsNullOrWhiteSpace(input) ? input : defaultValue;
        }

        private static bool IsReal(object o) => o is double || o is float;

        private static object DoMathsOperation(object input, object operand, Func<Expression, Expression, BinaryExpression> operation)
        {
            if (input == null || operand == null)
                return null;

            if (IsReal(input) || IsReal(operand))
            {
                input = Convert.ToDouble(input);
                operand = Convert.ToDouble(operand);
            }

            return ExpressionUtility.CreateExpression
                                    (operation, input.GetType(), operand.GetType(), input.GetType(), true)
                                    .DynamicInvoke(input, operand);
        }
    }

    internal static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrEmpty(s) || s.Trim().Length == 0;
        }
    }
}