using System.Configuration;
using GP.BLL.Configuration.DAL.Folketinget;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.DAL.Folketinget;
using LightInject;

namespace GP.IoC
{
    public class Container
    {
        public static void InitiateContainer(ServiceContainer container)
        {
            container.Register<IFolketingetService, FolketingetService>(new PerContainerLifetime());
            container.RegisterInstance<IFolketingetConfig>((FolketingetConfig)ConfigurationManager.GetSection("folketingetConfig"));
        }
    }
}