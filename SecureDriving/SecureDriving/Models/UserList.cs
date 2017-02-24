using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureDriving.Models
{
    public class UserList
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public DateTime ? creationDate { get; set; }
        public string Email { get; set; }
        public string active { get; set; }
        public string Address { get; set; }
        public string NJDL_ { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public int ? Role { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string Zip { get; set; }
        public string PhoneNo { get; set; }
        public string ShowDateOfBirth { get; set; }
        public bool Iscompleted { get; set; }
        public DateTime ICourseCompletedDate { get; set; }

        public DateTime StartOfWeek(DateTime d)
        {
            if (d == DateTime.MinValue)
            {
                return d;
            }
            var result = d.DayOfWeek - DayOfWeek.Sunday;

            if (result < 0)
            {
                result += 7;
            }

            return d.AddDays(result * -1);
        }

        public DateTime EndOfWeek(DateTime d)
        {
            if (d == DateTime.MinValue)
            {
                return d;
            }

            return this.StartOfWeek(d).AddDays(6);
        }
    }
}