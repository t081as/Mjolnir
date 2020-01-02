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
    /// Represents a single log entry.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        public LogEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class with the given values.
        /// </summary>
        /// <param name="timeStamp">The timestamp of this log entry.</param>
        /// <param name="logger">The name of the logger that recorded this entry.</param>
        /// <param name="level">The level of this log message.</param>
        /// <param name="thread">The name of the thread that emitted this entry.</param>
        /// <param name="message">The log message.</param>
        public LogEntry(DateTime timeStamp, string logger, LogLevel level, string? thread, string message)
        {
            this.TimeStamp = timeStamp;
            this.Logger = logger;
            this.Level = level;
            this.Thread = thread;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the timestamp of this log entry.
        /// </summary>
        /// <value>The timestamp of this log entry.</value>
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the name of the logger that recorded this entry.
        /// </summary>
        /// <value>The name of the logger that recorded this entry.</value>
        public string Logger { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the level of this log message.
        /// </summary>
        /// <value>The level of this log message.</value>
        public LogLevel Level { get; set; } = LogLevel.Trace;

        /// <summary>
        /// Gets or sets the name of the thread that emitted this entry.
        /// </summary>
        /// <value>The name of the thread that emitted this entry.</value>
        public string? Thread { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the log message.
        /// </summary>
        /// <value>The log message.</value>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the <see cref="Exception"/> associated with this entry.
        /// </summary>
        /// <value>The <see cref="Exception"/> associated with this entry.</value>
        public Exception? Exception { get; set; } = null;
    }
}