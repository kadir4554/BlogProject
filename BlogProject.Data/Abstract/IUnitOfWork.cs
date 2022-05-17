using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Articles { get; }//unitofwork.Articles
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }//_unitofwork.Categories.AddAsync();
        //_unitofwork.Users.AddAsync(user);
        //_unitofwork.Categories.AddAsync(category);
        //_unitofwork.SaveAsync();
        Task<int> SaveAsync();
    }
}
