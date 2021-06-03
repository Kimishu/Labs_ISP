using System;
using System.Text.RegularExpressions;

namespace Lab7
{
    public class Fraction : IEquatable<Fraction>, IComparable<Fraction>
    {
        //Целое число
        public int Numerator;
        //Натуральное число
        public uint Denominator;

        Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }
        public bool Equals(Fraction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public int CompareTo(Fraction other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var numeratorComparison = Numerator.CompareTo(other.Numerator);
            if (numeratorComparison != 0) return numeratorComparison;
            return Denominator.CompareTo(other.Denominator);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fraction)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        private uint CommonDenominator(Fraction fr1, Fraction fr2)
        {
            for (uint i = 0; i < ((fr1.Denominator * fr2.Denominator) + 1); i++)
            {
                if ((i % fr1.Denominator == 0) && (i % fr2.Denominator == 0) && i != 0) return i;
            }
            return 0;
        }
        public static Fraction Input(string text)
        {
            Console.WriteLine(text);
            Fraction fraction = new Fraction();
            string FractStr = Console.ReadLine();

            while (!fraction.FromString(FractStr))
            {
                Console.Write(text);
                FractStr = Console.ReadLine();
            }
            return fraction;
        }


        public override string ToString()
        {
            string FractStr = "", StrDen, StrNum;
            StrDen = Convert.ToString(Denominator);
            StrNum = Convert.ToString(Numerator);
            FractStr = StrNum + '/' + StrDen;
            return FractStr;
        }

        public bool FromString(string FractStr)
        {
            bool Minus = false;
            string StrDen = "", StrNum = "";

            string pattern1 = @"^-?[0-9]+[/]?[0-9]+$";
            string pattern2 = @"^-?[0-9]+[.]?[,]?[0-9]+$";
            if (Regex.IsMatch(FractStr, pattern1, RegexOptions.IgnoreCase))
            {
                int i = 0;
                if (FractStr[0] == '-') Minus = true;
                if (Minus) i++;

                while (Char.IsDigit(FractStr[i]))
                {
                    StrNum += FractStr[i].ToString();
                    i++;
                }
                i++;
                while (i < FractStr.Length)
                {
                    StrDen += FractStr[i].ToString();
                    i++;
                }

                Numerator = Convert.ToInt32(StrNum);
                Denominator = Convert.ToUInt32(StrDen);
                if (Minus) Numerator *= (-1);
                return true;
            }
            if (Regex.IsMatch(FractStr, pattern2, RegexOptions.IgnoreCase))
            {
                int i = 0;
                int index = 0;
                int Count = 0;
                if (FractStr[0] == '-') Minus = true;
                if (Minus) i++;
                while (i < FractStr.Length)
                {
                    if (Char.IsDigit(FractStr[i]))
                    {
                        StrNum += FractStr[i].ToString();
                    }
                    else
                    {
                        index = i + 1;
                    }
                    i++;
                }
                if (index == 0) Denominator = 1;
                else
                {
                    while (index < FractStr.Length)
                    {
                        Count++;
                        index++;
                    }

                    StrDen = Convert.ToString(Math.Pow(10, Count));
                    Denominator = Convert.ToUInt32(StrDen);
                    Numerator = Convert.ToInt32(StrNum);
                }

                return true;
            }
            Console.WriteLine("Некорректное выражение");
            return false;

        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            Fraction result = new Fraction();
            result.Denominator = result.CommonDenominator(fr1, fr2);
            result.Numerator = (int)(fr1.Numerator * (result.Denominator / fr1.Denominator) + fr2.Numerator * (result.Denominator / fr2.Denominator));

            return result;
        }

        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            Fraction result = new Fraction();
            result.Denominator = result.CommonDenominator(fr1, fr2);
            result.Numerator = (int)(fr1.Numerator * (result.Denominator / fr1.Denominator) - fr2.Numerator * (result.Denominator / fr2.Denominator));

            return result;
        }

        public static Fraction operator *(Fraction fr1, Fraction fr2)
        {
            Fraction result = new Fraction();
            result.Denominator = fr1.Denominator * fr2.Denominator;
            result.Numerator = fr1.Numerator * fr2.Numerator;
            return result;
        }

        public static Fraction operator /(Fraction fr1, Fraction fr2)
        {

            int NumerTemp = fr2.Numerator;
            uint DenomTemp = fr2.Denominator;
            if (NumerTemp < 0)
            {
                fr2.Numerator = (int)fr2.Denominator * (-1);
            }
            else
            {
                fr2.Numerator = (int)fr2.Denominator;
            }
            fr2.Denominator = (uint)Math.Abs(NumerTemp);
            var result = fr1 * fr2;
            fr2.Numerator = NumerTemp;
            fr2.Denominator = DenomTemp;
            return result;
        }

