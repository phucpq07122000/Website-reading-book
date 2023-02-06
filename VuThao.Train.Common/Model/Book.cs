using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuThao.Train.Common.Model
{
    public class Book
    {
        public int Row { get; set; }
        public int IdBook { get; set; }
        public string Name { get; set; }
        public int IdActor { get; set; }
        public int IdTeam { get; set; }
        public string NameActor { get; set; }
        public string NameTeam { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public int IdVol { get; set; }  
        public bool IsActivity { get; set; }


        public DateTime Created { get; set; }
        public DateTime Modify { get; set; }

        public string CreatedUser { get; set; }
        public string ModifyUser { get; set; }

    }
}
