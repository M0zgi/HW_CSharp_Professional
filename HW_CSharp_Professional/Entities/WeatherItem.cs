﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Weather.Lib;


namespace Weather.Entities
{
    public class WeatherItem
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // номер устройства

        XmlDictionary<string, Item> Par { get; set; } = new XmlDictionary<string, Item>(); // коллекция параметров по времени поступления

        //заполнение данными из DbContext
        public void SeedWeatherItem(List<Item> Items)
        {            
            foreach (var item in Items)
            {
                string dt = DateTime.UtcNow.ToString("yyyy.MM.dd_HH.mm.ss.fff", CultureInfo.InvariantCulture);
                Par.Add(dt, item);
            }
        }

        /// <summary>
        /// старая версия заполнения
        /// </summary>
        //public void Seed(Item item)
        //{
        //    string dt = DateTime.UtcNow.ToString("yyyy.MM.dd_HH.mm.ss.fff", CultureInfo.InvariantCulture);
        //   // dt = dt.Replace("-", ".");
        //   // dt = dt.Replace(":", ".");

        //    Par.Add(dt, item);
        //}

        public void PrintWI()
        {  

            foreach (var item in Par)
            {
                Console.WriteLine($"Id BigData: {Id}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Время загрузки данных: {item.Key}");
                Console.ResetColor();
                Console.WriteLine(item.Value);                
            }
        }
        
        public void Save()
        {
           // XmlReaderSettings settings = new XmlReaderSettings();
           // settings.ConformanceLevel = ConformanceLevel.Fragment;
            XmlTextWriter fileName = new XmlTextWriter("data.xml", null);
            fileName.Formatting = Formatting.Indented;
            Par.WriteXml(fileName);  
        } 

        public void Load()
        {
            XmlTextReader fileName = new XmlTextReader("data.xml");
           
            Par.ReadXml(fileName);
        }
    }
}
