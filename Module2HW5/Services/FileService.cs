using System;
using System.IO;
using ConsoleApp1;
using Module2HW5.Abstraction;
using Newtonsoft.Json;

namespace Module2HW5
{
    public class FileService : IFileService
    {
        public void WriteToFile(string s, DateTime now)
        {
            var configJson = File.ReadAllText("./config.json");
            var config = JsonConvert.DeserializeObject<Config>(configJson);
            var timeFormat = now.ToString("hh.mm.ss dd.MM.yyyy");
            Directory.CreateDirectory(config.Path);
            var fi = new FileInfo($"{config.Path}/{timeFormat}.txt");
            var isCreated = File.Exists($"{config.Path}/{timeFormat}.txt");
            if (!isCreated)
            {
                var stream = fi.Create();
                stream.Dispose();
            }

            File.AppendAllText($"{config.Path}/{timeFormat}.txt", s);
            var filesList = Directory.GetFiles(config.Path);
            Array.Sort(filesList);
            Array.Reverse(filesList);
            for (var i = 3; i < filesList.Length; i++)
            {
                var f = new FileInfo(filesList[i]);
                f.Delete();
            }
        }
    }
}