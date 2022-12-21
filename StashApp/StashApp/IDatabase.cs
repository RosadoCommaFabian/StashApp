using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace StashApp
{
    public interface IDatabase
    {
        SQLiteConnection ConnectToDB();
    }
}
