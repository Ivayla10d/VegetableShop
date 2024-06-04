using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableProject.Model
{
    public class Vegetable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Registration { get; set; }


        public int VegetableTypeId { get; set; }
        public VegetableType VegetableTypes { get; set; }

    }
}
