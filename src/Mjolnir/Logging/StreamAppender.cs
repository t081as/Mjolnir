#region MIT License
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
#endregion

#region Namespaces
using System;
using System.IO;
#endregion

namespace Mjolnir.Logging
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILogAppender"/> interface writing
    /// to a <see cref="Stream"/>.
    /// </summary>
    public class StreamAppender : IDisposable, ILogAppender
    {
        #region Constants and Fields

        /// <summary>
        /// The <see cref="Stream"/> used for logging.
        /// </summary>
        private Stream logStream;

        /// <summary>
        /// The synchonization lock object for the <see cref="logStream"/>.
        /// </summary>
        private object logStreamLock = new object();

        /// <summary>
        /// The implementation of the <see cref="ILogFormatter"/> that shall be used
        /// to format the log messages.
        /// </summary>
        private ILogFormatter logFormatter;

        /// <summary>
        /// Indicates if the class has already been disposed.
        /// </summary>
        private bool disposed = false;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamAppender"/> class.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> that shall be written to.</param>
        /// <param name="formatter">The formatter that shall be unsed to format the log entries.</param>
        public StreamAppender(Stream stream, ILogFormatter formatter)
        {
            this.logStream = stream;
            this.logFormatter = formatter;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="StreamAppender"/> class.
        /// </summary>
        ~StreamAppender()
        {
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        public LogLevel MinLevel { get; set; } = LogLevel.Trace;

        /// <inheritdoc />
        public LogLevel MaxLevel { get; set; } = LogLevel.Fatal;

        #endregion

        #region Methods

        /// <inheritdoc />
        public void Append(LogEntry entry)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            if (entry.Level >= this.MinLevel && entry.Level <= this.MaxLevel)
            {
                byte[] formattedEntry = this.logFormatter.Format(entry);

                lock (this.logStreamLock)
                {
                    this.logStream.Write(formattedEntry, 0, formattedEntry.Length);
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources shall also be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        this.logStream.Dispose();
                    }
                    catch
                    {
                        // The Dispose method must never throw exceptions
                    }
                }

                this.disposed = true;
            }
        }

        #endregion
    }
}
