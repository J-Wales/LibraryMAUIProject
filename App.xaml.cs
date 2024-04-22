using LibraryMAUIProject.Components.Pages;

namespace LibraryMAUIProject
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            MainPage = new MainPage();

            //Routing.RegisterRoute(nameof(LogIn), typeof(LogIn));
            //Routing.RegisterRoute(nameof(Weather), typeof(Weather));
        }
	}
}
