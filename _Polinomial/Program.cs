using System;

namespace _Polinomial {
    class Polinomial {
        private double[] coefs;
        public Polinomial(double[] coefs) {
            this.coefs = coefs;
            Trim();
        }
        public void Trim() {
            // Избавление от ведущих нулей
            int maxIndex = coefs.Length - 1;
            for (; maxIndex >= 0; maxIndex--)
                if (coefs[maxIndex] != 0)
                    break;
            coefs = coefs[..(maxIndex + 1)];
        }

        public static implicit operator string(Polinomial obj) {
            string result = string.Empty;
            string sign;
            string xString;
            string num;
            string mult;

            for (int i = obj.coefs.Length - 1; i >= 0; i--) {
                if (obj[i] == 0)
                    continue;
                sign = obj[i] >= 0 ? " + " : " - ";
                num = Math.Abs(obj[i]) switch {
                    1 when i != 0 => string.Empty,
                    _ => $"{Math.Abs(obj[i]):#.###}",
                };
                mult = string.IsNullOrEmpty(num) || i == 0 ? string.Empty : "*";
                xString = i switch {
                    0 => string.Empty,
                    1 => "x",
                    _ => $"x^{i}",
                };
                result += $"{sign}{num}{mult}{xString}";
            }
            return result;
        }
        public static Polinomial operator +(Polinomial A, Polinomial B) {
            // резервирование нужного количества коэффициентов
            double[] newCoefs = new double[Math.Max(A.coefs.Length, B.coefs.Length)];
            // получение минимальной длины среди многочленов
            int minLength = Math.Min(A.coefs.Length, B.coefs.Length);
            bool AIsBigger = A.coefs.Length > B.coefs.Length;
            // выполнение операции
            for (int i = 0; i < minLength; i++)
                newCoefs[i] = A[i] + B[i];
            // если остались неинициализированные данные, заполняем их
            for (int i = minLength; i < newCoefs.Length; i++)
                newCoefs[i] = AIsBigger ? A[i] : B[i];
            return new Polinomial(newCoefs);
        }
        public static Polinomial operator -(Polinomial A, Polinomial B) {
            double[] newCoefs = new double[Math.Max(A.coefs.Length, B.coefs.Length)];
            int minLength = Math.Min(A.coefs.Length, B.coefs.Length);
            bool AIsBigger = A.coefs.Length > B.coefs.Length;
            for (int i = 0; i < minLength; i++)
                newCoefs[i] = A[i] - B[i];
            for (int i = minLength; i < newCoefs.Length; i++)
                newCoefs[i] = AIsBigger ? A[i] : -B[i];
            return new Polinomial(newCoefs);
        }

        public double this[int index] {
            get {
                return coefs[index];
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            Polinomial firstPolinomial = GetNewPolinomial();
            Polinomial secondPolinomial = GetNewPolinomial();
            
            Console.WriteLine("Введённые многочлены : ");
            Console.WriteLine(firstPolinomial);
            Console.WriteLine(secondPolinomial);

            Polinomial sum = firstPolinomial + secondPolinomial;
            Console.WriteLine($"Сумма : " + sum);

            Polinomial sub = firstPolinomial - secondPolinomial;
            Console.WriteLine($"Разность : " + sub);
        }
        public static Polinomial GetNewPolinomial() {
            int length;
            while (true) {
                try {
                    Console.WriteLine("Введите максимальную степень многочлена : ");
                    length = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input");
                }
            }

            double[] coefs = new double[++length];
            for (int i = length - 1; i >= 0; i--) {
                while (true) {
                    try {
                        Console.WriteLine($"Введите коэффициент при x ^ {i} : ");
                        coefs[i] = double.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException) {
                        Console.WriteLine("Invalid input");
                    }
                }
            }

            Console.Clear();
            return new Polinomial(coefs);
        }
    }

}
