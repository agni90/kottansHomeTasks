using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
        double _radius;

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

		public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius];
		}
		
		public override string ShapeName
		{
            get { return "Circle"; }
        }

		public override double GetPerimeter()
		{
		    return 2 * Multiplier * Math.PI*_radius;
		}


		protected override double Area()
		{
		    return Math.PI*_radius* _radius * Multiplier * Multiplier;
		}

		public override void Move(int deltaX, int deltaY)
		{
            var coordX = deltaX + CoordX;
            var coordY = deltaY + CoordY;

		}
	}
}