/*
    PADME.NET: A .NET implementation of PADMÉ padding.
    Copyright (c) 2021-2022 Samuel Lucas

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

using System.Numerics;

namespace Padme;

public static class PADME
{
    public static ulong GetPaddedLength(ulong length)
    {
        if (length == 0) { return 0; }
        int exponent = 63 - BitOperations.LeadingZeroCount(length);
        int exponentBits = 64 - BitOperations.LeadingZeroCount((ulong)exponent);
        int zeroBits = exponent - exponentBits;
        ulong mask = ((ulong)1 << zeroBits) - 1;
        return (length + mask) & ~mask;
    }

    public static ulong GetPaddingLength(ulong length)
    {
        return GetPaddedLength(length) - length;
    }
}