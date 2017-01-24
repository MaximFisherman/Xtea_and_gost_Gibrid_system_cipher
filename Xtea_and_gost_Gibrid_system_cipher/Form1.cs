using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtea_and_gost_Gibrid_system_cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str_R_decode;
        string str_L_decode;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            string str = null;
            str = textBox1.Text;

            string strCount = "";
            int count = 0;
            if (str.Length < 16)
            {
                count = 16 - str.Length;
            }

            if(count != 0)
            for (int i = 0; i < count; i++)
                strCount += "*";

            str = str.Insert(str.Length, strCount);


            //Encript
            XTea xtea = new XTea();
            string str_L = str.Substring(0, 8);
            string str_R = str.Substring(8, 7);
            string str_L_round_1 = str_L;
            ///Encode left side
            str_L = xtea.Encrypt(str_R, "1234567890123456");
            textBox2.Text = str_L;
            
            ///Encode right side
            str_R = Ghost.encode(str_L_round_1, "maksimmaksimmaksimmaksimmaksimmaksim");
            textBox3.Text = str_R;
            
            //////////Reverse////////////////////////////////////////////////
            string str_R_round_1 = str_R;
            str_R = xtea.Encrypt(str_L, "1234567890123456");
            textBox6.Text = str_R;

            str_L = Ghost.encode(str_R_round_1, "maksimmaksimmaksimmaksimmaksimmaksim");
            string s = Ghost.decode(str_L, "maksimmaksimmaksimmaksimmaksimmaksim");
            textBox5.Text = str_L;
            str_R_round_1 = str_R;
            textBox4.Text += str_R+str_L;
            str_R_decode = str_R_round_1;
            str_L_decode = str_L;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XTea xtea = new XTea();
            string str_R = Ghost.decode(str_L_decode, "maksimmaksimmaksimmaksimmaksimmaksim");
            string str_L = xtea.Decrypt(str_R_decode, "1234567890123456");



            str_L = xtea.Decrypt(str_L, "1234567890123456");
            str_R = Ghost.decode(str_R, "maksimmaksimmaksimmaksimmaksimmaksim");
            textBox4.Text = "";
            textBox4.Text += str_R + str_L;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
    }
}
