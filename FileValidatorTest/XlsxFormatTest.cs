using System;
using System.IO;
using Xunit;

namespace FileValidatorTest
{

    public class XlsxFormatTest : FileFormatTestProvider
    {

        [Fact]
        public void RealFileTest()
        {
            string _fullPath;
            string _fileName;
            byte[] _content;
            
            bool _validResult;

            _fullPath = this.GetFullPath(@"file-header-sheet.xlsx");
            
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

            _fullPath = this.GetFullPath(@"file-header-sheet.xlsx");
            _fileName = Path.GetFileName(_fullPath);

            _fullPath = this.GetFullPath(@"file-header-app.doc");
            _content = File.ReadAllBytes(_fullPath);

            _validResult = this.Validator.ValidFormat(_fileName, _content);

            Assert.False(_validResult);
        }
    }
}
