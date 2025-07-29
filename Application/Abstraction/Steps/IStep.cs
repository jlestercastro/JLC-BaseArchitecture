namespace Application.Abstraction.Steps
{
    public interface IStep<TContext, TResult>
        where TContext : IStepContext<TResult>
    {
        IStep<TContext, TResult> Successor { get; }

        void SetSuccessor(IStep<TContext, TResult> successor);

        Task<TResult> ExecuteNextAsync(TContext context);

        Task<TResult> ExecuteAsync(TContext context);
    }
}
