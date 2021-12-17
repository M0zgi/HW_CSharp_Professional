using HW_CSharp_Professional;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Weather.Lib
{
    class XmlDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public int TKey_TValue{ get; set; }

        public event Action<Exception> OnError;

        public XmlDictionary()
        {
            OnError += (e) => {
                // Console.WriteLine("\n!!! Error: " + e.Message); 
                Program.Log.Error(e.Message);
            };
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {      
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            
            if (wasEmpty)
            {
                Program.Log.Info(" public void ReadXml(XmlReader reader) wasEmpty");

                return;
            }  
              
            int count = 0;
            try
            {
                while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
                {

                    if (count == 0)
                    {
                        reader.ReadStartElement("item");
                    }

                    //reader.Skip();
                    reader.ReadStartElement("key");
                    TKey key = (TKey)keySerializer.Deserialize(reader);
                    reader.ReadEndElement();
                    reader.ReadStartElement("value");
                    TValue value = (TValue)valueSerializer.Deserialize(reader);
                    reader.ReadEndElement();
                    this.Add(key, value);
                    count++;
                    //reader.ReadEndElement();
                    reader.MoveToContent();
                }
                reader.ReadEndElement();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Десериализация успешно завершена!\n");
                Console.ResetColor();
                Program.Log.Info("Десериализация успешно завершена!");
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            //string v = "</value>";
            //string i = "</item>";
            //string path = "data.xml";
            int count = 0;

            try
            {
                foreach (TKey key in this.Keys)
                {
                    if (count == 0)
                    {
                        writer.WriteStartElement("item");
                    }
                    writer.WriteStartElement("key");
                    keySerializer.Serialize(writer, key);
                    writer.WriteEndElement();
                    writer.WriteStartElement("value");
                    TValue value = this[key];
                    valueSerializer.Serialize(writer, value);
                    writer.WriteEndElement();
                    //writer.WriteEndElement();
                    count++;
                }

                writer.Close();

                //using (FileStream fs = new FileStream(path, FileMode.Append))
                //{
                //    byte[] input = Encoding.Default.GetBytes(v);
                //    fs.Write(input, 0, input.Length);
                //}

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Сериализация успешно завершена!");
                Console.ResetColor();

                Program.Log.Info("Сериализация успешно завершена!");
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }
    }
}
