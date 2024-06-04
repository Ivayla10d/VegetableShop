using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableProject.Model;

namespace VegetableProject.Controller
{
    public class VegetableTypeLogic
    {
        private VegetableDbContext _vegetableDbContext = new VegetableDbContext();

        public List<VegetableType> GetAllVegetables()
        {
            return _vegetableDbContext.VegetableTypes.ToList();

        }
        public string GetVegetableById(int id)
        {
            return _vegetableDbContext.Vegetables.Find(id).Name;
        }

    }
}
