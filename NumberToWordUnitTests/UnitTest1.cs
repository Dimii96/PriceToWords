using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PriceToWords;


namespace NumberToWordUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ValidNumbers()
        {
            try
            {

            // Test for single, tens, hungres, thousands, hundred thousand, millions, 
            var expected = new Dictionary<decimal, string>()
            {
                // All positive whole numbers
                { 0, "ZERO DOLLARS" },
                { 1, "ONE DOLLAR" },
                { 12, "TWELVE DOLLARS" },
                { 123, "ONE HUNDRED AND TWENTY THREE DOLLARS" },
                { 456, "FOUR HUNDRED AND FIFTY SIX DOLLARS" },
                { 6841, "SIX THOUSAND EIGHT HUNDRED AND FORTY ONE DOLLARS" },
                { 74401, "SEVENTY FOUR THOUSAND FOUR HUNDRED AND ONE DOLLARS" },
                { 569798, "FIVE HUNDRED AND SIXTY NINE THOUSAND SEVEN HUNDRED AND NINETY EIGHT DOLLARS" },
                { 3564102, "THREE MILLION FIVE HUNDRED AND SIXTY FOUR THOUSAND ONE HUNDRED AND TWO DOLLARS" },
                { 10357200, "TEN MILLION THREE HUNDRED AND FIFTY SEVEN THOUSAND TWO HUNDRED DOLLARS" },
                { 901876543, "NINE HUNDRED AND ONE MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS" },
                { 900876543, "NINE HUNDRED MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS" },
                { 1610420908, "ONE BILLION SIX HUNDRED AND TEN MILLION FOUR HUNDRED AND TWENTY THOUSAND NINE HUNDRED AND EIGHT DOLLARS" },
                { 2147483647, "TWO BILLION ONE HUNDRED AND FORTY SEVEN MILLION FOUR HUNDRED AND EIGHTY THREE THOUSAND SIX HUNDRED AND FORTY SEVEN DOLLARS" },

                // Positive decimal numbers
                { 0.83M, "EIGHTY THREE CENTS" },
                { 1.10M, "ONE DOLLAR AND TEN CENTS" },
                { 12.27M, "TWELVE DOLLARS AND TWENTY SEVEN CENTS" },
                { 123.01M, "ONE HUNDRED AND TWENTY THREE DOLLARS AND ONE CENT" },
                { 456.95M, "FOUR HUNDRED AND FIFTY SIX DOLLARS AND NINETY FIVE CENTS" },
                { 6841.30M, "SIX THOUSAND EIGHT HUNDRED AND FORTY ONE DOLLARS AND THIRTY CENTS" },
                { 74401.55M, "SEVENTY FOUR THOUSAND FOUR HUNDRED AND ONE DOLLARS AND FIFTY FIVE CENTS" },
                { 569798.19M, "FIVE HUNDRED AND SIXTY NINE THOUSAND SEVEN HUNDRED AND NINETY EIGHT DOLLARS AND NINETEEN CENTS" },
                { 3564102.02M, "THREE MILLION FIVE HUNDRED AND SIXTY FOUR THOUSAND ONE HUNDRED AND TWO DOLLARS AND TWO CENTS" },
                { 10357200.69M, "TEN MILLION THREE HUNDRED AND FIFTY SEVEN THOUSAND TWO HUNDRED DOLLARS AND SIXTY NINE CENTS" },
                { 901876543.01M, "NINE HUNDRED AND ONE MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS AND ONE CENT" },
                { 900876543.78M, "NINE HUNDRED MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS AND SEVENTY EIGHT CENTS" },
                { 1610420908.66M, "ONE BILLION SIX HUNDRED AND TEN MILLION FOUR HUNDRED AND TWENTY THOUSAND NINE HUNDRED AND EIGHT DOLLARS AND SIXTY SIX CENTS" },
                { 2147483647.99M, "TWO BILLION ONE HUNDRED AND FORTY SEVEN MILLION FOUR HUNDRED AND EIGHTY THREE THOUSAND SIX HUNDRED AND FORTY SEVEN DOLLARS AND NINETY NINE CENTS" },

                // All negative whole numbers
                //{ -0, "NEGATIVE ZERO DOLLARS" }, Negative 0 = 0
                { -1, "NEGATIVE ONE DOLLAR" },
                { -12, "NEGATIVE TWELVE DOLLARS" },
                { -123, "NEGATIVE ONE HUNDRED AND TWENTY THREE DOLLARS" },
                { -456, "NEGATIVE FOUR HUNDRED AND FIFTY SIX DOLLARS" },
                { -6841, "NEGATIVE SIX THOUSAND EIGHT HUNDRED AND FORTY ONE DOLLARS" },
                { -74401, "NEGATIVE SEVENTY FOUR THOUSAND FOUR HUNDRED AND ONE DOLLARS" },
                { -569798, "NEGATIVE FIVE HUNDRED AND SIXTY NINE THOUSAND SEVEN HUNDRED AND NINETY EIGHT DOLLARS" },
                { -3564102, "NEGATIVE THREE MILLION FIVE HUNDRED AND SIXTY FOUR THOUSAND ONE HUNDRED AND TWO DOLLARS" },
                { -10357200, "NEGATIVE TEN MILLION THREE HUNDRED AND FIFTY SEVEN THOUSAND TWO HUNDRED DOLLARS" },
                { -901876543, "NEGATIVE NINE HUNDRED AND ONE MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS" },
                { -900876543, "NEGATIVE NINE HUNDRED MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS" },
                { -1610420908, "NEGATIVE ONE BILLION SIX HUNDRED AND TEN MILLION FOUR HUNDRED AND TWENTY THOUSAND NINE HUNDRED AND EIGHT DOLLARS" },
                { -2147483647, "NEGATIVE TWO BILLION ONE HUNDRED AND FORTY SEVEN MILLION FOUR HUNDRED AND EIGHTY THREE THOUSAND SIX HUNDRED AND FORTY SEVEN DOLLARS" },

                // All negative decimal numbers
                { -0.83M, "NEGATIVE EIGHTY THREE CENTS" },
                { -1.10M, "NEGATIVE ONE DOLLAR AND TEN CENTS" },
                { -12.27M, "NEGATIVE TWELVE DOLLARS AND TWENTY SEVEN CENTS" },
                { -123.01M, "NEGATIVE ONE HUNDRED AND TWENTY THREE DOLLARS AND ONE CENT" },
                { -456.95M, "NEGATIVE FOUR HUNDRED AND FIFTY SIX DOLLARS AND NINETY FIVE CENTS" },
                { -6841.30M, "NEGATIVE SIX THOUSAND EIGHT HUNDRED AND FORTY ONE DOLLARS AND THIRTY CENTS" },
                { -74401.55M, "NEGATIVE SEVENTY FOUR THOUSAND FOUR HUNDRED AND ONE DOLLARS AND FIFTY FIVE CENTS" },
                { -569798.19M, "NEGATIVE FIVE HUNDRED AND SIXTY NINE THOUSAND SEVEN HUNDRED AND NINETY EIGHT DOLLARS AND NINETEEN CENTS" },
                { -3564102.02M, "NEGATIVE THREE MILLION FIVE HUNDRED AND SIXTY FOUR THOUSAND ONE HUNDRED AND TWO DOLLARS AND TWO CENTS" },
                { -10357200.69M, "NEGATIVE TEN MILLION THREE HUNDRED AND FIFTY SEVEN THOUSAND TWO HUNDRED DOLLARS AND SIXTY NINE CENTS" },
                { -901876543.01M, "NEGATIVE NINE HUNDRED AND ONE MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS AND ONE CENT" },
                { -900876543.78M, "NEGATIVE NINE HUNDRED MILLION EIGHT HUNDRED AND SEVENTY SIX THOUSAND FIVE HUNDRED AND FORTY THREE DOLLARS AND SEVENTY EIGHT CENTS" },
                { -1610420908.66M, "NEGATIVE ONE BILLION SIX HUNDRED AND TEN MILLION FOUR HUNDRED AND TWENTY THOUSAND NINE HUNDRED AND EIGHT DOLLARS AND SIXTY SIX CENTS" },
                { -2147483647.99M, "NEGATIVE TWO BILLION ONE HUNDRED AND FORTY SEVEN MILLION FOUR HUNDRED AND EIGHTY THREE THOUSAND SIX HUNDRED AND FORTY SEVEN DOLLARS AND NINETY NINE CENTS" },
            };

            var results = new Dictionary<decimal, string>();
            foreach (var item in expected)
            {
                try
                {
                    var result = PriceToWords.Methods.NumberToWords.PriceToWords(item.Key);
                    if (results.ContainsKey(item.Key))
                    {
                        Assert.Fail($"Test data is wrong, cant have double ups of data keys: {item.Key}");
                    }

                    results.Add(item.Key, result);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }

            var fails = string.Empty;

            foreach (var item in expected)
            {
                if (results.ContainsKey(item.Key))
                {
                    var blah = results[item.Key];
                    if (item.Value != blah)
                    {
                        string b = blah + " - " + item.Value; 
                        fails += $"\n > {item.Key}";
                    }
                }
                else
                {
                    fails += $"\n <ERROR> {item.Key}";
                }
            }
            Assert.IsTrue(string.IsNullOrEmpty(fails), $"Failed to convert number to word:{fails}");

            }
            catch (Exception ex)
            {
                var err = ex.ToString();
                throw;
            }
        }
    }
}