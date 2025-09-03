using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.domain
{
    public class product
    {
        private int Id {  get; set; }
        private string Name { get; set; }

        private double UnitPrice { get; set; }

        public int stock {  get; set; }


        public override string ToString()
        {
            return Name + "-" + stock;
        }

    }
}
