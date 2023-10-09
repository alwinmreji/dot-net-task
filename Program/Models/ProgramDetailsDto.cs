using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class ProgramDetailsDto
    {
        public string ProgramTitle { get; set; }
        public string SummaryOfTheProgram { get; set; }
        public string ProgramDescription { get; set; }
        public List<string> KeySkillsRequired { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
        public ProgramDetailsAdditionalInformationDto ProgramAdditionalInformation { get; set; }
    }
    public class ProgramDetailsAdditionalInformationDto
    {
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public int DurationInMonths { get; set; }
        public string ProgramLocation { get; set; }
        public string MinimumQualifications { get; set; }
        public string MaximumNumberOfApplications { get; set; }
    }
}
