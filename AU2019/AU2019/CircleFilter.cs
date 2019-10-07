using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
    public class CircleFilter : IFilterSource
    {
        public TypedValue[] GetFilter()
        {
            TypedValue[] filter = new TypedValue[1];
            filter.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 0);

            return filter;
        }
    }
}
