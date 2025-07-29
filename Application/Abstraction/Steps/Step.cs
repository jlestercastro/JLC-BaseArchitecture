using Domain.Primitives;

namespace Application.Abstraction.Steps
{
    public abstract class Step<TContext, TResult> : IStep<TContext, TResult>
        where TContext : IStepContext<TResult>
        where TResult : Result
    {
        public IStep<TContext, TResult> Successor { get; private set; } = default!;

        public async Task<TResult> ExecuteNextAsync(TContext context)
        {
            if (Successor != null && context.Result.IsSuccess)
            {
                return await Successor.ExecuteAsync(context);
            }

            return context.Result;
        }

        public void SetSuccessor(IStep<TContext, TResult> successor)
        {
            if (Successor == null)
            {
                Successor = successor;
            }
            else
            {
                Successor.SetSuccessor(successor);
            }
        }

        public abstract Task<TResult> ExecuteAsync(TContext context);
    }
}
