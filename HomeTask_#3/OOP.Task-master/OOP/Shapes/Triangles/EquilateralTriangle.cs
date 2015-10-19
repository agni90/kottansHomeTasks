using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        private readonly double _edge;

        public EquilateralTriangle(double edge):
            this (new Dictionary < ParamKeys, object > {
                { ParamKeys.Edge1, edge},
                { ParamKeys.CoordX, 0},
                { ParamKeys.CoordY, 0}
        })
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge = (double)parameters[ParamKeys.Edge1];


        }
        public override string ShapeName => "EquilateralTriangle";

        public override double GetPerimeter()
        {
            return (_edge * 3) * Multiplier;
        }

        protected override double Area()
        {
           return (Math.Sqrt(3) / 4 * _edge * _edge);
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX = deltaX + CoordX;
            CoordY = deltaY + CoordY;
        }
    }
}