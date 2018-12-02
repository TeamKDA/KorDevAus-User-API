using System;

using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Models
{
    [TestClass]
    public class AadUserProfileTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AadUser)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract();
        }

        [TestMethod]
        public void Given_Type_Should_HaveProperties()
        {
            typeof(AadUser)
                .Should().HaveProperty<Guid>("UserId")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AadUser)
                .Should().HaveProperty<string>("DisplayName")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AadUser)
                .Should().HaveProperty<string>("FirstName")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AadUser)
                .Should().HaveProperty<string>("LastName")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();

            typeof(AadUser)
                .Should().HaveProperty<string>("Email")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();
        }
    }
}