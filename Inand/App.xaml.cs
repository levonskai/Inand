using System.IO;
using System.Windows;

namespace Inand
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!Directory.Exists(Argv.RootName))
            {
                Directory.CreateDirectory(Argv.RootName);
            }
        }
    }
}
