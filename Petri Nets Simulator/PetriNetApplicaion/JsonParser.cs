using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PetriNetApplicaion
{
    public class JsonParser
    {
        public List<Location> Locations;
        public List<Transition> Transitions;

        public PetriNetModel GetPetriElements()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C: \Users\Benjamin Kelenyi\Desktop\PetriNetApplicaion\Input.txt");

            Locations = new List<Location>();
            Transitions = new List<Transition>();

            foreach (string line in lines)
            {
                if (line[1].Equals('l'))
                {
                    Location location = new Location(line);
                    Locations.Add(location);
                }
                else
                {
                    Transition transition = new Transition(line);
                    Transitions.Add(transition);
                }
            }
            //return Locations;//null

            PetriNetModel pnm = new PetriNetModel
            {
                Locations = Locations,
                Transitions = Transitions

            };
            return pnm;
        }
    }
}
