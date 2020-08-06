using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class UniqueBankAccount : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string account = value as string;
            if (account.Length != 18 || !account.All(Char.IsDigit))
            {
                return new ValidationResult(false, "Bank account must contain 18 digits.");
            }
            else
            {
                Doctors doctors = new Doctors();
                List<tblDoctor> doctorList = doctors.GetAllDoctors();
                var list = doctorList.Where(x => x.BankAccountNumber == account).ToList();
                //if exists employee with forwarded username, return false
                if (list.Count() > 0)
                {
                    return new ValidationResult(false, "This bank account already exists.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
        }
    }
}