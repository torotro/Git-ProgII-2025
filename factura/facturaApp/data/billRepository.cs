using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data
{
    public class billRepository : IBillrepository
    {
        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bill> getall()
        {
            List<Bill> lst = new List<Bill>();

            var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Facturas");
            foreach (DataRow item in dt.Rows)
            {

                Bill b = new Bill();
                type t=new type();
                b.id = Convert.ToInt32(item["nroFactura"]);
                b.date = (DateTime)item["fecha"];
                t.name = (string)item["idforma"];
                b.client = (string)item["cliente"];
                lst.Add(b);

            }

            return lst;
        }

        public Bill? getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public bool save(Bill bill)
        {
            throw new NotImplementedException();
        }
    }
}
