using System.Collections.Generic;

using FluentAssertions;
using FluentAssertions.Common;

using Kda.User.FunctionApp.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kda.User.FunctionApp.Tests.Models
{
    [TestClass]
    public class AadUserCollectionResponseTests
    {
        [TestMethod]
        public void Given_Type_Should_BePublic()
        {
            typeof(AadUserCollectionResponse)
                .Should().HaveAccessModifier(CSharpAccessModifier.Public)
                    .And.Should().NotBeAbstract();
        }

        [TestMethod]
        public void Given_Type_Should_HaveProperties()
        {
            typeof(AadUserCollectionResponse)
                .Should().HaveProperty<List<AadUser>>("Users")
                    .Which.Should().BeVirtual()
                .And.BeReadable()
                    .And.BeWritable();
        }
    }
}