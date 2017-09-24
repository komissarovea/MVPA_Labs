using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lab7.DAL
{
    public class CarActiveRecord
    {
        #region Properties

        public int Id { get; set; }

        public string Firm { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public int MaxSpeed { get; set; }

        #endregion

        public static IEnumerable<CarActiveRecord> GetAll(string connectionString)
        {
            //List<CarActiveRecord> list = new List<CarActiveRecord>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Cars", sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        CarActiveRecord customer = new CarActiveRecord()
                        {
                            Id = sqlDataReader.GetInt32(0),
                            Firm = sqlDataReader.GetString(1),
                            Make = sqlDataReader.GetString(2),
                            Year = sqlDataReader.GetInt32(3),
                            Price = sqlDataReader.GetInt32(4),
                            MaxSpeed = sqlDataReader.GetInt32(5),
                        };
                        yield return customer;
                        //list.Add(customer);
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            //return list;
        }

        public void Add(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Cars (Firm, Make, Year, Price, MaxSpeed) VALUES (@Firm,@Make,@Year,@Price,@MaxSpeed)", sqlConnection))
            {
                insertCommand.Parameters.Add(new SqlParameter("@Firm", typeof(string))).Value = Firm;
                insertCommand.Parameters.Add(new SqlParameter("@Make", typeof(string))).Value = Make;
                insertCommand.Parameters.Add(new SqlParameter("@Year", typeof(string))).Value = Year;
                insertCommand.Parameters.Add(new SqlParameter("@Price", typeof(string))).Value = Price;
                insertCommand.Parameters.Add(new SqlParameter("@MaxSpeed", typeof(string))).Value = MaxSpeed;
                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
