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
        
        //при создании сущности заполняем значения датчиков нулями, расчитываем на то, что датчики рабочие и всегда передедут актуальные данные
        public Item()
        {
            MyParams.Add(this.Id, list);           
        }

        public Guid Id { get; set; } = Guid.NewGuid(); // номер передачи данных

        //коллекция для хранения значений с датчиков
        public List<int> list = new List<int>() { 0,0,0} ;
        
        XmlDictionary<Guid, List<int>> MyParams = new XmlDictionary<Guid, List<int>>();

        //создание словаря для сериализации данных по конкретному датчику
        public void SetDictionaryValue(Guid k, List<int> w)
        {
            MyParams[k] = w;
        }

        //заполнение текущими значениями с дачиков у сущности
        public void SetListValue(int temperature, int pressure, int wind_speed)
        {
            //обрабатываем на наличие индексов в коллекции
            try
            {
                this.list[0] = temperature;
                this.list[1] = pressure;
                this.list[2] = wind_speed;
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
                Console.WriteLine($"Температура: {item2[0]} °С");
                Console.WriteLine($"Давление воздуха: {item2[1]} атм");
                Console.WriteLine($"Скорость ветра: {item2[2]} км/ч");                
            }          

        }

        //public override string ToString()
        //{
        //    return $"Guid Id {Id}, Key: {MyParams.Keys}, Value: {MyParams.Values}";
        //}
    }
}
