using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataLibrary.Logic
{
    public static class DBBridge
    {
        public static int CreateUser(int userId, string userFirstName, string userLastName, string userMail, string userPassword)
        {
            string hashedUserPassword = Convert.ToBase64String(System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(userPassword)));
            
            UserModel data = new UserModel
            {
                UserId = userId,
                UserFirstName = userFirstName,
                UserLastName = userLastName,
                UserMail = userMail,
                UserPassword = hashedUserPassword
            };
            
            string sql = @"INSERT INTO dbo.UserData (UserId, UserFirstName, UserLastName, UserMail, UserPassword) VALUES (@UserId, @UserFirstName, @UserLastName, @UserMail, @UserPassword);";

            return SqlAccess.UseData(sql, data);
        }

        public static List<UserModel> LoadUsers()
        {
            string sql = @"SELECT UserId, UserFirstName, UserLastName, UserMail FROM dbo.UserData;";

            return SqlAccess.LoadData<UserModel>(sql);
        }

        public static List<UserModel> LoginUser(string userMail, string userPassword)
        {
            string hashedUserPassword = Convert.ToBase64String(System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(userPassword)));

            UserModel data = new UserModel
            {
                UserMail = userMail,
                UserPassword = hashedUserPassword
            };
            
            string sql = @"SELECT * FROM dbo.UserData WHERE UserMail = @userMail AND UserPassword = @UserPassword;";

            return SqlAccess.SearchData<UserModel>(sql, data);
        }

        public static List<UserModel> SearchUser(string userMail)
        {
            UserModel data = new UserModel
            {
                UserMail = userMail,
            };

            string sql = @"SELECT * FROM dbo.UserData WHERE UserMail = @userMail;";

            return SqlAccess.SearchData<UserModel>(sql, data);
        }

            public static List<ResultModel> LoadResults()
        {
            string sql = @"SELECT res.ResId, assign.AsName, res.Score, res.TotAsNum FROM dbo.ResultData res INNER JOIN dbo.AssignmentData assign ON res.AsId = assign.AsId;";

            return SqlAccess.LoadData<ResultModel>(sql);
        }
    }
}
