namespace SalaryCalculatorAPI.Models
{
    public class SalaryOutputModel
    {
        public double SalaryBasedOnJobType { get; set; }                //שכר יסוד לפי חלקיות משרה
        public double YearsOfExperienceBonusInPrecentage{ get; set; } //שיעור תוספת וותק באחוזים
        public double YearsOfExperienceTotalBonus{ get; set; } //סה"כ תוספת וותק לשכר
        public double AdditionalSalaryWorkByLaw { get; set; } //סה"כ תוספת עבודה מתוקף מינוי בחוק
        public double TotalBaseSalaryBeforeRaise { get; set; } //סה"כ שכר בסיס לפני העלאה
        public double RaiseInPrecentage{ get; set; } //שיעור העלאת שכר באחוזים
        public double RaiseInTotal { get; set; } //סה"כ תוספת העלאת שכר 
        public double TotalBaseSalaryAfterRaise { get; set; } //סה"כ שכר בסיס לאחר העלאה






    }
}
