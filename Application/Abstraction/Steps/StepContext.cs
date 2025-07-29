namespace Application.Abstraction.Steps
{
    public class StepContext<TResult> : IStepContext<TResult>
    {
        public required TResult Result { get; set; }
    }
}
