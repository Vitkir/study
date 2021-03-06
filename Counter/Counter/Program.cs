﻿using System;
using System.Collections.Generic;

namespace Counter
{
	class Program
	{
		static void Main()
		{
			var list = new List<int>(10);
			FillList(list);
			Print(list);
			DeleteEverySecond(list);
			Console.ReadKey();
		}

		private static void FillList(List<int> list)
		{
			for (int i = 1; i <= list.Capacity; i++)
			{
				list.Add(i);
			}
		}

		static void DeleteEverySecond(List<int> list)
		{
			while (list.Count > 1)
			{
				for (int i = 1; i < list.Count; i++)
				{
					list.RemoveAt(i);
				}
				Print(list);
			}
		}

		static void Print(List<int> list)
		{
			Console.WriteLine("List:");
			foreach (var item in list)
			{
				Console.WriteLine(item.ToString());
			}
		}
	}
}
