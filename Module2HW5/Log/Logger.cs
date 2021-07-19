using System;
using System.Threading.Channels;
using Module2HW5.Abstraction;

namespace Module2HW5
{
    public class Logger : ILogger
    {
        private static DateTime _timeOfLog = DateTime.Now;
        private IFileService _fileService;

        public Logger(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Log(TypeOfLog typeOfLog, string message)
        {
            var result = $"{DateTime.Now} {typeOfLog} {message}";
            Console.WriteLine(result);
            _fileService.WriteToFile(result, _timeOfLog);
        }
    }
}