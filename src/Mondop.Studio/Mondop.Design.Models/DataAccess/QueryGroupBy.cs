using System.Collections.Generic;

namespace Mondop.Design.Models.DataAccess
{
    public class QueryGroupBy
    {
        public List<QueryGroupByField> Fields { get; set; } = new List<QueryGroupByField>();
    }
}
