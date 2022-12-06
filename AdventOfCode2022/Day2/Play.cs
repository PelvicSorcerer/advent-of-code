using System;
using System.Diagnostics.Contracts;

namespace Day2
{
	public abstract class Play
	{
		#region Enums

		public enum NameType
		{
			Rock = 1,
			Paper = 2,
			Scissors = 3
		}

        #endregion

		#region Properties

		public int PointValue => (int)Name;
		public NameType Name { get; protected set; }

		#endregion

		#region Public Methods

		public static Play GetPlay(string value)
        {
			var type = GetName(value);

			switch (type)
            {
				case NameType.Rock:
					return new Rock();
				case NameType.Paper:
					return new Paper();
				case NameType.Scissors:
                    return new Scissors();
				default:
					throw new NotImplementedException();
            }
        }

		public abstract Type Beats();

		public abstract Type BeatenBy();

		#endregion

		#region Private Methods

		private static NameType GetName(string guideValue)
		{
			NameType name;
			switch (guideValue)
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
