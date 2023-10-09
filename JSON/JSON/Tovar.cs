using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace JSON
{
    
    [System.Runtime.Serialization.DataContract]
    class Tovar
    {
        [System.Runtime.Serialization.DataMember]
        public int ID;
        [System.Runtime.Serialization.DataMember]
        public string Name;
        [System.Runtime.Serialization.DataMember]
        public double Price;
        public Tovar(int kod, string naimen, double cena)
        {
            this.ID = kod;
            this.Name = naimen;
            this.Price = cena;
        }
    }

}
