// The MIT License (MIT)
//
// Copyright © 2017-2020 Tobias Koch
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the “Software”), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.IO;
using System.Text;

namespace Mjolnir.Build.IO
{
    /// <summary>
    /// Contains tasks related to text files.
    /// </summary>
    public static class TextTasks
    {
        /// <summary>
        /// Gets an <see cref="UTF8Encoding"/> without BOM.
        /// </summary>
        public static UTF8Encoding UTF8EncodingNoBom => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        /// <summary>
        /// Replaces the given <paramref name="values"/> in a text file.
        /// </summary>
        /// <param name="fileName">The path and filename of the text file.</param>
        /// <param name="values">One or more tuples of a search term and a replacement.</param>
        /// <exception cref="ArgumentNullException"><c>fileName</c> is null.</exception>
        /// <exception cref="FileNotFoundException"><c>fileName</c> could not be found.</exception>
        public static void ReplaceInFile(string fileName, params (string searchTerm, string replacement)[] values)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File {fileName} not found", fileName);
            }

            string content = File.ReadAllText(fileName);

            foreach (var (searchTerm, replacement) in values)
            {
                content = content.Replace(searchTerm, replacement);
            }

            File.WriteAllText(fileName, content, UTF8EncodingNoBom);
        }
    }
}
