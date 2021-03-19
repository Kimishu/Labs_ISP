using System;

namespace lab2triangle
{
    class Program
    {
        static void PerimetrCalc(double a, double b, double c, out double Pmetr) => Pmetr = a + b + c;
        static void AreaCalc(double a, double b, double c, double pmetr, out double Area) => Area = Math.Round(Math.Pow((pmetr / 2) * ((pmetr / 2) - a) * ((pmetr / 2) - b) * ((pmetr / 2) - c), 0.5), 2);
        static void RadiusCalc(double a, double b, double c, double pmetr, double Area, out double R) => R = Math.Round((a * b * c) / (4 * Area), 2);
        static void radiusCalc(double a, double b, double c, double pmetr, double Area, out double r) => r = Math.Round((2 * Area) / (a + b + c), 2);
        static void HeightCalc(double Area, double a, double b, double c, out double H1, out double H2, out double H3)
        {
            double P = 0;
            PerimetrCalc(a, b, c, out P);
            AreaCalc(a, b, c, P, out Area);
            H1 = 2 * Area / a;
            H2 = 2 * Area / b;
            H3 = 2 * Area / c;
        }
        static void MedianCalc(double a, double b, double c, out double M1, out double M2, out double M3)
        {
            M1 = 0.5 * (Math.Pow(((2 * Math.Pow(b, 2)) + (2 * Math.Pow(c, 2))) - Math.Pow(a, 2), 0.5));
            M2 = 0.5 * (Math.Pow(((2 * Math.Pow(a, 2)) + (2 * Math.Pow(c, 2))) - Math.Pow(b, 2), 0.5));
            M3 = 0.5 * (Math.Pow(((2 * Math.Pow(a, 2)) + (2 * Math.Pow(b, 2))) - Math.Pow(c, 2), 0.5));
        }
        static void Main()
        {
            Console.WriteLine("Нахождение параметров:\n1.Нахождение двух сторон треугольника по одной стороне и прилегающим углам\n2.Углы\n3.Периметр\n4.Площадь\n5.Радиус описанной окружности\n6.Радиус вписанной окружности\n7.Высота\n8.Медианы");
            int Button = Convert.ToInt32(Console.ReadLine());
            double side1, side2, side3, angle1, angle2, angle3, PI = 3.14, Perimetr = 0, Area = 0, Radius = 0, radius = 0, Height1 = 0, Height2 = 0, Height3 = 0, Median1 = 0, Median2 = 0, Median3 = 0;
            switch (Button)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите сторону и два прилежащих к ней угла: ");
                    side3 = Convert.ToDouble(Console.ReadLine());
                    angle1 = Convert.ToDouble(Console.ReadLine()) * Math.PI / 180;
                    angle2 = Convert.ToDouble(Console.ReadLine()) * Math.PI / 180;
                    angle3 = PI - (angle1 + angle2);
                    side1 = Math.Round((side3 / Math.Sin(angle3)) * Math.Sin(angle1), 2);
                    side2 = Math.Round((side3 / Math.Sin(angle3)) * Math.Sin(angle2), 2);
                    Console.WriteLine("Стороны треугольника равны:\n" + side1 + " см\n" + side2 + " см");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:\n");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    angle1 = Math.Round(Math.Acos((Math.Pow(side2, 2) + Math.Pow(side3, 2) - Math.Pow(side1, 2)) / (2 * side2 * side3)) * (180 / Math.PI), 2);
                    angle2 = Math.Round(Math.Acos((Math.Pow(side1, 2) + Math.Pow(side3, 2) - Math.Pow(side2, 2)) / (2 * side1 * side3)) * (180 / Math.PI), 2);
                    angle3 = Math.Round(Math.Acos((Math.Pow(side2, 2) + Math.Pow(side1, 2) - Math.Pow(side3, 2)) / (2 * side2 * side1)) * (180 / Math.PI), 2);
                    Console.WriteLine("Против стороны A= " + side1 + " см  - лежит угол " + angle1 + " градусов\nПротив стороны B= " + side2 + " см  - лежит угол " + angle2 + " градусов\nПротив стороны C= " + side3 + " см  - лежит угол " + angle3 + " градусов\n");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    PerimetrCalc(side1, side2, side3, out Perimetr);
                    Console.WriteLine("Периметр треугольник равен: " + Perimetr + " см");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    PerimetrCalc(side1, side2, side3, out Perimetr);
                    AreaCalc(side1, side2, side3, Perimetr, out Area);
                    Console.WriteLine("Площадь треугольника равна: " + Area + " см^2");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    PerimetrCalc(side1, side2, side3, out Perimetr);
                    AreaCalc(side1, side2, side3, Perimetr, out Area);
                    RadiusCalc(side1, side2, side3, Perimetr, Area, out Radius);
                    Console.WriteLine("Радиус описанной окружности вокруг треугольника равен: " + Radius + " см");
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    PerimetrCalc(side1, side2, side3, out Perimetr);
                    AreaCalc(side1, side2, side3, Perimetr, out Area);
                    radiusCalc(side1, side2, side3, Perimetr, Area, out radius);
                    Console.WriteLine("Радиус вписанной окружности в треугольник равен: " + radius + " см");
                    Console.ReadLine();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    PerimetrCalc(side1, side2, side3, out Perimetr);
                    AreaCalc(side1, side2, side3, Perimetr, out Area);
                    HeightCalc(Area, side1, side2, side3, out Height1, out Height2, out Height3);
                    Console.WriteLine("Высота треугольника на сторону а = " + side1 + " см равна: " + Height1 + " см\nВысота треугольника на сторону b = " + side2 + " см равна: " + Height2 + " см\nВысота треугольника на сторону c = " + side3 + " см равна: " + Height3 + " см");
                    Console.ReadLine();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Введите стороны треугольника:");
                    side1 = Convert.ToDouble(Console.ReadLine());
                    side2 = Convert.ToDouble(Console.ReadLine());
                    side3 = Convert.ToDouble(Console.ReadLine());
                    MedianCalc(side1, side2, side3, out Median1, out Median2, out Median3);
                    Console.WriteLine("Медиана треугольника на сторону а = " + side1 + " см равна: " + Median1 + " см\nМедиана треугольника на сторону b = " + side2 + " см равна: " + Median2 + " см\nМедиана треугольника на сторону c = " + side3 + " см равна: " + Median3 + " см");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
