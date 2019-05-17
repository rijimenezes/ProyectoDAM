using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using System.IO;
using Proyecto.iOS.SQLite;
using Proyecto.Interfaces.SQLite;
using Xamarin.Forms;
[assembly: Dependency(typeof(FicDataBasePathSQLiteIOS))]
namespace Proyecto.iOS.SQLite
{
    public class FicDataBasePathSQLiteIOS : IFicDataBasePathSQLite
    {
        public string FicGetDataBasePath()
        {
            string libFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..","Library","Databases");
            if (!Directory.Exists(libFolder)) Directory.CreateDirectory(libFolder);
            return Path.Combine(libFolder, FicAppSettings.FicDataBaseName);
        }
    }
}