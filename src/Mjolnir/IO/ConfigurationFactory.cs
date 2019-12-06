﻿// The MIT License (MIT)
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

namespace Mjolnir.IO
{
    /// <summary>
    /// Creates and returns implementations of the <see cref="IConfiguration"/> interface.
    /// </summary>
    public static class ConfigurationFactory
    {
        /// <summary>
        /// Creates and returns an implementation of the <see cref="IConfiguration"/> interface.
        /// </summary>
        /// <returns>A new implementation of the <see cref="IConfiguration"/> interface.</returns>
        public static IConfiguration New()
        {
            return new DefaultConfiguration();
        }

        /// <summary>
        /// Creates and returns an implementation of the <see cref="IConfiguration"/> interface
        /// base on the given <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> that shall be copied.</param>
        /// <returns>A new implementation of the <see cref="IConfiguration"/> interface.</returns>
        public static IConfiguration Copy(IConfiguration configuration)
        {
            return new DefaultConfiguration(configuration);
        }
    }
}
