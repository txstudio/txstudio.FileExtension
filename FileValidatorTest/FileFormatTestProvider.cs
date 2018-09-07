using FileValidator;

namespace FileValidatorTest
{
    public abstract class FileFormatTestProvider
    {
        private readonly FileHeaderValidator _validator;

        public FileFormatTestProvider()
        {
            this._validator = new FileHeaderValidator();
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
