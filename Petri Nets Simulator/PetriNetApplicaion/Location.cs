using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PetriNetApplicaion
{
   public class Location
    {
        
        public List<Transition> InTransition { get; set; }
        public int Tokens { get; set; }
        public List<Transition> OutTransition { get; set; }
        public string Name { get; set; }

        public Location(string json)
        {
           
            JObject jObject = JObject.Parse(json);
            JToken jLocation = jObject["location"];
            Tokens = (int)jLocation["Tokens"];
            Name = (string)jLocation["Name"];
        }

    }
}
