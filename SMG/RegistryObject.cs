using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SMG
{
    class RegistryObject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string LaunchCommand { get; set; }
    }
}
