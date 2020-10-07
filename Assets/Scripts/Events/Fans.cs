namespace ships.events
{
    public interface Fans<T>
    {
        void OnEventFired(T item);
        
    }
}
