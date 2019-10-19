using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019.AreaAdapters
{
    public interface IAreaObject
    {
        double Area { get; }
        double Perimeter { get; }
    }

    //public class CircleAdapter : IAreaObject
    //{
    //    private Circle _entity;

    //    public CircleAdapter(Circle entity)
    //    {
    //        _entity = entity;
    //    }

    //    public double Area => _entity.Area;

    //    public double Perimeter => _entity.Circumference;
    //}

    //public class PolylineAdapter : IAreaObject
    //{
    //    private Polyline _entity;
    //    public PolylineAdapter(Polyline entity)
    //    {
    //        _entity = entity;
    //    }
    //    public double Area => _entity.Area;
    //    public double Perimeter => _entity.Length;
    //}
}
