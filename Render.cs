using UnityEngine;

namespace Ironcast.Trainer
{
	public static class Render
	{
		private static GUIStyle _stringStyle = null;

		private static GUIStyle StringStyle
		{
			get
			{
				// delay initialize stringStyle to be sure we are called under OnGui
				return _stringStyle = _stringStyle ?? new GUIStyle(GUI.skin.label);
			}
		}

		public static Color Color
		{
			get { return GUI.color; }
			set { GUI.color = value; }
		}

		public static Vector2 DrawString(Vector2 position, string label, Color color, bool centered = true)
		{
			Color = color;
			return DrawString(position, label, centered);
		}

		public static void GetContentAndSize(string label, out GUIContent content, out Vector2 size)
		{
			content = new GUIContent(label);
			size = StringStyle.CalcSize(content);
		}

		public static Vector2 DrawString(Vector2 position, string label, bool centered = true)
		{
			GetContentAndSize(label, out var content, out var size);
			var upperLeft = centered ? position - size / 2f : position;
			GUI.Label(new Rect(upperLeft.x, upperLeft.y, size.x, size.y), content);
			return size;
		}
	}
}
