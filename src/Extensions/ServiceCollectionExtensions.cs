using Messenger.Abstractions.Services;
using Scrutor;
using System.Reflection;

namespace Messenger.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers as scoped service every implementation of <see cref = "IScopedService" /> to the service collection by scanning the specified assembly <br />
    /// Registers every implementation with itself and with the first matching interface found (e.g. <c>SomeService</c> is matched to <c>ISomeService</c>)
    /// </summary>
    /// <returns>The service collection</returns>
    public static IServiceCollection AddScopedServicesFromAssembly(this IServiceCollection serviceCollection, Assembly assembly)
    {
        return serviceCollection.Scan(scan => scan
                                              .FromAssemblies(assembly)
                                              .AddClasses(filter => filter.AssignableTo<IScopedService>(), true)
                                              .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                                              .AsMatchingInterface()
                                              .AsSelf()
                                              .WithScopedLifetime());
    }

    /// <summary>
    /// Registers as singleton service every implementation of <see cref = "ISingletonService" /> to the service collection by scanning the specified assembly <br />
    /// Registers every implementation with itself and with the first matching interface found (e.g. <c>SomeService</c> is matched to <c>ISomeService</c>)
    /// </summary>
    /// <returns>The service collection</returns>
    public static IServiceCollection AddSingletonServicesFromAssembly(this IServiceCollection serviceCollection, Assembly assembly)
    {
        return serviceCollection.Scan(scan => scan
                                              .FromAssemblies(assembly)
                                              .AddClasses(filter => filter.AssignableTo<ISingletonService>(), true)
                                              .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                                              .AsMatchingInterface()
                                              .AsSelf()
                                              .WithSingletonLifetime());
    }

    /// <summary>
    /// Registers as transient service every implementation of <see cref = "ITransientService" /> to the service collection by scanning the specified assembly <br />
    /// Registers every implementation with itself and with the first matching interface found (e.g. <c>SomeService</c> is matched to <c>ISomeService</c>)
    /// </summary>
    /// <returns>The service collection</returns>
    public static IServiceCollection AddTransientServicesFromAssembly(this IServiceCollection serviceCollection, Assembly assembly)
    {
        return serviceCollection.Scan(scan => scan
                                              .FromAssemblies(assembly)
                                              .AddClasses(filter => filter.AssignableTo<ITransientService>(), true)
                                              .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                                              .AsMatchingInterface()
                                              .AsSelf()
                                              .WithTransientLifetime());
    }
}
