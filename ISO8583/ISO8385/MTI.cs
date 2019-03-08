using System;
using ISO8583.Exceptions;

namespace ISO8583.ISO8385
{
public class MTI
    {
        private char[] code;

        //ISO VERSION
        //RESERVED BY ISO THE OTHERS
        public enum FIRST_DIGIT
        {
            ISO_8583_1987 = 0,
            ISO_8583_1993 = 1,
            ISO_8583_2003 = 2,
            NATIONAL_USE = 8,
            PRIVATE_USE = 9,

            RESERVED_BY_ISO = -1
        }

        //MESSAGE CLASS
        //RESERVED BY ISO
        public enum SECOND_DIGIT
        {
            RESERVED_BY_ISO = -1,

            AUTHORIZATION_MESSAGE = 1,
            FINANCIAL_MESSAGE = 2,
            FILE_ACTION_MESSAGE = 3,
            REVERSAL_AND_CHARGEBACK_MESSAGES = 4,
            RECONSILIATION_MESSAGE = 5,
            ADMINISTRATIVE_MESSAGE = 6,
            FEE_COLLECTION_MESSAGE = 7,
            NETWORK_MANAGEMENT_MESSAGE = 8
        }

        //MESSAGE FUNCTION
        public enum THIRD_DIGIT
        {
            REQUEST = 0,
            REQUEST_RESPONSE = 1,
            ADVICE = 2,
            ADVICE_RESPONSE = 3,
            NOTIFICATION = 4,
            NOTIFICATION_ACKNOWLEDGEMENT = 5,
            INSTRUCTION = 6,
            INSTRUCTION_ACKNOWLEDGEMENT = 7,

            RESERVED_BY_ISO = -1
        }

        //MESAGE ORIGIN
        public enum FOURTH_DIGIT
        {
            ACQUIRER = 0,
            ACQUIRER_REPEAT = 1,
            ISSUER = 2,
            ISSUER_REPEAT = 3,
            OTHER = 4,
            OTHER_REPEAT = 5,

            RESERVED_BY_ISO = -1
        }

        //Constructor
        public MTI(string MTI)
        {
            if (MTI.Length != 4)
            {
                throw new MTI_EXC_LNG("MTI Length incorrect");
            }

            code = MTI.ToCharArray();
        }

        public FIRST_DIGIT getFirstDigit()
        {
            int digit = code[0] - '0';

            if (!Enum.IsDefined(typeof(FIRST_DIGIT), digit))
            {
                return FIRST_DIGIT.RESERVED_BY_ISO;
            }

            return (FIRST_DIGIT) digit;
        }

        public SECOND_DIGIT getSecondDigit()
        {
            int digit = code[1] - '0';

            if (!Enum.IsDefined(typeof(SECOND_DIGIT), digit))
            {
                return SECOND_DIGIT.RESERVED_BY_ISO;
            }

            return (SECOND_DIGIT) digit;
        }

        public THIRD_DIGIT getThirdDigit()
        {
            int digit = code[2] - '0';

            if (!Enum.IsDefined(typeof(THIRD_DIGIT), digit))
            {
                return THIRD_DIGIT.RESERVED_BY_ISO;
            }

            return (THIRD_DIGIT) digit;
        }

        public FOURTH_DIGIT GetFourthDigit()
        {
            int digit = code[3] - '0';

            if (!Enum.IsDefined(typeof(FOURTH_DIGIT), digit))
            {
                return FOURTH_DIGIT.RESERVED_BY_ISO;
            }

            return (FOURTH_DIGIT) digit;
        }

        public int[] getMTI()
        {
            int[] MTI = new int[code.Length];

            for (int i = 0; i < code.Length; i++)
            {
                MTI[i] = code[i] - '0';
            }

            return MTI;
        }
    }
}