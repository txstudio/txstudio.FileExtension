using System;
using System.Collections.Generic;
using FileValidator;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var _config = new FileHeaderConfig();
            //_config.Name = "jpeg";
            //_config.Extensions = new string[] { "jpg", "jpeg"};

            //var _bytes = new List<byte[]>();
            //_bytes.Add(new byte[] { 1, 233, 51 });
            //_bytes.Add(new byte[] { 203, 5, 79 });

            //_config.PrefixBytes = _bytes;

            //var _json = JsonConvert.SerializeObject(_config, Formatting.Indented);

            string _filePath = @"";
            byte[] _content;

            FileHeaderValidator _validator;

            _content = null;

            _validator = new FileHeaderValidator();
            _validator.ValidFormat(_filePath, _content);
            
            Console.ReadKey();
        }
    }
}
