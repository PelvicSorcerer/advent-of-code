using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Rock : Play
    {
		#region Constructors

		public Rock()
		{
            Name = NameType.Rock;
		}

        #endregion

        #region Public Methods

        public override Type Beats()
        {
            return typeof(Scissors);
        }

        public override Type BeatenBy()
        {
            return typeof(Paper);
        }

        #endregion
    }
}
