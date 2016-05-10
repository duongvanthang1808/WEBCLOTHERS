﻿using ProjectClothers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ProjectClothers.Common
{
    public class CustomPrincipal : IPrincipal
    {
        private User user;
        public CustomPrincipal(User user)
        {
            this.user = user;
            this.Identity = new GenericIdentity(user.Username);
        }
        public IIdentity Identity { get; set; }
        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.user.GroupID.Contains(r));
        }

    }
}