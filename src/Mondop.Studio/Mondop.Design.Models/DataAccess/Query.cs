using System.Collections.Generic;

namespace Mondop.Design.Models.DataAccess
{
    public class Query: DesignObject
    {
        public QuerySelect Select { get; set; }
        public QueryFrom From { get; set; }
        public List<QueryJoin> Joins { get; set; }
        public List<QueryCriteria> Criteria { get; set; }
        public QueryGroupBy GroupBy { get; set; }
        public QueryOrderBy OrderBy { get; set; }
    }
}
