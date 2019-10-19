using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
    public class AreaObjectSummarizer
    {
        //IAreaCalculator _calculator;
        //IFilterSource _filterSource;
        //public AreaObjectSummarizer(IFilterSource filterSource, IAreaCalculator calculator)
        //{
        //    _filterSource = filterSource;
        //    _calculator = calculator;
        //}

        //public void Summarize(Func<Editor, IFilterSource, PromptSelectionResult> selectionTechnique)
        public void Summarize()
        {
            TypedValue[] filters = new TypedValue[5];
            filters.SetValue(new TypedValue((int)DxfCode.Operator, "<OR"), 0);
            filters.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 1);
            filters.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 2);
            filters.SetValue(new TypedValue((int)DxfCode.Start, "REGION"), 3);
            filters.SetValue(new TypedValue((int)DxfCode.Operator, "OR>"), 4);
            var selectionFilter = new SelectionFilter(filters);
            //IFilterSource filterSource = new AreaFilter();
            //var selectionFilter = new SelectionFilter(filterSource.GetFilters());

            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
            //var ed = Active.Editor;
            var selectionResult = ed.SelectAll(selectionFilter);
            //var selectionResult = selectionTechnique(ed, filterSource);
            if (selectionResult.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\nUser cancelled, or no valid objects found.");
                return;
            }
            var selection = selectionResult.Value;

            double area = 0;
            double perimeter = 0;
            int cnt = 0;
            //IList<IAreaObject> areaObjects = new List<IAreaObject>();
            //Active.UsingTransaction(tr =>
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
                    //IAreaObject areaObject = ent.ToAreaObject();
                    //if (areaObject != null)
                    //    areaObjects.Add(areaObject);
                }

                //IAreaCalculator calculator = new AreaCalculator();
                //calculator.Update(areaObjects);

                var message = $"\nFound {cnt} objects" +
                    $"\nSum of areas: {area}" +
                    $"\nSum of perimiters: {perimeter}";

                ed.WriteMessage(message);
            }
        }
    }
}
