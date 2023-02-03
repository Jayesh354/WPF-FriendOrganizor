using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using FriendOrganizorApp.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizorApp.ViewModel
{
    public class NavigationViewModel : ViewModelBase,  INavigationViewModel
    {
        private readonly ILookupDataService dataService;
        private readonly IEventAggregator eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Friends { get; }

        private NavigationItemViewModel selectedFriend;

        public NavigationItemViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set { 
                selectedFriend = value;
                OnPropertyChanged();
                if (selectedFriend != null)
                {
                    eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(selectedFriend.Id);
                }
            }
        }



        public NavigationViewModel(ILookupDataService dataService,IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(OnFriendDetailUpdate);
        }

        private void OnFriendDetailUpdate(AfterFriendSaveEventArgs obj)
        {
            NavigationItemViewModel loopup = Friends.Single(f => f.Id == obj.Id);
            loopup.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await dataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var friend in lookup)
            {
                Friends.Add(new NavigationItemViewModel(friend.Id,friend.DisplayMember));
            }
        }
    }
}
