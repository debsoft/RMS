using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    public static class Constants
    {
    }

    /// <summary>
    /// Enumeration used for setting the log level when
    /// adding an entry to the Logger.
    /// </summary>
    /// <remarks>
    /// NOTE: 
    /// For now, use unique enum member names,
    /// the first character is used when writing to a text file.
    /// i.e. [D] [I] [W] etc.
    /// </remarks>
    [Flags()]
    public enum LogLevel
    {
        Debug = 1,
        Information = 2,
        Warning = 4,
        Error = 8,
        Fatal = 16
    }

    /// <summary>
    /// File name scheme used to determine when to create 
    /// new logfiles.
    /// </summary>
    public enum FileNameScheme
    {
        Daily = 0,
        Weekly = 1,
        MaxSize = 2
    }

    /// <summary>
    /// Folder name scheme used to determine when to create 
    /// new folders.
    /// </summary>
    public enum FolderNameScheme
    {
        None = 0,
        Month = 1,
        Day = 2,
        MonthDay = 3,
        YearMonth = 4,
        YearMonthDay = 5
    }

}//ns
