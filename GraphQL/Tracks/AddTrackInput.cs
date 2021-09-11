using System.Collections.Generic;
using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Tracks
{
    public record AddTrackInput(string Name);
}