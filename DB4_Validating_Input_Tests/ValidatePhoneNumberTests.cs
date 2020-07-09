using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidatePhoneNumberTests
    {

        /* 
         * Phone Number Rules:
         * Must have a 3 digit area code follow by 3 digits followed by 4 digits.
         * Separators must be used between the sections with . and - being interchangable.
         * If using () around the area code the first separator is not required.
         * A space is acceptable as the first separator.
         * 
         * Valid Entries:
         * 333-333.3333
         * (333)333.3333
         * (333).333.3333
         * (333) 333.3333
         * (333.333.3333
         * (333 333.3333
         * 333).333.3333
         * 333 333.3333
         * 
         */

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestAreaCodeTooShort()
        {
            Assert.False(GetResults("12-123-1234"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestAreaCodeTooLong()
        {
            Assert.False(GetResults("1234-123-1234"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestAreaCodeRightLength()
        {
            Assert.True(GetResults("123-123-1234"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestExchangeCodeTooShort()
        {
            Assert.False(GetResults("123-12-1234"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestExchangeCodeTooLong()
        {
            Assert.False(GetResults("123-1234-1234"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestExchangeCodeRightLength()
        {
            Assert.True(GetResults("123-123-1234"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestSubscriberNumberTooLong()
        {
            Assert.False(GetResults("123-123-123"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestSubscriberNumberTooShort()
        {
            Assert.False(GetResults("123-123-12345"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestSubscriberNumberRightLength()
        {
            Assert.True(GetResults("123-123-1234"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestParenthesisWork()
        {
            Assert.True(GetResults("(123)-123-1234"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestSpaceWithParenthesisWork()
        {
            Assert.True(GetResults("(123) 123-1234"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestSpacesNotOkay()
        {
            Assert.False(GetResults("123 123 1234"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestDotsWork()
        {
            Assert.True(GetResults("123.123.1234"));
        }

        private bool GetResults(string input)
        {
            ValidateInput toTest = new ValidateInput();
            return toTest.VerifyPhoneNumber(input);
        }
    }
}
