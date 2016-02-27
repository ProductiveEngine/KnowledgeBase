namespace DomainClasses.Base
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }
    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
