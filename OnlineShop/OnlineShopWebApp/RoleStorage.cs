using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Areas.Admin.Models;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class RoleStorage : IRoleStorage
    {
        private const string ROLES = @"Data/Roles.xml";
        private List<Role> _roles = new List<Role>();

        public Role TryGetRoleByName(string name)
        {
            var role = _roles.FirstOrDefault(role => role.Name == name);
            return role;
        }

        public List<Role> GetAll()
        {
            var xDoc = XDocument.Load(ROLES);
            _roles = xDoc.Element("roles")
                               .Elements("role")
                               .Select(role => new Role(
                                       role.Element("name").Value)).ToList();
            return _roles;
        }

        public void Add(string name)
        {
            var xDoc = XDocument.Load(ROLES);
            var root = xDoc.Element("roles");
            root.Add(new XElement("role",
                         new XElement("name", name)));

            xDoc.Save(ROLES);
        }

        public void Remove(string name)
        {
            var xDoc = XDocument.Load(ROLES);
            var root = xDoc.Element("roles");

            var role = root.Elements("role")
                              .FirstOrDefault(role => role.Element("name").Value == name);

            role.Remove();
            xDoc.Save(ROLES);
        }

        public void Edit(string oldName, Role role)
        {
            var xDoc = XDocument.Load(ROLES);
            var editRole = xDoc.Element("roles")
                              .Elements("role")
                              .FirstOrDefault(role => role.Element("name").Value == oldName);

            var name = editRole.Element("name");
            name.Value = role.Name;

            xDoc.Save(ROLES);
        }
    }
}
