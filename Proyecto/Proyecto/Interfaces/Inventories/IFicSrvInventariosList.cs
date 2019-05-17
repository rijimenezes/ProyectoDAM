using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;
namespace Proyecto.Interfaces.Inventories
{
    interface IFicSrvInventariosList
    {
        Task<IEnumerable<zt_inventarios>> FicMetGetListInventarios();
        Task<IEnumerable<zt_cat_estatus>> FicMetGetEstatusList();

    }
}
