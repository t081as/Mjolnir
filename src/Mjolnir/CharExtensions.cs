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
#endregion

namespace Mjolnir
{
    /// <summary>
    /// Contains extension methods for the <see cref="char"/> class.
    /// </summary>
    public static class CharExtensions
    {
        #region Methods

        /// <summary>
        /// Returns a <see cref="string"/> containing the given <paramref name="character"/> <paramref name="count"/> times.
        /// </summary>
        /// <param name="character">The character that shall be repeated.</param>
        /// <param name="count">The number of repetitions.</param>
        /// <returns>A <see cref="string"/> containing the given characters.</returns>
        public static string Repeat(this char character, int count)
        {
            return new string(character, count);
        }

        #endregion
    }
}
