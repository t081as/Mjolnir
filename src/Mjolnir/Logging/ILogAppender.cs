// The MIT License (MIT)
//
// Copyright © 2017-2019 Tobias Koch
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

namespace Mjolnir.Logging
{
    /// <summary>
    /// Describes objects allowing to emit log entries to a specific sink.
    /// </summary>
    public interface ILogAppender
    {
        /// <summary>
        /// Gets or sets the minimum log level processed by this log appender.
        /// </summary>
        /// <value>The minimum log level processed by this log appender.</value>
        LogLevel MinLevel { get; set; }

        /// <summary>
        /// Gets or sets the maximum log level processed by this log appender.
        /// </summary>
        /// <value>The maximum log level processed by this log appender.</value>
        LogLevel MaxLevel { get; set; }

        /// <summary>
        /// Appends the given <paramref name="entry"/> to the specific sink.
        /// </summary>
        /// <param name="entry">The <see cref="LogEntry"/> that shall be appended.</param>
        void Append(LogEntry entry);
    }
}
