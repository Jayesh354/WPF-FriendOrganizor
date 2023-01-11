using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FriendOrganizorApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        
        public MainViewModel(INavigationViewModel navigationViewModel,IFriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IFriendDetailViewModel FriendDetailViewModel { get;}

        public async Task LoadAsync()
        {
          await NavigationViewModel.LoadAsync();
        }
    }
}
