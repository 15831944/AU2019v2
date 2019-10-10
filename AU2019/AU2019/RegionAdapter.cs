using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
public class RegionAdapter : AreaObjectAdapterBase<Region>
{
    public RegionAdapter(Region region) : base(region)
    { }
    public override double Area => _entity.Area;
    public override double Perimeter => _entity.Perimeter;
}
}
