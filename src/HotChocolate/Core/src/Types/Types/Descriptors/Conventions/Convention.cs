using System;
using System.Diagnostics;

#nullable enable

namespace HotChocolate.Types.Descriptors
{
    public abstract class Convention : IConvention
    {
        private ConventionStatus _status = ConventionStatus.Uninitialized;

        public string? Scope { get; set; }

        public virtual void Initialize(IConventionContext context)
        {
            Scope = context.Scope;
            MarkInitialized();
        }

        protected void MarkInitialized()
        {
            Debug.Assert(_status == ConventionStatus.Uninitialized);

            if (_status != ConventionStatus.Uninitialized)
            {
                throw new InvalidOperationException();
            }

            _status = ConventionStatus.Initialized;
        }
    }
}