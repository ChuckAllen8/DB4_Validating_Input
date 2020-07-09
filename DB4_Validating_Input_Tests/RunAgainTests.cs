using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class RunAgainTests
    {
        [Fact]
        [Trait("Description", "Tests to make sure other input quits.")]
        public void OtherInputTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.RunAgain("J"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure yes keeps going")]
        public void LowerCaseTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.RunAgain("yes"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure uppercase works too.")]
        public void UpperCaseTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.RunAgain("YES"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure the letter y works.")]
        public void SingleLetterTest()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.RunAgain("y"));
        }
    }
}
