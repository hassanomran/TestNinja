﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTest
{
    public class FakeFileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            return "";
        }
    }
}
