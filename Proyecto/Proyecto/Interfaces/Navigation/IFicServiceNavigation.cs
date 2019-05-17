using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Interfaces.Navigation
{
    interface IFicServiceNavigation
    {
        void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null);
        void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null);
        void FicMetNavigateBack();
    }
}
