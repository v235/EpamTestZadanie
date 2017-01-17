using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;
using AutoAuction.DAL.Repositories;
using AutoAuction.Util;


namespace AutoAuction.Providers
{
    public class CustomerRoleProvider : RoleProvider
    {
        private IUnitofWork dataBase
        {
            get { return DependencyResolver.Current.GetService<IUnitofWork>();}
        }
        public override string[] GetRolesForUser(string customerName)
        {
            string[] role = new string[] { };
            // Получаем пользователя
            var customer = dataBase.Customers.GetByName(customerName);
            if (customer != null)
            {
                // получаем роль
                CustomerRole customerRole = dataBase.CustomerRoles.Get(customer.RoleId);
                if (customerRole != null)
                    role = new string[] { customerRole.RoleName };
            }
            return role;
        }
        public override void CreateRole(string roleName)
        {
            CustomerRole newRole = new CustomerRole() { RoleName = roleName };

            dataBase.CustomerRoles.Create(newRole);
            dataBase.Save();
        }
        public override bool IsUserInRole(string customerName, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            var customer = dataBase.Customers.GetByName(customerName);
            if (customer != null)
            {
                // получаем роль
                CustomerRole customerRole = dataBase.CustomerRoles.Get(customer.RoleId);
                //сравниваем
                if (customerRole != null && customerRole.RoleName == roleName)
                    outputResult = true;
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}