using System.Collections.Generic;

namespace bnaApi.data.repos
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}
