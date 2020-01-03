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
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Logging;

namespace Mjolnir.Tests.Logging
{
    /// <summary>
    /// Contains unit tests for the <see cref="LineFormatter"/> class.
    /// </summary>
    [TestClass]
    public class LineFormatterTests
    {
        /// <summary>
        /// Checks the <see cref="LineFormatter.Format(LogEntry)"/> method using the log level <c>Trace</c>.
        /// </summary>
        [TestMethod]
        public void FormatTraceTest()
        {
            string formattedText = FormatTest(LogLevel.Trace);
            StringAssert.Contains(formattedText, "TRACE");
        }

        /// <summary>
        /// Checks the <see cref="LineFormatter.Format(LogEntry)"/> method using the log level <c>Debug</c>.
        /// </summary>
        [TestMethod]
        public void FormatDebugTest()
        {
            string formattedText = FormatTest(LogLevel.Debug);
            StringAssert.Contains(formattedText, "DEBUG");
        }

        /// <summary>
        /// Checks the <see cref="LineFormatter.Format(LogEntry)"/> method using the log level <c>Info</c>.
        /// </summary>
        [TestMethod]
        public void FormatInfoTest()
        {
            string formattedText = FormatTest(LogLevel.Info);
            StringAssert.Contains(formattedText, "INFO");
        }

        /// <summary>
        /// Checks the <see cref="LineFormatter.Format(LogEntry)"/> method using the log level <c>Warning</c>.
        /// </summary>
        [TestMethod]
        public void FormatWarningTest()
        {
            string formattedText = FormatTest(LogLevel.Warning);
            StringAssert.Contains(formattedText, "WARN");
        }

        /// <summary>
        /// Checks the <see cref="LineFormatter.Format(LogEntry)"/> method using the log level <c>Error</c>.
        /// </summary>
        [TestMethod]
        public void FormatErrorTest()
        {
            string formattedText = FormatTest(LogLevel.Error);
            StringAssert.Contains(formattedText, "ERROR");
        }

        /// <summary>
        /// Checks the <see cref="LineFormatter.Format(LogEntry)"/> method using the log level <c>Fatal</c>.
        /// </summary>
        [TestMethod]
        public void FormatFatalTest()
        {
            string formattedText = FormatTest(LogLevel.Fatal);
            StringAssert.Contains(formattedText, "FATAL");
        }

        /// <summary>
        /// Checks if the <see cref="LineFormatter.Format(LogEntry)"/> method can handle an empty thread name.
        /// </summary>
        [TestMethod]
        public void FormatThreadNullTest()
        {
            LineFormatter formatter = new LineFormatter();
            LogEntry entry = new LogEntry();
            entry.Thread = null;

            byte[] unusedResult = formatter.Format(entry);
        }

        /// <summary>
        /// Checks if the <see cref="LineFormatter.Format(LogEntry)"/> method can handle an entry without exception.
        /// </summary>
        [TestMethod]
        public void FormatExceptionNullTest()
        {
            LineFormatter formatter = new LineFormatter();
            LogEntry entry = new LogEntry();
            entry.Exception = null;

            byte[] unusedResult = formatter.Format(entry);
        }

        /// <summary>
        /// Formats a test log entry with the given <paramref name="level"/>.
        /// </summary>
        /// <param name="level">The desired log level.</param>
        /// <returns>A <see cref="string"/> containing the formatted log message.</returns>
        private static string FormatTest(LogLevel level)
        {
            ApplicationException e1 = new ApplicationException("ApplicationException-Message");
            Exception e2 = new Exception("Exception-Message", e1);

            LogEntry entry = new LogEntry();
            entry.Level = level;
            entry.Thread = "TH1";
            entry.Logger = "Mjolnir.Tests.Logging.LineFormatterTests";
            entry.Message = "This is a simple test message\nwith a line break";
            entry.Exception = e2;

            LineFormatter formatter = new LineFormatter();
            string formattedText = new UTF8Encoding(false).GetString(formatter.Format(entry));

            StringAssert.Contains(formattedText, "TH1");
            StringAssert.Contains(formattedText, "Mjolnir.Tests.Logging.LineFormatterTests");
            StringAssert.Contains(formattedText, "This is a simple test message");
            StringAssert.Contains(formattedText, "with a line break");
            StringAssert.Contains(formattedText, "Exception-Message");
            StringAssert.Contains(formattedText, "ApplicationException-Message");

            return formattedText;
        }
    }
}