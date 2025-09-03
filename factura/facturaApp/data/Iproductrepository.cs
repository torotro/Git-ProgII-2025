using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data
{
    internal interface Iproductrepository
    {
        List<product> getall();
        Bill? getbyid(int id);
        bool save(product product);
        bool delete(int id);
    }
}
