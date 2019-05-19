using Proyecto.Interfaces.Navigation;
using Proyecto.ViewModels.Inventaries;
//using Proyecto.ViewModels.Security;
//using Proyecto.ViewModels.Structure;
using Proyecto.Views.Inventories;
//using Proyecto.Views.Security;
//using Proyecto.Views.Structure;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Proyecto.Services.Navigation
{
    class FicServicesNavigation : IFicServiceNavigation
    { //Here is the view before your viewmodel, for the answer of navigation
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
             {typeof(FicViewModelLogin), typeof(FicViewLogin)},
             {typeof(FicViewModelMasterDetailPageMaster), typeof(FicMasterDetailPageMaster) },
             {typeof(FicViewModelMasterDetailPage), typeof(FicMasterDetailPage)},
             {typeof(FicVmInventariosList),typeof(FicViInventariosList) },
             {typeof(FicVmInventarioConteoList),typeof(FicViInventarioConteoList) },
             {typeof(FicVmInventarioConteosItem),typeof(FicViInventarioConteosItem) },
             {typeof(FicVmInventarioAcumuladoList),typeof(FicViInventarioAcumuladoList) },
             {typeof(FicVmImportarWebApi), typeof(FicViImportarWebApi)},
             { typeof(FicVmExportarWebApi), typeof(FicViExportarWebApi)},
             {typeof(FicViewModelRegistry), typeof(FicViewRegistry) },
             {typeof(FicViewModelRestartPassword), typeof(FicViewRestartPassword) },

             {typeof(FicVmInventariosDetail), typeof(FicViInventariosDetail) },
             {typeof(FicVmInventarioAcumuladoDetail), typeof(FicViInventarioAcumuladoDetail)},
             {typeof(FicVmInventarioConteoDetail), typeof(FicViInventarioConteoDetail) } ,
        };

        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;
            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }
        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;
            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }
        public void FicMetNavigateBack()
        {
            var mdp = Application.Current.MainPage as MasterDetailPage; mdp.Detail.Navigation.PopAsync();
            // Application.Current.MainPage.Navigation.PopAsync(true); 
        }

    }
}
