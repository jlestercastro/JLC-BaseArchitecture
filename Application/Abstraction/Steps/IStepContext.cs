namespace Application.Abstraction.Steps
{
    public interface IStepContext<TResult>
    {
        TResult Result { get; set; }
    }
}
