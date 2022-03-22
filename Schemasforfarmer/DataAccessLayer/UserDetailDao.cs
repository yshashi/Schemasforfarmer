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
    public class UserDetailDao :IUserDetail
    {
        public List<UserDetail> GetUserDetail()
        {
            List<UserDetail> allDetails = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserDetails> allEntityDetails = db.UserDetails;
                    allDetails = allEntityDetails
                      .Select(entityCrop =>
                  new UserDetail
                  {
                      UserInfo=entityCrop.UserInfo,
                      UserType=entityCrop.UserType,
                      UserTypeId=entityCrop.UserTypeId
                  })
                      .ToList();
                }
                return allDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserDetail GetUserById(int id)

        {

            UserDetail user = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserDetails> allEntityusers = db.UserDetails;
                    var matchingAccount = allEntityusers.Where(p => p.UserTypeId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        UserDetails p = matchingAccount.First<UserDetails>();
                        user = new UserDetail
                        {
                            UserInfo = p.UserInfo,
                            UserType = p.UserType,
                            UserTypeId = p.UserTypeId

                        };
                    }
                }
                return user;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public bool InsertUserDetail(UserDetail user)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserDetails> allusers = db.UserDetails;
                    UserDetails  users = new UserDetails
                    {
                        UserInfo = user.UserInfo,
                        UserType = user.UserType,
                        UserTypeId = user.UserTypeId



                    };
                    allusers.Add(users);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteUserDetail(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserInfo> info = db.UserInfo;

                    UserInfo user = info.Where(p => p.UserTypeId == id).FirstOrDefault();
                    info.Remove(user);
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
    
