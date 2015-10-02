using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GP.BLL.Caching;
using GP.BLL.Configuration.DAL.Folketinget;
using GP.BLL.Interfaces.Caching;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.DAL.Folketinget;
using GP.DAL.Folketinget.Interfaces;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GP.Tests.Integration.Folketinget
{
    /// <summary>
    ///     Summary description for AktørIntegrationTests
    /// </summary>
    [TestClass]
    public class AktørIntegrationTests : TestBase
    {
        protected override void ConfigureContainer(ServiceContainer container)
        {
            container.Register<IFolketingetServiceRepository, FolketingetServiceRepository>(new PerContainerLifetime());
            container.Register<IGlobalCache, GlobalCache>();
            container.RegisterInstance<IFolketingetConfig>((FolketingetConfig) ConfigurationManager.GetSection("folketingetConfig"));
        }


        [TestMethod, TestCategory("Integration")]
        public void TestGetAktørList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();
           
            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.AktørList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });          
        }

        [TestMethod, TestCategory("Integration"), Ignore]
        public void TestGetAktørAktørList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.AktørAktørList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetAktørTypeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.AktørTypeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetDokumentList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.DokumentList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetDokumentationList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.DokumentationList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetDokumentKategoriList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.DokumentKategoriList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetDokumentStatusList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.DokumentStatusList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetDokumentTypeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.DokumentTypeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetFilList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.FilList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetNyhedList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.NyhedList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Console.WriteLine(list.Count());
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetOmtrykList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.OmtrykList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetTaleList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.TaleList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetVideoList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.VideoList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetAfstemningList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.AfstemningList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetAfstemningstypeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.AfstemningstypeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetDagsordenspunktList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.DagsordenspunktList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetMødeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.MødeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetMødeStatusList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.MødeStatusList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetMødeTypeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.MødeTypeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetStemmeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.StemmeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetStemmeTypeList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.StemmeTypeList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetKolonneBeskrivelseList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.KolonneBeskrivelseList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetSlettetList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.SlettetList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetSlettetMapList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.SlettetMapList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
        [TestMethod, TestCategory("Integration")]
        public void TestGetTabelBeskrivelseList()
        {
            var service = Container.GetInstance<IFolketingetServiceRepository>();

            Parallel.For(0, 10, x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var list = service.TabelBeskrivelseList();
                stopWatch.Stop();
                Console.WriteLine($"#{x}: {stopWatch.ElapsedMilliseconds} ms");
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            });
        }
    }
}