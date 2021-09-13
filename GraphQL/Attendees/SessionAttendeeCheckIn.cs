using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Attendees
{
    public class SessionAttendeeCheckIn
    {
        [ID(nameof(Session))]
        public int SessionId { get; }

        [ID(nameof(Attendee))]
        public int AttendeeId { get; }

        public SessionAttendeeCheckIn(int sessionId, int attendeeId)
        {
            SessionId = sessionId;
            AttendeeId = attendeeId;
        }

        [UseApplicationDbContext]
        public async Task<int> CheckInCountAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
                await context.Sessions
                    .Where(session => session.Id == SessionId)
                    .SelectMany(session => session.SessionAttendees)
                    .CountAsync(cancellationToken);

        public Task<Attendee> GetAttendeeAsync(
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken) =>
            attendeeById.LoadAsync(AttendeeId, cancellationToken);

        public Task<Session> GetSessionAsync(
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            sessionById.LoadAsync(AttendeeId, cancellationToken);

    }
}
