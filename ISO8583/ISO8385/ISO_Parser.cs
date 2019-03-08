using System.Collections.Generic;

namespace ISO8583.ISO8385
{
    public class ISO_Parser
    {
        public MTI Mti => mti;
        public string Message => message;
        public Bitmap_Manager Bitmap_manager => bitmap_manager;
        public string Code => code;

        private MTI mti;
        private Bitmap_Manager bitmap_manager;
        private string message;
        private string code;

        public const int BITMAP_LENGHT = 16;
        public const int MTI_LENGHT = 4;

        public ISO_Parser(string message)
        {
            //get the message
            this.message = message;

            //initialize bitmap manager
            bitmap_manager = new Bitmap_Manager();

            //get the MTI
            mti = getMTI(ref message);

            //as long as we have another bitmap add it
            do
            {
                bitmap_manager.addBitmap(getBitmap(ref message));
            } while (bitmap_manager.hasNextBitmap());

            //the rest of the message is the code
            code = message;
        }

        private MTI getMTI(ref string message, bool remove_flag = true)
        {
            string mti = message.Substring(0, MTI_LENGHT);

            if (remove_flag)
            {
                message = message.Remove(0, MTI_LENGHT);
            }


            return new MTI(mti);
        }

        private Bitmap getBitmap(ref string message, bool remove_flag = true)
        {
            string bitmap = message.Substring(0, BITMAP_LENGHT);

            if (remove_flag)
            {
                message = message.Remove(0, BITMAP_LENGHT);
            }

            return new Bitmap(bitmap);
        }
    }
}