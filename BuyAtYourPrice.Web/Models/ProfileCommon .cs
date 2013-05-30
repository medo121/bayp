using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace BuyAtYourPrice.Web.Models
{
    public class ProfileCommon : ProfileBase
    {
        public virtual string Phone
        {
            get { return ((string) (this.GetPropertyValue("Phone"))); }
            set { this.SetPropertyValue("Phone", value); }
        }

        public virtual string City
        {
            get { return ((string) (this.GetPropertyValue("City"))); }
            set { this.SetPropertyValue("City", value); }
        }

        public virtual string State
        {
            get { return ((string) (this.GetPropertyValue("State"))); }
            set { this.SetPropertyValue("State", value); }
        }

        public virtual string Zip
        {
            get { return ((string) (this.GetPropertyValue("Zip"))); }
            set { this.SetPropertyValue("Zip", value); }
        }

        public virtual ProfileCommon GetProfile(string username)
        {
            return Create(username) as ProfileCommon;
        }
    }
}