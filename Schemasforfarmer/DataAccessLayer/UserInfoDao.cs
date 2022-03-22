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
    public class UserInfoDao :IUserInfo
    {
        public List<UsersInfo> GetUserDetail()
        {
            List<UsersInfo> allUsers = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserInfo> allEntityUsers = db.UserInfo;
                    allUsers = allEntityUsers
                      .Select(entityCrop =>
                  new UsersInfo
                  {
                    
                     UserTypeId= entityCrop.UserTypeId,
                     Address= entityCrop.Address,
                      UserId = entityCrop.UserId,
                     City = entityCrop.City,
                     ContactNo= entityCrop.ContactNo,
                     Password= entityCrop.Password,
                     Pincode= entityCrop.Pincode,
                     State= entityCrop.State,
                     EmailId= entityCrop.EmailId,
                     PermittedtoSale= entityCrop.PermittedtoSale,
                    
                     FullName= entityCrop.FullName
                   
                  })
                      .ToList();
                }
                return allUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsersInfo GetUserById(int id)

        {

            UsersInfo users = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserInfo> allEntityUsers = db.UserInfo;
                    var matchingAccount = allEntityUsers.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        UserInfo p = matchingAccount.First();
                        users=new UsersInfo
                        
                        {
                            UserTypeId = p.UserTypeId,
                            Address = p.Address,
                            UserId = p.UserId,
                            City = p.City,
                            ContactNo = p.ContactNo,
                            Password = p.Password,
                            Pincode = p.Pincode,
                            State = p.State,
                            EmailId = p.EmailId,
                            PermittedtoSale = p.PermittedtoSale,

                            FullName = p.FullName


                        };
                    }
                }
                return users;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public bool InsertUser(UsersInfo info)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserInfo> alluser = db.UserInfo;
                    UserInfo user = new UserInfo
                    {
                        UserTypeId = info.UserTypeId,
                        Address = info.Address,
                        UserId = info.UserId,
                        City = info.City,
                        ContactNo = info.ContactNo,
                        Password = info.Password,
                        Pincode = info.Pincode,
                        State = info.State,
                        EmailId = info.EmailId,
                        PermittedtoSale =info.PermittedtoSale,

                        FullName = info.FullName




                    };
                    alluser.Add(user);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteUser(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<UserInfo> users = db.UserInfo;

                    UserInfo user = users.Where(p => p.UserId == id).FirstOrDefault();
                    users.Remove(user);
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
    
