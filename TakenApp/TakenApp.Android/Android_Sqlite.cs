using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TakenApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Android_Sqlite))]

namespace TakenApp.Droid
{
    public class Android_Sqlite : Interfaces.iSql
    {
        public SQLite.SQLiteConnection DbConnection()
        {
            var dbName = "taskDatabase.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            return new SQLite.SQLiteConnection(path);
        }
    }
}