using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
	class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
	{
		T[] array;
		int position = -1;

		public T this[int i]
		{
			get => array[i];
			set => array[i] = value;
		}

		public int Length { get; set; }

		public int Capacity => array.Length;

		public T Current
		{
			get
			{
				if (position == -1 || position >= Capacity)
					throw new InvalidOperationException();
				return array[position];
			}
		}

		object IEnumerator.Current => throw new NotImplementedException();

		public DynamicArray()
		{
			array = new T[8];
		}

		public DynamicArray(int capacity)
		{
			array = new T[capacity];
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
			var capacity = CountCollection(collection);
			Length = capacity;
			array = new T[capacity];
			int i = 0;
			foreach (var item in collection)
			{
				array[i] = item;
				i++;
			}
		}

		public void Add(T input)
		{
			if (Length == Capacity)
			{
				IncreaseArray();
			}
			array[Length] = input;
			Length++;
		}

		public void IncreaseArray()
		{
			var newCapacity = Capacity * 2;
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
			int capacity = Capacity;
			int exponent = 1;
			while (capacity < Length + CountCollection(collection))
			{
				capacity = capacity * 2;
				exponent++;
			}
			IncreaseArray(exponent);
			foreach (var item in collection)
			{
				array[Length - 1] = item;
				Length++;
			}
		}

		//public bool Remove(int index)
		//{
		//	for (int i = 0; index < Length - 1; i++)
		//	{
		//		array[index] = array[index + 1];
		//		index++;
		//	}
		//	array[index] = default;
		//}

		public IEnumerator<T> GetEnumerator()
		{

		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			position++;
			return (position < Capacity);
		}

		public void Reset()
		{
			position = -1;
		}
	}
}
