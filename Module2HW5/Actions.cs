using System;
using Module2HW5.Abstraction;
using Module2HW5.Exceptions;

namespace Module2HW5
{
    public class Actions
    {
        private ILogger _logger;

        public Actions(ILogger logger)
        {
            _logger = logger;
        }

        public bool Method1()
        {
            var message = $"Start method: {nameof(Method1)}";
            _logger.Log(TypeOfLog.Info, message);
            return true;
        }

        public bool Method2()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public bool Method3()
        {
            throw new Exception("I broke logic");
        }
    }
}