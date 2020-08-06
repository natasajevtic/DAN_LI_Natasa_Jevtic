using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class UniqueHealthInsuranceCardNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (number.Length != 11 || !number.All(Char.IsDigit))
            {
                return new ValidationResult(false, "Number must contain 11 digits.");
            }
            else
            {
                Patients patients = new Patients();
                List<tblPatient> patientList = patients.GetAllPatients();
                var list = patientList.Where(x => x.HealthInsuranceCardNumber == number).ToList();
                //if exists employee with forwarded username, return false
                if (list.Count() > 0)
                {
                    return new ValidationResult(false, "This number already exists.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
        }
    }
}