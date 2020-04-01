using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DTO;

namespace Data_Layer
{
    public class DataFile : IData
    {
        private FileStream input;
        private StreamReader reader;

        public DataFile()
        {

        }

        public bool isUserRegistered(String socSecNb, String pw)
        {
            bool isRegistered = false;
            String inputRecord;
            String[] inputFields;       

            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb && inputFields[1] == pw)
                {
                    isRegistered = true;
                    break;
                }
            }

            input.Close();

            return isRegistered;
        }

        public int getHeight(String socSecNb)
        {
            int height = 0;
            String inputRecord;
            String[] inputFields;

            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    height = Convert.ToInt32(inputFields[2]);
                    break;
                }
            }

            input.Close();
            return height;
        }

        public List<DTO_Weight> getWeightData(String socSecNb)
        {
            //double BMI;
            List<DTO_Weight> weightList = new List<DTO_Weight>();

            String inputRecord;
            String[] inputFields;

            input = new FileStream("Weight Data.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    //BMI = getHeight(socSecNb) / (Math.Pow(Convert.ToDouble(inputFields[1]), 2));
                    weightList.Add(new DTO_Weight(Convert.ToDouble(inputFields[1]), 0, Convert.ToDateTime(inputFields[2])));
                }
            }

            input.Close();

            return weightList;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            List<DTO_BSugar> BSList = new List<DTO_BSugar>();

            String inputRecord;
            String[] inputFields;

            input = new FileStream("Blood Sugar Data.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    BSList.Add(new DTO_BSugar(Convert.ToDouble(inputFields[1]), Convert.ToDateTime(inputFields[2])));
                }
            }

            input.Close();

            return BSList;

        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            List<DTO_BPressure> BPList = new List<DTO_BPressure>();

            String inputRecord;
            String[] inputFields;

            input = new FileStream("Blood Pressure Data.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    BPList.Add(new DTO_BPressure(Convert.ToInt32(inputFields[1]), Convert.ToInt32(inputFields[2]), Convert.ToDateTime(inputFields[3])));
                }
            }

            input.Close();

            return BPList;
        }



    }
}
