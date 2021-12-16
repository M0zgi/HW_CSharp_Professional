using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Entities;

namespace Weather.Data
{
    class DbContext
    {
        public List<Item> Items { get; set; } = new List<Item>();

    }
}
