using JwtAuthentication.DbContexts;
using JwtAuthentication.Entities;
using JwtAuthentication.IServices;
using JwtAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Services
{
    public class UserService : IUserService
    {

        /// <summary>
        /// Get all data.
        /// </summary>
        /// <returns></returns>
        public object GetAllData()
        {
            using (var context = new jwt_testContext())
            {
                var data = context.Users.ToList();
                return data;
            }
               
        }


        /// <summary>
        /// Post new user 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object Post(UserModel model)
        {
            using (var context = new jwt_testContext())
            {
                var newUser = new User
                {
                    Name = model.Name,
                    MailAddress = model.MailAddress,
                    Password = model.Password,
                    Surname = model.Surname,
                    CreatedAt = DateTime.Now,
                };

                try
                {
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return newUser;
                }
                catch (DbUpdateException ex)
                {
                    return ex;
                }
            }
        }


        /// <summary>
        /// Get by user id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetById(int id)
        {
            using (var context = new jwt_testContext())
            {
                var data = context.Users.SingleOrDefault(x => x.Id == id);
                if (data == null)
                    return new ArgumentNullException("Does not exists");
                return data;
            }
        }

        /// <summary>
        /// Update exsist data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public object Update(int id,UserModel model)
        {
            using (var context = new jwt_testContext())
            {
                var data = context.Users.SingleOrDefault(x => x.Id == id);

                if (data == null)
                    return new ArgumentNullException("Please check user id");

                if(!String.IsNullOrEmpty(model.Name))
                    data.Name = model.Name;
                if (!String.IsNullOrEmpty(model.Surname))
                    data.Surname = model.Surname;
                if (!String.IsNullOrEmpty(model.Password))
                    data.Password = model.Password;
                if (!String.IsNullOrEmpty(model.MailAddress))
                    data.MailAddress = model.MailAddress;

                try
                {
                    context.Users.Update(data);
                    context.SaveChanges();
                    return data;
                }
                catch (DbUpdateException ex)
                {
                    return ex;
                }
            }
        }


        /// <summary>
        /// Delete by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object Delete(int id)
        {
            using (var context = new jwt_testContext())
            {
                var data = context.Users.SingleOrDefault(x => x.Id == id);
                if (data == null)
                    return new ArgumentNullException("Plase check user id");
                try
                {
                    context.Users.Remove(data);
                    context.SaveChanges(true);
                    return data;
                }
                catch(DbUpdateException ex)
                {
                    return ex;
                }
            }
        }
    }
}
