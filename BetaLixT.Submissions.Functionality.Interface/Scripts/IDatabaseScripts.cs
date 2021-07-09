using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Scripts
{
    public interface IDatabaseScripts
    {
        /// <summary>
        /// Used to ensure that the underlying database is
        /// correctly configured and initialized
        /// </summary>
        public void Initialize();
    }
}
