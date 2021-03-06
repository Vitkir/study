﻿using System;

namespace Graphics
{
	public class Ring : IPrintable
	{
		public Round Inner { get; set; }

		public Round Outer { get; set; }

		public double Area
		{
			get => Outer.Area - Inner.Area;
		}

		public double SumLength
		{
			get => Outer.Length + Inner.Length;
		}

		public Ring(Round inner, double radius)
		{
			if (inner.Radius >= Outer.Radius)
			{
				throw new ArgumentException("Outer radius must be greater inner radius.");
			}

			Inner = inner;
			Outer = new Round(inner.Center, radius);
		}

		public string Printable()
		{
			return string.Format("Ring:{0}Coordinates of center [x,y]:" +
								"Inner radius: {3}{0}" +
								"Outer radius: {4}{0}" +
								"Area: {5}{0}" +
								"Sum inner and outer lengths: {6}",
								Environment.NewLine,
								Inner.Center.X.ToString(),
								Inner.Center.Y.ToString(),
								Inner.Radius.ToString(),
								Outer.Radius.ToString(),
								Area.ToString(),
								SumLength.ToString());
		}
	}
}

