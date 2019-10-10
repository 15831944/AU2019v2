using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
public class PolylineAdapter : AreaObjectAdapterBase<Polyline>
{
    public PolylineAdapter(Polyline polyline) : base(polyline)
    { }
    public override double Area => _entity.Area;
    public override double Perimeter => _entity.Length;
}

public class PolylineAdapter : IAreaObject
{
    private Polyline _entity;

    public PolylineAdapter(Polyline entity)
    {
        _entity = entity;
    }

    public double Area => _entity.Area;

    public double Perimeter => _entity.Length;
}

}
