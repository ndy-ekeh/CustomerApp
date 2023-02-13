using Customer.Domain.DTOs;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly IConfiguration _config;

        public CustomerRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<int> AddCustomer(CreateCustomerRequest request)
        {
            var result = 0;
            try
            {
                var query = @"Insert into tbl_CustomerDetails (AccountNumber, PhoneNo, CustomerCode, Email, 
                    FirstName, LastName, HseAddress) 
                    Values(@AccountNumber, @PhoneNo, @CustomerCode, @Email, @FirstName, @LastName, @HseAddress);";

                Log.Information("Calling Database to add Customer");
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand command = new SqlCommand(query);
                    command.Connection = connection;
                    command.Parameters.Add("AccountNumber", SqlDbType.VarChar).Value = request.AccountNumber;
                    command.Parameters.Add("PhoneNo", SqlDbType.VarChar).Value = request.PhoneNo;
                    command.Parameters.Add("CustomerCode", SqlDbType.BigInt).Value = request.CustomerCode;
                    command.Parameters.Add("Email", SqlDbType.VarChar).Value = request.Email;
                    command.Parameters.Add("FirstName", SqlDbType.VarChar).Value = request.FirstName;
                    command.Parameters.Add("LastName", SqlDbType.VarChar).Value = request.LastName;
                    command.Parameters.Add("HseAddress", SqlDbType.VarChar).Value = request.HouseAddress;
                    connection.Open();

                    result = await command.ExecuteNonQueryAsync();
                    connection.Close();
                }

                Log.Information("Call to Add Customer ended");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"An error occured while trying to add Customer: {request.CustomerCode}");
                result = -2;
            }

            return result;
        }

        public async Task<int> UpdateCustomer(UpdateCustomerRequest request)
        {
            var result = 0;
            try
            {
                var query = @"Update tbl_CustomerDetails set AccountNumber = @AccountNumber, PhoneNo = @PhoneNo, 
                    CustomerCode = @CustomerCode, Email = @Email, FirstName = @FirstName, LastName = @LastName, 
                    HseAddress = @HseAddress where ID = @ID;";

                Log.Information("Calling Database to update Customer");
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand command = new SqlCommand(query);
                    command.Connection = connection;
                    command.Parameters.Add("ID", SqlDbType.BigInt).Value = request.ID;
                    command.Parameters.Add("AccountNumber", SqlDbType.VarChar).Value = request.AccountNumber;
                    command.Parameters.Add("PhoneNo", SqlDbType.VarChar).Value = request.PhoneNo;
                    command.Parameters.Add("CustomerCode", SqlDbType.BigInt).Value = request.CustomerCode;
                    command.Parameters.Add("Email", SqlDbType.VarChar).Value = request.Email;
                    command.Parameters.Add("FirstName", SqlDbType.VarChar).Value = request.FirstName;
                    command.Parameters.Add("LastName", SqlDbType.VarChar).Value = request.LastName;
                    command.Parameters.Add("HseAddress", SqlDbType.VarChar).Value = request.HouseAddress;
                    connection.Open();

                    result = await command.ExecuteNonQueryAsync();
                    connection.Close();
                }

                Log.Information("Call to update Customer ended");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"An error occured while trying to update Customer with ID: {request.ID}");
                result = -2;
            }

            return result;
        }

        
        public async Task<List<GetCustomerResponseData>?> GetCustomer(string query, int ID = 0)
        {
            try
            {
                var customers = new List<GetCustomerResponseData>();

                Log.Information("Calling Database to get Customer(s)");
                using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand command = new SqlCommand(query);

                    if(ID != 0)
                        command.Parameters.Add("ID", SqlDbType.BigInt).Value = ID;

                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader dr = await command.ExecuteReaderAsync();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            try
                            {
                                var customer = new GetCustomerResponseData();
                                customer.ID = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("ID")).ToString() ?? string.Empty);
                                customer.CustomerCode = Convert.ToInt64(dr.GetValue(dr.GetOrdinal("CustomerCode")).ToString() ?? string.Empty);
                                customer.FirstName = dr.GetValue(dr.GetOrdinal("FirstName"))?.ToString();
                                customer.LastName = dr.GetValue(dr.GetOrdinal("LastName"))?.ToString();
                                customer.PhoneNo = dr.GetValue(dr.GetOrdinal("PhoneNo"))?.ToString();
                                customer.Email = dr.GetValue(dr.GetOrdinal("Email"))?.ToString();
                               // customer.DateCreated = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("DateCreated"))?.ToString() ?? string.Empty);
                                customer.HouseAddress = dr.GetValue(dr.GetOrdinal("HseAddress"))?.ToString();
                                customer.AccountNumber = dr.GetValue(dr.GetOrdinal("AccountNumber"))?.ToString();

                                customers.Add(customer);
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex, "Error fetching customer");
                            }
                           
                        }
                    }
                }
                Log.Information($"Calling to database to get Customer(s) ended. {customers?.Count} records returned and filtered");


                return customers;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetCustomer");
                return null;
            }
        }

        public async Task<int> DeleteCustomer(int ID)
        {
            var result = 0;
            try
            {
                var query = @"Delete from tbl_CustomerDetails where ID = @ID;";

                Log.Information("Calling Database to delete Customer");
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand command = new SqlCommand(query);
                    command.Connection = connection;
                    command.Parameters.Add("ID", SqlDbType.BigInt).Value = ID;
                    connection.Open();

                    result = await command.ExecuteNonQueryAsync();
                    connection.Close();
                }

                Log.Information("Call to delete Customer ended");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"An error occured while trying to delete Customer with ID: {ID}");
                result = -2;
            }

            return result;
        }
    }
}
