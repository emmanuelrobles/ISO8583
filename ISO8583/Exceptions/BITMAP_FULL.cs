using System;

namespace ISO8583.Exceptions
{
    public class BITMAP_FULL: Exception
    {
        public BITMAP_FULL(string message)
            : base(message)
        {
        }
        
    }
}