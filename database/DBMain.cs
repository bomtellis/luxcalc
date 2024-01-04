using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using LightingCalculator.helpers;

namespace LightingCalculator.database
{
    public class DBMain
    {
        public SQLiteConnection sqlite_conn;
        public DBMain()
        {
            sqlite_conn = CreateConnection();
        }

        public double findUtilisationFactor(double ceiling, double wall, double floor, double RoomIndex)
        {
            System.Diagnostics.Debug.WriteLine("\n Ceiling Index: " + ceiling);
            System.Diagnostics.Debug.WriteLine("\n Wall Index: " + wall);
            System.Diagnostics.Debug.WriteLine("\n Floor Index: " + floor);
            System.Diagnostics.Debug.WriteLine("\n Room Index: " + RoomIndex);

            double output = 0;

            SQLiteConnection conn = CreateConnection();
            SQLiteDataReader dataReader;
            SQLiteCommand cmd = conn.CreateCommand();
            string CreateSql = "SELECT UTILISATION_FACTOR FROM CWF_LOOKUP " +
                                "JOIN RI_UF_LOOKUP ON CWF_LOOKUP.LOOKUP_KEY = RI_UF_LOOKUP.LOOKUP_KEY " +
                                "WHERE CEILING = " + ceiling.ToString() + " AND WALL = " + wall.ToString() + " AND FLOOR = " + floor.ToString() + " AND ROOM_INDEX = " + RoomIndex.ToString();
            System.Diagnostics.Debug.WriteLine("\n SQL String: " + CreateSql);
            cmd.CommandText = CreateSql;

            try
            {
                dataReader = cmd.ExecuteReader();
                dataReader.ReadAsync().Wait();
                System.Diagnostics.Debug.WriteLine("\n Data" + dataReader.GetValue(0));
                //return dataReader.GetDouble(0);
                output = double.Parse(dataReader.GetValue(0).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();  
            }

            return output;
            //SELECT UTILISATION_FACTOR FROM CWF_LOOKUP
            //JOIN RI_UF_LOOKUP ON CWF_LOOKUP.LOOKUP_KEY = RI_UF_LOOKUP.LOOKUP_KEY
            //WHERE CEILING = '0.7' AND WALL = '0.5' AND FLOOR = '0.2' AND ROOM_INDEX = '1.5'
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=lighting data.db; Version = 3; New = True; Compress = True; ");
           // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
           string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
           sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();

        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test Text ', 1); ";
           sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test1 Text1 ', 2); ";
           sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test2 Text2 ', 3); ";
           sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = "INSERT INTO SampleTable1 (Col1, Col2) VALUES('Test3 Text3 ', 3); ";
           sqlite_cmd.ExecuteNonQuery();

        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    
        public List<string> lightList() // get list of lights to listbox1
        {
            List<string> output = new List<string>();

            using (SQLiteConnection conn = CreateConnection())
            {
                SQLiteCommand sqlite_cmd = conn.CreateCommand();
                string sqlQuery = "SELECT ProductCode FROM Lights";
                SQLiteCommand cmd = sqlite_conn.CreateCommand();
                cmd.CommandText = sqlQuery;

                SQLiteDataReader dataReader = cmd.ExecuteReader();
                
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        Object myreader = dataReader.GetValue(0);
                        output.Add(myreader.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
            }

            return output;
        }

        public List<Light> lightAndLux(List<string> lights)
        {
            List<Light> output = new List<Light>();

            using (SQLiteConnection conn = CreateConnection())
            {
                string SQLString = "";

                for (int i = 0; i < lights.Count; i++)
                {
                    SQLString += "'" + lights[i] + "',";
                }

                SQLString = SQLString.Remove(SQLString.Length - 1);

                SQLiteCommand sqlite_cmd = conn.CreateCommand();
                string sqlQuery = "SELECT ProductCode, LumenOutput, Description, CircuitWattage FROM Lights WHERE ProductCode IN (" + SQLString + ")";
                Console.WriteLine("\n" + sqlQuery);
                SQLiteCommand cmd = sqlite_conn.CreateCommand();
                cmd.CommandText = sqlQuery;

                SQLiteDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        output.Add(new Light()
                        {
                            ProductCode = dataReader.GetString(0),
                            LumenOutput = dataReader.GetDouble(1),
                            LightDescription = dataReader.GetString(2),
                            CircuitWattage = dataReader.GetDouble(3)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
            }

            return output;
        }
    }
}
