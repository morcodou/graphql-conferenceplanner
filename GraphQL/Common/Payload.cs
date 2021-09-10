using System;
using System.Collections.Generic;

namespace ConferencePlanner.GraphQL.Common
{
    public class Payload
    {
        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError>? Errors { get; }
    }
}
