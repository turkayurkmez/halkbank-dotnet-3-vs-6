using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOfCsharp
{
    public struct Point
    {
        public int X { get; init; } = 0;
        public int Y { get; init; } = default(int);

        public Point()
        {
            X = default(int);
            Y = default(int);
        }
    }

    public record struct Address(string Street, string City, string PostalCode, string Country);
}
