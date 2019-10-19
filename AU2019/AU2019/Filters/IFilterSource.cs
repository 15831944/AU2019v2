using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019.Filters
{
    public interface IFilterSource
    {
        TypedValue[] GetFilter();
    }

    //public class AreaFilter : IFilterSource
    //{
    //    public TypedValue[] GetFilter()
    //    {
    //        TypedValue[] filter = new TypedValue[5];
    //        filter.SetValue(new TypedValue((int)DxfCode.Operator, "<OR"), 0);
    //        filter.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 1);
    //        filter.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 2);
    //        filter.SetValue(new TypedValue((int)DxfCode.Start, "REGION"), 3);
    //        filter.SetValue(new TypedValue((int)DxfCode.Operator, "OR>"), 4);

    //        return filter;
    //    }
    //}
    //public class CircleFilter : IFilterSource
    //{
    //    public TypedValue[] GetFilter()
    //    {
    //        TypedValue[] filter = new TypedValue[1];
    //        filter.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 0);

    //        return filter;
    //    }
    //}

}
