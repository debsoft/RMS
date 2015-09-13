using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IBookingDAO
    {
        CResult GetBookingInfoAll(DateTime inCurrentDate);
        CResult GetBookingInfoByID(Int64 inBookingID);
        CResult InsertBookingInfo(CBooking inBookingInfo);
        CResult UpdateBookingInfo(CBooking inBookingInfo);
        CResult DeleteBookingInfo(Int64 inBookingID);
    }
}
