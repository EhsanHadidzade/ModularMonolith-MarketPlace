namespace AccountManagement.Application.Contract.Personality
{
    public class PersonalityViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long PersonalityTypeId { get; set; }
        public string PersonalityTypeTitle { get; set; }
        public string CreationDate { get; set; }
    }
}
