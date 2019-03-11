using System;
using System.Collections.Generic;
using System.Linq;

namespace ISO8583.ISO8385
{
    public class Bitmap
    {
        public string[] BitmapRaw => bitmap_raw;

        public string BitmapBits => bitmap_bits;

        public const int BITMAP_LENGTH = 16;

        //hex values
        private string[] bitmap_raw;

        //bits values
        private string bitmap_bits;

        public Bitmap(string bitmap)
        {
            //will contain the each hex value with a space in between
            string hexMap = "";
            //populate hexmap
            while (bitmap.Length > 0)
            {
                hexMap += bitmap.Substring(0, 2);
                bitmap = bitmap.Remove(0, 2);
                hexMap += " ";
            }

            //get rid of last blank space
            hexMap = hexMap.Trim();
            //split the hexmap and save each hex value in bitmap raw
            bitmap_raw = hexMap.Split();

            //convert each hex value to bit representation
            foreach (string value in bitmap_raw)
            {
                bitmap_bits += Convert.ToString(Convert.ToInt32(value, 16), 2).PadLeft(value.Length * 4, '0');
            }
        }
        
        public bool hasNextBitmap()
        {
            if (bitmap_bits[0] == '1')
            {
                return true;
            }

            return false;
        }

        public int[] dataElements()
        {
            List<int> temp_List = new List<int>();

            for (int i = 0; i < bitmap_bits.Length; i++)
            {
                if (bitmap_bits[i].Equals('1'))
                {
                    temp_List.Add(i + 1);
                }
            }

            return temp_List.ToArray();
        }
    }
}