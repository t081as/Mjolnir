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
using System.Collections.Generic;
#endregion

namespace Mjolnir.Logging
{
    /// <summary>
    /// Produces instances of <see cref="ILogger"/> classes.
    /// </summary>
    internal class LogFactory : ILogFactory, ILogEntryWriter
    {
        #region Constants and Fields

        /// <summary>
        /// The configured log appenders.
        /// </summary>
        private Synchronizable<IEnumerable<ILogAppender>> appenders;

        /// <summary>
        /// The list of produced loggers.
        /// </summary>
        private Synchronizable<Dictionary<string, ILogger>> loggers;

        /// <summary>
        /// The list of log entries that shall be written to all appenders.
        /// </summary>
        private Synchronizable<Queue<LogEntry>> entries;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFactory"/> class with the given log <paramref name="appenders"/>.
        /// </summary>
        /// <param name="appenders">The configured log appenders.</param>
        public LogFactory(IEnumerable<ILogAppender> appenders)
        {
            this.loggers = new Synchronizable<Dictionary<string, ILogger>>(new Dictionary<string, ILogger>());
            this.entries = new Synchronizable<Queue<LogEntry>>(new Queue<LogEntry>());
            this.appenders = new Synchronizable<IEnumerable<ILogAppender>>(appenders);
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        public IEnumerable<ILogAppender> Appenders
        {
            get
            {
                lock (this.appenders.SyncRoot)
                {
                    return this.appenders.Value;
                }
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public ILogger GetLogger<T>()
        {
            return this.GetLogger(typeof(T));
        }

        /// <inheritdoc />
        public ILogger GetLogger(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            string typeName = type.FullName;

            lock (this.loggers.SyncRoot)
            {
                if (!this.loggers.Value.ContainsKey(typeName))
                {
                    this.loggers.Value.Add(typeName, null);
                }

                return this.loggers.Value[typeName];
            }
        }

        /// <inheritdoc />
        public void Write(LogEntry entry)
        {
            if (entry != null)
            {
                lock (this.entries.SyncRoot)
                {
                    this.entries.Value.Enqueue(entry);
                }
            }
        }

        #endregion
    }
}