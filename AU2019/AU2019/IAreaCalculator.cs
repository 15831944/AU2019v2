using System.Collections.Generic;

namespace AU2019
{
public interface IAreaCalculator
{
    double Area { get; }
    int Count { get; }
    double Perimeter { get; }

    void Update(IEnumerable<IAreaObject> objects);
}
}