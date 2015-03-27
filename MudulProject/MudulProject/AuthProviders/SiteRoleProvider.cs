using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Web.Security;

namespace MudulProject.AuthProviders
{
    public class SiteRoleProvider : RoleProvider
    {
        private int _cacheTimeoutInMinutes = 30;

        public override void Initialize(string name, NameValueCollection config)
        {
            int val;

            if (!string.IsNullOrEmpty(config["cacheTimeoutInMinutes"]) &&
                Int32.TryParse(config["cacheTimeoutInMinutes"], out val))
                _cacheTimeoutInMinutes = val;

            base.Initialize(name, config);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = new List<string>(GetRolesForUser(username));

            return userRoles.Contains(roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            const string sqlRolesForUser = @"
SELECT b.Description
  FROM RolesXUsers a inner join Roles b on a.RoleId = b.Id
 WHERE Username = @username
ORDER BY RoleId";

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;

            var cacheKey = string.Format(ConfigurationManager.AppSettings["cacheKey"], username);

           /* if (HttpRuntime.Cache[cacheKey] != null && HttpRuntime.Cache[cacheKey].ToString() != "")
            {
                return new HttpRuntime.Cache[cacheKey]y();
            }*/

            var userRoles = new List<string> { };

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MoodleConnection"].ToString()))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlRolesForUser;
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userRoles.Add(reader[0].ToString());
                        }

                        reader.Close();
                    }

                    command.Dispose();
                }

                connection.Close();
            }

            HttpRuntime.Cache.Insert(cacheKey, userRoles, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);

            return userRoles.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}