using System;
using System.Collections.Generic;
using Weather.Data;
using Weather.Entities;

namespace HW_CSharp_Professional
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item_1 = new Item();
            Item item_2 = new Item();

            item_1.SetListValue(8, 1, 5);
            item_1.SetDictionaryValue(item_1.Id, item_1.list);

            item_2.SetListValue(18, 3, 9);
            item_2.SetDictionaryValue(item_2.Id, item_1.list);


            DbContext db = new DbContext();

            db.Items.Add(item_1);
            db.Items.Add(item_2);

            db.Print();
            Console.WriteLine(new string('-', 30));
            WeatherItem weatherItem = new WeatherItem();

            weatherItem.Seed(item_1);
            weatherItem.Seed(item_2);

            weatherItem.Save();

            //weatherItem.Load();

            weatherItem.PrintWI();
        }
    }
}
