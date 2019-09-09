using System.Collections.Generic;
using System.Linq;

namespace DynamicArray
{
	class DynamicArray
	{
		public dynamic[] Array { get; set; }

		public DynamicArray()
		{
			Array = new dynamic[8];
		}

		public DynamicArray(int capacity)
		{
			Array = new dynamic[capacity];
		}

		public DynamicArray(IEnumerable<dynamic> collection)
		{
			dynamic[] array = new dynamic[collection.Count()];
			int index = 0;
			foreach (var item in collection)
			{
				array[index] = item;
				index++;
			}
		}
	}
}
