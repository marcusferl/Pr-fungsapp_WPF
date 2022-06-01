using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Ressources
{
    public class datas
    {
        public List<Datas> Datas { get; set;}
    }
    public class Datas
    {
    public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
