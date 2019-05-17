using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto.Interfaces.Inventories;
using Proyecto.Context;
using Proyecto.Models;
using Proyecto.Interfaces.SQLite;

namespace Proyecto.Services.Inventories
{
    class FicSrvInventariosList : IFicSrvInventariosList
    {
        private readonly FicDataBaseContext FicLoBDContext;
        public FicSrvInventariosList()
        {
            FicLoBDContext = new FicDataBaseContext(DependencyService.Get<IFicDataBasePathSQLite>().FicGetDataBasePath());
        }//constructor
        public async Task<IEnumerable<zt_cat_estatus>> FicMetGetEstatusList()
        {
            return await (from inv in FicLoBDContext.zt_cat_estatus select inv).AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<zt_inventarios>> FicMetGetListInventarios()
        {
            return await(from inv in FicLoBDContext.zt_inventarios select inv).AsNoTracking().ToArrayAsync();
        }
    }
}
