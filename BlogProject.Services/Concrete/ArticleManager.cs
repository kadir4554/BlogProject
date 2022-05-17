using BlogProject.Data.Abstract;
using BlogProject.Entities.Dtos;
using BlogProject.Services.Abstract;
using BlogProject.Shared.Utilities.Results.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using BlogProject.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
  
        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article =await _unitOfWork.Articles.GetAsync(a=>a.Id == articleId,a=>a.User,a =>a.Category);
            if (article!=null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article=article,
                    ResultStatus=ResultStatus.Success,
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, message: "Böyle bir makale bulunamadı.",null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles=await _unitOfWork.Articles.GetAllAsync(null,a=>a.User,a=>a.Category);
            if (articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles=articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result) { 
            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && a.IsDeleted && a.IsActive,
                a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success,
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı.", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Böyle bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync( a => a.IsDeleted, a => a.User,a=>a.Category);
            if (articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success,new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus=ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive,a=>a.User,a=>a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı.", null);
        }

        public Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int articleId)
        {
            throw new NotImplementedException();
        }

    }
}
