using Mondop.Design.Models.Types;

namespace Mondop.Design.Models.DataAccess
{
    public class QueryJoin
    {
        public QueryJoinType Type { get; set; }
        public string Name { get; set; }
        public Collection Collection { get; set; }
        public QueryCriteria Criteria { get; set; }
    }
}
