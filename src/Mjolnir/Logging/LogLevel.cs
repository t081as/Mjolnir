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

namespace Mjolnir.Logging
{
    /// <summary>
    /// Represents the level of a log message.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Trace log level.
        /// </summary>
        Trace = 10,

        /// <summary>
        /// Debug log level.
        /// </summary>
        Debug = 20,

        /// <summary>
        /// Info log level.
        /// </summary>
        Info = 30,

        /// <summary>
        /// Warning log level.
        /// </summary>
        Warning = 40,

        /// <summary>
        /// Error log level.
        /// </summary>
        Error = 50,

        /// <summary>
        /// Fatal log level.
        /// </summary>
        Fatal = 60,
    }
}