using System;
using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Tracks
{
    public class TrackPayloadBase :  Payload
    {
        protected TrackPayloadBase(Track track)
        {
            Track = track;
        }

        protected TrackPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Track? Track { get; }
    }
}
