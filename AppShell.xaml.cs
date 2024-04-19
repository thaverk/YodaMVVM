using YodaMVVM.Views;

namespace YodaMVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }


        private void RegisterRoutes()
        {
            Routing.RegisterRoute("factpage", typeof(FactPage));
            
        }


    }
}
