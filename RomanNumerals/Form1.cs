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
        readonly Dictionary<string, int> roman_numerals = new Dictionary<string, int>()
        {
            {"I",1},
            {"V",5},
            {"X",10},
            {"L",50},
            {"C",100},
            {"D",500},
            {"M",1000}
        };
        int first_num;
        int second_num;
        string operation = "";
        bool operarator_pressed = false;
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void NumeralClick(object sender, EventArgs e)
        {
            if (operarator_pressed == true)
            {
                ResultBoxTwo.Text = ResultBoxOne.Text;
                ResultBoxOne.Clear();
            }
            Button bnum = (Button)sender;

            ResultBoxOne.Text = ResultBoxOne.Text + bnum.Text;
            operarator_pressed = false;
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
            

            

         }

        public string IntToNumerals(int number)
        {
            string x = "";
            if(number == 0)
            {
                return "NULLA"; 
            }
            
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
                    
                }
                

            }
            
            return x;
        }

      

        private void OperatorClick(object sender, EventArgs e)
        {

            if (operarator_pressed == false)
            {
                first_num = NumeralsToInt(ResultBoxOne.Text);

                Button bnum = (Button)sender;
                ResultBoxOne.Text = ResultBoxOne.Text + bnum.Text;

                operation = bnum.Text;
                operarator_pressed = true;
            }
            else
            {
                ResultBoxOne.Text = "consilio inito error";
            }
            
            

        }

        private void SolveClick(object sender, EventArgs e)
        {
            second_num = NumeralsToInt(ResultBoxOne.Text);
            int result;

            switch (operation)
            {
                case "+":
                    result = first_num + second_num;
                    ResultBoxOne.Text = IntToNumerals(result);
                    break;

                case "-":
                    if ((first_num - second_num) < 0)
                    {
                        ResultBoxOne.Text = "There are no negative numbers in Rome!";
                        break;
                    }
                    else
                    {
                        result = first_num - second_num;
                        ResultBoxOne.Text = IntToNumerals(result);
                        break;
                    }
                case "*":
                    result = first_num * second_num;
                    ResultBoxOne.Text = IntToNumerals(result);
                    break;
                case "/":
                    if(first_num % second_num != 0)
                    {
                        ResultBoxOne.Text = "There are no decimals in Rome!";
                        break;
                    }
                    else
                    {
                        result = first_num / second_num;
                        ResultBoxOne.Text = IntToNumerals(result);
                        break;
                    }


            }
            operarator_pressed = false;
            second_num = first_num;
            ResultBoxTwo.Clear();
            
            
        }

        private void ClearClick(object sender, EventArgs e)
        {
            first_num = 0;
            second_num = 0;
            ResultBoxOne.Clear();
            ResultBoxTwo.Clear();
            operarator_pressed = false;
            
        }

        private void ClearEntryClick(object sender, EventArgs e)
        {
            ResultBoxOne.Clear();
            operarator_pressed = false;
        }

        public bool NumberCheck(String check)
        {
            int test;
            try
            {
                test = Int16.Parse(check);
            }

            catch (System.FormatException)
            {
                return false;

            }
            return true;

        } 
    }
}
