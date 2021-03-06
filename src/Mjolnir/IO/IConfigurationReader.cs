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
using System.IO;
using System.Threading.Tasks;

namespace Mjolnir.IO
{
    /// <summary>
    /// Describes objects allowing to read configuration data from a <see cref="Stream"/>.
    /// </summary>
    public interface IConfigurationReader
    {
        /// <summary>
        /// Reads configuration data from the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the configuration data.</param>
        /// <returns>A new implementation of the <see cref="IConfiguration"/> interface representing the configuration data.</returns>
        /// <exception cref="IOException">Error while reading the data.</exception>
        IConfiguration Read(Stream stream);

        /// <summary>
        /// Reads configuration data from the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the configuration data.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that represents the asynchronous write operation.
        /// The <c>TResult</c> parameter contains an implementation of the <see cref="IConfiguration"/>
        /// interface representing the configuration data.
        /// </returns>
        /// <exception cref="IOException">Error while reading the data.</exception>
        Task<IConfiguration> ReadAsync(Stream stream);
    }
}
