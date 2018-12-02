using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Models
{
    [TestClass]
    public class AadUserResponseTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AadUserResponse)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract();
        }

        [TestMethod]
        public void Given_Type_Should_HaveProperties()
        {
            typeof(AadUserResponse)
                .Should().HaveProperty<AadUser>("User")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();
        }
    }
}