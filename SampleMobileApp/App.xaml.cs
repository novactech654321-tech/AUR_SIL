using SampleMobileApp.Views;

namespace SampleMobileApp;

public partial class App : Application
{
    private readonly MainPage _mainPage;

    public App(MainPage mainPage)
    {
        InitializeComponent();
        _mainPage = mainPage;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(_mainPage)) { Title = "Sample Mobile App" };
    }
}
