using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GP.BLL.Caching;
using GP.BLL.Configuration.DAL.Folketinget;
using GP.BLL.Interfaces.Caching;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.BLL.Model.Folketinget;
using GP.DAL.Folketinget;
using GP.DAL.Folketinget.Interfaces;
using GP.DAL.Folketinget.Model.Aktør;
using GP.DAL.Folketinget.Model.Dokument;
using GP.DAL.Folketinget.Model.Møde;
using GP.DAL.Folketinget.Model.Øvrige;
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
        private const int Threads = 1000;
        protected override void ConfigureContainer(ServiceContainer container)
        {
            container.Register<IFolketingetService, FolketingetService>(new PerContainerLifetime());
            container.Register<IGlobalCache, GlobalCache>();
            container.RegisterInstance<IFolketingetConfig>(
                (FolketingetConfig) ConfigurationManager.GetSection("folketingetConfig"));
        }

        private static void AnalyseTimes(IEnumerable<long> times)
        {
            Console.WriteLine("Average ms: " + times.Average());
            var stdDeviation = Math.Sqrt(times.Average(x => Math.Pow(x - times.Average(), 2)));
            var deviationPercent = stdDeviation/times.Average();
            Assert.IsTrue(deviationPercent < 0.1); //10%
            Console.WriteLine("Std. Deviation ms: {0} ({1})", stdDeviation , deviationPercent.ToString("P1"));
        }


        [TestMethod, TestCategory("Integration")]
        public void TestGetAktørList()
        {
            var service = Container.GetInstance<IFolketingetService>();
            var tasks = new Task<IEnumerable<Actor>>[Threads];
            var times = new long[Threads];
            Parallel.For(0, Threads, async x =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                tasks[x] = service.GetActors();
                var list = await tasks[x];
                stopWatch.Stop();
                times[x] = stopWatch.ElapsedMilliseconds;
                
            });
            var results = Task.WhenAll(tasks).Result;
            AnalyseTimes(times);
            foreach (var list in results)
            {
                Assert.IsNotNull(list);
                Assert.IsTrue(list.Any());
            }
            foreach (var actor in results.First())
            {
                Console.WriteLine(actor.FirstName + " " + actor.LastName);
            }
        }

        //[TestMethod, TestCategory("Integration"), Ignore]
        //public void TestGetAktørAktørList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<AktørAktør>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.AktørAktørList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetAktørTypeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<AktørType>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.AktørTypeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetDokumentList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Dokument>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.DokumentList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetDokumentationList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Dokumentation>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.DokumentationList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetDokumentKategoriList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<DokumentKategori>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.DokumentKategoriList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetDokumentStatusList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<DokumentStatus>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.DokumentStatusList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetDokumentTypeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<DokumentType>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.DokumentTypeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetFilList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Fil>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.FilList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetNyhedList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Nyhed>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.NyhedList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetOmtrykList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Omtryk>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.OmtrykList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetTaleList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Tale>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.TaleList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetVideoList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Video>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.VideoList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetAfstemningList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Afstemning>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.AfstemningList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetAfstemningstypeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Afstemningstype>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.AfstemningstypeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetDagsordenspunktList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Dagsordenspunkt>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.DagsordenspunktList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetMødeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Møde>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.MødeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetMødeStatusList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<MødeStatus>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.MødeStatusList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetMødeTypeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<MødeType>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.MødeTypeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetStemmeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Stemme>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.StemmeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetStemmeTypeList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<StemmeType>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.StemmeTypeList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetKolonneBeskrivelseList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<KolonneBeskrivelse>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.KolonneBeskrivelseList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetSlettetList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<Slettet>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.SlettetList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetSlettetMapList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<SlettetMap>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.SlettetMapList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}

        //[TestMethod, TestCategory("Integration")]
        //public void TestGetTabelBeskrivelseList()
        //{
        //    var service = Container.GetInstance<IFolketingetServiceRepository>();
        //    var tasks = new Task<IEnumerable<TabelBeskrivelse>>[Threads];
        //    var times = new long[Threads];
        //    Parallel.For(0, Threads, async x =>
        //    {
        //        var stopWatch = new Stopwatch();
        //        stopWatch.Start();
        //        tasks[x] = service.TabelBeskrivelseList();
        //        var list = await tasks[x];
        //        stopWatch.Stop();
        //        times[x] = stopWatch.ElapsedMilliseconds;
        //    });
        //    var results = Task.WhenAll(tasks).Result;
        //    AnalyseTimes(times);
        //    foreach (var list in results)
        //    {
        //        Assert.IsNotNull(list);
        //        Assert.IsTrue(list.Any());
        //    }
        //}
    }
}