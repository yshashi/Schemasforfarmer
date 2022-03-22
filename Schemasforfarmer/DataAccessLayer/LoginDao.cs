using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer.Interfaces;
using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer
{
    public class LoginDao :ILoginInfo
    {
        public List<Login> GetLoginDetails()
        {
            List<Login> allLogins = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<LoginInfo> allEntityLogins = db.LoginInfo;
                    allLogins = allEntityLogins
                      .Select(entityCrop =>
                  new Login
                  {
                      EmailId=entityCrop.EmailId,
                      Password=entityCrop.Password,
                      UserId=entityCrop.UserId,
                     
                      UserTypeId=entityCrop.UserTypeId,
                      
                  })
                      .ToList();
                }
                return allLogins;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Login GetinfoById(int id)

        {

            Login login = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<LoginInfo> allEntityLogins = db.LoginInfo;
                    var matchingAccount = allEntityLogins.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        LoginInfo p = matchingAccount.First<LoginInfo>();
                        login = new Login
                        {
                            EmailId = p.EmailId,
                            Password = p.Password,
                            UserId = p.UserId,
                    
                            UserTypeId = p.UserTypeId,
                         

                        };
                    }
                }
                return login;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public bool InsertLoginDetail(Login login)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<LoginInfo> alllogin = db.LoginInfo;
                    LoginInfo log = new LoginInfo
                    {
                        EmailId = login.EmailId,
                        Password = login.Password,
                        UserId = login.UserId,
                     
                        UserTypeId = login.UserTypeId,
                  



                    };
                    alllogin.Add(log);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteInfo(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<LoginInfo> logins = db.LoginInfo;

                    LoginInfo log = logins.Where(p => p.UserId == id).FirstOrDefault();
                    logins.Remove(log);
                    int rawAffected = db.SaveChanges();
                    return rawAffected;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
    
