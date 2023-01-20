using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotter.Games.Core.Forces;

namespace HarryPotter.Games.Core
{
    public class ObscureForce : Force
    {
        #region Constructors
        public ObscureForce() : base("Force Obscure")
        {
            this.Id = 2;
        }
        #endregion
    }
}
