namespace SalaryCalculatorAPI.Models
{
    public class SalaryInputModel
    {

        public double JobType { get; set; }
        public string ?Experience { get; set; }
        public int AdministrationLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string ExtraWorkTeam { get; set; }

    }
}
