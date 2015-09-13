using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
  public  interface IShiftScheduleDao
    {
      CShiftSchedule AddShiftSchedule(CShiftSchedule shiftSchedule);
      CShiftSchedule UpdateShiftSchedule(CShiftSchedule shiftSchedule);
      bool DeleteShiftSchedule(long shiftScheuleID);
      List<CShiftSchedule> GetAllShiftSchedule();
      CShiftSchedule GetAllShiftScheduleID(long shiftScheuleID);
      List<CShiftSchedule> GetAllShiftScheduleByShiftID(long ShiftID);

      List<CShiftSchedule> GetAllShiftSCheduleByCreationDate(DateTime creationDate);
        
    }
}
