using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
    public static class EditorExtensions
    {
        public static PromptSelectionResult SelectAllByIFilterSource(this Editor ed, IFilterSource filterSource)
        {
            var filter = filterSource.GetFilter();
            var selectionFilter = new SelectionFilter(filter);

            return ed.SelectAll(selectionFilter);
        }

        public static PromptSelectionResult SelectByPickCrossingWindow(this Editor ed, IFilterSource filterSource)
        {
            var filter = filterSource.GetFilter();
            var selectionFilter = new SelectionFilter(filter);

            var startPoint = ed.GetPoint("\nSelect first point: ").Value;
            var endPoint = ed.GetCorner("\nSelect second point: ", startPoint).Value;

            return ed.SelectCrossingWindow(startPoint, endPoint, selectionFilter);
        }
    }
}
