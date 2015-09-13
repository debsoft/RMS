using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ICategory3DAO
    {
        //void Category3Insert(CCategory3 inCategory3);
        void Category3Update(CCategory3 inCategory3);
        //void Category3Delete(CCategory3 inCategory3);

        CResult Category3Insert(CCategory3 inCategory3);
        //CResult Category3Update(CCategory3 inCategory3);
        void Category3Delete(CCategory3 inCategory3);
        List<CCategory3> GetAllCategory3();
    }
}
