using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Proyecto.UWP.SQLite;
using Proyecto.Interfaces.SQLite;
using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency(typeof(FicDataBasePathSQLiteUWP))]
namespace Proyecto.UWP.SQLite
{
    class FicDataBasePathSQLiteUWP : IFicDataBasePathSQLite
    {
        public string FicGetDataBasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, FicAppSettings.FicDataBaseName);
        }
    }
}
