using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Doctors
    {
        Encryption encryption = new Encryption();
        /// <summary>
        /// This method creates a list of data from view of all doctors.
        /// </summary>
        /// <returns>List of doctors.</returns>
        public List<tblDoctor> GetAllDoctors()
        {
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    return context.tblDoctors.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds doctor to DbSet and save changes to database.
        /// </summary>
        /// <param name="doctor">Doctor.</param>
        /// <returns>True if created, false if not.</returns>
        public bool AddDoctor(vwDoctor doctor)
        {
            Users users = new Users();
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    tblUser user = new tblUser
                    {
                        Name = doctor.Name,
                        Password = encryption.EncryptPassword(doctor.Password),
                        Surname = doctor.Surname,
                        Username = doctor.Username,
                        JMBG = doctor.JMBG
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    doctor.UserId = user.UserId;
                    tblDoctor newDoctor = new tblDoctor
                    {
                        UserId = user.UserId,
                        BankAccountNumber = doctor.BankAccountNumber
                    };
                    context.tblDoctors.Add(newDoctor);
                    context.SaveChanges();
                    doctor.DoctorId = newDoctor.DoctorId;
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