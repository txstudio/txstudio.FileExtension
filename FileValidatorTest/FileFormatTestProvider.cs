using FileValidator;
using System.IO;

namespace FileValidatorTest
{
    public abstract class FileFormatTestProvider
    {
        private readonly string _rootPath;
        private readonly FileHeaderValidator _validator;

        public FileFormatTestProvider()
        {
            this._rootPath = "../../../Files";
            this._validator = new FileHeaderValidator();
        }

        protected string GetFullPath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) == true)
                return string.Empty;

            return Path.Combine(this._rootPath, fileName);
        }

        protected FileHeaderValidator Validator
        {
            get
            {
                return this._validator;
            }
        }

    }
}
