using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PetriNetApplicaion
{
    public class Transition
    {
        public string name { get; set; }
        public List<Location> InLocation { get; set; }
        public int Delay { get; set; }
        public List<Location> OutLocation { get; set; }
        public int Wait { get; set; }
        public Array InLocationName { get;set;}
        public Array OutLocationName { get; set; }

        public Transition(string json)
        {

            JObject jObject = JObject.Parse(json);
            JToken jTransition = jObject["transition"];
            name = (string)jTransition["name"];
            Delay=(int)jTransition["Delay"];
            Wait= (int)jTransition["WaitingFor"];
            OutLocationName = jTransition["OutLocationName"].ToArray();
            InLocationName = jTransition["InLocationName"].ToArray();
        }

        public bool IsExecutable(int time)
        {
            if (InLocation != null && this.Delay <= this.Wait )
                foreach (var loc in InLocation)
                {
                    if (loc.Tokens == 0)
                        return false;

                }
            else if (InLocation != null && this.Wait < this.Delay)
            {
                return false;
            }
            else if (InLocation == null && this.Wait < this.Delay)
                return false;
            return true;
        }

        /// <summary>
        /// Get the tokens from in and put them in out list
        /// </summary>
        public void ExecuteTransition(int time)
        {
            if (this.IsExecutable(time))
            {
                if (InLocation == null)
                {
                    foreach (var loc in OutLocation)
                    {
                        loc.Tokens++;
                    }
                }
                else
                {
                    foreach (var loc in InLocation)
                    {
                        loc.Tokens--;
                    }

                    foreach (var loc in OutLocation)
                    {
                        loc.Tokens++;
                    }
                }
                this.Wait = 0;
            }
            else if(IsTokensInIns(this))
                this.Wait++;
        }

        public bool IsTokensInIns(Transition t)
        {
                foreach (var l in t.InLocation)
                {
                    if (l.Tokens == 0) return false;
                }
            return true;
        }
    }
}
