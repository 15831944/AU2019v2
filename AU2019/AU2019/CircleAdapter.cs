using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
public class CircleAdapter : AreaObjectAdapterBase<Circle>
{
    public CircleAdapter(Circle circle) : base(circle)
    {
    }

    public override double Area => _entity.Area;
    public override double Perimeter => _entity.Circumference;
}

public class CircleAdapter : IAreaObject
{
    private Circle _entity;

    public CircleAdapter(Circle entity)
    {
        _entity = entity;
    }

    public double Area => _entity.Area;

    public double Perimeter => _entity.Circumference;
}
}
