﻿using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data
{
    internal interface IBillrepository
    {
        List<Bill> getall();
        Bill? getbyid(int id);
        bool save(Bill bill);
        bool delete(int id);

    }
}
