using System;
using Autodesk.AutoCAD.Runtime;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LegalPlotter
{
    public class Legal
    {
        public string parcelName;
        public string legalDescription;
        public List<Dictionary<string, string>> legalList;
        public List<(double, double)> legalPoints;
        
        [CommandMethod("LEGALPLOTTER")]
        public void OpenForm()
        {
            LegalForm legalForm = new LegalForm(this);
            legalForm.Show();
        }

        // Called when you press submit on the form
        public void LegalPlotter()
        {
            Active.CreateLayer("Parcel " + parcelName);
            LegalParser();
            SegmentsToPoints();
            Active.DrawPolyline(legalPoints);
        }

        public void PrintLegal()
        {
            Active.Edit.WriteMessage("\n" + parcelName);
            Active.Edit.WriteMessage("\n" + legalDescription + "\n\n");

            foreach (Dictionary<string, string> segment in legalList)
            {
                Active.Edit.WriteMessage("\n" + segment["type"]);
                Active.Edit.WriteMessage("\n" + segment["vertical"]);
                Active.Edit.WriteMessage("\n" + segment["horizontal"]);
                Active.Edit.WriteMessage("\n" + segment["degrees"]);
                Active.Edit.WriteMessage("\n" + segment["minutes"]);
                Active.Edit.WriteMessage("\n" + segment["seconds"]);
                Active.Edit.WriteMessage("\n" + segment["distance"] + "\n\n");

            }

            Active.Edit.WriteMessage("\n");
        }

        public void LegalParser()
        {
            legalList = new List<Dictionary<string, string>>();
            
            foreach (Match match in Regex.Matches(legalDescription, @"\b(?<vertical>N|NORTH|S|SOUTH)\s{0,1}(?<degrees>\d*)\D(?<minutes>\d*)\D(?<seconds>\d*)\D\s{0,1}(?<horizontal>E|EAST|W|WEST)\b\D*(?<distance>\d*[.]\d*)\s*('|FT|FEET)"))
            {
                Dictionary<string, string> segment = new Dictionary<string, string>()
                {
                    { "type", "LINE" },
                    { "vertical", match.Groups["vertical"].Value },
                    { "horizontal", match.Groups["horizontal"].Value },
                    { "degrees", match.Groups["degrees"].Value },
                    { "minutes", match.Groups["minutes"].Value },
                    { "seconds", match.Groups["seconds"].Value },
                    { "distance", match.Groups["distance"].Value }
                };

                legalList.Add(segment);
            }
        }

        public void SegmentsToPoints()
        {
            (double, double) nextPoint = (0,0);
            (double, double) previousPoint = (0, 0);

            legalPoints = new List<(double, double)>();
            legalPoints.Add(nextPoint);

            foreach (Dictionary<string, string> segment in legalList)
            {
                if (segment["type"] == "LINE") 
                {
                    nextPoint = Calculate.CalculateLine(previousPoint, segment);
                }
                else if (segment["type"] == "CURVE")
                {
                    nextPoint = Calculate.CalculateCurve(previousPoint, segment);
                }

                legalPoints.Add(nextPoint);
                previousPoint = nextPoint;

            }
        }
    }
}
