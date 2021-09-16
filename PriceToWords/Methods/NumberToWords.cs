using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceToWords.Methods
{
    public class NumberToWords
    {


        public static string PriceToWords(decimal price)
        {
            try
            {

                // Round price to 2 decimals for cents                
                price = Math.Round(price, 2);

                // Check if negative price
                string priceAsText = "";
                if (price < -2147483647.99M || price > 2147483647.99M)
                {
                    return ("Price number out of range.");
                }
                else
                if (price < 0)
                {
                    priceAsText = "Negative ";
                    var positiveValue = Math.Abs(price);
                    price = positiveValue;
                }
                else if (price == 0)
                {
                    return "ZERO DOLLARS";
                }

                // Convert dollar value to text
                int dollarAmount = (int)Math.Floor(price);
                string dollarsInText = IntToWords(dollarAmount);
                priceAsText += dollarsInText;
                if (price < 0 || price >= 1)
                {
                    priceAsText += (price >= 2 || price <= -2) ? " dollars" : " dollar";
                }

                // Convert cents value to text
                var floor = Math.Floor(price);
                int centAmount = (int)((price - floor) * 100); // Get int value of the cents
                if (centAmount > 0)
                {
                    string centsInText = IntToWords(centAmount);
                    //if ((dollarAmount < 0 && dollarAmount >= 1) || centsInText != "")
                    if (dollarAmount != 0)
                        priceAsText += " and ";
                    priceAsText += centsInText;
                    priceAsText += centAmount < 2 ? " cent" : " cents";
                }

                return priceAsText.ToUpper();
            }
            catch (Exception err)
            {
                // TODO: Log error
                Console.Write(err.Message);
                var errorMessage = "There was an error converting price.";
                return errorMessage;
            }
        }



        public static string IntToWords(int val)
        {
            string[] numberNames =
            {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion"
            };

            // Split price into list of ints
            List<int> priceArr = val.ToString().Select(x => Convert.ToInt32(x.ToString())).ToList();

            int arrayLength = priceArr.Count();

            // Add 0's to beginning of number to make length of price a multiple of 3
            while (arrayLength % 3 != 0)
            {
                priceArr.Insert(0, (char)0);
                arrayLength = priceArr.Count();
            }

            // Check how many groups of 3 numbers in the price
            int groupCount = arrayLength / 3;


            string dollarsToText = "";
            int tmpGroupNumber = 0;


            for (int i = (arrayLength - 1); i >= 0; i--)
            {
                string tmp = "";
                int num1 = priceArr[i - 2];
                var num2 = priceArr[i - 1];
                var num3 = priceArr[i];

                // Check leading zeros and skip to next set of three numbers
                if (num1 == 0 && num2 == 0 && num3 == 0)
                {
                    tmpGroupNumber++;
                    groupCount -= 1;
                    i -= 2;
                    continue;
                }
                if (num1 > 0 && (num2 > 0 || num3 > 0))
                {
                    // Check if over 100
                    tmp += NumberToWords.GetSingle(num1) + "hundred";
                }
                else if (num1 > 0 && num2 == 0 && num3 == 0)
                {
                    // check if is multiple of 100
                    tmp += NumberToWords.GetSingle(num1) + "hundred ";
                }

                // Make sure it isnt first iteration and if its suitable to add AND 
                if ((num1 > 0 && (num2 > 0 || num3 > 0)) // checks: 101,110,111
                    || ((tmpGroupNumber == 0 && groupCount > 1) && num1 == 0 && (num2 > 0 || num3 > 0))) // checks: xxx001, xxx010, xxx011 
                {
                    tmp += " and ";
                }

                // Check for 11 - 19
                if (num2 == 1 && num3 > 0)
                {
                    tmp += NumberToWords.GetElevenToNineteen(num3);
                }
                else
                {
                    // Get 20 - 99
                    tmp += NumberToWords.GetTen(num2);
                    tmp += NumberToWords.GetSingle(num3);
                }

                // Get number group number
                tmp += numberNames[tmpGroupNumber] + " ";
                tmpGroupNumber++;

                groupCount -= 1;
                dollarsToText = tmp + dollarsToText;
                i -= 2; // skip to next set of three numbers
            }
            return dollarsToText.Trim();
        }


        public static string GetSingle(int num)
        {
            string str = "";
            switch (num)
            {
                case 1:
                    str = "one ";
                    break;
                case 2:
                    str = "two ";
                    break;
                case 3:
                    str = "three ";
                    break;
                case 4:
                    str = "four ";
                    break;
                case 5:
                    str = "five ";
                    break;
                case 6:
                    str = "six ";
                    break;
                case 7:
                    str = "seven ";
                    break;
                case 8:
                    str = "eight ";
                    break;
                case 9:
                    str = "nine ";
                    break;
                default:
                    break;
            }
            return str;
        }

        public static string GetTen(int num)
        {
            string str = "";
            switch (num)
            {
                case 1:
                    str = "ten ";
                    break;
                case 2:
                    str = "twenty ";
                    break;
                case 3:
                    str = "thirty ";
                    break;
                case 4:
                    str = "forty ";
                    break;
                case 5:
                    str = "fifty ";
                    break;
                case 6:
                    str = "sixty ";
                    break;
                case 7:
                    str = "seventy ";
                    break;
                case 8:
                    str = "eighty ";
                    break;
                case 9:
                    str = "ninety ";
                    break;
                default:
                    break;
            }
            return str;
        }

        public static string GetElevenToNineteen(int num)
        {
            string str = "";
            switch (num)
            {
                case 1:
                    str = "eleven ";
                    break;
                case 2:
                    str = "twelve ";
                    break;
                case 3:
                    str = "thirteen ";
                    break;
                case 4:
                    str = "fourteen ";
                    break;
                case 5:
                    str = "fifteen ";
                    break;
                case 6:
                    str = "sixteen ";
                    break;
                case 7:
                    str = "seventeen ";
                    break;
                case 8:
                    str = "eighteen ";
                    break;
                case 9:
                    str = "nineteen ";
                    break;
                default:
                    break;
            }
            return str;
        }



    }
}
