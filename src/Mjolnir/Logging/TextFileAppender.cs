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
#endregion

namespace Mjolnir.Logging
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILogAppender"/> interface writing
    /// to a simple text file
    /// </summary>
    public class TextFileAppender
    {
        #region Constants and Fields

        /// <summary>
        /// The <see cref="StreamWriter"/> pointing to the log file.
        /// </summary>
        private StreamWriter logWriter;

        /// <summary>
        /// The implementation of the <see cref="ILogFormatter"/> that shall be used
        /// to format the log messages.
        /// </summary>
        private ILogFormatter logFormatter;

        #endregion

        #region Constructors and Destructors

        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion
    }
}
