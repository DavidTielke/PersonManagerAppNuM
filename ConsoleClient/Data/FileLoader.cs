﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleClient.Data
{
    // T-System
    public class FileLoader : IFileStorer
    {
        public List<string> LoadAllLines(string path)
        {
            return File.ReadAllLines(path).ToList();
        }

        //public void WriteAllLines(string path, List<string> lines)
        //{
        //    File.WriteAllLines(path, lines);
        //}
    }
}