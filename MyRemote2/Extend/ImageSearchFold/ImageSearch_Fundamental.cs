using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2.Extend.ImageSearchFold
{
    public static class ImageSearch_Fundamental
    {
        private static string scriptname = "ImageSearch_Fundamental";
        /*
        public static Color getColorFromPoint(ImageFile img, Point point)
        {
            Color color = Color.Aqua;
            return color;
        }*/

        public static class AboutColor
        {
            public static bool PerfectSame(Color A, Color B)
            {
                if (A == B)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// 완전히 똑같은 것 제외
            /// threshold가 클수록 안 비슷해도 비슷하다고 판별
            /// 30 정도면 비슷함
            /// </summary>
            /// <param name="A"></param>
            /// <param name="B"></param>
            /// <returns></returns>
            public static bool Near_ExceptSame(Color BaseColor, Color TargetColor, int threshold)
            {
                if (PerfectSame(BaseColor, TargetColor))
                {
                    return false;
                }
                return Near_ContainSame(BaseColor, TargetColor, threshold);

            }

            /// <summary>
            /// 완전히 똑같은 것 포함
            /// threshold가 클수록 안 비슷해도 비슷하다고 판별
            /// 30 정도면 비슷함
            /// </summary>
            /// <param name="A"></param>
            /// <param name="B"></param>
            /// <returns></returns>
            public static bool Near_ContainSame(Color BaseColor, Color TargetColor, int threshold)
            {

                // 색상 차이 계산을 위해 RGB 값을 가져옵니다.
                int redDiff = Math.Abs(BaseColor.R - TargetColor.R);
                int greenDiff = Math.Abs(BaseColor.G - TargetColor.G);
                int blueDiff = Math.Abs(BaseColor.B - TargetColor.B);


                // 색상 차이가 임계값보다 작으면 비슷한 색으로 판별합니다.
                if (redDiff <= threshold && greenDiff <= threshold && blueDiff <= threshold)
                {
                    // 비슷한 색깔일 때의 처리를 수행합니다.
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }

        public static Bitmap NearRedPixelSearchImage(Bitmap image_)
        {
            Bitmap image = (Bitmap)image_.Clone();
            Bitmap result = new Bitmap(image.Width, image.Height);

            //int grayValue = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    Color NearRedColor = Color.FromArgb(143, 92, 91);

                    // 색상 차이 계산을 위해 RGB 값을 가져옵니다.
                    int redDiff = Math.Abs(pixel.R - NearRedColor.R);
                    int greenDiff = Math.Abs(pixel.G - NearRedColor.G);
                    int blueDiff = Math.Abs(pixel.B - NearRedColor.B);

                    // 색상 차이의 임계값을 설정합니다.
                    int threshold = 30; // 적절한 임계값을 선택하세요.

                    // 색상 차이가 임계값보다 작으면 비슷한 색으로 판별합니다.
                    if (redDiff <= threshold && greenDiff <= threshold && blueDiff <= threshold)
                    {
                        // 비슷한 색깔일 때의 처리를 수행합니다.
                        result.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.White);
                    }




                }
            }

            return result;
        }
        /// <summary>
        /// threshold 색상의 임계값. 높을수록 안 비슷한 색깔도 Near하다고 판단
        /// </summary>
        /// <param name="image_"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static Dictionary<Point, Color> NearColorPixelSearchImage_GetDictionary(Bitmap image_, int threshold, Color targetColor)
        {
            Bitmap image = (Bitmap)image_.Clone();
            //Bitmap result = new Bitmap(image.Width, image.Height);
            Dictionary<Point, Color> result = new Dictionary<Point, Color>();

            //int grayValue = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);

                    // 색상 차이 계산을 위해 RGB 값을 가져옵니다.
                    int redDiff = Math.Abs(pixel.R - targetColor.R);
                    int greenDiff = Math.Abs(pixel.G - targetColor.G);
                    int blueDiff = Math.Abs(pixel.B - targetColor.B);



                    // 색상 차이가 임계값보다 작으면 비슷한 색으로 판별합니다.
                    if (redDiff <= threshold && greenDiff <= threshold && blueDiff <= threshold)
                    {
                        // 비슷한 색깔일 때의 처리를 수행합니다.
                        //result.SetPixel(x, y, Color.Black);
                        UTIL.CollectCon.Dict.Set_IfNotExistAdd(
                            result, new Point(x, y), targetColor);
                    }
                    else
                    {
                        //result.SetPixel(x, y, Color.White);
                    }




                }
            }

            return result;
        }


        public static bool NearIsBlack(Bitmap image, Point point)
        {
            bool result = false;

            int x = point.X;
            int y = point.Y;

            int threshold = 2;//

            for (int X = x - threshold; X < x + threshold; X++)
            {
                for (int Y = y - threshold; Y < y + threshold; Y++)
                {
                    bool ThisDotImageOut = false;

                    if (X >= image.Width || X < 0)
                    {
                        ThisDotImageOut = true;
                    }
                    if (Y >= image.Height || Y < 0)
                    {
                        ThisDotImageOut = true;
                    }

                    if (!ThisDotImageOut)
                    {

                        //Console.WriteLine($"x,y:({x},{y})");

                        if (image.GetPixel(X, Y).ToArgb() == Color.Black.ToArgb())
                        {
                            //Console.WriteLine($"x,y:({x},{y})");
                            result = true;
                        }
                    }
                }
            }



            return result;


        }
    }
}
