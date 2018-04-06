using System.Collections.Generic;

namespace PMS_Object
{
    public abstract class PMSObject
    {
        public TrangThaiDuLieu TrangThaiThayDoi { get; set; }

        public PMSObject()
        {
            TrangThaiThayDoi = TrangThaiDuLieu.KhongThayDoi;
        }
        
    }
}
