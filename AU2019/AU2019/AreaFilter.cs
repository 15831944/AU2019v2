using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
    public class AreaFilter : IFilterSource
{
    public TypedValue[] GetFilter()
    {
        TypedValue[] filter = new TypedValue[5];
        filter.SetValue(new TypedValue((int)DxfCode.Operator, "<OR"), 0);
        filter.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 1);
        filter.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 2);
        filter.SetValue(new TypedValue((int)DxfCode.Start, "REGION"), 3);
        filter.SetValue(new TypedValue((int)DxfCode.Operator, "OR>"), 4);

        return filter;
    }
}
}
