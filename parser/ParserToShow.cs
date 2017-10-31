using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public interface IHtmlGrabber
    {
        string Fetch(string url);
    }

    public class HtmlGrabber : IHtmlGrabber
    {
        public string Fetch(string url)
        {
            var client = new System.Net.WebClient();
            var siteText = client.DownloadString(url);
            return siteText;
        }
    }

    public class ParserToShow
    {
        private readonly IHtmlGrabber grabber;
        public ParserToShow(IHtmlGrabber grabber)
        {
            this.grabber = grabber;
        }

        public void Start(string url)
        {
          //  try
         // {
                var qwerty = grabber.Fetch(url);
                Console.WriteLine(qwerty);
       //     }
      //      catch(Exception)
      //      {
       //         Console.WriteLine("Somethign was wrong");
      //      }
           
        }
    }
}
