using System;
namespace ShaftesApp
{
    public class C
    {
        public static int X_MID, Y_MID, X_MAX, Y_MAX, MOX = 0, MOY = 0;

        //how far to move everything over when bars thingy is tapped (make 1/3 of screen width)
        public static int X_BAR_INSET = 200;

        public C(ViewController v)
        {
            X_MAX = v.ViewWidth / 2;
            X_MID = v.ViewWidth / 4;
            Y_MAX = v.ViewHeight / 2;
            Y_MID = v.ViewHeight / 4;
        }
    }
}
