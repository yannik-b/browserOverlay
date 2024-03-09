using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace browserOverlay
{
    internal class AppSettings
    {
        public string url { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public bool? dockBottom { get; set; }
        public bool? dockLeft { get; set; }
        public bool? dockRight { get; set; }
        public bool? dockTop { get; set; }


    }
}
