using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotter.Games.Core.Forces;

namespace HarryPotter.Games.Core
{
    public class LumineuseForce : Force
    {
        #region Constructors
        public LumineuseForce() : base("Force Lumineuse")
        {
            this.Id = 1;
        }
        #endregion
    }
}
