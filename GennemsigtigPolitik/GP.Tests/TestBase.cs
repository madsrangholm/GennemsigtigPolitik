using LightInject;

namespace GP.Tests
{
    public abstract class TestBase
    {
        protected ServiceContainer Container { get; }

        protected TestBase()
        {
            Container = new ServiceContainer();
            ConfigureContainer(Container);
        }

        protected abstract void ConfigureContainer(ServiceContainer container);
    }
}