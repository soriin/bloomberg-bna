using log4net;
using System.Collections.Generic;

namespace bnaApi.data.repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private static ILog _logger;
        private bloombergEntities _context;

        public CategoryRepository(bloombergEntities context)
        {
            _logger = LogManager.GetLogger(this.GetType().FullName);
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
