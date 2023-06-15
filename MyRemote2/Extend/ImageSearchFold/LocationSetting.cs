using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2.Extend.ImageSearchFold
{
    public static class LocationSetting
    {
        public static int StartX;
        public static int StartY;
        public static int EndX;
        public static int EndY;

        public static Step currentStep;
        public enum Step
        {
            None,
            StartPointSetting,
            EndPointSetting
        }

        public static void LocationPointSettingStart()
        {
            currentStep = Step.StartPointSetting;
        }

        public static void LocationPointSetting_StartPoint()
        {
            var point = WindowRobotFold.WorkFold.MouseWork.GetMouseCurrentPosition();

            StartX = (int)point.X;
            StartY = (int)point.Y;
        }
        public static void LocationPointSetting_EndPoint()
        {
            var point = WindowRobotFold.WorkFold.MouseWork.GetMouseCurrentPosition();

            EndX = (int)point.X;
            EndY = (int)point.Y;
        }




    }
}
