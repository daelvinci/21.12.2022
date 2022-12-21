using System;
using System.Collections.Generic;
using System.Text;

namespace _12._21._2022
{
    internal class Notebook:Product
    {
        public double Ram;
        public Notebook(string name, double price, double ram) :base(name, price)
        {
            Ram = ram;
        }

    }
}
