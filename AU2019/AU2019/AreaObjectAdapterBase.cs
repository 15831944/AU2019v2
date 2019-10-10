using Autodesk.AutoCAD.DatabaseServices;

namespace AU2019
{
public abstract class AreaObjectAdapterBase<T> : IAreaObject
    where T : Entity
{
    protected T _entity;
    public AreaObjectAdapterBase(T entity)
    {
        _entity = entity;
    }

    public abstract double Area { get; }
    public abstract double Perimeter { get; }
}
}
