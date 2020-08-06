using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Users
    {
        Encryption encryption = new Encryption();
        /// <summary>
        /// This method finds patient in database with forwarded username and password.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Patient if finded, null if not.</returns>
        public vwPatient FindPatient(string username, string password)
        {
            string encryptedPassword = encryption.EncryptPassword(password);
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    return context.vwPatients.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method finds doctor in database with forwarded username and password.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Doctor if finded, null if not.</returns>
        public vwDoctor FindDoctor(string username, string password)
        {
            string encryptedPassword = encryption.EncryptPassword(password);
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    return context.vwDoctors.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method creates a list of data from view of all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (Medical_InstitutionEntities context = new Medical_InstitutionEntities())
                {
                    return context.tblUsers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}