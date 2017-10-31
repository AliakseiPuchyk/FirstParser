using System;
using System.Collections.Generic;

namespace Parser
{
    static class Parser
    {
        private static List<string> GetCarList()
        {

            var client = new System.Net.WebClient();
            string href;
            var carsList = new List<string>();
           // int CountOfPages = GetCountOfPages();
            for (var count = 1; true; count++)
            {
                string siteText = client.DownloadString("https://cars.av.by/bmw/3-reihe-e36/page/" + count).Replace(" ", string.Empty);


                string findstr = "listing-item-title";
                int carsOnPage = (siteText.Length - siteText.Replace(findstr, "").Length) / findstr.Length;
                int pointOnStr = 0;
                int firstPointOnStr = 0;
                int secondPointonStr = 0;

                var processedText = siteText;

                for (int i = 0; i < carsOnPage; i++)
                {
                    pointOnStr = processedText.IndexOf(findstr);
                    href = processedText.Substring(pointOnStr);
                    processedText = processedText.Substring(pointOnStr + findstr.Length);

                    firstPointOnStr = href.IndexOf("href=");
                    secondPointonStr = href.IndexOf("</a>");

                    href = href.Substring(firstPointOnStr, secondPointonStr - firstPointOnStr);

                    firstPointOnStr = href.IndexOf("\"");
                    href = href.Substring(firstPointOnStr + 1);

                    firstPointOnStr = href.IndexOf("\"");
                    href = href.Substring(0, firstPointOnStr);
                    carsList.Add(href);
                }

                string findstr1 = "pages-numbers-item--active";
                string flagnextpage = "pages-numbers-item";

                pointOnStr = siteText.IndexOf(findstr1);
                siteText = siteText.Substring(pointOnStr + findstr.Length);
                var pointOnStrFlag = siteText.IndexOf(flagnextpage);
                if (pointOnStrFlag == -1)
                    break;
            }

            return carsList;
        }


        public static void GetCarsInfo()
        {
            var client = new System.Net.WebClient();
            var firstStringToLookUp = "card-price-main";
            var cars = new List<Auto>();

            var carList = GetCarList();
            for (int i = 0; i < carList.Count; i++)
            {

                var siteText = client.DownloadString(carList[i]).Replace(" ", string.Empty);
                System.Threading.Thread.Sleep(100);

                var firstPointOnStr = siteText.IndexOf(firstStringToLookUp);
                var tempString = siteText.Substring(firstPointOnStr + firstStringToLookUp.Length,40);

                var intInfo = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(tempString, @"[^\d]+", ""));

                cars.Add(new Auto());
                cars[i].Price = intInfo;

                Console.WriteLine(cars[i].Price +"\t"+ carList[i]);
            }
        }
    }
}
