using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
public class AreaCalculator
{
    public double Area => _objects != null ? _objects.Sum(obj => obj.Area) : 0;
    public double Perimeter => _objects != null ? _objects.Sum(obj => obj.Perimeter) : 0;
    public int Count => _objects != null ? _objects.Count() : 0;

    IEnumerable<IAreaObject> _objects;

    public void Update(IEnumerable<IAreaObject> objects)
    {
        _objects = objects;
    }
}
}
