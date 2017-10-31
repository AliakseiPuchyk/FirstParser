using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser.Test
{
    [TestClass]
    public class I_Expect_Parser_To_Parce_Correctly
    {
        private class GrabberMock503 : IHtmlGrabber
        {
            public string Fetch(string url)
            {
                throw new Exception();
            }
        }

        [TestMethod]
        public void In_case_I_get_503_error_parser_should_not_fail()
        {
            var grabberMock = new GrabberMock503();

            var parser = new ParserToShow(grabberMock);

            Assert.ThrowsException<Exception>(() => parser.Start("https://httpstat.us/503"));
        }

        [TestMethod]
        public void In_case_I_get_503_error_parser_should_not_fail()
        {
            var inputHtml = "<html>.....<div clas='listing-item-title'>";
            var grabberMock = new GrabberMock503();

            var parser = new ParserToShow(grabberMock);

            Assert.ThrowsException<Exception>(() => parser.Start("https://httpstat.us/503"));
        }
    }
}
