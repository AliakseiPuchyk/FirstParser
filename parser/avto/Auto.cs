using System;

namespace Parser
{
    public class Auto
    {
        public int Year { get; set; } //год выпуска
        public string Condition { get; set; } //состояние
        public int Mileage { get; set; }  //пробег
        public string TypeFuel { get; set; }  //тип топлива
        public double TheVolume { get; set; } //объем
        public string Colour { get; set; }  //цвет
        public string BodyType { get; set; } //тип кузова
        public string Transmission { get; set; } //коробка
        public string Drive { get; set; } //привод
        public double Price { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Год:" + Year + "\n" + 
                              "Cостояние:" + Condition + "\n" +
                              "Пробег:" + Mileage + "\n" +
                              "Тип топлива:" + TypeFuel + "\n" +
                              "Объем:" + TheVolume + "\n" +
                              "Цвет:" + Colour + "\n" +
                              "Тип кузова:" + BodyType + "\n" +
                              "Трансмиссия:" + Transmission + "\n" +
                              "Привод:" + Drive + "\n" +
                              "Цена:" + Price + "\n" 
                              );
        }

    }
}
