using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace LegalPlotter
{
    public static class Active
    {

        public static Document Doc => Application.DocumentManager.MdiActiveDocument;
        public static Editor Edit => Doc.Editor;
        public static Database DB => Doc.Database;

        public static void CreateLayer(string layerName)
        {
            using (Transaction Trans = Active.DB.TransactionManager.StartTransaction())
            {
                Doc.LockDocument();

                LayerTable LT = Trans.GetObject(DB.LayerTableId, OpenMode.ForRead) as LayerTable;

                if (!(LT.Has(layerName)))
                {
                    LayerTableRecord LTR = new LayerTableRecord
                    {
                        Name = layerName,
                        Color = Color.FromColorIndex(ColorMethod.ByAci, 4)
                    };

                    LT.UpgradeOpen();
                    LT.Add(LTR);
                    Trans.AddNewlyCreatedDBObject(LTR, true);
                }

                DB.Clayer = LT[layerName];
                Trans.Commit();
            }
        }

        public static void DrawPolyline(List<(double, double)> pointList )
        {
            try
            {
                using (Transaction Trans = DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //Edit.WriteMessage("\nDrawing Polyline!");

                    Point3d origin = SelectPoint("\nSelect starting point for parcel: ");
                    double originX = origin.X;
                    double originY = origin.Y;


                    Polyline polyLine = new Polyline();

                    int i = 0;
                    foreach ((double, double) point in pointList)
                    {
                        polyLine.AddVertexAt(i, new Point2d(originX + point.Item1, originY + point.Item2), 0, 0, 0);
                        i++;
                    }

                    polyLine.SetDatabaseDefaults();

                    BTR.AppendEntity(polyLine);
                    Trans.AddNewlyCreatedDBObject(polyLine, true);
                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Edit.WriteMessage("\nError encountered while drawing Polyine: " + ex.Message);
            }

        }

        public static Point3d SelectPoint(string prompt)
        {
            while (true)
            {
                try
                {
                    using (Transaction Trans = DB.TransactionManager.StartTransaction())
                    {
                        PromptPointOptions options = new PromptPointOptions(prompt);

                        PromptPointResult PPR = Edit.GetPoint(options);

                        return PPR.Value;
                    }
                }
                catch (System.Exception ex)
                {
                    Edit.WriteMessage("\nError while selecting a point: " + ex.Message);
                }
            }
        }


        public static void DrawLine(double x1, double y1, double x2, double y2)
        {
            try
            {
                using (Transaction Trans = DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //Edit.WriteMessage("\nDrawing Line!");

                    Point3d point1 = new Point3d(x1, y1, 0);
                    Point3d point2 = new Point3d(x2, y2, 0);
                    Line newLine = new Line(point1, point2);

                    BTR.AppendEntity(newLine);
                    Trans.AddNewlyCreatedDBObject(newLine, true);
                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Edit.WriteMessage("\nError encountered while drawing Line: " + ex.Message);
            }

        }

        public static void DrawText(string text, double x, double y)
        {
            try
            {
                using (Transaction Trans = DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //TextStyleTable TST;
                    //TST = Trans.GetObject(Active.DB.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                    //Edit.WriteMessage("\nDrawing MText!");

                    Point3d point = new Point3d(x, y, 0);
                    MText mText = new MText
                    {
                        Contents = text,
                        Location = point,
                        Attachment = AttachmentPoint.MiddleCenter,
                        TextHeight = 2.5,
                    };


                    BTR.AppendEntity(mText);
                    Trans.AddNewlyCreatedDBObject(mText, true);
                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Edit.WriteMessage("\nError encountered while drawing MText: " + ex.Message);
            }
        }

        public static void EraseAll()
        {
            try
            {
                using (Transaction Trans = DB.TransactionManager.StartTransaction())
                {
                    BlockTable BT;
                    BT = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord BTR;
                    BTR = Trans.GetObject(BT[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    //Active.Ed.WriteMessage("\nErasing All!");

                    PromptSelectionResult PSR = Active.Edit.SelectAll();

                    SelectionSet SS = PSR.Value;

                    foreach (SelectedObject SO in SS)
                    {
                        DBObject OB = Trans.GetObject(SO.ObjectId, OpenMode.ForWrite) as DBObject;
                        OB.Erase();
                    }

                    Trans.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Edit.WriteMessage("\nError encountered while erasing all: " + ex.Message);
            }
        }

    }

}
