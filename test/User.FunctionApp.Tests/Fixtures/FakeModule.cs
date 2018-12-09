using Kda.User.FunctionApp.Modules;

using Microsoft.Extensions.DependencyInjection;

namespace Kda.User.FunctionApp.Tests.Fixtures
{
    /// <summary>
    /// This represents the fake module entity.
    /// </summary>
    public class FakeModule : AppModule
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            base.Load(services);
        }
    }
}