using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SQLkab
{
    public class Customer
    {
        //const string source = "Data Source=.;Initial Catalog = kab; Integrated Security = True";

        #region
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        #endregion

        public Customer(int customerID, string userName, string userPassword, string firstName, string lastName, string street, string zip, string city, string countryCode, string email, string phoneNumber, bool isAdmin, bool isActive)
        {
            CustomerID = customerID;
            UserName = userName;
            UserPassword = userPassword;
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            Zip = zip;
            City = city;
            CountryCode = countryCode;
            Email = email;
            PhoneNumber = phoneNumber;
            IsAdmin = isAdmin;
            IsActive = isActive;

        }
        public override string ToString()
        {
            return $"CustomerID: {CustomerID}, UserName: {UserName}, UserPassword: {UserPassword}, FirstName: {FirstName}, LastName: {LastName}, Street: {Street}, Zip: {Zip}, City: {City}, CountryCode: {CountryCode}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }

    }
}
