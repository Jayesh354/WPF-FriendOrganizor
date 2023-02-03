using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizorApp.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        public int Id { get; }
		private string displayMember;

		public string DisplayMember
		{
			get { return displayMember; }
			set { displayMember = value;
				OnPropertyChanged();
			}
		}
		public NavigationItemViewModel(int id,string displayMember)
		{
			Id= id;
			DisplayMember= displayMember;
		}

	}
}
