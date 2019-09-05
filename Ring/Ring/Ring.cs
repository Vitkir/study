using System;

namespace GraphicEditorBlank
{
	class Ring
	{
		private GraphicEditorBlank.Round inner;
		private GraphicEditorBlank.Round outer;
		private double thickness;

		public GraphicEditorBlank.Round.Point Center { get; set; }

		public double Thickness
		{
			get => Outer.Radius - Inner.Radius;
			set
			{
				thickness = value;
				Outer.Radius = inner.Radius + thickness;
			}
		}

		public GraphicEditorBlank.Round Inner
		{
			get => inner;
			set
			{
				inner = value;
				Outer.Radius = inner.Radius + thickness;
			}
		}

		public GraphicEditorBlank.Round Outer
		{
			get => outer;
			set
			{
				outer = value;
				if (outer.Radius - thickness > 0)
				{
					Inner.Radius = outer.Radius - thickness;
				}
				else
				{
					throw new ArgumentException("Invalid outer radius value. The inner radius is less than or equal to zero.");
				}
			}
		}

		public double Area
		{
			get => Outer.Area - Inner.Area;
		}

		public double SumLength
		{
			get => Outer.Length + Inner.Length;
		}

		public Ring(GraphicEditorBlank.Round inner, GraphicEditorBlank.Round outer)
		{
			if (inner.Radius < outer.Radius)
			{
				Center = outer.Center = inner.Center;
				Inner = inner;
				Outer = outer;
			}
		}

		public override string OutputsToConsole()
		{
			return string.Format("Ring: Inner radius: {1}{0}" +
										"Outer radius{2}{0}" +
										"Thickness{3}{0}" +
										"Area{4}{0}" +
										"Sum inner and outer lengths",
										Environment.NewLine,
										Inner.Radius,
										Outer.Radius,
										Thickness,
										Area,
										SumLength);
		}
	}
}

