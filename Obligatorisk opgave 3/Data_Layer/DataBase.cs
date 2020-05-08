using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace Data_Layer
{
    public class Database : IData
    {
        private SqlConnection conn;
        private SqlDataReader reader;
        private SqlCommand command;
        private const String db = "F20ST2ITS2201905063";

        public Database()
        {
            conn = new SqlConnection($"Data Source=st-i4dab.uni.au.dk;Initial Catalog={db};User ID={db};Password={db} ;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public bool isUserRegistered(String socSecNb, String pw) 
        {

            bool isRegistered = false;
            String sosec;
            command = new SqlCommand($"SELECT SoSec, pin FROM RegUsers WHERE SoSec = '{socSecNb}' AND pin = '{pw}'", conn);
            conn.Open();
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isRegistered = true;
                    sosec = (String)reader["SoSec"];
                }
            }
            catch(SqlException e)
            {
            }
            
            conn.Close();

            return isRegistered;
        }

        public int getHeight(String socSecNb)
        {
            int height = 0;
            command = new SqlCommand($"SELECT height FROM RegUsers WHERE SoSec = '{socSecNb}'", conn);
            conn.Open();
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    height = (int)(reader["height"]);
                }
            }
            catch(SqlException e)
            {
            }

            conn.Close();

            return height;
        }

        public List<DTO_Weight> getWeightData(String socSecNb)
        {
            List<DTO_Weight> weightList = new List<DTO_Weight>();
            double vægt;
            DateTime dato;

            command = new SqlCommand($"SELECT Weight, Date FROM WeightData WHERE SoSec = '{socSecNb}'", conn);
            conn.Open();
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    weightList.Add(new DTO_Weight(Math.Round(Convert.ToDouble(reader["Weight"]),1),0,(DateTime)(reader["Date"])));
                }
            }
            catch (SqlException e)
            {
            }

            conn.Close();
            return weightList;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {

            List<DTO_BSugar> BSList = new List<DTO_BSugar>();
            command = new SqlCommand($"SELECT Bloodsugar, Date FROM BSData WHERE SoSec = '{socSecNb}'", conn);
            conn.Open();
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BSList.Add(new DTO_BSugar(Math.Round(Convert.ToDouble(reader["Bloodsugar"]),1), (DateTime)(reader["Date"])));
                }
            }
            catch (SqlException e)
            {
            }

            conn.Close();

            return BSList;
        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            
            List<DTO_BPressure> BPList = new List<DTO_BPressure>();
            int Diastole;
            int systole;
            DateTime dato;

            command = new SqlCommand($"SELECT systolic, diastolic, Date FROM BPData WHERE SoSec = '{socSecNb}'", conn);
            conn.Open();
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    systole = Convert.ToInt32(reader["systolic"]);
                    Diastole = Convert.ToInt32(reader["diastolic"]);
                    dato = (DateTime)(reader["Date"]);
                    BPList.Add(new DTO_BPressure(Convert.ToInt32(reader["Systolic"]), Convert.ToInt32(reader["Diastolic"]),(DateTime)(reader["Date"])));
                }
            }
            catch (SqlException e)
            {
            }

            conn.Close();
            return BPList;
        }


    }
}
