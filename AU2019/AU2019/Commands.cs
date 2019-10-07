using AU2019.Autocad;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
    public class Commands
    {
        [CommandMethod("SUMAREASSTART")]
        public void SumAreasStart()
        {
            TypedValue[] filters = new TypedValue[5];
            filters.SetValue(new TypedValue((int)DxfCode.Operator, "<OR"), 0);
            filters.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 1);
            filters.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 2);
            filters.SetValue(new TypedValue((int)DxfCode.Start, "REGION"), 3);
            filters.SetValue(new TypedValue((int)DxfCode.Operator, "OR>"), 4);
            var selectionFilter = new SelectionFilter(filters);

            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
        var ed = doc.Editor;
        var selectionResult = ed.SelectAll(selectionFilter);
        if (selectionResult.Status != PromptStatus.OK)
        {
            ed.WriteMessage("\nUser cancelled, or no valid objects found.");
            return;
        }
        var selection = selectionResult.Value;

            double area = 0;
            double perimeter = 0;
            int cnt = 0;
            using (var tr = db.TransactionManager.StartTransaction())
            {
                foreach (SelectedObject ssObj in selection)
                {
                    Entity ent = (Entity)tr.GetObject(ssObj.ObjectId, OpenMode.ForRead);
                    switch (ent)
                    {
                        case Circle c:
                            area += c.Area;
                            perimeter += 2 * Math.PI * c.Radius;
                            cnt++;
                            break;
                        case Polyline p:
                            if (p.Closed)
                            {
                                area += p.Area;
                                perimeter += p.Length;
                                cnt++;
                            }
                            break;
                        case Region r:
                            area += r.Area;
                            perimeter += r.Perimeter;
                            cnt++;
                            break;
                        default:
                            break;
                    }
                }
                var message = $"\nFound {cnt} objects" +
                    $"\nSum of areas: {area}" +
                    $"\nSum of perimiters: {perimeter}";

                ed.WriteMessage(message);
            }

        }

    [CommandMethod("SUMAREASREFACTORED")]
    public void SumAreasRefactored()
    {
        var filterSource = new AreaFilter();
        SumAreas(ed => ed.SelectAllByIFilterSource(filterSource));
    }

    [CommandMethod("SUMAREASCIRCLES")]
    public void SumCircleAreas()
    {
        var filterSource = new CircleFilter();
        SumAreas(ed => ed.SelectAllByIFilterSource(filterSource));
    }

    [CommandMethod("SUMAREASCIRCLESWINDOW")]
    public void SumCircleAreasWindow()
    {
        var filterSource = new CircleFilter();
        SumAreas(ed => ed.SelectByPickCrossingWindow(filterSource));
    }

    private void SumAreas(Func<Editor, PromptSelectionResult> selectionTechnique)
    {
        var ed = Active.Editor;
        var selectionResult = selectionTechnique(ed);
        if (selectionResult.Status != PromptStatus.OK)
        {
            ed.WriteMessage("\nUser cancelled, or no valid objects found.");
            return;
        }

        var selection = selectionResult.Value;
        var areaObjects = new List<IAreaObject>();
        Active.UsingTransaction(tr =>
        {
            foreach (SelectedObject ssObj in selection)
            {
                Entity ent = (Entity)tr.GetObject(ssObj.ObjectId, OpenMode.ForRead);
                var areaObject = ent.ToAreaObject();
                if (areaObject != null)
                    areaObjects.Add(areaObject);
            }
        });

        var calculator = new AreaCalculator();
        calculator.Update(areaObjects);
        var message = $"\nFound {calculator.Count} objects" +
            $"\nSum of areas: {calculator.Area}" +
            $"\nSum of perimiters: {calculator.Perimeter}";

        ed.WriteMessage(message);
    }
    }
}
