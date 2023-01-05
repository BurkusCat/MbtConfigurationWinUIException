using Mobile.BuildTools.Configuration;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MbtConfigurationWinUIException.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();

        ConfigurationManager.Init(true);
        TransformConfiguration(ConfigurationManager.Current);
    }

    public static void TransformConfiguration(IConfigurationManager configurationManager)
    {
        // Transform config based on current environment defined by config
        configurationManager.Reset();

        var targetEnvironment = configurationManager.AppSettings["CurrentEnvironment"];

        if (!configurationManager.EnvironmentExists(targetEnvironment))
        {
            Console.WriteLine($"Unable to target configured environment: {targetEnvironment} because it does not exist");
            return;
        }

        configurationManager.Transform(targetEnvironment);
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
