#region MIT License
// The MIT License (MIT)
//
// Copyright © 2017-2019 Tobias Koch <t.koch@tk-software.de>
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
#endregion

#region Namespaces
using System;
using System.IO;
using System.Text;
#endregion

namespace Mjolnir.Logging
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILogFormatter"/> interface writing
    /// log entries to single lines.
    /// </summary>
    public class LineFormatter : ILogFormatter
    {
        #region Constants and Fields

        /// <summary>
        /// The encoding used for writing the entries.
        /// </summary>
        private Encoding encoding;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LineFormatter"/> class.
        /// </summary>
        public LineFormatter()
            : this(new UTF8Encoding(false))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineFormatter"/> class with the given encoding.
        /// </summary>
        /// <param name="encoding">The encoding used for writing the entries.</param>
        public LineFormatter(Encoding encoding)
        {
            this.encoding = encoding;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public byte[] Format(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            throw new NotImplementedException();
        }

        #endregion
    }
}
