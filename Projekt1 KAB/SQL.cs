using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;

namespace SQLkab
{
    public class SQL
       
    {
        const string source = "Data Source=.;Initial Catalog = kab; Integrated Security = True";

        public void Update()
        {
            //return TODO;
        }

        public static int AddCustomer(string userName, string userPassword, string firstName, string lastName, string street, string zip, string city, string countryCode, string email, string phoneNumber, bool isAdmin, bool isActive)
        {
            int nID = 0;
            SqlConnection myConnection = new SqlConnection(source);
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("AddCustomer", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newUserName = new SqlParameter("@userName", SqlDbType.VarChar);
                newUserName.Value = userName;
                SqlParameter newUserPassword = new SqlParameter("@userPassword", SqlDbType.VarChar);
                newUserPassword.Value = userPassword;
                SqlParameter newFirstName = new SqlParameter("@firstName", SqlDbType.VarChar);
                newFirstName.Value = firstName;
                SqlParameter newLastName = new SqlParameter("@lastName", SqlDbType.VarChar);
                newLastName.Value = lastName;
                SqlParameter newStreet = new SqlParameter("@street", SqlDbType.VarChar);
                newStreet.Value = street;
                SqlParameter newZip = new SqlParameter("@zip", SqlDbType.VarChar);
                newZip.Value = zip;
                SqlParameter newCity = new SqlParameter("@city", SqlDbType.VarChar);
                newCity.Value = city;
                SqlParameter newCountryCode = new SqlParameter("@countryCode", SqlDbType.VarChar);
                newCountryCode.Value = countryCode;
                SqlParameter newEmail = new SqlParameter("@email", SqlDbType.VarChar);
                newEmail.Value = email;
                SqlParameter newPhoneNumber = new SqlParameter("@phoneNumber", SqlDbType.VarChar);
                newPhoneNumber.Value = phoneNumber;
                SqlParameter newIsAdmin = new SqlParameter("@isAdmin", SqlDbType.VarChar);
                newIsAdmin.Value = isAdmin;
                SqlParameter newIsActive = new SqlParameter("@isActive", SqlDbType.VarChar);
                newIsActive.Value = isActive;

                SqlParameter customerID = new SqlParameter("@customer_id", SqlDbType.Int);
                customerID.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newUserName);
                myCommand.Parameters.Add(newUserPassword);
                myCommand.Parameters.Add(newFirstName);
                myCommand.Parameters.Add(newLastName);
                myCommand.Parameters.Add(newStreet);
                myCommand.Parameters.Add(newZip);
                myCommand.Parameters.Add(newCity);
                myCommand.Parameters.Add(newCountryCode);
                myCommand.Parameters.Add(newEmail);
                myCommand.Parameters.Add(newPhoneNumber);
                myCommand.Parameters.Add(newIsAdmin);
                myCommand.Parameters.Add(newIsActive);
                myCommand.Parameters.Add(customerID);

                myCommand.ExecuteNonQuery();
                nID = (int)customerID.Value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                myConnection.Close();
            }
            return nID;
        }


        public static List<Customer> ReadAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = source;
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("select * from Customer", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    customers.Add(new Customer(Convert.ToInt32(myReader["CustomerID"].ToString()), myReader["UserName"].ToString(), myReader["UserPassword"].ToString(), 
                    myReader["FirstName"].ToString(), myReader["LastName"].ToString(), myReader["Street"].ToString(), myReader["Zip"].ToString(), myReader["City"].ToString(), 
                    myReader["CountryCode"].ToString(), myReader["Email"].ToString(), myReader["PhoneNumber"].ToString(), Convert.ToBoolean(myReader["IsAdmin"]), Convert.ToBoolean(myReader["IsActive"])));
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                myConnection.Close();
            }
            return customers;
        }



    }
}
