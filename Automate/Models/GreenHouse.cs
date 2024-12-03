using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public static class GreenHouse
    {
        public static bool isLightOpen { get; set; } = false;
        public static bool isFanActivated { get; set; } = false;
        public static bool isHeaterActivated { get; set; } = false;
        public static bool isWindowOpen { get; set; } = false;
        public static bool isSprinklerActivated { get; set; } = false;
    }
}
