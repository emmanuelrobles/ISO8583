using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISO8583.Exceptions;
using ISO8583.ISO8385;

namespace ISO8583
{
    class Program
    {
        static void Main(string[] args)
        {
//            string message =
//                "020042000400000000021612345678901234560609173030123456789ABC1000123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";

                string message =
                    "0200B2200000001000000000000000800000201234000000010000011072218012345606A5DFGR057ABCDEFGHIJ";
            
            ISO_Parser parser = new ISO_Parser(message);

            parser.Bitmap_manager.getDataElements().ToList().ForEach(Console.WriteLine);

            Console.WriteLine(parser.Bitmap_manager.getBitmapCount());
            
            Console.WriteLine(parser.Code);

        }
    }


}