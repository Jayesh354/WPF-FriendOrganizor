using System.Threading.Tasks;

namespace FriendOrganizorApp.ViewModel
{
    public interface IFriendDetailViewModel
    {
        Task LoadAsync(int friendId);
    }
}