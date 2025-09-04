using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data
{
    internal class productRepository : Iproductrepository
    {
        
        public List<product> getall()
        {
            List<product>lst = new List<product>();

            var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Articulos");
            foreach (DataRow item in dt.Rows) 
            {

                product p = new product();
                p.Id = Convert.ToInt32(item["id_articulo"]);
                p.Name=(string)item["nombre"];
                p.UnitPrice = (double)item["precioUnitario"];
                p.stock = (int)item["stock"];
                lst.Add(p);

            }

            return lst;
        }

        
        public bool save(product product)
        {
            throw new NotImplementedException();
        }
    }
}
