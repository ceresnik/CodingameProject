using System;
using System.Linq;

namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        private readonly CandidateNameElectionGainPairs tips;
        private readonly string defaultCandidateName = string.Empty;
        private const double DefaultElectionGain = 0;            
        private const int MaximumCountOfTips = 5;

        public ProvidedTip(string tipperName, CandidateNameElectionGainPairs tips)
        {
            TipperName = tipperName;
            if (tips.Count > MaximumCountOfTips)
            {
                throw new ArgumentException($"Maximum {MaximumCountOfTips} tips are allowed.", nameof(tips));
            }
            this.tips = tips;
        }

        public readonly string TipperName;

        public string CandidateOnFirstPosition
        {
            get
            {                
                string result = defaultCandidateName;
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
                string result = defaultCandidateName;
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
                string result = defaultCandidateName;
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
                double result = DefaultElectionGain;
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
                double result = DefaultElectionGain;
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
                double result = DefaultElectionGain;
                if (tips.Count > 2)
                {
                    result = tips[2].ElectionGainInPercent;
                }
                return result;
            }
        }
    }
}