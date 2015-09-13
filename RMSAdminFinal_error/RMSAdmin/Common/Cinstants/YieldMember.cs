using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using System.Reflection;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace RMS
{
    namespace Common
    {
        /// <summary>
        /// Provides the method that is used to yield the value of an object member.
        /// </summary>
        /// <param name="item">The item to get the value from.</param>
        /// <returns>The value yielded.</returns>
        public delegate U YieldMember<T, U>(T item);
    }//ns
}//ns