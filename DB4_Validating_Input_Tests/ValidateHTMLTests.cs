using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DB4_Validating_Input;

namespace DB4_Validating_Input_Tests
{
    public class ValidateHTMLTests
    {
        private bool GetResults(string testString)
        {
            ValidateInput toTest = new ValidateInput();
            return toTest.VerifyHTML(testString);
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNoEndingSlash()
        {
            Assert.False(GetResults("<h> <h>"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNoBeginningOpenCarrot()
        {
            Assert.False(GetResults("h> </h>"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNoBeginningCloseCarrot()
        {
            Assert.False(GetResults("<h </h>"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNoEndingOpenCarrot()
        {
            Assert.False(GetResults("<h> /h>"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestNoEndingCloseCarrot()
        {
            Assert.False(GetResults("<h> </h"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestElementMisMatch()
        {
            Assert.False(GetResults("<h> </a>"));
        }

        [Fact]
        [Trait("Type", "OutOfBounds")]
        public void TestLongerElementMisMatch()
        {
            Assert.False(GetResults("<Div> </Header>"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestElementMatch()
        {
            Assert.True(GetResults("<h> </h>"));
        }

        [Fact]
        [Trait("Type", "WithinBounds")]
        public void TestLongerElementMatch()
        {
            Assert.True(GetResults("<Div> </Div>"));
        }
    }
}
