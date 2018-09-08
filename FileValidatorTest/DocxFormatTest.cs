using System;
using System.IO;
using Xunit;

namespace FileValidatorTest
{

    public class DocxFormatTest : FileFormatTestProvider
    {

        [Fact]
        public void RealFileTest()
        {
            string _fullPath;
            string _fileName;
            byte[] _content;
            
            bool _validResult;

            _fullPath = this.GetFullPath(@"file-header-app.docx");
            
            _fileName = Path.GetFileName(_fullPath);
            _content = File.ReadAllBytes(_fullPath);

            _validResult = this.Validator.ValidFormat(_fileName, _content);
            
            Assert.True(_validResult);
        }

        [Fact]
        public void WrongFileTest()
        {
            string _fullPath;
            string _fileName;
            byte[] _content;

            bool _validResult;

            _fullPath = this.GetFullPath(@"file-header-app.docx");
            _fileName = Path.GetFileName(_fullPath);

            _fullPath = this.GetFullPath(@"github-txstudio-screenshot.gif");
            _content = File.ReadAllBytes(_fullPath);

            _validResult = this.Validator.ValidFormat(_fileName, _content);

            Assert.False(_validResult);
        }
    }
}
