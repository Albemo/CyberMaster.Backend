using CyberMaster.Backend.Core.Common;
using CyberMaster.Backend.Core.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMaster.Backend.Core.Models
{
    public class User : IdentityUser<int>, IAuditable
    {
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName?.ToTitleCase();
            }
            set
            {
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName?.ToTitleCase();
            }
            set
            {
                lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string Initials
        {
            get
            {
                return FirstName.ToUpper().Trim().Initial() + LastName?.ToUpper().Trim().Initial();
            }
        }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public int? CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public int? UpdatedById { get; set; }

        public User UpdatedBy { get; set; }
    }
}
