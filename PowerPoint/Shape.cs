using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface Shape
    {
        // Area
        double GetArea();

        // GetLength
        double GetLength();

        // Coordinates
        double[] GetCoordinates();
    }
}
