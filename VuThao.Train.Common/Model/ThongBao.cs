using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuThao.Train.Common.Model
{
    public class ThongBao
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public  string content { get; set; }
        public DateTime cre{ get; set; }
        public string creUser{ get; set; }

    }
}
