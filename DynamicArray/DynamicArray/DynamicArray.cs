using System;
using System.Collections.Generic;

namespace DynamicArray
{
	class DynamicArray<T>
	{
		T[] array;
		int count;

		public DynamicArray()
		{
			array = new T[8];
			count = 0;
		}

		public DynamicArray(int capacity)
		{
			array = new T[capacity];
			count = 0;
		}

		static int CountCollection(IEnumerable<T> collection)
		{
			int count = 0;
			foreach (var item in collection)
			{
				count++;
			}
			return count;
		}

		public DynamicArray(IEnumerable<T> collection)
		{
			count = CountCollection(collection);
			array = new T[count];
			int index = 0;
			foreach (var item in collection)
			{
				array[index] = item;
				index++;
			}
		}

		public void Add(T input)
		{
			if (count == array.Length - 1)
			{
				IncreaseArray();
			}
			array[count] = input;
			count++;
		}

		public void IncreaseArray()
		{
			var newCapacity = array.Length * 2;
			var newArray = new T[newCapacity];
			int index = 0;
			foreach (var item in array)
			{
				array[index] = newArray[index];
				index++;
			}
			array = newArray;
		}

		public void IncreaseArray(int exponent)
		{
			var newCapacity = array.Length * (int)Math.Pow(2, exponent);
			var newArray = new T[newCapacity];
			int index = 0;
			foreach (var item in array)
			{
				array[index] = newArray[index];
				index++;
			}
			array = newArray;
		}

		public void AddRange(IEnumerable<T> collection)
		{
			int capacity = array.Length - 1;
			int exponent = 1;
			while (capacity < count + CountCollection(collection))
			{
				capacity = capacity * 2;
				exponent++;
			}
			IncreaseArray(exponent);
			foreach (var item in collection)
			{
				array[count] = item;
				count++;
			}
		}

		public bool Remove(int index)
		{
			if (index > array.Length - 1)
			{
				result = false;
			}
			for (int i = 0; index + 1 == count; i++)
			{

			}
		}
	}
}
