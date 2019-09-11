using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
	class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
	{
		T[] array;
		private int position = -1;

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
				if (position <= -1 || position >= Capacity)
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

		public void Add(T value)
		{
			if (Length == Capacity)
			{
				IncreaseArray();
			}
			array[Length] = value;
			Length++;
		}

		public void AddRange(IEnumerable<T> collection)
		{
			int capacity = Capacity;
			int exponent = 1;
			while (capacity < Length + CountCollection(collection))
			{
				capacity *= 2;
				exponent++;
			}
			IncreaseArray(exponent);
			position += Length;
			foreach (var item in collection)
			{
				MoveNext();
				array[position] = item;
			}
			Reset();
		}

		public bool Insert(int index, T value)
		{
			if (index < 0 || index >= Capacity)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (Length == Capacity)
			{
				IncreaseArray();
			}
			for (int i = Length - 1; i > index; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = value;
			return true;
		}

		public bool Remove(int index)
		{
			if (index < 0 || index > Length - 1)
			{
				return false;
			}
			for (int i = index; i < Length - 1; i++)
			{
				array[i] = array[i + 1];
			}
			array[Length - 1] = default;
			Length -= 1;
			return true;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)array).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)array).GetEnumerator();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if (position < Capacity - 1)
			{
				position++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			position = -1;
		}

		private int CountCollection(IEnumerable<T> collection)
		{
			int count = 0;
			foreach (var item in collection)
			{
				count++;
			}
			return count;
		}

		private void IncreaseArray()
		{
			var newCapacity = Capacity * 2;
			var newArray = new T[newCapacity];
			ChangeArray(newArray, 0);
		}

		private void IncreaseArray(int exponent)
		{
			var newCapacity = array.Length * (int)Math.Pow(2, exponent);
			var newArray = new T[newCapacity];
			ChangeArray(newArray, 0);
		}

		private int ChangeArray(T[] newArray, int index)
		{
			foreach (var item in array)
			{
				newArray[index] = array[index];
				index++;
			}
			array = newArray;
			return index;
		}
	}
}
