using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BuyAtYourPrice.Web.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateEmailAddressAttribute : RegularExpressionAttribute
    {
        private const string defaultErrorMessage = "{0} is invalid.";
        private const string pattern = "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$";

        public ValidateEmailAddressAttribute()
            : base(pattern)
        {
            this.ErrorMessage = defaultErrorMessage;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, this.ErrorMessageString,
                                 name);
        }
    }
}