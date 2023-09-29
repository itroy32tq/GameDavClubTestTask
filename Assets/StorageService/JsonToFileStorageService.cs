﻿using Assets.Script.Interfaces;
using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.StorageService
{
    public class JsonToFileStorageService : IStorageService
    {

        public void Save(string key, object data, Action<bool> callback = null)
        {
            string path = BuildPath(key);
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            using (var fileStrem = new StreamWriter(path))
            { 
                fileStrem.Write(json);
            }

            callback?.Invoke(true);
        }

        public void Load<T>(string key, Action<T> callback)
        {
            string path = BuildPath(key);
            using (var fileStream = new StreamReader(path))
            { 
                var json = fileStream.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);
                callback?.Invoke(data);
            }
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}
