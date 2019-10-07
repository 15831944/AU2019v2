using AU2019.Autocad;
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
        private IFilterSource _filterSource;

        public AreaObjectSummarizer(IFilterSource filterSource)
        {
            _filterSource = filterSource;
        }
        public void Summarize(Func<Editor, IFilterSource, PromptSelectionResult> selectionTechnique)
        {
            var ed = Active.Editor;
            var selectionResult = selectionTechnique(ed, _filterSource);
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
