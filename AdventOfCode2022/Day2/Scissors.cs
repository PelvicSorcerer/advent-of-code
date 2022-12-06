using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Scissors : Play
    {
        #region Constructors

        public Scissors()
        {
            Name = NameType.Scissors;
        }

        #endregion

        #region Public Methods

        public override Type Beats()
        {
            return typeof(Paper);
        }

        public override Type BeatenBy()
        {
            return typeof(Rock);
        }

        #endregion
    }
}
