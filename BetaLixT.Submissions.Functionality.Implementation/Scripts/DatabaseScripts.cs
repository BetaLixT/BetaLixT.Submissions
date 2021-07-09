using BetaLixT.Submissions.Functionality.Implementation.Context;
using BetaLixT.Submissions.Functionality.Interface.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Implementation.Scripts
{
    public class DatabaseScripts : IDatabaseScripts
    {
        private readonly DatabaseContext _databaseContext;
        public DatabaseScripts (DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public void Initialize()
        {
            this._databaseContext.Database.EnsureCreated();
        }
    }
}
