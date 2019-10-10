using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
public class AreaCalculator : IAreaCalculator
{
    IEnumerable<IAreaObject> _objects;

    public double Area => _objects != null ? _objects.Sum(obj => obj.Area) : 0;
    public double Perimeter => _objects != null ? _objects.Sum(obj => obj.Perimeter) : 0;
    public int Count => _objects != null ? _objects.Count() : 0;

    public void Update(IEnumerable<IAreaObject> objects)
    {
        _objects = objects;
    }
}
}
