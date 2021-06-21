using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6
{
    [Serializable]
    public class Car
    {
        public string Name { get; set; }
        public string Firm { get; set; }
        public string Owner { get; set; }
        
        public Car()
        {

        }

        [OnSerializing]
        internal void OnSerializing(StreamingContext context)
        {
            Name = Name.ToUpper();
            Firm = Firm.ToUpper();
            Owner = Owner.ToUpper();
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            Name = Name.ToLower();
            Firm = Firm.ToLower();
            Owner = Owner.ToLower();
        }

        public Car(string name, string firm, string owner)
        {
            Name = name;
            Firm = firm;
            Owner = owner;
        }
    }
}
