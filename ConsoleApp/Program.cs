using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

            string _filePath = @"../../../github-txstudio-screenshot.gif";
            byte[] _content;

            _content = File.ReadAllBytes(_filePath);
            var _take = _content.Take(50);

            Console.WriteLine(string.Join(",", _take));
            Console.WriteLine();



            _filePath = @"../../../replacement.gif";

            _content = File.ReadAllBytes(_filePath);
            _take = _content.Take(50);

            Console.WriteLine(string.Join(",", _take));
            Console.WriteLine();


            Console.WriteLine("press any to exit");
            Console.ReadKey();
        }
    }
}
