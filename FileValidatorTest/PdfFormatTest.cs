using System;
using System.IO;
using Xunit;

namespace FileValidatorTest
{

    public class PdfFormatTest : FileFormatTestProvider
    {

        [Fact]
        public void RealPdfFileTest()
        {
            string _fullPath;
            string _fileName;
            byte[] _content;
            
            bool _validResult;

            _fullPath = @"../../../Files/github-txstudio-homepage.pdf";
            
            _fileName = Path.GetFileName(_fullPath);
            _content = File.ReadAllBytes(_fullPath);

            _validResult = this.Validator.ValidFormat(_fileName, _content);
            
            Assert.True(_validResult);
        }
    }
}