using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarryPotter.Games.Core.Forces;

namespace HarryPotter.Games.Core
{
    public class NeutreForce : Force
    {
        #region Constructors
        public NeutreForce() : base("Force Neutre")
        {
            this.Id = 3;
        }
        #endregion
    }
}
