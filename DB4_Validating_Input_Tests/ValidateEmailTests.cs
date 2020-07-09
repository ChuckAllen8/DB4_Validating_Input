using DB4_Validating_Input;
using System;
using Xunit;

namespace DB4_Validating_Input_Tests
{
    public class ValidateEmailTests
    {
        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestUserNameTooShort()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("John@Example.com"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestUserNameTooLong()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("JohnJacobJingleHeimerSchmidtIII@Example.com"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestUserNameLowerLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.com"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestUserNameUpperLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("JohnJacobJingleHeimerSchmidtII@Example.com"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestUserNameNoSpecialCharacters()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("J!mmy@Example.com"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestUserNameNumbersAllowed()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("J1mmy@Example.com"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDomainNameTooShort()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@user.com"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestDomainNameTooLong()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@ExampleUser.com"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestDomainNameLowerLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Users.com"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestDomainNameUpperLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@UserSample.com"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestDomainNameNoSpecialCharacters()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Examp!e.com"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestDomainNameNumbersAllowed()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Examp1e.com"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestExtensionTooShort()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Example.e"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestExtensionTooLong()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Example.comm"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestExtensionLowerLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.eu"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestExtensionUpperLimit()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.com"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestExtensionNoSpecialCharacters()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Example.eu!"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestExtensionNumbersAllowed()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.True(toTest.VerifyEmail("Johny@Example.eu3"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestAtSignRequired()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("JohnyExample.com"));
        }

        [Fact]
        [Trait("Type", "Feature")]
        public void TestDotSymbolRequired()
        {
            ValidateInput toTest = new ValidateInput();
            Assert.False(toTest.VerifyEmail("Johny@Examplecom"));
        }
    }
}
