using System;
using Module2HW5.Abstraction;
using Module2HW5.Exceptions;

namespace Module2HW5
{
    public class Starter
    {
        private Actions _actions;
        private ILogger _logger;

        public Starter(Actions actions, ILogger logger)
        {
            _actions = actions;
            _logger = logger;
        }

        public void Run()
        {
            var rndm = new Random();
            for (var i = 0; i < 1000; i++)
            {
                try
                {
                    var methodNumber = rndm.Next(0, 3);
                    if (methodNumber.ToString().ToLowerInvariant().Equals("0"))
                    {
                        _actions.Method1();
                    }
                    else if (methodNumber.ToString().ToLowerInvariant().Equals("1"))
                    {
                        _actions.Method2();
                    }
                    else
                    {
                        _actions.Method3();
                    }
                }
                catch (BusinessException be)
                {
                   _logger.Log(TypeOfLog.Warning, $"Action got this custom Exception: {be}");
                }
                catch (Exception e)
                {
                    _logger.Log(TypeOfLog.Error, $"Action failed by reason: {e}");
                }
            }
        }
    }
}