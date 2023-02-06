using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuThao.Train.Common.Model
{
    public class Vol_book
    {
        public string IdVol { get; set; }
        public int IdBook { get; set; }
        public string NameVol { get; set; }
        public string Part { get; set; }
        public string Vol { get; set; }
        public bool IsActivity { get; set; }
        public DateTime CreDate { get; set; }   
        public string CreUser { get; set; }
    }
}
