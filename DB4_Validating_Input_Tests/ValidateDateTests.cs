using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidateDateTests
    {
        private bool GetResults(string testString)
        {
            ValidateInput toTest = new ValidateInput();
            return toTest.VerifyDate(testString);
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestSingleDigitMonth()
        {
            Assert.True(GetResults("10/1/2020"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestSingleDigitDay()
        {
            Assert.True(GetResults("1/10/2020"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDayTooLarge()
        {
            Assert.False(GetResults("32/10/2020"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDayTooSmall()
        {
            Assert.False(GetResults("00/10/2020"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestMonthTooLarge()
        {
            Assert.False(GetResults("20/13/2020"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestMonthTooSmall()
        {
            Assert.False(GetResults("20/00/2020"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestDateSmallestTwoYear()
        {
            Assert.True(GetResults("20/10/01"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDateTooSmallForTwoYear()
        {
            Assert.False(GetResults("20/10/00"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestDateSmallestFourYear()
        {
            Assert.True(GetResults("20/10/1000"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDateTooSmallForFourYear()
        {
            Assert.False(GetResults("20/10/0900"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestDateLargestTwoYear()
        {
            Assert.True(GetResults("20/10/29"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDateTooLargeForTwoYear()
        {
            Assert.False(GetResults("20/10/30"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestDateLargestFourYear()
        {
            Assert.True(GetResults("20/10/2999"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDateTooLArgeForFourYear()
        {
            Assert.False(GetResults("20/10/3000"));
        }
    }
}
