using System;

namespace Graphics
{
	public class Round : Circle
	{
		protected override string FigureName => "Round";
		public double Area
		{
			get => Math.PI * Radius * Radius;
		}

		public override string OutputsToConsole()
		{
			return string.Format("{1}{0}Area: {2}.",
								Environment.NewLine,
								base.OutputsToConsole(),
								Area.ToString());
		}
	}
}
