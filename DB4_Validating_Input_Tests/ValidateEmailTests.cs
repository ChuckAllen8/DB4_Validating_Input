using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidateEmailTests
    {
        [Fact]
        [Trait("Description", "Test user names can't be too short.")]
        public void TestUserNameTooShort()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("John@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test user names can't be too long.")]
        public void TestUserNameTooLong()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("JohnJacobJingleHeimerSchmidtIII@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test user names at the lower limit are okay.")]
        public void TestUserNameLowerLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test user names at the upper limit are okay.")]
        public void TestUserNameUpperLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("JohnJacobJingleHeimerSchmidtII@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test user names cannot have special characters.")]
        public void TestUserNameNoSpecialCharacters()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("J!mmy@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test user names can have numbers.")]
        public void TestUserNameNumbersAllowed()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("J1mmy@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test Domain Name can't be too short.")]
        public void TestDomainNameTooShort()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@user.com"));
        }

        [Fact]
        [Trait("Description", "Test Domain Name can't be too long.")]
        public void TestDomainNameTooLong()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@ExampleUser.com"));
        }

        [Fact]
        [Trait("Description", "Test Domain Name at lower limit is okay.")]
        public void TestDomainNameLowerLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Users.com"));
        }

        [Fact]
        [Trait("Description", "Test Domain Name at upper limit is okay.")]
        public void TestDomainNameUpperLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@UserSample.com"));
        }

        [Fact]
        [Trait("Description", "Test Domain Name cannot have special characters.")]
        public void TestDomainNameNoSpecialCharacters()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Examp!e.com"));
        }

        [Fact]
        [Trait("Description", "Test Domain Name can have numbers.")]
        public void TestDomainNameNumbersAllowed()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Examp1e.com"));
        }

        [Fact]
        [Trait("Description", "Test Extension cannot be too short.")]
        public void TestExtensionTooShort()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Example.e"));
        }

        [Fact]
        [Trait("Description", "Test Extension cannot be too long.")]
        public void TestExtensionTooLong()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Example.comm"));
        }

        [Fact]
        [Trait("Description", "Test Extension at lower limit is okay.")]
        public void TestExtensionLowerLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.eu"));
        }

        [Fact]
        [Trait("Description", "Test Extension at upper limit is okay.")]
        public void TestExtensionUpperLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.com"));
        }

        [Fact]
        [Trait("Description", "Test Extension cannot have special characters.")]
        public void TestExtensionNoSpecialCharacters()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Example.eu!"));
        }

        [Fact]
        [Trait("Description", "Test Extension can have numbers.")]
        public void TestExtensionNumbersAllowed()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.eu3"));
        }

        [Fact]
        [Trait("Description", "An at symbol is required")]
        public void TestAtSignRequired()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("JohnyExample.com"));
        }

        [Fact]
        [Trait("Description", "A . is required")]
        public void TestDotSymbolRequired()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Examplecom"));
        }
    }
}
