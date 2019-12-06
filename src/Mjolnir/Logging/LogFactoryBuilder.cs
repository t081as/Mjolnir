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
using System.Collections.Generic;

namespace Mjolnir.Logging
{
    /// <summary>
    /// Produces instances of <see cref="ILogFactory"/> classes.
    /// </summary>
    public class LogFactoryBuilder
    {
        /// <summary>
        /// The log appenders used to produce an instance of the <see cref="ILogFactory"/> class.
        /// </summary>
        private List<ILogAppender> appenders;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFactoryBuilder"/> class.
        /// </summary>
        private LogFactoryBuilder()
        {
            this.appenders = new List<ILogAppender>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFactoryBuilder"/> class.
        /// </summary>
        /// <returns>A new instance of the <see cref="LogFactoryBuilder"/> class.</returns>
        public static LogFactoryBuilder New()
        {
            return new LogFactoryBuilder();
        }

        /// <summary>
        /// Adds the given log <paramref name="appender"/>.
        /// </summary>
        /// <param name="appender">An instance of the <see cref="ILogAppender"/> interface.</param>
        /// <returns>The current <see cref="LogFactoryBuilder"/>.</returns>
        public LogFactoryBuilder WithAppender(ILogAppender appender)
        {
            this.appenders.Add(appender);
            return this;
        }

        /// <summary>
        /// Produces an instance of the <see cref="ILogFactory"/> class.
        /// </summary>
        /// <returns>An instance of the <see cref="ILogFactory"/> class.</returns>
        public ILogFactory Build()
        {
            return new LogFactory(this.appenders);
        }
    }
}