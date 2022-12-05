using System;
using System.Diagnostics.Contracts;

namespace Day2
{
	public class Play
	{
		#region Enums

		public enum NameType
		{
			Rock = 1,
			Paper = 2,
			Scissors = 3
		}

		#endregion

		#region Constructors

		public Play(string value)
		{
			GuideValue = value;
		}

		#endregion

		#region Properties

		public int PointValue => (int)Name;

		private string GuideValue { get; }

		public NameType Name => GetName();

		#endregion

		#region Public Methods

		#region Comparison Operator Overrides

		public static bool operator <(Play p1, Play p2)
		{
			if (p1.Name == NameType.Rock && p2.Name == NameType.Scissors)
			{
				return false;
			}
			else if (p1.Name == NameType.Scissors && p2.Name == NameType.Rock)
			{
				return true;
			}
			else
			{
				return p1.Name < p2.Name;
			}
		}

		public static bool operator >(Play p1, Play p2)
		{
			if (p1.Name == NameType.Rock && p2.Name == NameType.Scissors)
			{
				return true;
			}
			else if (p1.Name == NameType.Scissors && p2.Name == NameType.Rock)
			{
				return false;
			}
			else
			{
				return p1.Name > p2.Name;
			}
		}

		public static bool operator ==(Play p1, Play p2)
		{
			return p1.Name == p2.Name;
		}

		public static bool operator !=(Play p1, Play p2)
		{
			return p1.Name != p2.Name;
		}

		#endregion

		#endregion

		#region Private Methods

		private NameType GetName()
		{
			NameType name;
			switch (GuideValue)
			{
				case "A":
				case "X":
					name = NameType.Rock; break;
				case "B":
				case "Y":
					name = NameType.Paper; break;
				case "C":
				case "Z":
					name = NameType.Scissors; break;
				default:
					throw new NotImplementedException();
			}

			return name;
		}

		#endregion
	}
}
