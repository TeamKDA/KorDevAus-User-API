using System.Collections.Generic;

using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Configurations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Configurations
{
    [TestClass]
    public class AuthenticationSettingsTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AuthenticationSettings)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract();
        }

        [TestMethod]
        public void Given_Type_Should_HaveConstructor()
        {
            typeof(AuthenticationSettings)
                .Should().HaveDefaultConstructor();
        }

        [TestMethod]
        public void Given_Type_Should_HaveProperties()
        {
            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("TenantId")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("ClientId")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("ClientSecret")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("RedirectUri")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("AuthorityUri")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("AdalBaseUri")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("AdalApiVersion")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("MsalBaseUri")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<string>("MsalApiVersion")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AuthenticationSettings)
                .Should().HaveProperty<List<string>>("MsalScopes")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();
        }
    }
}