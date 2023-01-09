using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using System.Collections.ObjectModel;

namespace FriendOrganizorApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFriendDataService _friendDataService;

        public ObservableCollection<Friend> Friends { get; set; }
        private Friend selectedFriend;

        public MainViewModel(IFriendDataService friendDataService)
        {
            Friends=new ObservableCollection<Friend>();
            _friendDataService=friendDataService;
        }
       
        public Friend SelectedFriend
        {
            get { return selectedFriend; }
            set { 
                selectedFriend = value;
                OnPropertyChanged();  
            }
        }
  
        public void Load()
        {
           var friends = _friendDataService.GetAll();
            Friends.Clear();    
            foreach (var friend in friends) { 
                Friends.Add(friend);    
            }
        }
    }
}
