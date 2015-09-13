using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.BLL
{
    public class UnitCreateBLL
    {
        public string InsertUnit(Unit sr)
        {
            string srr = string.Empty;
            UnitCreateDAO aDao=new UnitCreateDAO();
            srr = aDao.InsertUnit(sr);
            return srr;
        }

        public List<Unit> GetALLUnit()
        {
            UnitCreateDAO aDao=new UnitCreateDAO();
            List<Unit> aList=new List<Unit>();
            aList = aDao.GetALLUnit();
            aList = aList.OrderBy(alist => alist.UnitName).ToList();
            return aList;
        }

        public Unit GetUnitByUnitId(int unitId)
        {
            UnitCreateDAO aDao=new UnitCreateDAO();
            Unit aUnit=new Unit();
           aUnit = aDao.GetUnitByUnitId(unitId);
            return aUnit;
        }

        public bool CheckExit(string sr)
        {
            UnitCreateDAO aDao = new UnitCreateDAO();
            List<Unit> aList = new List<Unit>();
            aList = aDao.GetALLUnit();
            bool flag=false ;
            foreach (Unit unit in aList)
            {
                if (unit.UnitName.ToUpper() == sr.ToUpper()) flag=true;
            }
            if (flag) return true;
            return false;
        }
    }
}
