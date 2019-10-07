using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
    public interface IFilterSource
    {
        TypedValue[] GetFilter();
    }
}