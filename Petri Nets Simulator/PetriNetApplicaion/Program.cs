using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PetriNetApplicaion
{
    class Program
    {
        public static int time = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Petri Nets Simulator");
            Console.WriteLine("@author: Benjamin Kelenyi");
            Console.WriteLine("");
            Console.WriteLine("Simulation started:");
            Console.WriteLine("");

            var petriNetModel = new PetriNetModel();

            var pnm=petriNetModel.InitializeModel();

            for (int i = 0; i <= 15; i++)
            {
                pnm.Display();
                pnm.Execute(time);

                time++;
            }
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
