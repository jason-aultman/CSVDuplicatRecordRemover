namespace CSVDuplicatRecordRemover.Classes
{
    public class Tourney
    {
        public string State { get; set; }
        public string Course { get; set; }
        public string Golfer { get; set; }

        public Tourney(string state, string course, string golfer)
        {
            State = state;
            Course = course;
            Golfer = golfer;

        }
    }
}