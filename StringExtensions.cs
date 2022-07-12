namespace TypeExtensions
{
    /// <summary>
    /// Extensions for string types.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all chars that <paramref name="pred"/> returns true for.
        /// </summary>
        public static string RemoveIf(this string s, Predicate<char> pred)
        {
            for (int i = s.Length - 1; i >= 0; --i)
            {
                if (pred(s[i]))
                    s = s.Remove(i, i);
            }

            return s;
        }
        /// <summary>
        /// Removes all preceeding/trailing occurrences of the specified characters from a string.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <param name="trimChars">Any number of characters in a string.</param>
        /// <returns>String with all preceeding/trailing characters from trimChars removed.</returns>
        public static string Trim(this string s, string trimChars)
            => s.Trim(trimChars.ToCharArray());

        /// <summary>
        /// Gets the <see langword="char"/> at <paramref name="index"/>, or <paramref name="defaultChar"/> if the index is out of range.
        /// </summary>
        /// <param name="s">The string that this extension method was called on.</param>
        /// <param name="index">The target index within the string to access.</param>
        /// <param name="defaultChar">A character to return when the index is out-of-range.</param>
        /// <returns>The character at <paramref name="index"/> in <paramref name="s"/> if the index is within range; otherwise <paramref name="defaultChar"/>.</returns>
        public static char AtIndexOrDefault(this string s, int index, char defaultChar) => index < s.Length ? s[index] : defaultChar;
        /// <summary>
        /// Gets the <see langword="char"/> at <paramref name="index"/>, or the result of the <see langword="default"/> keyword if the index is out of range.
        /// </summary>
        /// <returns>The character at <paramref name="index"/> in <paramref name="s"/> if the index is within range; otherwise <see langword="default"/>.</returns>
        /// <inheritdoc cref="AtIndexOrDefault(string, int, char)"/>
        public static char AtIndexOrDefault(this string s, int index) => s.AtIndexOrDefault(index, default);
        /// <summary>
        /// Check if <paramref name="s"/> equals any of the given <paramref name="compare"/> strings using <paramref name="sCompareType"/> comparison.
        /// </summary>
        /// <param name="s">A string.</param>
        /// <param name="sCompareType">The <see cref="StringComparison"/> to use.</param>
        /// <param name="compare">Any number of strings to compare to <paramref name="s"/>.</param>
        /// <returns><see langword="true"/> when <paramref name="s"/> equals at least one of the <paramref name="compare"/> strings; otherwise <see langword="false"/></returns>
        public static bool EqualsAny(this string s, StringComparison sCompareType, params string[] compare) => compare.Any(c => s.Equals(c, sCompareType));
        /// <summary>
        /// Check if <paramref name="s"/> equals any of the given <paramref name="compare"/> strings using <see cref="StringComparison.Ordinal"/> comparison.
        /// </summary>
        /// <inheritdoc cref="EqualsAny(string, StringComparison, string[])"/>
        public static bool EqualsAny(this string s, params string[] compare) => s.EqualsAny(StringComparison.Ordinal, compare);
        /// <summary>
        /// Retrieves as much of a substring from this instance as possible without exceeding its boundaries.<br/>
        /// </summary>
        /// <remarks>
        /// This method differs from <see cref="string.Substring(int, int)"/> by not throwing out-of-range exceptions, and instead returns as much of the substring as possible.
        /// </remarks>
        /// <param name="s">The <see cref="string"/> instance to operate on.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in <paramref name="s"/>.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>
        /// A string that is equivalent to the substring of up to length <paramref name="length"/> that begins at <paramref name="startIndex"/> in this instance, or <see cref="string.Empty"/> if <paramref name="startIndex"/> is greater or equal to the length of this instance.
        /// </returns>
        public static string TrySubstring(this string s, int startIndex, int length)
        {
            if (startIndex > s.Length)
                startIndex = s.Length;
            return s.Substring(startIndex, Math.Min(length, s.Length - startIndex));
        }
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
        /// </summary>
        /// <remarks>
        /// This method differs from <see cref="string.Substring(int)"/> by not throwing out-of-range exceptions, and instead returns as much of the substring as possible.
        /// </remarks>
        /// <param name="s">The <see cref="string"/> instance to operate on.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in <paramref name="s"/>.</param>
        /// <returns>
        /// A string that is equivalent to the substring that begins at <paramref name="startIndex"/> in <paramref name="s"/>, or <see cref="string.Empty"/> if <paramref name="startIndex"/> is greater or equal to the length of <paramref name="s"/>.
        /// </returns>
        public static string TrySubstring(this string s, int startIndex)
        {
            if (startIndex > s.Length)
                startIndex = s.Length;
#           pragma warning disable IDE0057
            return s.Substring(startIndex);
#           pragma warning restore IDE0057
        }
    }
}
