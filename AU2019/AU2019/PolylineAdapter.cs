using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
    public class PolylineAdapter : AreaObjectAdapterBase<Polyline>
    {
        public PolylineAdapter(Polyline polyline) : base(polyline)
        {
        }
        public override double Area => _entity.Area;
        public override double Perimeter => _entity.Length;
    }
}
