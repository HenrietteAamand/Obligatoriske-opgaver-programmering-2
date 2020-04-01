using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Data_Layer
{
    public interface IData
    {
        bool isUserRegistered(String socSecNb, String pw);

        int getHeight(String socSecNb);

        List<DTO_Weight> getWeightData(String socSecNb);

        List<DTO_BSugar> getBSugarData(String socSecNb);

        List<DTO_BPressure> getBPressureData(String socSecNb);
    }
}
