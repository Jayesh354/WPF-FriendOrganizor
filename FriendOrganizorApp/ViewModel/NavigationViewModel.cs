using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizorApp.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private readonly ILookupDataService dataService;
        public ObservableCollection<LookupItem> Friends { get; }

        public NavigationViewModel(ILookupDataService dataService)
        {
            this.dataService = dataService;
            Friends = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await dataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var friend in lookup)
            {
                Friends.Add(friend);
            }
        }
    }
}
