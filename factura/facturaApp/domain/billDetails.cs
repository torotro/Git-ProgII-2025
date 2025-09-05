using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.domain
{
    public class billDetails
    {
        public Product? product {  get; set; }

        public Bill? id { get; set; }
        public int count {  get; set; }

        public float price { get; set; }    



        public float total() 
        { 
            return price * count;
        }


    }
}
