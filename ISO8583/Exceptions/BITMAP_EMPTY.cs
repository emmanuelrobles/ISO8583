using System;

namespace ISO8583.Exceptions
{
    public class BITMAP_EMPTY: Exception
    {
        public BITMAP_EMPTY(string message)
            : base(message)
        {
        }
    }
}