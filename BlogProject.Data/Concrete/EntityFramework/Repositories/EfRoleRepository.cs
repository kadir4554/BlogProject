﻿using BlogProject.Data.Abstract;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfRoleRepository:EfEntityRepositoryBase<Role>,IRoleRepository
    {
        public EfRoleRepository(DbContext context):base(context)
        {

        }
    }
}
