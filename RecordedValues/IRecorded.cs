namespace RecordedValues
{
    public interface IRecorded : IGeneric
    {
        object Current { get; }
        object Previous { get; }

        bool Update(object value);
    }

    public interface IRecorded<T> : IRecorded
    {
        new T Current { get; }
        new T Previous { get; }

        bool Update(T value);
    }
}