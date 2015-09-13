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
        public class ObjectComparer<T, U> : IComparer<T> where U : IComparable<U>
        {
            #region Fields

            /* 1 = ignore case
         * 2 = invert
         * 4 = object nullable
         * 8 = value nullable
         */
            private int _options;
            private YieldMember<T, U> _yield;

            #endregion

            #region Properties

            /// <summary>
            /// Gets or sets a value that determines if comparisons are case-sensitive.
            /// </summary>
            /// <value>True if comparisons are case-sensitive; otherwise, false.  This value is ignored
            /// if comparison values are not type <see cref="String"/>.  The default value is true.</value>
            public bool IgnoreCase
            {
                get
                {
                    return ((_options & 1) == 1);
                }
                set
                {
                    if (value)
                        _options |= 1;
                    else
                        _options &= ~1;
                }
            }

            /// <summary>
            /// Gets or sets a value that indicates if comparisons are inverted.
            /// </summary>
            /// <value>True if comparisons are inverted; otherwise, false.  The default value is false.</value>
            /// <remarks>Sorting alogrithms sort in ascending order by default.  Inverting the comparison
            /// results in the sort being performed in descending order.</remarks>
            public bool InvertComparison
            {
                get
                {
                    return ((_options & 2) == 2);
                }
                set
                {
                    if (value)
                        _options |= 2;
                    else
                        _options &= ~2;
                }
            }

            private bool ObjectIsNullable
            {
                get
                {
                    return ((_options & 4) == 4);
                }
                set
                {
                    if (value)
                        _options |= 4;
                    else
                        _options &= ~4;
                }
            }

            private bool ValueIsNullable
            {
                get
                {
                    return ((_options & 8) == 8);
                }
                set
                {
                    if (value)
                        _options |= 8;
                    else
                        _options &= ~8;
                }
            }

            #endregion

            #region Methods

            private bool IsNull(T value)
            {
                if (ObjectIsNullable)
                    return (value == null);

                return false;
            }

            private bool IsNull(U value)
            {
                if (ValueIsNullable)
                    return (value == null);

                return false;
            }

            #endregion

            #region Constructors

            /// <summary>
            /// Instantiates a new instance of the <see cref="ObjectComparer{T,U}"/> class.
            /// </summary>
            /// <param name="yield">The method used to yield the member value of the compared objects.</param>
            /// <exception cref="ArgumentNullException"><i>yield</i> is a null reference (Nothing in Visual Basic)</exception>
            public ObjectComparer(YieldMember<T, U> yield)
                : this(yield, false, true)
            {
            }

            /// <summary>
            /// Instantiates a new instance of the <see cref="ObjectComparer{T,U}"/> class.
            /// </summary>
            /// <param name="yield">The method used to yield the member value of the compared objects.</param>
            /// <param name="invertComparison">Indicates whether results are evaluated inversely.</param>
            /// <exception cref="ArgumentNullException"><i>yield</i> is a null reference (Nothing in Visual Basic)</exception>
            public ObjectComparer(YieldMember<T, U> yield, bool invertComparison)
                : this(yield, invertComparison, true)
            {
            }

            /// <summary>
            /// Instantiates a new instance of the <see cref="ObjectComparer{T,U}"/> class.
            /// </summary>
            /// <param name="yield">The method used to yield the member value of the compared objects.</param>
            /// <param name="invertComparison">Indicates whether results are evaluated inversely.</param>
            /// <param name="ignoreCase">Indicates whether the case of values is ignored.</param>
            /// <exception cref="ArgumentNullException"><i>yield</i> is a null reference (Nothing in Visual Basic)</exception>
            public ObjectComparer(YieldMember<T, U> yield, bool invertComparison, bool ignoreCase)
            {
                if ((_yield = yield) == null)
                    throw new ArgumentNullException("yield");

                // set properties
                IgnoreCase = ignoreCase;
                InvertComparison = invertComparison;
                ObjectIsNullable = !typeof(T).IsValueType;
                ValueIsNullable = !typeof(U).IsValueType;
            }

            #endregion

            #region IComparer<T> Members

            /// <summary>
            /// Compares one object against another.
            /// </summary>
            /// <param name="x">The object that is basis of the comparison.</param>
            /// <param name="y">The object that is being compared.</param>
            /// <returns>Zero if the objects are equal, one if <i>x</i> is greater than <i>y</i>,
            /// or negative one if <i>x</i> is less than <i>y</i>.</returns>
            public int Compare(T x, T y)
            {
                bool reverse = InvertComparison;

                // check for null objects
                if (IsNull(x) && IsNull(y))
                    return 0;
                else if (IsNull(x))
                    return (reverse ? 1 : -1);
                else if (IsNull(y))
                    return (reverse ? -1 : 1);

                // evaluate the value for x
                U value = _yield(x);
                int result = 0;

                if (IsNull(value))
                {
                    // check for null values
                    result = (IsNull(_yield(y)) ? 0 : -1);
                }
                else if (value is string)
                {
                    // special handling for strings
                    if (IgnoreCase)
                        result = StringComparer.OrdinalIgnoreCase.Compare(value, _yield(y));
                    else
                        result = StringComparer.Ordinal.Compare(value, _yield(y));
                }
                else
                {
                    // let the IComparable<T> interface do all the work
                    result = value.CompareTo(_yield(y));
                }

                // return result
                return (reverse ? -result : result);
            }

            #endregion
        }
    }//ns
}//ns