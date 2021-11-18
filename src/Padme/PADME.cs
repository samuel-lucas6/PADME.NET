﻿using System.Numerics;

/*
    PADME.NET: A .NET implementation of PADMÉ padding.
    Copyright (c) 2021 Samuel Lucas

    Permission is hereby granted, free of charge, to any person obtaining a copy of
    this software and associated documentation files (the "Software"), to deal in
    the Software without restriction, including without limitation the rights to
    use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
    the Software, and to permit persons to whom the Software is furnished to do so,
    subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

namespace Padme
{
    public class PADME
    {
        public static int GetPaddedLength(int length)
        {
            if (length == 0) { return 0; }
            ulong ulongLength = Convert.ToUInt64(length);
            int exponent = 63 - BitOperations.LeadingZeroCount(ulongLength);
            int exponentBits = 64 - BitOperations.LeadingZeroCount(Convert.ToUInt64(exponent));
            int lowBitsToSetToZero = exponent - exponentBits;
            ulong mask = (Convert.ToUInt64(1) << lowBitsToSetToZero) - 1;
            return (int)((ulongLength + mask) & ~mask);
        }

        public static int GetPaddingLength(int length)
        {
            return GetPaddedLength(length) - length;
        }
    }
}