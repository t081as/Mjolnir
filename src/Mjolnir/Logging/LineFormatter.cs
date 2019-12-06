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
using System.Globalization;
using System.Text;

namespace Mjolnir.Logging
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILogFormatter"/> interface writing
    /// log entries to single lines.
    /// </summary>
    public class LineFormatter : ILogFormatter
    {
        /// <summary>
        /// The encoding used for writing the entries.
        /// </summary>
        private Encoding encoding;

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

        /// <inheritdoc />
        public byte[] Format(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            StringBuilder logMessageBuilder = new StringBuilder();
            StringBuilder exceptionBuilder = new StringBuilder();
            StringBuilder logLineBuilder = new StringBuilder();

            logMessageBuilder.Append($"{entry.Logger}: ");
            logMessageBuilder.Append(entry.Message ?? string.Empty);

            if (entry.Exception != null)
            {
                Exception currentException = entry.Exception;

                while (currentException != null)
                {
                    exceptionBuilder.AppendLine($"{currentException.GetType().ToString()}: {currentException.Message}");
                    exceptionBuilder.AppendLine(currentException.StackTrace);
                    currentException = currentException.InnerException;
                }

                logMessageBuilder.AppendLine(exceptionBuilder.ToString());
            }

            foreach (string line in logMessageBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                // Date and time
                logLineBuilder.Append(entry.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
                logLineBuilder.Append(' '.Repeat(2));

                // Severity
                switch (entry.Level)
                {
                    case LogLevel.Trace:
                        logLineBuilder.Append("TRACE");
                        break;

                    case LogLevel.Debug:
                        logLineBuilder.Append("DEBUG");
                        break;

                    case LogLevel.Info:
                        logLineBuilder.Append("INFO ");
                        break;

                    case LogLevel.Warning:
                        logLineBuilder.Append("WARN ");
                        break;

                    case LogLevel.Error:
                        logLineBuilder.Append("ERROR");
                        break;

                    case LogLevel.Fatal:
                        logLineBuilder.Append("FATAL");
                        break;

                    default:
                        throw new NotImplementedException();
                }

                logLineBuilder.Append(' '.Repeat(2));

                // Thread
                string threadName = entry.Thread;

                if (string.IsNullOrEmpty(threadName))
                {
                    threadName = "UNKN";
                }

                if (threadName.Length > 4)
                {
                    threadName = threadName.Substring(0, 4);
                }
                else if (threadName.Length < 4)
                {
                    threadName += ' '.Repeat(4 - threadName.Length);
                }

                logLineBuilder.Append(threadName);
                logLineBuilder.Append(' '.Repeat(2));

                // Message
                logLineBuilder.Append(' '.Repeat(2));
                logLineBuilder.Append(line);
            }

            return this.encoding.GetBytes(logLineBuilder.ToString());
        }
    }
}
