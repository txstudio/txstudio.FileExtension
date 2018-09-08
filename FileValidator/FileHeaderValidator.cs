using System;
using System.Collections.Generic;
using System.IO;

namespace FileValidator
{
    public sealed class FileHeaderValidator
    {
        public bool ValidFormat(string fileName, byte[] content)
        {
            if (string.IsNullOrWhiteSpace(fileName) == true)
                return false;

            if (content == null)
                return false;

            if (content.Length == 0)
                return false;


            var _configs = DefaultFileHeaderConfig.GetDefaultConfig();
            var _fileExtension = Path.GetExtension(fileName);


            foreach (var _config in _configs)
            {
                foreach (var _extension in _config.Extensions)
                {
                    if(_fileExtension.EndsWith(_extension) == true)
                    {
                        foreach (var _bytes in _config.PrefixBytes)
                        {
                            using (MemoryStream _stream = new MemoryStream(content))
                            {
                                foreach (var _byte in _bytes)
                                {
                                    int _value = _stream.ReadByte();

                                    if (_byte == _value)
                                        continue;

                                    return false;
                                }
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }

    public sealed class FileHeaderConfig
    {   
        public string Name { get; set; }
        public IEnumerable<string> Extensions { get; set; }
        public IEnumerable<byte[]> PrefixBytes { get; set; }
    }

    public class DefaultFileHeaderConfig
    {
        private static List<FileHeaderConfig> _defaultConfig = null;

        public static IEnumerable<FileHeaderConfig> GetDefaultConfig()
        {
            if (_defaultConfig == null)
            {
                _defaultConfig = new List<FileHeaderConfig>();

                //document
                _defaultConfig.Add(GetDocConfig());
                _defaultConfig.Add(GetDocxConfig());
                _defaultConfig.Add(GetPdfConfig());

                //image
                _defaultConfig.Add(GetPngConfig());
                _defaultConfig.Add(GetJpgConfig());
            }

            return _defaultConfig.ToArray();
        }

        #region document

        private static FileHeaderConfig GetDocConfig()
        {
            FileHeaderConfig _config;
            List<byte[]> _prefixBytes;

            _prefixBytes = new List<byte[]>();
            _prefixBytes.Add(new byte[] { 208, 207, 17, 224, 161, 177, 26, 225, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 3, 0, 254, 255, 9, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            _config = new FileHeaderConfig();
            _config.Name = "doc";
            _config.Extensions = new string[] { "doc" };
            _config.PrefixBytes = _prefixBytes;

            return _config;
        }

        private static FileHeaderConfig GetDocxConfig()
        {
            FileHeaderConfig _config;
            List<byte[]> _prefixBytes;

            _prefixBytes = new List<byte[]>();
            _prefixBytes.Add(new byte[] { 80, 75, 3, 4, 20, 0, 6, 0, 8, 0, 0, 0, 33, 0 });

            _config = new FileHeaderConfig();
            _config.Name = "docx";
            _config.Extensions = new string[] { "docx" };
            _config.PrefixBytes = _prefixBytes;

            return _config;
        }

        private static FileHeaderConfig GetPdfConfig()
        {
            FileHeaderConfig _config;
            List<byte[]> _prefixBytes;

            _prefixBytes = new List<byte[]>();
            _prefixBytes.Add(new byte[] { 37, 80, 68, 70 });

            _config = new FileHeaderConfig();
            _config.Name = "pdf";
            _config.Extensions = new string[] { "pdf" };
            _config.PrefixBytes = _prefixBytes;

            return _config;
        }

        #endregion

        #region image

        private static FileHeaderConfig GetPngConfig()
        {
            FileHeaderConfig _config;
            List<byte[]> _prefixBytes;

            _prefixBytes = new List<byte[]>();
            _prefixBytes.Add(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 });

            _config = new FileHeaderConfig();
            _config.Name = "png";
            _config.Extensions = new string[] { "png" };
            _config.PrefixBytes = _prefixBytes;

            return _config;
        }

        private static FileHeaderConfig GetJpgConfig()
        {
            FileHeaderConfig _config;
            List<byte[]> _prefixBytes;

            _prefixBytes = new List<byte[]>();
            _prefixBytes.Add(new byte[] { 255, 216, 255, 224 });

            _config = new FileHeaderConfig();
            _config.Name = "jpg";
            _config.Extensions = new string[] { "jpg" };
            _config.PrefixBytes = _prefixBytes;

            return _config;
        }

        #endregion

    }


}
