using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PetriNetApplicaion
{
    public class PetriNetModel
    {
        public List<Location> Locations { get; set; }
        public List<Transition> Transitions { get; set; }


        public PetriNetModel InitializeModel()
        {
            JsonParser parser = new JsonParser();
            var pnm=parser.GetPetriElements();

            Dictionary<string, Location> dictionary = new Dictionary<string, Location>();

            foreach (var model in pnm.Locations)
            {
                dictionary.Add(model.Name, model);
            }

            foreach (var model in pnm.Transitions)
            {
                model.InLocation = GetLocationByName(model.InLocationName, dictionary);
                model.OutLocation = GetLocationByName(model.OutLocationName, dictionary);
            }

            List<string> s = new List<string>();
            s.Add("P1");
            return pnm;
            }

        public List<Location> GetLocationByN(List<string> Names, Dictionary<string, Location> dictionary)
        {
            List<Location> locList = new List<Location>();

            foreach (var dict in dictionary)
            {
                foreach(var name in Names)
                {
                    if (dict.Key.Equals(name)) locList.Add(dict.Value);
                }
            }
            return locList;
        }

        public List<Location> GetLocationByName(Array Names, Dictionary<string, Location> dictionary)
        {
            List<Location> locList = new List<Location>();

            foreach (var dict in dictionary)
            {
                foreach (var name in Names)
                {
                    if (dict.Key.Equals(name.ToString()))
                        locList.Add(dict.Value);
                }
            }
            return locList;
        }

        public void Execute(int time)
        {
            foreach(var tr in Transitions)
            {
                tr.ExecuteTransition(time);
            }
        }
        public static int z = 0;
        public void Display()
        {
            ;
            foreach(var loc in Locations)
            {
                Console.WriteLine(loc.Name+" "+loc.Tokens); 
            }
            z++;
            Console.WriteLine("------"+z+"-------");
        }  
    }
}
