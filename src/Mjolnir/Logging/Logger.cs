﻿// The MIT License (MIT)
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
using System.Threading;

namespace Mjolnir.Logging
{
    /// <summary>
    /// The default implementation of the <see cref="ILogger"/> interface.
    /// </summary>
    internal class Logger : ILogger
    {
        /// <summary>
        /// The reference to the log entry writer.
        /// </summary>
        private ILogEntryWriter writer;

        /// <summary>
        /// The name of the type this logger is used for.
        /// </summary>
        private string typeName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="writer">The reference to the log entry writer.</param>
        /// <param name="typeName">The name of the type this logger is used for.</param>
        public Logger(ILogEntryWriter writer, string typeName)
        {
            this.writer = writer;
            this.typeName = typeName;
        }

        /// <inheritdoc />
        public void Trace(string message)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Trace,
                Logger = this.typeName,
                Message = message,
                Exception = null,
            });
        }

        /// <inheritdoc />
        public void Debug(string message)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Debug,
                Logger = this.typeName,
                Message = message,
                Exception = null,
            });
        }

        /// <inheritdoc />
        public void Info(string message)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Info,
                Logger = this.typeName,
                Message = message,
                Exception = null,
            });
        }

        /// <inheritdoc />
        public void Warning(string message)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Warning,
                Logger = this.typeName,
                Message = message,
                Exception = null,
            });
        }

        /// <inheritdoc />
        public void Warning(string message, Exception exception)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Warning,
                Logger = this.typeName,
                Message = message,
                Exception = exception,
            });
        }

        /// <inheritdoc />
        public void Error(string message)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Error,
                Logger = this.typeName,
                Message = message,
                Exception = null,
            });
        }

        /// <inheritdoc />
        public void Error(string message, Exception exception)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Error,
                Logger = this.typeName,
                Message = message,
                Exception = exception,
            });
        }

        /// <inheritdoc />
        public void Fatal(string message)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Fatal,
                Logger = this.typeName,
                Message = message,
                Exception = null,
            });
        }

        /// <inheritdoc />
        public void Fatal(string message, Exception exception)
        {
            this.Log(new LogEntry
            {
                TimeStamp = DateTime.UtcNow,
                Thread = Thread.CurrentThread.Name,
                Level = LogLevel.Fatal,
                Logger = this.typeName,
                Message = message,
                Exception = exception,
            });
        }

        /// <inheritdoc />
        public void Log(LogEntry entry)
        {
            this.writer.Write(entry);
        }
    }
}
