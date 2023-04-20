using Lomo_Template.Models;
using System;
using System.Collections.Generic;

namespace Lomo_Template.Dao
{
    public class TestDao : BaseDao
    {
        public TestDao(string connectionString) : base(connectionString) { }

        public List<People> GetPerson()
        {
            var res = new List<People>();
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.GetPeople");
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(new People
                        {
                            PeopleId = Convert.ToInt32(reader.GetValue(0)),
                            Name = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString(),
                            Phone = reader.GetValue(3).ToString()
                        });
                    }
                }
                DBContext.CommitTransaction();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }
   
        public People GetPersonById(int id)
        {
            var res = new People();
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.GetPersonById");
                AddStringParameter(sqlCommand, "@param1", id.ToString());
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = new People
                        {
                            PeopleId = Convert.ToInt32(reader.GetValue(0)),
                            Name = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString(),
                            Phone = reader.GetValue(3).ToString()
                        };
                    }
                }
                DBContext.CommitTransaction();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }

        public List<Addresses> GetAddresses()
        {
            var res = new List<Addresses>();
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.GetAddresses");
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(new Addresses
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            PersonId = Convert.ToInt32(reader.GetValue(1)),
                            Address = reader.GetValue(2).ToString()
                        });
                    }
                }
                DBContext.CommitTransaction();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }

        public List<Addresses> GetAddressesWithPeople()
        {
            var res = new List<Addresses>();
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.GetAddressesWithPeople");
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Addresses address = new Addresses
                        {
                            Address = reader.GetValue(0).ToString()
                          
                        };
                        address.SetPeople(new People()
                        {
                            Name = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString()
                        });
                        res.Add(address);
                    }
                }
                DBContext.CommitTransaction();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }

        public List<People> GetPeopleWithAddress()
        {
            var res = new List<People>();
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.GetPeopleWithAddress");
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        People people = new People
                        {
                            PeopleId = Convert.ToInt32(reader.GetValue(0)),
                            Name = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString(),
                            Phone = reader.GetValue(3).ToString()
                        };
                        people.SetAddresses(new Addresses()
                        {
                            Address = reader.GetValue(4).ToString()
                        });
                        res.Add(people);
                    }
                }
                
                DBContext.CommitTransaction();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }

        public int CreatePerson(People people)
        {
            int res = 0;
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.CreatePerson");
                AddStringParameter(sqlCommand, "name", people.Name);
                AddStringParameter(sqlCommand, "lastName", people.LastName);
                AddStringParameter(sqlCommand, "phone", people.Phone);

                res = (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }

        public int CreateAddresses(Addresses address)
        {
            int res = 0;
            try
            {
                DBContext.OpenConnection();
                // Commented for test
                var sqlCommand = DBContext.CreateStoredProcedureCommand("dbo.CreateAddress");
                AddStringParameter(sqlCommand, "personId", address.PersonId.ToString());
                AddStringParameter(sqlCommand, "address", address.Address);

                res = (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                DBContext.RollbackTransaction();
                throw e;
            }
            finally
            {
                DBContext.CloseConnection();
            }
            return res;
        }

    }
}
