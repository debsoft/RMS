using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CShiftSchedule
    {     
        private long  schedule_id ;
        private long shift_id;
        private int shift_no;
        private DateTime creationDate;
        private DateTime start_day;
        private DateTime start_time;
        private DateTime end_day;
        private DateTime end_time;
        private long start_timestamp;
        private long end_timestamp;       
        private bool isactive;


       public long ScheduleId
       {
           get { return schedule_id; }
           set { schedule_id = value; }
       }

       public long ShiftId
       {
           get { return shift_id; }
           set { shift_id = value; }
       }

       public int ShiftNo
       {
           get { return shift_no; }
           set { shift_no = value; }

       }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public DateTime StartDay
        {
            get { return start_day; }
            set { start_day = value; }
        }

        public DateTime StartTime
        {
            get { return start_time; }
            set { start_time = value; }
        }

        public DateTime EndDay
        {
            get { return end_day; }
            set { end_day = value; }
        }

        public DateTime EndTime
        {
            get { return end_time; }
            set { end_time = value; }
        }

        public long StartTimestamp
        {
            get { return start_timestamp; }
            set { start_timestamp = value; }
        }

        public long EndTimestamp
        {
            get { return end_timestamp; }
            set { end_timestamp = value; }
        }

        public bool Isactive
        {
            get { return isactive; }
            set { isactive = value; }
        }
    }
}
