using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.SearchService
{
    public interface ISearchRepository
    {
        Task<(bool IsSuccess, dynamic Result, string ShowErrorMessage)> SearchAsync(int CustomerId);
    }
}
