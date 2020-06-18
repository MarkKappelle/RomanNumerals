using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanNumerals
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> roman_numerals = new Dictionary<string, int>()
        {
            {"I",1},
            {"V",5},
            {"X",10},
            {"L",50},
            {"C",100},
            {"D",500},
            {"M",1000}
        };
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void NumeralClick(object sender, EventArgs e)
        {
            Button bnum = (Button)sender;

            ResultBoxOne.Text = ResultBoxOne.Text + bnum.Text;
        }

        public int NumeralsToInt(string numerals)
        {
            int number_int = 0;
            char[] numerals_arr = numerals.ToCharArray();
            if (numerals_arr.Length == 1)
            {
               
                return roman_numerals[numerals_arr[0].ToString()];
            }
            else
            {
                for (int i = 0; i < numerals_arr.Length; i++)
                {
                    if (i == (numerals_arr.Length - 1))
                    {
                        number_int += roman_numerals[numerals_arr[i].ToString()];
                    }
                    else if(roman_numerals[numerals_arr[i].ToString()] < roman_numerals[numerals_arr[(i + 1)].ToString()])
                    {
                        number_int -= roman_numerals[numerals_arr[i].ToString()];
                    }
                    else
                    {
                        number_int += roman_numerals[numerals_arr[i].ToString()];
                    }
                }
                return number_int;
            }
            

            return 1;

         }

        public string IntToNumerals(int number)
        {
            string x = "";
            
            while (number != 0)
            {
                ResultBoxOne.Text = number.ToString();
                if (number>= 1000)
                {
                    number -= 1000;
                    x += "M";
                }
                else if (number >= 900 && number < 1000)
                {
                    number -= 900;
                    x += "CM";
                }
                else if (number >= 500 && number < 900)
                {
                    number -= 500;
                    x += "D";
                }
                else if (number >= 400 && number < 500)
                {
                    number -= 400;
                    x += "CD";
                }
                else if (number >= 100 && number < 400)
                {
                    number -= 100;
                    x += "C";
                }
                else if (number >= 90 && number < 100)
                {
                    number -= 90;
                    x += "XC";
                }
                else if (number >= 50 && number < 90)
                {
                    number -= 50;
                    x += "L";
                }
                else if (number >= 40 && number < 50)
                {
                    number -= 40;
                    x += "XL";
                }
                else if (number >= 10 && number < 40)
                {
                    number -= 10;
                    x += "X";
                }
                else if (number >= 9 && number < 10)
                {
                    number -= 9;
                    x += "IX";
                }
                else if (number >= 5 && number < 9)
                {
                    number -= 5;
                    x += "V";
                }
                else if (number >= 4 && number < 5)
                {
                    number -= 4;
                    x += "IV";
                }
                else
                {
                    number -= 1;
                    x += "I";
                    ResultBoxOne.Text = "help";
                }
                

            }
            
            return x;
        }

        private void ConvertNumeralsToInt(object sender, EventArgs e)
        {
            int x;
            x = NumeralsToInt(ResultBoxOne.Text);
            //ResultBoxOne.Text = IntToNumerals(x);
            ResultBoxOne.Text = IntToNumerals(999);
        }

        private void ResvereTest(object sender, EventArgs e)
        {
            string y;
            int x = Int32.Parse(ResultBoxOne.Text);
            y = IntToNumerals(x);
            ResultBoxOne.Text = y;
        }
    }
}
