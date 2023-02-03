using FriendOrganizor.Model;
using FriendOrganizorApp.Data;
using FriendOrganizorApp.Event;
using FriendOrganizorApp.Wrapper;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizorApp.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendDataService dataService;
        private readonly IEventAggregator eventAggregator;
        private FriendWrapper friend;

        public ICommand SaveCommand { get;}
        public FriendWrapper Friend
        {
            get { return friend; }
            set
            {
                friend = value;
                OnPropertyChanged();
            }
        }
        public FriendDetailViewModel(IFriendDataService dataService,
            IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
            SaveCommand = new DelegateCommand(ExecuteSaveFriendDetail,CanExecuteSaveFriendDetail);
        }
        public async Task LoadAsync(int friendId)
        {
            var friend = await dataService.GetByIdAsync(friendId);
            Friend = new FriendWrapper(friend);
        }
        private bool CanExecuteSaveFriendDetail()
        {
            // TODO: check the friend is valid
            return true;
        }
        private async void ExecuteSaveFriendDetail()
        {
            await dataService.SaveAsync(Friend.Model);
            eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
            new AfterFriendSaveEventArgs()
            {
                Id = Friend.Id,
                DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
            });
        }
        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }
    }
}
