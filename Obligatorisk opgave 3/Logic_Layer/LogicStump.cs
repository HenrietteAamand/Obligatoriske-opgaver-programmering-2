using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Data_Layer;

namespace Logic_Layer
{

    public class Logic
    {
        private IData dataObject;

        public Logic()
        {
            dataObject = new Database();

        }

        public bool checkLogin( String socSecNb, String pw )
        {
            return dataObject.isUserRegistered(socSecNb, pw);
        }

        public List<DTO_Weight> getWeightAndBMIData(string id)
        {
            List<DTO_Weight> returnListOfDTOs = dataObject.getWeightData(id);

            for (int i = 0; i < dataObject.getWeightData(id).Count; i++)
            {
                returnListOfDTOs[i].BMI_ = dataObject.getWeightData(id)[i].Weight_/Math.Pow((dataObject.getHeight(id) / 100.0), 2);
            }
           
            return returnListOfDTOs;
        }

        public List<DTO_BSugar> getBSugarData(string id)
        {
            return dataObject.getBSugarData(id);
        }

        public List<DTO_BPressure> getBPressureData(string id)
        {
            return dataObject.getBPressureData(id);
        }

    }
}