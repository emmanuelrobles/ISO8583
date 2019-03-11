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
            bitmap = new List<Bitmap>(BITMAP_LENGTH);
        }

        //add a bitmap
        public void addBitmap(Bitmap bitmap)
        {
            if (this.bitmap.Count == BITMAP_LENGTH)
            {
                throw new BITMAP_FULL("Already have the maximum of 3 bitmaps");
            }

            this.bitmap.Add(bitmap);
        }

        //get the bitmap at a given poss
        public Bitmap getBitmap(int pos)
        {
            if (pos >= BITMAP_LENGTH || pos > bitmap.Count)
            {
                throw new ArgumentOutOfRangeException("Bitmap " + pos + " does not exist");
            }

            return bitmap[pos];
        }

        
        //check if the last bitmap has a next bitmap
        public bool hasNextBitmap()
        {
            if (bitmap.Count == 0)
            {
                throw new BITMAP_EMPTY("No Bitmaps were added");
            }

            return bitmap[bitmap.Count - 1].hasNextBitmap();
        }

        //get an array with the data elements of all bitmaps
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

        
        //get the ammount of bitmaps
        public int getBitmapCount()
        {
            return bitmap.Count;
        }
    }
}