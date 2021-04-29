namespace lab7
{
    public class Entry
    {
        public Key key;
        public Value value;
        public Entry(Key key, Value value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return $"{key} {value}";
        }
    }
}