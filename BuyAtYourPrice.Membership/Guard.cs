using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyAtYourPrice.Membership
{
    internal static class Guard
    { 
        /// <summary>
        /// Asserts that argument is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="argument"></param>
        internal static void ArgumentIsNotNull<T>(this T value, string argument)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(argument);
            }
        }
    }
}
