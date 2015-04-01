using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Joomiz.ReleaseCalendar.Models
{
    public class PeriodRepository
    {
        public List<Period> GetReleasePeriods(int year, string description)
        {
            using (SqlConnection connection = this.CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT A.StartDate, A.EndDate FROM Period A INNER JOIN Calendar B ON A.CalendarId = B.Id WHERE B.Name = @Name AND B.Year = @Year AND A.PeriodTypeId = 1";

                command.Parameters.AddWithValue("@Name", description);
                command.Parameters.AddWithValue("@Year", year);

                SqlDataReader reader = command.ExecuteReader();

                var list = ReadPeriods(reader);

                connection.Close();

                return list;
            }
        }

        public List<Period> GetFreezingPeriods(int year, string description)
        {
            using (SqlConnection connection = this.CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT A.StartDate, A.EndDate FROM Period A INNER JOIN Calendar B ON A.CalendarId = B.Id WHERE B.Name = @Name AND B.Year = @Year AND A.PeriodTypeId = 3";

                command.Parameters.AddWithValue("@Name", description);
                command.Parameters.AddWithValue("@Year", year);

                SqlDataReader reader = command.ExecuteReader();

                var list = ReadPeriods(reader);

                connection.Close();

                return list;
            }
        }

        public List<Period> GetInfrastructurePeriods(int year, string description)
        {
            using (SqlConnection connection = this.CreateConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT A.StartDate, A.EndDate FROM Period A INNER JOIN Calendar B ON A.CalendarId = B.Id WHERE B.Name = @Name AND B.Year = @Year AND A.PeriodTypeId = 2";

                command.Parameters.AddWithValue("@Name", description);
                command.Parameters.AddWithValue("@Year", year);

                SqlDataReader reader = command.ExecuteReader();

                var list = ReadPeriods(reader);

                connection.Close();

                return list;
            }
        }


        private List<Period> ReadPeriods(SqlDataReader reader)
        {
            var list = new List<Period>();

            while (reader.Read())
            {
                list.Add(new Period(reader.GetDateTime(0), reader.GetDateTime(1)));
            }

            return list;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["CalendarContext"].ConnectionString;
            return connection;
        }

        
    }
}