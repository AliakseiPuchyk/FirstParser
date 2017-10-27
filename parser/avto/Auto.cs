using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    class Auto
    {
        private int year; //год выпуска
        private string condition; //состояние
        private int mileage; //пробег
        private string typeFuel; //тип топлива
        private double theVolume; //объем
        private string colour; //цвет
        private string bodyType; //тип кузова
        private string transmission; //коробка
        private string drive; //привод
        private double price;

        public Auto()
        {
            year = 0;
            condition = "";
            mileage = 0;
            typeFuel = "";
            theVolume = 0.0;
            colour = "";
            bodyType = "";
            transmission = "";
            drive = "";
            price = 0.0;
        }
        ~Auto() { }

        public int Year { get { return this.year; } set { this.year = value; } }
        public string Condition { get { return this.condition; } set { this.condition = value; } }
        public int Mileage { get { return this.mileage; } set { this.mileage = value; } }
        public string TypeFuel { get { return this.typeFuel; } set { this.typeFuel = value; } }
        public double TheVolume { get { return this.theVolume; } set { this.theVolume = value; } }
        public string Colour { get { return this.colour; } set { this.colour = value; } }
        public string BodyType { get { return this.bodyType; } set { this.bodyType = value; } }
        public string Transmission { get { return this.transmission; } set { this.transmission = value; } }
        public string Drive { get { return this.drive; } set { this.drive = value; } }
        public double Price { get { return this.price; } set { this.price = value; } }

        public void PrintInfo()
        {
            Console.WriteLine("Год:" + year + "\n" + 
                              "Cостояние:" + condition + "\n" +
                              "Пробег:" + mileage + "\n" +
                              "Тип топлива:" + typeFuel + "\n" +
                              "Объем:" + theVolume + "\n" +
                              "Цвет:" + colour + "\n" +
                              "Тип кузова:" + bodyType + "\n" +
                              "Трансмиссия:" + transmission + "\n" +
                              "Привод:" + drive + "\n" +
                              "Цена:" + price + "\n" 
                              );
        }

    }
}
