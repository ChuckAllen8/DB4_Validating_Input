using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidateNameTests
    {
        [Fact]
        [Trait("Description", "Tests to make sure a single letter is not a name.")]
        public void TestNameLengthLessThanMinimum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyName("J"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure a two letter name is okay.")]
        public void TestNameLengthAtMinimum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyName("Jo"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure names that are too long are not okay.")]
        public void TestNameLengthGreaterThanMaximum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyName("JohnJacobJingleHeimerSchmidtIII"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure names of 30 characters are allowed.")]
        public void TestNameLengthAtMaximum()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyName("JohnJacobJingleHeimerSchmidtII"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure a single letter is not a name.")]
        public void TestNameStartsWithCapital()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyName("Jo"));
        }

        [Fact]
        [Trait("Description", "Tests to make sure a single letter is not a name.")]
        public void TestNameStartsWithoutCapital()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyName("jo"));
        }
    }
}
