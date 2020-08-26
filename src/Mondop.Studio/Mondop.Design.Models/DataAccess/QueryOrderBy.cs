using System;
using System.Collections.Generic;
using System.Text;

namespace Mondop.Design.Models.DataAccess
{
    public class QueryOrderBy
    {
        public List<QueryOrderByField> Fields { get; set; } = new List<QueryOrderByField>();
    }
}
