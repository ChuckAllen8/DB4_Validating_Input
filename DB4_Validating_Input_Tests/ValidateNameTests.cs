using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidateNameTests
    {
        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNameLengthLessThanMinimum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyName("J"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestNameLengthAtMinimum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyName("Jo"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNameLengthGreaterThanMaximum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyName("JohnJacobJingleHeimerSchmidtIII"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestNameLengthAtMaximum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyName("JohnJacobJingleHeimerSchmidtII"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestNameStartsWithCapital()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyName("Jo"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestNameStartsWithoutCapital()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyName("jo"));
        }
    }
}
