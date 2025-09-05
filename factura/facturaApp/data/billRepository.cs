using facturaApp.domain;
using Microsoft.Data.SqlClient;
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
            throw new NotImplementedException();
            //List<Bill> lst = new List<Bill>();

            //var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Facturas");
            //foreach (DataRow item in dt.Rows)
            //{

            //    Bill b = new Bill();
            //    type t=new type();
            //    b.id = Convert.ToInt32(item["nroFactura"]);
            //    b.date = (DateTime)item["fecha"];
            //    t.name = (string)item["idforma"];
            //    b.client = (string)item["cliente"];
            //    lst.Add(b);

              

              
            //}

            //return lst;

        }

           
            
        

        public Bill? getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public bool save(Bill bill)
        {
            bool result = true;
            SqlConnection? cnn = null;
            SqlTransaction? t=null;

            try
            {
                cnn=Datahelper.GetInstance().GetConnection();
                cnn.Open();
                t=cnn.BeginTransaction();
                var cmd = new SqlCommand("sp_insertar_Maestro", cnn, t);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Convert.ToString(DateTime.Now), bill.date);
                cmd.Parameters.AddWithValue("@tipo", bill.type);
                cmd.Parameters.AddWithValue("@nombre", bill.client);


                SqlParameter p=new SqlParameter("@id",SqlDbType.Int);
                p.Direction= ParameterDirection.Output;
                cmd.Parameters.Add(p);

                int billid=(int)p.Value;
                int detailId = 1;
                foreach (var d in bill.details)
                {
                    var cmdDetails = new SqlCommand("sp_insertar_Detalle", cnn, t);
                    cmdDetails.CommandType=CommandType.StoredProcedure;

                    cmdDetails.Parameters.AddWithValue("@id", detailId);
                    cmdDetails.Parameters.AddWithValue("@articulo", d.product?.Id);
                    cmdDetails.Parameters.AddWithValue("@cantidad",d.count);
                    cmdDetails.Parameters.AddWithValue("@nroFactura", billid);
                    cmdDetails.Parameters.AddWithValue("@monto", d.total());
                    cmdDetails.ExecuteNonQuery();
                    detailId++;
                }

                cmd.ExecuteNonQuery();
                t.Commit();
                
            }
            catch(SqlException)
            {
                if(t!= null) t.Rollback();
            }
            finally
            {
                if(cnn != null && cnn.State==ConnectionState.Open) { cnn.Close(); }
            }
            return result;
        }
    }
}
