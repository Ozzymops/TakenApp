using System;
using System.Collections.Generic;
using System.Text;

namespace TakenApp.Interfaces
{
    public interface iSql
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
