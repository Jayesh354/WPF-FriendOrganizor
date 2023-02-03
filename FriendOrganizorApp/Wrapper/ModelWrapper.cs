using System.Runtime.CompilerServices;

namespace FriendOrganizorApp.Wrapper
{
    public class ModelWrapper<T> : NotifyErrorInforBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }
        public T Model { get; }

        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model, null);
        }

        protected virtual void SetValue<TValue>(TValue value,[CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged(propertyName);
        }
    }
}
