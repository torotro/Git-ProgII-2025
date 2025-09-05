using facturaApp.data;
using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.services
{
    public class Billservices
    {
        private Iproductrepository _repository;
        public Billservices()
        {
            _repository = new productRepository();
        }


        public bool save(Bill bill)
        {
            bool result;
            var billID = _repository.getbyid(bill.id);


            if (billID != null)
            {
                result = _repository.save(billID);
            }
            else
            {
                result = false;
            }

            return result;
        }

    }

}
