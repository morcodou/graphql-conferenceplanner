using System;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConferencePlanner.GraphQL
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor)
            where TDbContext : DbContext
        {
            return descriptor.UseScopedService<TDbContext>(
              create: provider => provider.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
              disposeAsync: (provider, dbContext) => dbContext.DisposeAsync());
        }
    }
}
