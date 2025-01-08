using SalaryCalculatorAPI.Models;
using System.Data;
using System.Xml.Schema;

namespace SalaryCalculatorAPI.Handlers
{
    public class SalaryCalculatorHandler : ISalaryCalculator
    {
        //using fixed variables that is easier to change in future reworks
        private const int MonthlyHours = 170;
        private const double baseHourlyWage = 100.0;
        private const double ExperiencedHourlyWage = 120.0;
        private const int ManagerialBonus = 20;
        private const double workBonus_TeamA = 0.01;
        private const double workBonus_TeamB = 0.005;

        public SalaryOutputModel CalculateSalary(SalaryInputModel user_salary_request)
        {
            SalaryOutputModel user_salary_response = new SalaryOutputModel();

            //calculating hours based on job type and experience
            int monthlyHours = user_salary_request.JobType switch
            {
                100 => MonthlyHours,
                70 => (int)(MonthlyHours * 0.7),
                50 => (int)(MonthlyHours * 0.5),
                _ => throw new ArgumentException("Invalid job type")
            };

            switch (user_salary_request.Experience)
            {
                case "junior":
                    user_salary_response.SalaryBasedOnJobType =
                        monthlyHours * baseHourlyWage; //juniors can't have managerial experience
                    break;
                case "senior":
                    user_salary_response.SalaryBasedOnJobType =
                        monthlyHours * (ExperiencedHourlyWage + (ManagerialBonus * user_salary_request.AdministrationLevel));
                    break;
                default:
                    throw new ArgumentException("invalid experience type");
            }


            // calculating years in experience bonus
            user_salary_response.YearsOfExperienceTotalBonus = user_salary_request.YearsOfExperience *
                                                                    (user_salary_response.SalaryBasedOnJobType * 0.0125);
            //precentage
            user_salary_response.YearsOfExperienceBonusInPrecentage = Math.Round(user_salary_request.YearsOfExperience * 1.25,2);
            

            //calculating additional work bonus by team
            user_salary_response.AdditionalSalaryWorkByLaw = user_salary_response.SalaryBasedOnJobType *
                user_salary_request.ExtraWorkTeam switch
            {
                "A" => workBonus_TeamA,
                "B" => workBonus_TeamB,
                _ => 0
            };


            //total base salary
            user_salary_response.TotalBaseSalaryBeforeRaise = user_salary_response.SalaryBasedOnJobType +
                                                              user_salary_response.YearsOfExperienceTotalBonus +
                                                              user_salary_response.AdditionalSalaryWorkByLaw;

            //calculating raise
            double raiseMultiplier;
            switch (user_salary_response.TotalBaseSalaryBeforeRaise)
            {
                case <= 20000:
                    raiseMultiplier = 1.015;
                    break;
                case <= 30000:
                    raiseMultiplier = 1.0125;
                    break;
                case > 30000:
                    raiseMultiplier = 1.01 ;
                    break;
                default:
                    throw new ArgumentException("salary value is invalid");
            }

            //get the managerial level bonus 
            raiseMultiplier += user_salary_request.AdministrationLevel * 0.001;
            //(using Math round to pretiffy the results)
            //add to base salary to get after raise ssalary
            user_salary_response.TotalBaseSalaryAfterRaise = Math.Round(user_salary_response.TotalBaseSalaryBeforeRaise * raiseMultiplier, 2);
            // in precentage
            user_salary_response.RaiseInPrecentage = Math.Round((raiseMultiplier - 1) * 100, 2);
            // in numbers
            user_salary_response.RaiseInTotal = Math.Round(user_salary_response.TotalBaseSalaryAfterRaise - user_salary_response.TotalBaseSalaryBeforeRaise, 2);

            return user_salary_response;

        }

    }


    public interface ISalaryCalculator
    {
        public SalaryOutputModel CalculateSalary(SalaryInputModel user_request);


    }
}
