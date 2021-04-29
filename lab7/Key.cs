namespace lab7
{
    public class Key
    {
        public string firstName;
        public string lastName;
        public Key()
        {
            firstName = null;
            lastName = null;
        }
        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}