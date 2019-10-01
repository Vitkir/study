using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
	class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>, ICloneable
	{
		T[] array;
		protected int position = -1;
		private int capacity;

		public T this[int i]
		{
			get => array[i];
			set => array[i] = value;
		}

		public int Length { get; set; }

		public int Capacity
		{
			get => capacity;
			set
			{
				if (value < 1)
				{
					throw new ArgumentException();
				}
				capacity = value;
			}
		}

		public T Current
		{
			get
			{
				if (position > -1 && position < Length)
				{
					return array[position];
				}
				else if (position < 0 && position >= -Length)
				{
					return array[Length + position];
				}
				throw new IndexOutOfRangeException();
			}
		}

		object IEnumerator.Current => Current;

		public DynamicArray()
		{
			Capacity = 8;
			array = new T[Capacity];
		}

		public DynamicArray(int capacity)
		{
			array = new T[capacity];
			Capacity = capacity;
		}

		public DynamicArray(IEnumerable<T> collection)
		{
			Capacity = CountCollection(collection);
			Length = Capacity;
			array = new T[Capacity];
			int index = 0;
			foreach (var item in collection)
			{
				array[index] = item;
				index++;
			}
		}

		public DynamicArray(DynamicArray<T> array)
		{
			this.array = new T[array.Capacity];
			Capacity = array.Capacity;
			Length = Capacity;
		}

		public void Add(T value)
		{
			if (Length == Capacity)
			{
				ChangeArray();
			}
			array[Length] = value;
			Length++;
		}

		public void AddRange(IEnumerable<T> collection)
		{
			int capacity = Capacity;
			int exponent = 0;
			int newLength = Length + CountCollection(collection);
			if (capacity < newLength)
			{
				while (capacity < newLength)
				{
					capacity *= 2;
					exponent++;
				}
				ChangeArray(exponent);
			}
			foreach (var item in collection)
			{
				Add(item);
			}
		}

		public void ChangeCapacity(int newCapacity)
		{
			var newArray = new T[newCapacity];
			if (newCapacity > Capacity)
				IncreaseArray(newArray);
			ReduceArray(newArray);
		}

		public Array ToArray()
		{
			return array;
		}

		public bool Insert(int index, T value)
		{
			if (index < 0 || index >= Capacity)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (Length == Capacity)
			{
				ChangeArray();
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
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
		}

		public virtual bool MoveNext()
		{
			if (position < Length - 1)
			{
				position++;
				return true;
			}
			Reset();
			return false;
		}

		public void Reset()
		{
			position = -1;
		}

		public object Clone()
		{
			DynamicArray<T> arrayClone = new DynamicArray<T>(array);
			return arrayClone;
		}

		private void ChangeArray()
		{
			var newCapacity = Capacity * 2;
			var newArray = new T[newCapacity];
			IncreaseArray(newArray);
		}

		private void ChangeArray(int exponent)
		{
			var newCapacity = array.Length * (int)Math.Pow(2, exponent);
			var newArray = new T[newCapacity];
			IncreaseArray(newArray);
		}

		private int IncreaseArray(T[] newArray)
		{
			var index = 0;
			foreach (var item in array)
			{
				newArray[index] = array[index];
				index++;
			}
			array = newArray;
			Capacity = array.Length;
			return index;
		}

		private int ReduceArray(T[] newArray)
		{
			var index = 0;
			foreach (var item in newArray)
			{
				newArray[index] = array[index];
				index++;
			}
			array = newArray;
			Capacity = array.Length;
			return index;
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
	}
}
