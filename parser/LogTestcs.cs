using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine(log);
        }
    }

    public class FileLogger : ILogger
    {
        public void WriteLog(string log)
        {
            File.WriteAllText("somepath", log);
            //Console.WriteLine(log);
        }
    }

    public interface ILogger
    {
        void WriteLog(string message);
    }

    class LogTestcs
    {
        public void something(ILogger logger)
        {
           //
            logger.WriteLog("Doing 1 thing");

            
           /// ..////
        }
    }

    class LogTestcs2
    {
        public void something(ILogger logger)
        {
         //   var logger = new FileLogger();
            logger.WriteLog("Doing 1 thing");
        }
    }

    class LogTestcs3
    {
        public void something(ILogger logger)
        {
        //    var logger = new FileLogger();
            logger.WriteLog("Doing 1 thing");
        }
    }


}
