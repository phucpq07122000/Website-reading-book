using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuThao.Train.Common.Model
{
    public class User
    {
        public int IdUser { get; set; }
        public int Row { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Sex  { get; set; }
        public string Email { get; set; }

        public string NameTeam { get; set; }
        public int IdTeam { get; set; }
        public byte[] Image { get; set; }
        public bool Role { get; set; }
        public bool IsActivity { get; set; }
        //public int IDTeam { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modify { get; set; }

        public string CreatedUser { get; set; }
        public string ModifyUser { get; set; }
    }
}
