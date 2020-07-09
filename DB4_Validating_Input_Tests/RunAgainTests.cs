using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class RunAgainTests
    {
        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void OtherInputTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.RunAgain("J"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void LowerCaseTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.RunAgain("yes"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void UpperCaseTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.RunAgain("YES"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void SingleLetterTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.RunAgain("y"));
        }
    }
}
