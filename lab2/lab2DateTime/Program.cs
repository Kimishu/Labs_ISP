using System;
using System.Globalization;
namespace lab2
{
    class Program
    {
        static void Main()
        {
            switch (Console.ReadLine())
            {
                case "Russian":
                    Months("ru-Ru");
                    break;
                case "Ukrainian":
                    Months("uk-Ua");
                    break;
                case "Belarusian":
                    Months("be-By");
                    break;
                case "French":
                    Months("fr-Fr");
                    break;
                case "German":
                    Months("de-De");
                    break;
                case "Polish":
                    Months("pl-Pl");
                    break;
                default:
                    Months(CultureInfo.CurrentCulture.Name);
                    break;
            }
        }
        static void Months(string country)
        {
            DateTime Date = DateTime.Now;
            CultureInfo culture = new CultureInfo(country, false);
            Console.Clear();
            for (int i = 0; i < 12; i++)
                Console.WriteLine(Date.AddMonths(i).ToString("MMMM", culture));
        }
    }
}
