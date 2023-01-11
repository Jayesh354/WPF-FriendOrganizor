using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
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

        public FriendDetailViewModel(IFriendDataService dataService)
        {
            this.dataService = dataService;
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
