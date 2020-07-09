using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidateDateTests
    {

        /* 
         * Date Rules:
         * 
         * Accepts a 1 or 2 digit day and/or month.
         * days are between 1-31
         * months are from 1-12
         * years are from 1000-2999 if using 4 digit
         * or 01-29 if using 2 digit.
         * format is:
         * day/month/year
         * - can be substituted for the /
         * 
         * Valid Entries:
         * 1/1/1000
         * 31/12/2999
         * 01/01/01
         * 31/12/29
         * 01-01-01
         * 
         */

        private bool GetResults(string testString)
        {
            ValidateInput toTest = new ValidateInput();
            return toTest.VerifyDate(testString);
        }

        [Fact]
        [Trait("Description", "Tests single digit month.")]
        public void TestSingleDigitMonth()
        {
            Assert.True(GetResults("10/1/2020"));
        }

        [Fact]
        [Trait("Description", "Tests single digit day.")]
        public void TestSingleDigitDay()
        {
            Assert.True(GetResults("1/10/2020"));
        }

        [Fact]
        [Trait("Description", "Tests days can't be too large")]
        public void TestDayTooLarge()
        {
            Assert.False(GetResults("32/10/2020"));
        }

        [Fact]
        [Trait("Description", "Tests days can't be too small")]
        public void TestDayTooSmall()
        {
            Assert.False(GetResults("00/10/2020"));
        }

        [Fact]
        [Trait("Description", "Tests months can't be too large")]
        public void TestMonthTooLarge()
        {
            Assert.False(GetResults("20/13/2020"));
        }

        [Fact]
        [Trait("Description", "Tests months can't be too small")]
        public void TestMonthTooSmall()
        {
            Assert.False(GetResults("20/00/2020"));
        }

        [Fact]
        [Trait("Description", "Tests the smallest two digit year date.")]
        public void TestDateSmallestTwoYear()
        {
            Assert.True(GetResults("20/10/01"));
        }

        [Fact]
        [Trait("Description", "Tests a date too small for two digit year.")]
        public void TestDateTooSmallForTwoYear()
        {
            Assert.False(GetResults("20/10/00"));
        }

        [Fact]
        [Trait("Description", "Tests the smallest four digit year date.")]
        public void TestDateSmallestFourYear()
        {
            Assert.True(GetResults("20/10/1000"));
        }

        [Fact]
        [Trait("Description", "Tests a date too small for four digit year.")]
        public void TestDateTooSmallForFourYear()
        {
            Assert.False(GetResults("20/10/0900"));
        }

        [Fact]
        [Trait("Description", "Tests the Largest two digit year date.")]
        public void TestDateLargestTwoYear()
        {
            Assert.True(GetResults("20/10/29"));
        }

        [Fact]
        [Trait("Description", "Tests a date too large for two digit year.")]
        public void TestDateTooLargeForTwoYear()
        {
            Assert.False(GetResults("20/10/30"));
        }

        [Fact]
        [Trait("Description", "Tests the Largest four digit year date.")]
        public void TestDateLargestFourYear()
        {
            Assert.True(GetResults("20/10/2999"));
        }

        [Fact]
        [Trait("Description", "Tests a date too large for four digit year.")]
        public void TestDateTooLArgeForFourYear()
        {
            Assert.False(GetResults("20/10/3000"));
        }
    }
}
