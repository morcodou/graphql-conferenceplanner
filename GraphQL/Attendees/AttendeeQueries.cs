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

namespace ConferencePlanner.GraphQL.Attendees
{
    [ExtendObjectType(Name = "Query")]
    public class AttendeeQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Attendee> GetAttendees(
            [ScopedService] ApplicationDbContext context) => context.Attendees;

        public Task<Attendee> GetAttendeeByIdAsync(
            [ID(nameof(Attendee))] int id,
            AttendeeByIdDataLoader dataLoader,
            CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Attendee>> GetAttendeesByIdAsync(
           [ID(nameof(Attendee))] int[] ids,
           AttendeeByIdDataLoader dataLoader,
           CancellationToken cancellationToken) => await dataLoader.LoadAsync(ids, cancellationToken);

    }
}