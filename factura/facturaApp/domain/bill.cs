using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.domain
{
    public class Bill
    {
        public int id {  get; set; }
        public DateTime date {  get; set; }
        public type type { get; set; }
        public string? client { get; set; }


        public List<billDetails> details;

        public Bill (billDetails d) 
        {
            details = new List<billDetails>();
        }

        public void addDetail(billDetails d)
        {
           if(d != null)
            {
                details.Add(d);
            }
        }

        public void removeDetail(int i)
        {
            details.RemoveAt(i);
        }

        public float total()
        {
            float total = 0;
              foreach(var d in details)
            {
                total += d.total();
            }
              return total;
        }
    }
}
