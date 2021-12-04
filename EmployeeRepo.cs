using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeDatabase
{
    class EmployeeRepo
    {
        public static string connectionString = "Server=(localdb)\\MSSQLLOCALDB (DESKTOP-U23RQH1\\CSC);Database=AddressBookservice";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                AddressbookModel addressbookModel = new AddressbookModel();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllAddressBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            addressbookModel.FirstName = dr.GetString(0);
                            addressbookModel.LastName = dr.GetString(1);
                            addressbookModel.Address = dr.GetString(2);
                            addressbookModel.City = dr.GetString(3);
                            addressbookModel.State = dr.GetString(4);
                            addressbookModel.ZipCode = dr.GetInt32(5);
                            addressbookModel.PhoneNumber = dr.GetString(6);
                            addressbookModel.Email = dr.GetString(7);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", addressbookModel.FirstName, addressbookModel.LastName
                                , addressbookModel.Address, addressbookModel.City, addressbookModel.State, addressbookModel.ZipCode, addressbookModel.PhoneNumber, addressbookModel.Email);

                        }
                        dr.Close();
                        this.connection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool Add(AddressbookModel addressbookModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddInAddressBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressbookModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", addressbookModel.LastName);
                    command.Parameters.AddWithValue("@Address", addressbookModel.Address);
                    command.Parameters.AddWithValue("@City", addressbookModel.City);
                    command.Parameters.AddWithValue("@State", addressbookModel.State);
                    command.Parameters.AddWithValue("@ZipCode", addressbookModel.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", addressbookModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", addressbookModel.Email);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }
        public bool UpdateData(AddressbookModel addressModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateInAddressBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressModel.FirstName);
                    command.Parameters.AddWithValue("@State", addressModel.State);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public bool DeletePerson(AddressbookModel addressModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteInAddressBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressModel.FirstName);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void RetrivePersonCityOrState(AddressbookModel addressModel)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spPersonsCityorState", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", addressModel.City);
                    command.Parameters.AddWithValue("@State", addressModel.State);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    //command.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressModel.FirstName = dr.GetString(0);
                            addressModel.City = dr.GetString(1);
                            addressModel.State = dr.GetString(2);
                            Console.WriteLine(addressModel.FirstName + "," + addressModel.City + "," + addressModel.State);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data not found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

    }
}





        

                        
                        
            
