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

namespace ConferencePlanner.GraphQL.Speakers
{
    [ExtendObjectType(Name = "Query")]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers(
            [ScopedService] ApplicationDbContext context) => context.Speakers.ToListAsync();

        public Task<Speaker> GetSpeakerByIdAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Speaker>> GetSpeakersByIdAsync(
           [ID(nameof(Speaker))] int[] ids,
           SpeakerByIdDataLoader dataLoader,
           CancellationToken cancellationToken) => await dataLoader.LoadAsync(ids, cancellationToken);

    }
}