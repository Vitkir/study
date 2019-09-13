using DynamicArray;

namespace CycledDynamicArray
{
	class CycledDynamicArray<T> : DynamicArray<T>
	{
		public override bool MoveNext()
		{
			if (position < Capacity - 1)
			{
				position++;
				return true;
			}
			Reset();
			return true;
		}
	}
}
