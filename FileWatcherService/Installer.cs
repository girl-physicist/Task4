using System.ComponentModel;
using System.ServiceProcess;

namespace FileWatcherService
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;
        public Installer()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "FileWatcherService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
