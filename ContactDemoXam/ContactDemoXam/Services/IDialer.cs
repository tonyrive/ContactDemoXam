using System;
using System.Collections.Generic;
using System.Text;

namespace ContactDemoXam.Services
{
    public interface IDialer
    {
        bool Dial(string number);
    }
}
