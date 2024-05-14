﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SupermarketManager.Model.DataAccessLayer
{
    public class JsonPersitence
    {
        public static void SaveToJson<T>(T obj, string filePath)
        {
            List<T> currentObjs = LoadFromJson<T>(filePath);

            if (currentObjs == null)
            {
                currentObjs = new List<T>();
            }

            currentObjs.Add(obj);

            string json = JsonConvert.SerializeObject(currentObjs, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        public static void SaveToJson<T>(List<T> objs, string filePath)
        {
            string json = JsonConvert.SerializeObject(objs, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<T> LoadFromJson<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found");
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
