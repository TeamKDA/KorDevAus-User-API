using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Configurations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Configurations
{
    [TestClass]
    public class AppSettingsTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AppSettings)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract();
        }

        [TestMethod]
        public void Given_Type_Should_HaveConstructor()
        {
            typeof(AppSettings)
                .Should().HaveDefaultConstructor();
        }

        [TestMethod]
        public void Given_Type_Should_HaveProperties()
        {
            typeof(AppSettings)
                .Should().HaveProperty<AuthenticationSettings>("Auth")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.NotBeWritable();
        }
    }
}