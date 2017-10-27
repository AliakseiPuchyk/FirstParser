using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    class Parser
    {
        private static int getCountOfPages()
        {
            var client = new System.Net.WebClient();
            string findstr = "pages-numbers-item--active";
            string flagnextpage = "pages-numbers-item";
            string siteText = client.DownloadString("https://cars.av.by/bmw/3-reihe-e36/").Replace(" ", string.Empty);
            int pointOnStr = 0;
            int pointOnStrFlag = 0;
            int countPages = 1;
            bool EndFlag = true;

            while (EndFlag)
            {
                siteText = client.DownloadString("https://cars.av.by/bmw/3-reihe-e36/page/"+ countPages).Replace(" ", string.Empty);
                pointOnStr = siteText.IndexOf(findstr);
                siteText = siteText.Substring(pointOnStr + findstr.Length);
                pointOnStrFlag = siteText.IndexOf(flagnextpage);
                if (pointOnStrFlag != -1)
                    countPages++;
                else EndFlag = false;
                pointOnStrFlag = 0;
            }

            return countPages;

        }
        public static List<string> getHrefCar()
        {

            var client = new System.Net.WebClient();
            int count = 1;
            string href;
            List<string> carsList = new List<string>();
            int CountOfPages = getCountOfPages();
            for (count = 1; count < CountOfPages + 1; count++)
            {
                string siteText = client.DownloadString("https://cars.av.by/bmw/3-reihe-e36/page/"+count).Replace(" ", string.Empty);


                string findstr = "listing-item-title";
                int carsOnPage = (siteText.Length - siteText.Replace(findstr, "").Length) / findstr.Length;
                int pointOnStr = 0;
                int firstPointOnStr = 0;
                int secondPointonStr = 0;
                

                for (int i = 0; i < carsOnPage; i++)
                {
                    pointOnStr = siteText.IndexOf(findstr);
                    href = siteText.Substring(pointOnStr);
                    siteText = siteText.Substring(pointOnStr + findstr.Length);

                    firstPointOnStr = href.IndexOf("href=");
                    secondPointonStr = href.IndexOf("</a>");

                    href = href.Substring(firstPointOnStr, secondPointonStr - firstPointOnStr);

                    firstPointOnStr = href.IndexOf("\"");
                    href = href.Substring(firstPointOnStr + 1);

                    firstPointOnStr = href.IndexOf("\"");
                    href = href.Substring(0, firstPointOnStr);
                    carsList.Add(href);
                }

            }

            return carsList;
        }
        public static void /*List<Auto>*/ GetInfoCars()
        {
            var client = new System.Net.WebClient();
            List<string> href = new List<string>();
            string siteText = "";
            string tempString = "";
            string findstr = "";
            List<Auto> cars = new List<Auto>();
            int firstPointOnStr = 0;
            //int secondPointonStr = 0;
            int intInfo = 0;

            href = getHrefCar();
            for(int i =0; i < href.Count; i++)
            {
                siteText = client.DownloadString(href[i]).Replace(" ", string.Empty);
                System.Threading.Thread.Sleep(100);
                findstr = "card-price-main";
                firstPointOnStr = siteText.IndexOf(findstr);
                tempString = siteText.Substring(firstPointOnStr + findstr.Length,40);
                intInfo = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(tempString, @"[^\d]+", ""));
                cars.Add(new Auto());
                cars[i].Price = intInfo;

                Console.WriteLine(cars[i].Price +"\t"+ href[i]);

            }


            //return cars;
        }
    }
}
