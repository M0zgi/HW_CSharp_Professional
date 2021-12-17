using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Weather.Entities;

namespace Weather.Data
{
    class DbContext
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public void SeedDbContext(Item Items)
        {       
            this.Items.Add(Items);
        }

        public void Print()
        {
            foreach (var item in Items)
            {
                item.Print();
                Console.WriteLine(new string('-', 20));
            }
        }       
    }
}
