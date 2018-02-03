using System;
using MenuParser.Exceptions;
using MenuParser.Models;

namespace MenuParser
{
	/// <summary>
	/// Prints <see cref="Menu"/> objects to the <see cref="Console"/>
	/// highlighting matching paths.
	/// </summary>
	internal static class MenuPrinter
	{
		internal static void Print(Menu menu, string pathToMatch, int indentCount = 0)
		{
			foreach (var item in menu.Items)
			{
				PrintItem(item, pathToMatch, indentCount);
			}
		}

		private static void PrintItem(Item item, string pathToMatch, int indentCount = 0)
		{
			const string active = " ACTIVE";
			AssertValidItem(item);
			var spaces = new string('\t', indentCount);
			var activeStatus = IsActive(item, pathToMatch) ? active : string.Empty;
			Console.WriteLine($"{spaces}{item.DisplayName}, {item.Path.Value}{activeStatus}");
			if (item.SubMenu != null)
			{
				Print(item.SubMenu, pathToMatch, indentCount + 2);
			}
		}

		private static bool IsActive(Item item, string pathToMatch)
		{
			if (item.Path.Value == pathToMatch) return true;

			if (item.SubMenu == null) return false;
			foreach (var subItem in item.SubMenu.Items)
			{
				if (IsActive(subItem, pathToMatch)) return true;
			}

			return false;
		}

		private static void AssertValidItem(Item item)
		{
			if (string.IsNullOrEmpty(item.DisplayName) || string.IsNullOrEmpty(item.Path?.Value))
			{
				throw new InvalidMenuException();
			}
		}
	}
}
