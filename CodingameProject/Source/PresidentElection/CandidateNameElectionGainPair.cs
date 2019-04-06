namespace CodingameProject.Source.PresidentElection
{
    public class CandidateNameElectionGainPair
    {
        public string CandidateName { get; }
        public double ElectionGainInPercent { get; }

        public CandidateNameElectionGainPair(string candidateName, double electionGainInPercent)
        {
            CandidateName = candidateName;
            ElectionGainInPercent = electionGainInPercent;
        }
    }
}