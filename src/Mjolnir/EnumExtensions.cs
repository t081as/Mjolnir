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
using System.ComponentModel;
using System.Linq;

namespace Mjolnir
{
    /// <summary>
    /// Contains extension methods of the <see cref="Enum"/> class.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the <see cref="DescriptionAttribute"/> of the given enum <paramref name="value"/>
        /// or the <paramref name="value"/> if no description attribute is available.
        /// </summary>
        /// <param name="value">The value whose description shall be returned.</param>
        /// <returns>
        /// The <see cref="DescriptionAttribute"/> of the value or the value itself if no description is available.
        /// </returns>
        public static string AsString(this Enum value)
        {
            if (value != null)
            {
                var enumFieldInfo = value.GetType().GetField(value.ToString());
                var enumFieldAttributes = enumFieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (enumFieldAttributes != null && enumFieldAttributes.Any())
                {
                    return enumFieldAttributes.First().Description;
                }
                else
                {
                    return value.ToString();
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
