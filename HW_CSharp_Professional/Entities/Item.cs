using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Lib;

namespace Weather.Entities
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // номер передачи данных

        //коллекция для хранения значений с датчиков
        public List<int> list = new List<int>(); //{ 0,0,0} 

        XmlDictionary<Guid, List<int>> MyParams = new XmlDictionary<Guid, List<int>>();

        //создание словаря для сериализации данных по конкретному датчику
        public void SetDictionaryValue(Guid k, List<int> w)
        {
            MyParams[k] = w;
        }

        //заполнение текущими значениями с дачиков у сущности
        public void SetListValue(int temperature, int pressure, int wind_speed)
        {
            try
            {
                this.list.Add(temperature);
                this.list.Add(pressure);
                this.list.Add(wind_speed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); ;
            }            
        
        }

        public void Print()
        {
            Console.WriteLine($"Guid Id {Id}");           

            foreach (var item2 in MyParams.Values)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Температура: {item2[0]} °С");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Давление воздуха: {item2[1]} мм");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Скорость ветра: {item2[2]} км/ч");
                Console.ResetColor();

            }
        }

        public override string ToString()
        {

            return $"Id устройства с датчиками: { Id}\n" + 
                $"Температура: {this.list[0]} °С\n" +
                $"Давление воздуха: {this.list[1]} мм\n" +
                $"Скорость ветра: {this.list[2]} км/ч\n";
        }
    }
}
