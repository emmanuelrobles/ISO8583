using System;

namespace ISO8583.Exceptions
{
    class MTI_EXC_LNG : Exception
    {
        public MTI_EXC_LNG(string message)
            : base(message)
        {
        }
    }
}