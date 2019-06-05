namespace Assassins.Configuration
{
    public class AppValueConfig
    {
        public int SqlCommandTimeout { get; set; }
        public string DefaultConnString { get; set; }

        public string ReportsLocation { get; set; }
        public string ReportingConnString { get; set; }
        

        public FileLocationType ModelLocationType { get; set; }
        public string AzureModelConnectionString { get; set; }
        public string AzureModelFolderName { get; set; }
        public string ModelGlobalLocation { get; set; }
        public string ModelLocalLocation { get; set; }

        public FileLocationType InterfaceLocationType { get; set; }
        public string AzureInterfaceConnectionString { get; set; }
        public string AzureInterfaceFolderName { get; set; }
        public string InterfaceGlobalLocation { get; set; }
        public string InterfaceLocalLocation { get; set; }

        public GraphsSource GraphsSource { get; set; }
        public string GraphsSourceFileDirectory { get; set; }
        public int GraphsSourceNumberOfIterationsThroughDirectory { get; set; }
    }

    public enum FileLocationType
    {
        azure,
        local
    }

    public enum GraphsSource
    {
        File,
        Queue,
        DirectoryWatcher
    }
}

