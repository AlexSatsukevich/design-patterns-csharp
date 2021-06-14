namespace DesignPatterns.Iterator
{
    public interface IIterator<out T>
    {
        bool HasNext();
        T Current();
        void Next();
    }
}