        public static bool operator ==(Fraction fr1, Fraction fr2)
        {
            if (!(fr2 is null) && fr2.Equals(fr1))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Fraction fr1, Fraction fr2)
        {
            if (!(fr1 == fr2)) return true;
            return false;
        }

        public static bool operator >(Fraction fr1, Fraction fr2)
        {
            if (fr1 == fr2)
                return false;
            if (fr1.Numerator * (fr1.CommonDenominator(fr1, fr2) / fr1.Denominator) >
                fr2.Numerator * (fr2.CommonDenominator(fr1, fr2) / fr2.Denominator))
                return true;
            return false;
        }

        public static bool operator <(Fraction fr1, Fraction fr2)
        {
            if (fr1 == fr2)
                return false;
            if (fr1.Numerator * (fr1.CommonDenominator(fr1, fr2) / fr1.Denominator) <
                fr2.Numerator * (fr2.CommonDenominator(fr1, fr2) / fr2.Denominator))
                return true;
            return false;
        }

        public static bool operator <=(Fraction fr1, Fraction fr2)
        {
            if (fr1 == fr2 || fr1 < fr2) return true;
            return false;
        }

        public static bool operator >=(Fraction fr1, Fraction fr2)
        {
            if (fr1 == fr2 || fr1 > fr2) return true;
            return false;
        }

        public static implicit operator int(Fraction fr1)
        {
            int result = (int)(fr1.Numerator / fr1.Denominator);
            return result;
        }

        public static implicit operator Fraction(int num)
        {
            Fraction result = new Fraction();
            result.Numerator = num;
            result.Denominator = 1;
            return result;
        }

        public static implicit operator double(Fraction fr1)
        {
            double result = (double)fr1.Numerator / fr1.Denominator;
            return result;
        }

        public static implicit operator Fraction(double num)
        {
            int ten = 0;
            while (true)
            {
                double temp = num % 10;
                if (temp == 0)
                    break;
                num *= 10;
                ten++;
            }

            Fraction result = new Fraction();
            result.Numerator = (int)num;
            result.Denominator = (uint)(Math.Pow(10, ten));
            return result;
        }

    }
    class Program
    {
        
        
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Арифметические действия\n2.Сравнение дробей\n3.Конвертация\n4.Выход");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        Fraction FractionArithmetic1 = Fraction.Input("Введите первую дробь: ");
                        Fraction FractionArithmetic2 = Fraction.Input("Введите вторую дробь: ");
                        Fraction ArithmeticResult;
                        bool Check = true;
                        while (Check)
                        {
                          Console.Clear();
                          Console.WriteLine("1.Сложение\n2.Вычитание\n3.Умножение\n4.Деление\n5.Назад");
                          
                           switch (Convert.ToInt32(Console.ReadLine()))
                           {
                                case 1:
                                    ArithmeticResult = FractionArithmetic1 + FractionArithmetic2;
                                    Console.WriteLine("Сложение:\n" + FractionArithmetic1 + "+" + FractionArithmetic2 + "=" + ArithmeticResult);
                                    Check = false;
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    ArithmeticResult = FractionArithmetic1 - FractionArithmetic2;
                                    Console.WriteLine("Вычитание:\n" + FractionArithmetic1 + "-" + FractionArithmetic2 + "=" + ArithmeticResult);
                                    Check = false;
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    ArithmeticResult = FractionArithmetic1 * FractionArithmetic2;
                                    Console.WriteLine("Умножение:\n" + FractionArithmetic1 + "*" + FractionArithmetic2 + "=" + ArithmeticResult);
                                    Check = false;
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    ArithmeticResult = FractionArithmetic1 / FractionArithmetic2;
                                    Console.WriteLine("Деление:\n" + FractionArithmetic1 + "/" + FractionArithmetic2 + "=" + ArithmeticResult);
                                    Check = false;
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Check = false;
                                    break;
                           }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Fraction FractionCompare1 = Fraction.Input("Введите первую дробь: ");
                        Fraction FractionCompare2 = Fraction.Input("Введите вторую дробь: ");
                        if(FractionCompare1 > FractionCompare2)
                            Console.WriteLine(FractionCompare1 + " больше, чем " + FractionCompare2);
                        else if(FractionCompare1 < FractionCompare2)
                            Console.WriteLine(FractionCompare1 + " меньше, чем " + FractionCompare2);
                        else if(FractionCompare1 == FractionCompare2)
                            Console.WriteLine("Дроби равны");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Fraction ConvertibleFraction = Fraction.Input("Конвертируемая дробь: ");
                        double inDouble = ConvertibleFraction;
                        int inInt = ConvertibleFraction;
                        Console.Clear();
                        Console.WriteLine("Целая часть: " + inInt);
                        Console.WriteLine("Десятичная запись: " + inDouble);
                        Console.ReadKey();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
