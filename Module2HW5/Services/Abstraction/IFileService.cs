using System;

namespace Module2HW5.Abstraction
{
    public interface IFileService
    {
        void WriteToFile(string message, DateTime now);
    }
}