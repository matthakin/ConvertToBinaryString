using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToBinaryString
{
    public class ConvertToBinaryString
    {
        // This holds the string representation of the number
        private String Binaryresult;

        // This holds the integer value
        private Int32 intVal;


        // These three variables tell is it is 8 16 or 32 bit number
        private bool Is8bit = false;
        private bool Is16bit = false;
        private bool Is32bit = false;
        private String hihBits;
        private String loBits;
        private string sBinaryValue;
        // Standard Constructor
        public ConvertToBinaryString() : this(1)
        {

        }
        // Main Constructor
        public ConvertToBinaryString(Int32 inNum)
        {

            intVal = inNum;
            hihBits = "00000000";
            loBits = "00000000";
            // Decide if the number is 8, 16 or 32 bit
            if (intVal < 256)
            {
                Binaryresult = cConvert8(intVal);
                //splitIntoTo8bitStrings(Binaryresult);
            }
            else if (intVal < 65536 && intVal > 255)
            {
                Binaryresult = cConvert16(intVal);
                //splitIntoTo8bitStrings(Binaryresult);
            }
            else
            {
                Binaryresult = cConvert32(intVal);
               // splitIntoTo8bitStrings("00000000000000000000000000000000");
            }

            splitIntoTo8bitStrings();
        }

        public int returnIntFromTwosComplement16bit(string uBinary)
        {
            string s = uBinary;
            s = s.PadLeft(32, s[0]);
            int i = Convert.ToInt32(s, 2);
            return i;
        }

        // This method combines two strings that are 8 bit representtions of a number 
        // This arguments must be 8 characters long
        public string CombineTwo8BitBinaryStrings(string frontString, string rearString)
        {
            string f = "";
            if ((frontString.Length < 8 || rearString.Length < 8)|| (frontString == "00000000" && rearString == "00000000"))
            {
                Binaryresult = "00000000";
                hihBits = "00000000";
                loBits = "00000000";
                Is8bit = true;
                Is16bit = false;
                Is32bit = false;
                intVal = 0;
            }
            else
            {


               

                

                if ((isBinaryString(frontString) && isBinaryString(rearString)) || frontString[0] != '1')
                {
                    String tempStr = frontString + rearString;
                    Binaryresult = tempStr;
                    Int64 tempInt;
                    hihBits = frontString;
                    loBits = rearString;



                    // Set the integer value for the object
                    tempInt = Convert.ToInt64(removeLeadingZeros(tempStr), 2);
                    intVal = (int)tempInt;
                    // Decide if 8, 16 or 32 bits based on number of chars
                    if ((removeLeadingZeros(tempStr).Length < 9))
                    {
                        Is8bit = true;
                        Is16bit = false;
                        Is32bit = false;
                    }
                    else if ((removeLeadingZeros(tempStr).Length > 8 && tempStr.Length < 17))
                    {
                        Is8bit = false;
                        Is16bit = true;
                        Is32bit = false;
                    }
                    else if ((removeLeadingZeros(tempStr).Length > 16))
                    {
                        Is8bit = false;
                        Is16bit = false;
                        Is32bit = true;
                    }
                }
                else
                {
                    Binaryresult = "0000000000000000";
                    intVal = 0;
                    Is8bit = false;
                    Is16bit = true;
                    Is32bit = false;


                
                }
               
            }
            // returns full 32 char string
            

            return Binaryresult;
            
        }

        // get binary string
        public virtual string BinaryString
        {
            get { return Binaryresult; }
        }

        // get integer value
        public virtual Int32 IntValue
        {
            get { return intVal; }
            set
            {
                intVal = value;
                hihBits = "00000000";
                loBits = "00000000";
                if (intVal < 256)
                {
                    Binaryresult = cConvert8(intVal);
                    //splitIntoTo8bitStrings(Binaryresult);
                }
                else if (intVal < 65536 && intVal > 255)
                {
                    Binaryresult = cConvert16(intVal);
                    //splitIntoTo8bitStrings(Binaryresult);
                }
                else
                {
                    Binaryresult = cConvert32(intVal);
                    //splitIntoTo8bitStrings("00000000000000000000000000000000");
                }
                splitIntoTo8bitStrings();

            }
        }

        public virtual string BinaryValue
        {
            get
            {
                if (Is8bit)
                {
                    return cConvert8(intVal);
                } else if (Is16bit)
                {
                    return cConvert16(intVal);
                }
                else if (Is32bit)
                {
                    return cConvert32(intVal);
                }else
                {
                    return "00000000";
                }
            }
        }


        // return what kind of int
        public virtual bool is8bit
        {
            get { return Is8bit; }
        }
        public virtual bool is16bit
        {
            get { return Is16bit; }
        }
        public virtual bool is32bit
        {
            get { return Is32bit; }
        }

        public virtual string HiBits
        {
            get { return hihBits; }
        }
        public virtual string LoBits
        {
            get { return loBits; }
        }


        // convert an 8 bit number to a string
        private string cConvert8(Int32 inV)
        {
            int decimalnumber = intVal;
            int remainder;
            string result = string.Empty;
            // set the int type
            Is8bit = true;
            Is16bit = false;
            Is32bit = false;


            while (decimalnumber > 0)
            {
                remainder = decimalnumber % 2;
                decimalnumber /= 2;
                result = remainder.ToString() + result;

            }

            if (result.Length < 8)
            {
                for (int i = 1; i < (9 - (result.Length)); i++)
                {
                    result = "0" + result;

                }
                if (result.Length == 4)
                {
                    result = "0" + result;
                }
                if (result.Length == 5)
                {
                    result = "0" + result;
                }
                if (result.Length == 6)
                {
                    result = "0" + result;
                }
                if (result.Length == 7)
                {
                    result = "0" + result;
                }

            }

            return result;
        }

        private string cConvert16(Int32 inV)
        {
            int decimalnumber = intVal;
            int remainder;
            string result = string.Empty;
            Is8bit = false;
            Is16bit = true;
            Is32bit = false;
            while (decimalnumber > 0)
            {
                remainder = decimalnumber % 2;
                decimalnumber /= 2;
                result = remainder.ToString() + result;

            }

            if (result.Length < 16)
            {
                for (int i = 0; i < (17 - result.Length); i++)
                {
                    result = "0" + result;
                }
            }
            if (result.Length == 12)
            {
                result = "0" + result;
            }
            if (result.Length == 13)
            {
                result = "0" + result;
            }
            if (result.Length == 14)
            {
                result = "0" + result;
            }
            if (result.Length == 15)
            {
                result = "0" + result;
            }

            return result;
        }

        private string cConvert32(Int32 inV)
        {
            int decimalnumber = intVal;
            int remainder;
            string result = string.Empty;
            Is8bit = false;
            Is16bit = false;
            Is32bit = true;
            while (decimalnumber > 0)
            {
                remainder = decimalnumber % 2;
                decimalnumber /= 2;
                result = remainder.ToString() + result;

            }

            if (result.Length < 32)
            {
                for (int i = 0; i < (32 - result.Length); i++)
                {
                    result = "0" + result;
                }
            }
            if (result.Length == 23)
            {
                result = "0" + result;
            }
            if (result.Length == 24)
            {
                result = "0" + result;
            }
            if (result.Length == 25)
            {
                result = "0" + result;
            }
            if (result.Length == 26)
            {
                result = "0" + result;
            }
            if (result.Length == 27)
            {
                result = "0" + result;
            }
            if (result.Length == 28)
            {
                result = "0" + result;
            }
            if (result.Length == 29)
            {
                result = "0" + result;
            }
            if (result.Length == 30)
            {
                result = "0" + result;
            }
            if (result.Length == 31)
            {
                result = "0" + result;
            }

            return result;
        }

        private string removeLeadingZeros(string sString)
        {
            string returnString = "";
            bool isFinished = false;
            int ct = 0;
            bool sss = sString.StartsWith("1");
            while (!isFinished)
            {
                if (sString.StartsWith("0"))
                {
                    isFinished = false;
                    returnString = sString.Substring(1);
                    sString = returnString;
                }
                else
                {
                    isFinished = true;
                    break;
                }
                ct++;

                if (ct > 32)
                {
                    isFinished = true;
                }
            }



            return returnString;
        }


        private bool isBinaryString(string inBinString)
        {
            int sLen = inBinString.Length;
            bool bStatus = true;


            for (int i = 0; i < sLen; i++)
            {

                if (inBinString[i].ToString() == "0" || inBinString[i].ToString() == "1")
                {
                    bStatus = true;
                }
                else
                {
                    bStatus = false;
                    break;
                }
            }

            return bStatus;
        }

        private void splitIntoTo8bitStrings()
        {
            hihBits = "";
            loBits = "";
            if (is8bit)
            {
                hihBits = "00000000";
                loBits = Binaryresult;
                
            }
            else if (Is16bit)
            {
               // hihBits = "00000000";
               //loBits = "00000000";
                hihBits = Binaryresult.Substring(0, 8);
                loBits = Binaryresult.Substring(8, 8);
            }
            else
            {
                hihBits = "00000000";
                loBits = "00000000";
            }
        }

    }
}
