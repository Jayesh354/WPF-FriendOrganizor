using Autofac;
using FriendOrganizor.DataAccess;
using FriendOrganizorApp.Data;
using FriendOrganizorApp.ViewModel;

namespace FriendOrganizorApp.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            
            var builder = new ContainerBuilder();
           
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendOrganizorDbContext>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();

            return builder.Build();
        }
    }
}
