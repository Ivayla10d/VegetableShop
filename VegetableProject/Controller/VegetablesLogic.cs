using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableProject.Model;

namespace VegetableProject.Controller
{
    public class VegetablesLogic
    {
        private VegetableDbContext _vegetableDbContext = new VegetableDbContext();
        public Vegetable Get(int id)
        {
            Vegetable findedVegetable = _vegetableDbContext.Vegetables.Find(id);
            if (findedVegetable != null)
            {
                _vegetableDbContext.Entry(findedVegetable).Reference(x => x.VegetableTypes).Load();

            }
            return findedVegetable;
        }
        public List<Vegetable> GetAll()
        {
            return _vegetableDbContext.Vegetables.Include("VegetableTypes").ToList();
        }

        public void Create(Vegetable vegetable)
        {
            
            _vegetableDbContext.Vegetables.Add(vegetable);
            _vegetableDbContext.SaveChanges();
        }

        public void Update(int id, Vegetable vegetable)
        {
            Vegetable findedVegetable = _vegetableDbContext.Vegetables.Find(id);
            if (findedVegetable == null)
            {
                return;
            }
           // findedVegetable.Id = vegetable.Id;
            findedVegetable.Name = vegetable.Name;
            findedVegetable.Price = vegetable.Price;
            findedVegetable.Description = vegetable.Description;
            findedVegetable.VegetableTypeId = vegetable.VegetableTypeId;
            _vegetableDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Vegetable findedVegetable = _vegetableDbContext.Vegetables.Find(id);
            _vegetableDbContext.Vegetables.Remove(findedVegetable);
            _vegetableDbContext.SaveChanges();
        }


    }
}

