using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using FriendOrganizorApp.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizorApp.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendDataService dataService;
        private readonly IEventAggregator eventAggregator;

        public FriendDetailViewModel(IFriendDataService dataService,IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await dataService.GetByIdAsync(friendId);
        }
        private Friend friend;

        public Friend Friend
        {
            get { return friend; }
            set
            {
                friend = value;
                OnPropertyChanged();
            }
        }


    }
}
