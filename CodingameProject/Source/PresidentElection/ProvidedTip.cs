using System.Linq;

namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        private readonly CandidateNameElectionGainPairs tips;

        public readonly string TipperName;

        public string CandidateOnFirstPosition
        {
            get
            {
                string result = string.Empty;
                if (tips.Any())
                {
                    result = tips[0].CandidateName;
                }
                return result;
            }
        }

        public string CandidateOnSecondPosition
        {
            get
            {
                string result = string.Empty;
                if (tips.Count > 1)
                {
                    result = tips[1].CandidateName;
                }
                return result;
            }
        }

        public string CandidateOnThirdPosition
        {
            get
            {
                string result = string.Empty;
                if (tips.Count > 2)
                {
                    result = tips[2].CandidateName;
                }
                return result;
            }
        }

        public double CandidateOnFirstPositionPercent
        {
            get
            {
                double result = 0;
                if (tips.Any())
                {
                    result = tips[0].ElectionGainInPercent;
                }
                return result;
            }
        }

        public double CandidateOnSecondPositionPercent
        {
            get
            {
                double result = 0;
                if (tips.Count > 1)
                {
                    result = tips[1].ElectionGainInPercent;
                }
                return result;
            }
        }

        public double CandidateOnThirdPositionPercent
        {
            get
            {
                double result = 0;
                if (tips.Count > 2)
                {
                    result = tips[2].ElectionGainInPercent;
                }
                return result;
            }
        }

        public ProvidedTip(string tipperName, CandidateNameElectionGainPairs tips)
        {
            TipperName = tipperName;
            this.tips = tips;
        }
    }
}