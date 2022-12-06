using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Paper : Play
    {
        #region Constructors

        public Paper()
        {
            Name = NameType.Paper;
        }

        #endregion

        #region Public Methods

        public override Type Beats()
        {
            return typeof(Rock);
        }

        public override Type BeatenBy()
        {
            return typeof(Scissors);
        }

        #endregion
    }
}
