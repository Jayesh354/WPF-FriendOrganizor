using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
  
        public async Task LoadAsync()
        {
           var friends = await _friendDataService.GetAllAsync();
            Friends.Clear();    
            foreach (var friend in friends) { 
                Friends.Add(friend);    
            }
        }
    }
}
