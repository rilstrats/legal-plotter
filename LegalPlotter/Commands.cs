using Autodesk.AutoCAD.Runtime;

namespace LegalPlotter
{
    public static class Commands
    {

        [CommandMethod("LEGALPLOTTER")]
        public static void LegalPlotter()
        {
            Active.CreateLayer("Parcels");

            (double, double)[] points = {
                (0, 0), 
                (10, 0), 
                (10, 10), 
                (0, 10), 
                (0,0)
            };

            Active.DrawPolyline(points);
        }

    }
}
