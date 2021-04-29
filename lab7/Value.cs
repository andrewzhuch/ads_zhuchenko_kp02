namespace lab7
{
    public class Value
    {
        public int patientID;
        public string familyDoctor;
        public  string address;
        public Value()
        {
            patientID = 0;
            familyDoctor = null;
            address = null;
        }
        public override string ToString()
        {
            return $"{patientID} {familyDoctor} {address}";
        }
    }
}