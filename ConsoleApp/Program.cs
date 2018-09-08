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
            IEnumerable<string> _paths;

            _paths = new string[]
            {
                "../../../filename1.gif",
                "../../../filename2.gif",
            };

            byte[] _content;

            foreach (string _path in _paths)
            {
                _content = File.ReadAllBytes(_path);
                var _take = _content.Take(50);

                Console.WriteLine(string.Join(",", _take));
                Console.WriteLine();
            }
            
            Console.WriteLine("press any to exit");
            Console.ReadKey();
        }
    }
}
