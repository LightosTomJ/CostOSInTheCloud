using Microsoft.AspNetCore.Components;

namespace UI
{
    public class HelperService
    {
        private NavigationManager _navigationManager;
        public HelperService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void ChangePage(string uri)
        {
            _navigationManager.NavigateTo(uri);
        }
        public void ChangePage(string uri, bool force)
        {
            _navigationManager.NavigateTo(uri, force);
        }
    }
}
