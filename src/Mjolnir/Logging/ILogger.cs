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

namespace Mjolnir.Logging
{
    /// <summary>
    /// Describes objects allowing to emit log entries.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        void Trace(string message);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        void Debug(string message);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        void Info(string message);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        void Warning(string message);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/> appending the given <paramref name="exception"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        /// <param name="exception">The <see cref="Exception"/> that shall be appended.</param>
        void Warning(string message, Exception exception);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        void Error(string message);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/> appending the given <paramref name="exception"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        /// <param name="exception">The <see cref="Exception"/> that shall be appended.</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        void Fatal(string message);

        /// <summary>
        /// Emits a log entry with the given <paramref name="message"/> appending the given <paramref name="exception"/>.
        /// </summary>
        /// <param name="message">The message that shall be emitted.</param>
        /// <param name="exception">The <see cref="Exception"/> that shall be appended.</param>
        void Fatal(string message, Exception exception);

        /// <summary>
        /// Emits the given <paramref name="entry"/>.
        /// </summary>
        /// <param name="entry">The entry that shall be emitted.</param>
        void Log(LogEntry entry);
    }
}
