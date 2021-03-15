using System;
namespace _Vectors {
    class Vector {
        private float x;
        private float y;
        private float z;

        public Vector(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Info(string message = "vector") {
            string result = $"Info for {message}: ";
            Console.WriteLine($"Info for {message}: ({x},{y},{z})");
        }

        public static Vector operator +(Vector vectFirst, Vector vectSecond) {
            return new Vector(vectFirst.x + vectSecond.x, vectFirst.y + vectSecond.y, vectFirst.z + vectSecond.z);
        }

        public static Vector operator -(Vector vectFirst, Vector vectSecond) {
            return new Vector(vectFirst.x - vectSecond.x, vectFirst.y - vectSecond.y, vectFirst.z - vectSecond.z);
        }

        // Векторное произведение
        public static Vector operator *(Vector vectFirst, Vector vectSecond) {
            return new Vector(vectFirst.y * vectSecond.z - vectFirst.z * vectSecond.y,
                                vectFirst.z * vectSecond.x - vectFirst.x * vectSecond.z,
                                vectFirst.x * vectSecond.y - vectFirst.y * vectSecond.x);
        }
    }

    class Program {
        static void Main(string[] args) {
            Vector firstVect, secondVect;
            GetNewVector(out firstVect, nameof(firstVect));
            GetNewVector(out secondVect, nameof(secondVect));

            Vector sum = firstVect + secondVect;
            sum.Info("sum of firstVector & secondVector");

            Vector sub = firstVect - secondVect;
            sub.Info("sub of firstVector & secondVector");

            Vector mul = firstVect * secondVect;
            sub.Info("vector mult of firstVector & secondVector");
        }

        public static void GetNewVector(out Vector vect, string message) {
            float x, y, z;
            while (true) {
                Console.WriteLine($"Enter three coordinates for {message}:");
                try {
                    x = float.Parse(Console.ReadLine());
                    y = float.Parse(Console.ReadLine());
                    z = float.Parse(Console.ReadLine());
                    vect = new Vector(x, y, z);
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input\n");
                }
            }
        }
    }
}
