using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Configurations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Configurations
{
    [TestClass]
    public class MailChimpSettingsTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(MailChimpSettings)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract();
        }

        [TestMethod]
        public void Given_Type_Should_HaveConstructor()
        {
            typeof(MailChimpSettings)
                .Should().HaveDefaultConstructor();
        }

        [TestMethod]
        public void Given_Type_Should_HaveProperties()
        {
            typeof(MailChimpSettings)
                .Should().HaveProperty<string>("BaseUri")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(MailChimpSettings)
                .Should().HaveProperty<string>("ApiVersion")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(MailChimpSettings)
                .Should().HaveProperty<string>("ApiKey")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(MailChimpSettings)
                .Should().HaveProperty<string>("ListId")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();
        }
    }
}