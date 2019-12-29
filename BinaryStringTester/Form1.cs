using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryStringTester
{
    public partial class Form1 : Form
    {
        ConvertToBinaryString.ConvertToBinaryString BS;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string hiVal = "11111111";
            string loVal = "11111111";

            BS = new ConvertToBinaryString.ConvertToBinaryString(0);
            if (hiVal[0] == '1')
            {
                hiVal = "0" + hiVal;
            }

            string poo = BS.CombineTwo8BitBinaryStrings(hiVal, loVal);
            this.Text = BS.IntValue.ToString();
           


            string ff = BS.CombineTwo8BitBinaryStrings(hiVal, "11111111");

           //int twosComp = BS.returnIntFromTwosComplement16bit("1111111111110111");

            this.Text = BS.IntValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strOne = textBox1.Text;
            string strTwo = textBox2.Text;
            BS.CombineTwo8BitBinaryStrings(strOne, strTwo);
            this.Text = BS.IntValue.ToString();
        }
    }
}
