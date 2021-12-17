using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using Weather.Data;
using Weather.Entities;

namespace HW_CSharp_Professional
{
    class Program
    {
        public static Logger Log;
        static void Main(string[] args)
        {
            //логирование
            LogManager.Configuration = new XmlLoggingConfiguration("NLog.config.xml");
            Log = LogManager.GetCurrentClassLogger();
            Log.Info("Я запустил код");

            //создание сущностей с датчиками и уникальным ID
            Item item_1 = new Item();
            Item item_2 = new Item();

            
            item_1.SetListValue(8, 1, 5);
            item_1.SetDictionaryValue(item_1.Id, item_1.list);

            item_2.SetListValue(18, 3, 9); 
            item_2.SetDictionaryValue(item_2.Id, item_1.list);

            // создание списка для сущностей
            DbContext db = new DbContext();

            // заполнение списка сущностями List<Item> Items
            db.SeedDbContext(item_1);
            db.SeedDbContext(item_2);

            // выводим данные сущностей из сформированного List<Item> Items
            db.Print();

            Console.WriteLine(new string('-', 30));

            // создание сущности для получения данных из DbContext с уникальным ID
            WeatherItem weatherItem = new WeatherItem();

            // заполнение сущности получеными данными из DbContext
            weatherItem.SeedWeatherItem(db.Items);

            //Сериализация, сохранение полученных данных из DbContext
            weatherItem.Save();

            //Десериализация. Для тестирования закомментировать все, кроме 3 строк с LogManager и WeatherItem weatherItem = new WeatherItem();
            //И раскоментировать weatherItem.Load();
            //weatherItem.Load();

            weatherItem.PrintWI();

            Log.Info("Работа программы завершена");
        }
    }
}
