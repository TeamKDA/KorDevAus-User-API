using AutoMapper;

using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Mappers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Mappers
{
    [TestClass]
    public class AadUserProfileTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AadUserProfile)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract()
                        .And.BeDerivedFrom<Profile>();
        }

        [TestMethod]
        public void Given_Type_Should_HaveConstructor()
        {
            typeof(AadUserProfile)
                .Should().HaveDefaultConstructor()
                    .Which.Should().HaveAccessModifier(CSharpAccessModifier.Public);
        }
    }
}