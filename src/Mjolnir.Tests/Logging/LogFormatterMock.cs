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
using Mjolnir.Logging;
#endregion

namespace Mjolnir.Tests.Logging
{
    /// <summary>
    /// Represent an implementation of the <see cref="ILogFormatter"/> interface
    /// returning static test data.
    /// </summary>
    public class LogFormatterMock : ILogFormatter
    {
        #region Properties and Fields

        /// <summary>
        /// The static data returned by this moch object.
        /// </summary>
        private byte[] data;

        #endregion

        #region Constructors and Destrutors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFormatterMock"/> class with the given static data.
        /// </summary>
        /// <param name="data">The static data that shall be returned by this instance.</param>
        public LogFormatterMock(byte[] data)
        {
            this.data = data;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public byte[] Format(LogEntry entry)
        {
            return this.data;
        }

        #endregion
    }
}
