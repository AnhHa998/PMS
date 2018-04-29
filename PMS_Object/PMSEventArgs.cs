using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PMS_Object
{
    public class PMSEventArgs : EventArgs
    {
        //public string GiaTri { get; set; }

        public List<SqlParameter> ListParameter { get; set; }

    }
}
