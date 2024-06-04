using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableProject.Model
{
    public class VegetableType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Vegetable> Vegetables { get; set; }
    }
}
