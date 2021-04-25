using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase;

namespace MovieDatabase
{
    public class data
    {
        private static OleDbConnection dbConnection;
        private static OleDbCommand dbCommand;
        private static OleDbDataReader dataReader;

        private static string conn;
        public static void SetConnectionString(string connection)
        {
            conn = connection;
        }

        private int id;
        private string movieName;
        private int movieDuration;
        private DateTime movieTime;
        private string movieDetail;
        private int moviePrice;

        public string MovieName { get => movieName; set => movieName = value; }
        public int MovieDuration { get => movieDuration; set => movieDuration = value; }
        public DateTime MovieTime { get => movieTime; set => movieTime = value; }
        public string MovieDetail { get => movieDetail; set => movieDetail = value; }
        public int MoviePrice { get => moviePrice; set => moviePrice = value; }


        public data(int id, string movieName, int movieDuration, DateTime movieTime, int moviePrice, string movieDetail)
        {
            this.id = id;
            MovieName = movieName;
            MovieDuration = movieDuration;
            MovieTime = movieTime;
            MoviePrice = moviePrice;
            MovieDetail = movieDetail;
        }

        public static data[] Read()
        {
            string querystring = "SELECT Movie.* FROM Movie";
            string error = string.Empty;
            dbConnection = new OleDbConnection(conn);
            dbCommand = new OleDbCommand(querystring, dbConnection);

            List<data> Movies = new List<data>();

            try
            {
                dbConnection.Open();
                dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    data movie = new data(Convert.ToInt32(dataReader[0]), dataReader[1].ToString(), Convert.ToInt32(dataReader[2]), Convert.ToDateTime(dataReader[3]), Convert.ToInt32(dataReader[4]), dataReader[5].ToString());
                    Movies.Add(movie);
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            return Movies.ToArray();
        }

        public int Create()
        {
            return 0;
        }

        public int Update(int id)
        {
            return 0;
        }
        public int Delete(int id)
        {
            return 0;
        }
    }
}
