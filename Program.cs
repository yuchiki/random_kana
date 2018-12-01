using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace random_kana {
    static class Program {
        static Random rand = new Random();

        static List<string> ReadFrequency() {
            var mora = new List<string>();
            var reader = new StreamReader("frequency.txt");
            while (!reader.EndOfStream) {
                var line = reader.ReadLine().Split(" ");
                mora.AddRange(Enumerable.Repeat(line[0], (int) (double.Parse(line[1]) * 100)));
            }
            return mora;
        }

        static string GetRandomMora(List<string> mora) => mora[rand.Next(mora.Count)];
        static void DisplayLetter(List<string> mora) {
            Console.Write(GetRandomMora(mora));
            Thread.Sleep(100);
        }

        static void Recite(List<string> mora) {
            Action displayLetter = () => DisplayLetter(mora);

            void Pause() {
                Console.Write(" ");
                Thread.Sleep(500);
            }

            (5).Times(displayLetter);
            Pause();
            (7).Times(displayLetter);
            Pause();
            (5).Times(displayLetter);
            Pause();
            (7).Times(displayLetter);
            Pause();
            (7).Times(displayLetter);
            Console.WriteLine();
            Pause();
        }

        static void Main(string[] args) {
            var mora = ReadFrequency();

            while (true) {
                Recite(mora);
            }

        }

        static void Times(this int n, Action a) {
            for (int i = 0; i < n; i++) a();
        }
    }
}
