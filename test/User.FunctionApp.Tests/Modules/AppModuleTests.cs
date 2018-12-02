using System.Linq;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using AutoMapper;

using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Configurations;
using Kda.User.FunctionApp.Modules;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Modules
{
    [TestClass]
    public class AadUserTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AppModule)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract()
                        .And.BeDerivedFrom<Module>();
        }

        [TestMethod]
        public void Given_Type_Should_HaveMethod()
        {
            typeof(AppModule)
                .Should().HaveMethod("Load", new[] { typeof(IServiceCollection) })
                    .Which.Should().HaveAccessModifier(CSharpAccessModifier.Public)
                        .And.ReturnVoid();
        }

        [TestMethod]
        public void Given_Instance_Should_HaveAppSettings()
        {
            var module = new AppModule();
            var services = new ServiceCollection();

            module.Load(services);

            var instance = services.SingleOrDefault(p => p.ServiceType.Equals(typeof(AppSettings)));
            instance.Should().NotBeNull();
            instance.Lifetime.Should().Be(ServiceLifetime.Singleton);
            instance.ServiceType.Should().Be<AppSettings>();
        }

        [TestMethod]
        public void Given_Instance_Should_HaveIMapper()
        {
            var module = new AppModule();
            var services = new ServiceCollection();

            module.Load(services);

            var instance = services.SingleOrDefault(p => p.ServiceType.Equals(typeof(IMapper)));
            instance.Should().NotBeNull();
            instance.Lifetime.Should().Be(ServiceLifetime.Scoped);
            instance.ServiceType.Should().Be<IMapper>();
        }
    }
}