using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Models
{
    public class ApplicationFormDto
    {
        public string UploadedCoverImage { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public ProfileInformationDto ProfileInformation { get; set; }
        public List<QuestionDto> AdditionalQuestionList { get; set; }

    }
    public class InternalInformationDto<T> where T :  class
    {
        public T Value { get; set; }
        public bool? IsInternal { get; set; }
        public bool IsHidden { get; set; }
        public bool? IsMandate { get; set; }
    }

    public class QuestionDto
    {
        public string Question { get; set; }
    }
    public class MultipleChoiceQuestionDto:QuestionDto
    {
        public List<string> ChoiceList { get; set; }
        public int MaximumChoice { get; set; } = 1;
        public bool IsOtherOptionAvailable { get; set; } = false;
    }
    public class DropdownQuesitionDto:QuestionDto
    {
        public List<string> ChoiceList { get; set; }
        public bool IsOtherOptionAvailable { get; set; } = false;
    }
    public class YesOrNoQuestionDto : QuestionDto
    {
        public bool IsDisqualifyOnNo { get; set; }
    }
    public class PersonalInformationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public InternalInformationDto<string> Phone { get; set; }
        public InternalInformationDto<string> Nationality { get; set; }
        public InternalInformationDto<string> CurrentResidence { get; set; }
        public InternalInformationDto<string> IdNumber { get; set; }
        public InternalInformationDto<string> DateOfBirth { get; set; }
        public InternalInformationDto<string> Gender { get;set; }
        public List<QuestionDto> QuestionList { get; set; }
    }
    public class EducationDto
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrentlyStudying { get; set; }
    }
    public class WorkExperienceDto
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrentlyWorking { get; set; }
    }
    public class ProfileInformationDto
    {
        public InternalInformationDto<EducationDto> EducationList { get; set; }
        public InternalInformationDto<WorkExperienceDto> WorkExperienceList { get; set; }
        public InternalInformationDto<string> Resume { get; set; }
    }

}
