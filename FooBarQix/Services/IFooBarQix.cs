using FooBarQix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBarQix.Services
{
    public interface IFooBarQix
    {
        string Calculate(Entry entry);
    }
}
