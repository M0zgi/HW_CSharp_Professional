using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Lib;

namespace Weather.Entities
{
    class WeatherItem
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // номер устройства

        public XmlDictionary<int, Item> Par { get; set; } // коллекция параметров по времени поступления
    }
}
