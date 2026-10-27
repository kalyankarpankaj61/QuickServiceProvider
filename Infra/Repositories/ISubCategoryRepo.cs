using Core;
using Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface ISubCategoryRepo :IGeneric<SubCategory>
    {
        Task<List<SubCategoryDto>> GetByMainCategories(Int64 mainCategoryID);
    }
}
