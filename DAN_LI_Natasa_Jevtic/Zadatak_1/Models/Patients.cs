using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Patients
    {
        Encryption encryption = new Encryption();
        /// <summary>
        /// This method creates a list of data from view of all patients.
        /// </summary>
        /// <returns>List of patients.</returns>
        public List<tblPatient> GetAllPatients()
        {
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    return context.tblPatients.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds patient to DbSet and save changes to database.
        /// </summary>
        /// <param name="patient">patient.</param>
        /// <returns>True if created, false if not.</returns>
        public bool AddPatient(vwPatient patient)
        {
            Users users = new Users();
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    tblUser user = new tblUser
                    {
                        Name = patient.Name,
                        Password = encryption.EncryptPassword(patient.Password),
                        Surname = patient.Surname,
                        Username = patient.Username,
                        JMBG = patient.JMBG
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    patient.UserId = user.UserId;
                    tblPatient newPatient = new tblPatient
                    {
                        UserId = user.UserId,
                        DoctorId = null,
                        HealthInsuranceCardNumber = patient.HealthInsuranceCardNumber
                    };
                    context.tblPatients.Add(newPatient);
                    context.SaveChanges();
                    patient.PatientId = newPatient.PatientId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}