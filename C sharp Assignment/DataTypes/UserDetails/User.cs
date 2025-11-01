using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDetails
{
    // Enum to represent marital status with clear and distinct values
    public enum MaritalStatus
    {
        Single = 0,
        Married = 1,
        Divorced = 2,
        Widowed = 3
    }

    public class User
    {
        // Age is a naturally non-negative number and represented as a whole number
        public uint age { get; set; }
        // Height can be a decimal value, offers more precision suitable for biological measurements
        public double height { get; set; }
        // Weight can be a decimal value, offers more precision suitable for biological measurements
        public decimal weight { get; set; }
        // MaritalStatus uses the defined enum for clarity and type safety
        public MaritalStatus MaritalStatus { get; set; }

        public User(uint age, double height, decimal weight, MaritalStatus maritalStatus)
        {
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.MaritalStatus = maritalStatus;
        }
    }
}
