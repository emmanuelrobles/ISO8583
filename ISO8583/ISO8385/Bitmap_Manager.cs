using System;
using System.Collections.Generic;
using ISO8583.Exceptions;

namespace ISO8583.ISO8385
{
    public class Bitmap_Manager
    {
        public const int BITMAP_LENGTH = 3;

        private List<Bitmap> bitmap;

        public Bitmap_Manager()
        {
            bitmap = new List<Bitmap>(3);
        }

        public void addBitmap(Bitmap bitmap)
        {
            if (this.bitmap.Count == BITMAP_LENGTH)
            {
                throw new BITMAP_FULL("Already have the maximum of 3 bitmaps");
            }

            this.bitmap.Add(bitmap);
        }

        public Bitmap getBitmap(int pos)
        {
            if (pos >= BITMAP_LENGTH || pos > bitmap.Count)
            {
                throw new ArgumentOutOfRangeException("Bitmap " + pos + " does not exist");
            }

            return bitmap[pos];
        }

        public bool hasNextBitmap()
        {
            if (bitmap.Count == 0)
            {
                throw new BITMAP_EMPTY("No Bitmaps were added");
            }

            return bitmap[bitmap.Count - 1].hasNextBitmap();
        }

        public int[] getDataElements()
        {
            List<int> temp_dataElements = new List<int>();

            int flag_sum = 0;
            foreach (Bitmap b in bitmap)
            {
                foreach (int element in b.dataElements())
                {
                    temp_dataElements.Add(element + flag_sum);
                }

                flag_sum = 64;
            }

            return temp_dataElements.ToArray();
        }

        public int getBitmapCount()
        {
            return bitmap.Count;
        }
    }
}