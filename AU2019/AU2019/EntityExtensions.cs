using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019
{
public static class EntityExtensions
{
    public static IAreaObject ToAreaObject(this Entity ent)
    {
        switch (ent)
        {
            case Circle c:
                return new CircleAdapter(c);
            case Polyline p:
                if (p.Closed)
                {
                    return new PolylineAdapter(p);
                }
                break;
            case Region r:
                return new RegionAdapter(r);
            default:
                break;
        }

        return null;
    }
}
}
