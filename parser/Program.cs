using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parser.GetCarsInfo();

            // Console.WriteLine("Ready!!!!");
            //Console.ReadKey();

            var grabber = new HtmlGrabber();

            var parser = new ParserToShow(grabber);

            parser.Start("https://httpstat.us/503");
        }
    }
}
