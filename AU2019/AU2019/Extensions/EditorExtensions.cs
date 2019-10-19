using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019.Extensions
{
    //public static class EditorExtensions
    //{
    //    public static PromptSelectionResult SelectAllUsingFilterSource(this Editor ed, IFilterSource filterSource)
    //    {
    //        var selectionFilter = GetSelectionFilterFrom(filterSource);

    //        return ed.SelectAll(selectionFilter);
    //    }

    //    public static PromptSelectionResult SelectCrossingWindowUsingFilterSource(this Editor ed, IFilterSource filterSource)
    //    {
    //        var selectionFilter = GetSelectionFilterFrom(filterSource);

    //        var startPoint = ed.GetPoint("\nSelect first point: ").Value;
    //        var endPoint = ed.GetCorner("\nSelect second point: ", startPoint).Value;

    //        return ed.SelectCrossingWindow(startPoint, endPoint, selectionFilter);
    //    }

    //    private static SelectionFilter GetSelectionFilterFrom(IFilterSource filterSource)
    //    {
    //        return new SelectionFilter(filterSource.GetFilter());
    //    }
    //}

}
