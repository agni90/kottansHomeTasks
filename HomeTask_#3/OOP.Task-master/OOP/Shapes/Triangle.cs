using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
     //TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        readonly double _edge1;
        readonly double _edge2;
        readonly double _edge3;

        public Triangle(double edge1 , double edge2 , double edge3 ):
            this(new Dictionary<ParamKeys, object> {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, edge3},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];

        }
        public override string ShapeName => "Triangle";

        public override double GetPerimeter()
        {
            return (_edge1 + _edge2 + _edge3) * Multiplier;
        }

        protected override double Area()
        {
            var s = (_edge1 + _edge2 + _edge3) / 2;
            var A = Math.Sqrt(s*(s - _edge1)*(s - _edge2)*(s - _edge3));
            return A;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX = deltaX + CoordX;
            CoordY = deltaY + CoordY;
        }
    }
}