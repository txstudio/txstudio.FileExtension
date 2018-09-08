using System;
using System.IO;
using Xunit;

namespace FileValidatorTest
{

    public class GifFormatTest : FileFormatTestProvider
    {

        [Fact]
        public void RealFileTest()
        {
            string _fullPath;
            string _fileName;
            byte[] _content;
            
            bool _validResult;

            _fullPath = this.GetFullPath(@"github-txstudio-screenshot.gif");
            
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

            _fullPath = this.GetFullPath(@"github-txstudio-screenshot.gif");
            _fileName = Path.GetFileName(_fullPath);

            _fullPath = this.GetFullPath(@"github-txstudio-screenshot.png");
            _content = File.ReadAllBytes(_fullPath);

            _validResult = this.Validator.ValidFormat(_fileName, _content);

            Assert.False(_validResult);
        }
    }
}
