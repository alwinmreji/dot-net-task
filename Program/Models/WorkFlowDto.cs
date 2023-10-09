using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class WorkFlowDto
    {
        public List<StageDto> StageList { get; set; }
    }
    public class StageDto
    {
        public string StageName { get; set; }
        public bool IsShortlistingType { get; set; }
        public VideoInterviewDto VideoInterview { get; set; }
        public bool IsPlacement { get; set; }
        public bool IsStageVisibleToCandidate { get; set; }
    }
    public class VideoInterviewDto
    {
        public bool IsVideoInterviewRequired { get; set; } = false;
        public string Question { get; set; }
        public string AdditionalInformation { get; set; }
        public VideoDurationDto VideoDuration { get; set; }
        public int DeadlineDaysCount { get; set; }

    }
    public class VideoDurationDto
    {
        public int MaxDurationOfVideo { get; set; }
        public int Unit { get; set; }
    }
}
