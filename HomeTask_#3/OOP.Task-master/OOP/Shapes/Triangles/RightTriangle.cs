using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        readonly double _edge1;
        readonly double _edge2;
        readonly double _hypotenuse;

        public RightTriangle(double edge1, double edge2, double hypotenuse) :
            this(new Dictionary<ParamKeys, object> {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, hypotenuse},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _hypotenuse = (double)parameters[ParamKeys.Edge3];

        }
        public override string ShapeName => "RightTriangle";

        public override double GetPerimeter()
        {
            return (_edge1 + _edge2 + _hypotenuse) * Multiplier;
        }

        protected override double Area()
        {
            return (0.5 * _edge1 * _edge2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX = deltaX + CoordX;
            CoordY = deltaY + CoordY;
        }
    }
}