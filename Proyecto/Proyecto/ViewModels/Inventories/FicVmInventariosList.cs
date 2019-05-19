using Proyecto.Interfaces.Inventories;
using Proyecto.Interfaces.Navigation;
using Proyecto.Models;
//using Proyecto.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Proyecto.ViewModels.Inventaries
{
    class FicVmInventariosList: INotifyPropertyChanged
    {
        public List<zt_inventarios> _FicSfDataGrid_ItemSource_Inventario, _FicSfDataGrid_ItemSource_InventarioTotal;
        public zt_inventarios _FicSfDataGrid_SelectItem_Inventario;
        private ICommand _FicMetAddConteoICommand, _FicMetAcumuladosICommand, _FicMetDetalleICommand;
        private List<zt_cat_estatus> _FicSourceAutoCompleteEstatus;
        private IFicServiceNavigation IFicSrvNavigationlnventario;
        private IFicSrvInventariosList IFicSrvinventarioslist;
        private zt_cat_estatus _IdEstatus;
        public List<zt_inventarios> FicSfDataGrid_ItemSource_Inventario { get { return _FicSfDataGrid_ItemSource_Inventario; } }
        public List<zt_inventarios> FicSfDataGrid_ItemSource_InventarioTotal { get { return _FicSfDataGrid_ItemSource_InventarioTotal; } }
        public List<zt_cat_estatus> FicSourceAutoCompleteEstatus { get { return _FicSourceAutoCompleteEstatus; } }
        public zt_inventarios FicSfDataGrid_SelectItem_Inventario
        {
            get { return _FicSfDataGrid_SelectItem_Inventario; }
            set
            {
                if (value != null)
                {
                    FicSfDataGrid_SelectItem_Inventario = value;
                    RaisePropertyChanged();
                }
            }
        }
        public zt_cat_estatus IdEstatus
        {
            get { return _IdEstatus; }
            set
            {
                if (value != null)
                {
                    _IdEstatus = value; RaisePropertyChanged("IdEstatus");
                }
            }
        }

        public FicVmInventariosList(IFicServiceNavigation IFicSrvNavigationInventario, IFicSrvInventariosList IFicSrvInventariosList)
        {
            this.IFicSrvNavigationlnventario = IFicSrvNavigationInventario;
            this.IFicSrvinventarioslist = IFicSrvInventariosList;
            _FicSfDataGrid_ItemSource_Inventario = new List<zt_inventarios>(); _FicSfDataGrid_ItemSource_InventarioTotal = new List<zt_inventarios>();
        }//CONSTRUCTOR 

        public ICommand FicMetAddConteoICommand { get { return _FicMetAddConteoICommand = _FicMetAddConteoICommand ?? new FicViewModelExecuteCommands(FicMetAddConteo); } }
        private async void FicMetAddConteo()
        {
            if (_FicSfDataGrid_SelectItem_Inventario != null)
            {
                object[] temp = { _FicSfDataGrid_SelectItem_Inventario, null }; IFicSrvNavigationlnventario.FicMetNavigateTo<FicVmInventarioConteoList>(temp);
            }
            else await Ap.Current.MainPage.DisplayAlert("Alerta", "Seleccione un item", "OK");
        }

        public ICommand FicMetAcumuladosICommand { get { return _FicMetAcumuladosICommand = _FicMetAcumuladosICommand ?? new FicViewModelExecuteCommands(FicMetAcomulados); } }
        private async void FicMetAcomulados()
        {
            if (_FicSfDataGrid_SelectItem_Inventario != null) IFicSrvNavigationlnventario.FicMetNavigateTo<FicVmInventarioAcumuladoList>(_FicSfDataGrid_SelectItem_Inventario);
            else await App.Current.MainPage.DisplayAlert("Alerta", "Seleccione un item", "OK");
        }

        public ICommand FicMetDetalleICommand { get { return _FicMetDetalleICommand = _FicMetDetalleICommand ?? new FicViewModelExecuteCommands(FicMetDetalle); } }
        private async void FicMetDetalle()
        {
            if (_FicSfDataGrid_SelectItem_Inventario != null) IFicSrvNavigationlnventario.FicMetNavigateTo<FicVmInventariosDetail>(_FicSfDataGrid_SelectItem_Inventario);
            else await App.Current.MainPage.DisplayAlert("Alerta", "Seleccione un item", "OK");
        }

        public async void FicEstatus(bool encontro)
        {
            try
            {
                if (FicSourceAutoCompleteEstatus != null && FicSourceAutoCompleteEstatus.Count() > 0)
                {
                    _FicSfDataGrid_ItemSource_Inventario.Clear();
                    foreach (zt_inventarios inv in _FicSfDataGrid_ItemSource_InventarioTotal)
                    {
                        if (IdEstatus.DesEstatus == "Todos" && encontro == true)
                        {
                            _FicSfDataGrid_ItemSource_Inventario = FicSfDataGrid_ItemSource_InventarioTotal.ToList();
                        }
                        if (IdEstatus.DesEstatus == "En Proceso" && encontro == true)
                        {
                            if (inv.IdEstatus != "1" && inv.IdEstatus != "6")
                            {
                                _FicSfDataGrid_ItemSource_Inventario.Add(inv);
                            }
                        }
                        if (IdEstatus.DesEstatus != "En Proceso" && IdEstatus.DesEstatus != "Todos")
                        {
                            if (inv.IdEstatus == IdEstatus.IdEstatus && encontro == true)
                            {
                                _FicSfDataGrid_ItemSource_Inventario.Add(inv);
                            }
                        }
                    }
                    RaisePropertyChanged("FicSfDataGrid_ItemSource_Inventario");
                }
            }
            catch (Exception e) { }
        }

        public async Task FicMetloadInfoEstatus(String Estatus)
        {
            bool encontro = false;
            try
            {
                if (FicSourceAutoCompleteEstatus != null && FicSourceAutoCompleteEstatus.Count() > 0)
                {
                    foreach (zt_cat_estatus est in FicSourceAutoCompleteEstatus)
                    {
                        if (est.DesEstatus.ToLower() == Estatus.ToLower()) { _IdEstatus = est; encontro = true; }
                        else { if (encontro == false) { /*_IdEstatus = new zt_cat_estatus(); _IdEstatus.DesEstatus = "";*/ } }
                    }
                    //if(encontro == false) { _IdEstatus = (from e in FicSourceAutoCompleteEstatus where e.IdEstatus == "20" select e).ToList()[0];  
                }
            }
            catch (Exception e) { }
            FicEstatus(encontro);
        }

        public async void OnAppearing()
        {
            try
            {
                _FicSourceAutoCompleteEstatus = new List<zt_cat_estatus>();
                _FicSfDataGrid_ItemSource_Inventario = new List<zt_inventarios>();
                _FicSfDataGrid_ItemSource_InventarioTotal = new List<zt_inventarios>();
                _FicSourceAutoCompleteEstatus = await IFicSrvinventarioslist.FicMetGetEstatusList() as List<zt_cat_estatus>;
                var todos = new zt_cat_estatus() { IdEstatus = "20", DesEstatus = "Todos", FechaReg = DateTime.Today, UsuarioReg = "System" };
                var proceso = new zt_cat_estatus() { IdEstatus = "19", DesEstatus = "En Proceso", FechaReg = DateTime.Today, UsuarioReg = "System" };
                _IdEstatus = proceso;
                _FicSourceAutoCompleteEstatus.Add(todos);
                _FicSourceAutoCompleteEstatus.Add(proceso); RaisePropertyChanged("FicSourceAutoCompleteEstatus");
                var source_local_inv = await IFicSrvinventarioslist.FicMetGetListInventarios();
                if (source_local_inv != null)
                {
                    _FicSfDataGrid_ItemSource_Inventario.Clear();
                    _FicSfDataGrid_ItemSource_InventarioTotal.Clear();
                    foreach (zt_inventarios inv in source_local_inv)
                    {
                        _FicSfDataGrid_ItemSource_Inventario.Add(inv);
                        _FicSfDataGrid_ItemSource_InventarioTotal.Add(inv);
                    }
                }//LLENAR EL GRID 
                RaisePropertyChanged("IdEstatus");
                RaisePropertyChanged("FicSfDataGrid_ItemSource_InventarioTotal");
                RaisePropertyChanged("FicSfDataGrid_ItemSource_Inventario");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRE CARGA AL METODO OnAppearing() DE LA VIEW 

        #region INotifyPropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
