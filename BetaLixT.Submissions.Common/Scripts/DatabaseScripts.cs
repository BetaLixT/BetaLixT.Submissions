using BetaLixT.Submissions.Common.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Scripts
{
    public class DatabaseScripts
    {
        private readonly DatabaseContext _databaseContext;
        public DatabaseScripts(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public void Initialize()
        {
            this._databaseContext.Database.EnsureCreated();
        }
    }
}
