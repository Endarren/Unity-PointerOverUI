//<author>Nicholas Irwin</author>
//<company> nonPareil Institute</company>
//<copyright file ="PointerOverUI.cs" All Rights Reserved
//</copyright>
//<date>1/20/2018</date>

namespace npScripts.UI
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.EventSystems;

	/// <summary>
	/// This script is used to keep track of all the UI panel types the mouse cursor is over.  This can be used to prevent certain actions from happening, like firing a gun, when the mouse is clicked.
	/// </summary>
	[AddComponentMenu("NonPareil/UI/Pointer Over UI", 70)]
	public class PointerOverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		#region Fields

		/// <summary>
		/// The overlap types this UI panel involves.
		/// </summary>
		[Tooltip("The overlap types this UI panel involves.")]
		public string [] overlapType = new string [0];

		/// <summary>
		/// Stores the number of overlaps for each type.
		/// </summary>
		private static Dictionary<string, int> overlapList = new Dictionary<string, int>();

		#endregion

		#region Methods

		/// <summary>
		/// Checks if the cursor is over a certain overlap type.
		/// </summary>
		/// <param name="s">The <see cref="string"/></param>
		/// <returns>The <see cref="bool"/></returns>
		public static bool IsPointerOverType(string s)
		{
			if (!overlapList.ContainsKey(s))
			{
				return false;
			}
			return overlapList [s] != 0;
		}

		/// <summary>
		/// The mouse pointer has entered this UI element.
		/// </summary>
		/// <param name="eventData">The <see cref="PointerEventData"/></param>
		public void OnPointerEnter(PointerEventData eventData)
		{
			for (int i = 0; i < overlapType.Length; i++)
			{

				if (!overlapList.ContainsKey(overlapType [i]))
				{
					overlapList.Add(overlapType [i], 0);
				}
				overlapList [overlapType [i]] += 1;
			}
		}

		/// <summary>
		/// The mouse pointer has moved off this UI element.
		/// </summary>
		/// <param name="eventData">The <see cref="PointerEventData"/></param>
		public void OnPointerExit(PointerEventData eventData)
		{
			for (int i = 0; i < overlapType.Length; i++)
			{
				if (!overlapList.ContainsKey(overlapType [i]))
				{
					overlapList.Add(overlapType [i], 0);
				}
				else
				{
					overlapList [overlapType [i]] -= 1;
				}
			}
		}

		#endregion
	}
}
