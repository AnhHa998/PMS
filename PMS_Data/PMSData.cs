using PMS_Object;
using System.Collections.Generic;
using System.Data;

namespace PMS_Data
{
    public abstract class PMSData
    {
        protected abstract PMSObject PhanTichDataRow(DataRow dr);

        //public abstract List<T> LayDuLieu<T>();

        public abstract void Them(PMSObject obj);

        public abstract void Xoa(object ma);

        public abstract void CapNhat(PMSObject obj);

    }
}
