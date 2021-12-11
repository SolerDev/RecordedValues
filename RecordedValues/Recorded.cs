namespace RecordedValues
{
    public abstract class Recorded : IRecorded
    {
        public abstract Type GenericType { get; }
        object IRecorded.Current => CurrentBase;
        object IRecorded.Previous => PreviousBase;


        protected abstract object CurrentBase { get; }
        protected abstract object PreviousBase { get; }

        public abstract bool Update(object value);
    }

    public class Recorded<T> : Recorded, IRecorded<T>
    {
        public override Type GenericType => typeof(T);
        protected override object CurrentBase => Current;
        protected override object PreviousBase => Previous;
        public T Current { get; private set; }
        public T Previous { get; private set; }

        public bool Update(T value)
        {
            if (Equals(value, Current))
                return false;

            Previous = Current;
            Current = value;

            return true;
        }

        public override bool Update(object value)
        {
            return Update((T)value);
        }
    }
}