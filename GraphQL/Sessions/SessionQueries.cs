using System.Linq;
using HotChocolate;
using ConferencePlanner.GraphQL.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate.Types.Relay;
using HotChocolate.Types;
using ConferencePlanner.GraphQL.Types;

namespace ConferencePlanner.GraphQL.Sessions
{
    [ExtendObjectType(Name = "Query")]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<SessionType>))]
        public IQueryable<Session> GetSessions( [ScopedService] ApplicationDbContext context) => context.Sessions;

        public Task<Session> GetSessionByIdAsync(
            [ID(nameof(Speaker))] int id,
            SessionByIdDataLoader dataLoader,
            CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
           [ID(nameof(Session))] int[] ids,
           SessionByIdDataLoader dataLoader,
           CancellationToken cancellationToken) =>
           await dataLoader.LoadAsync(ids, cancellationToken);

    }
}