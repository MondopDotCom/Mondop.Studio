using System.Collections.Generic;

namespace Mondop.Design.Models.DataAccess
{
    public class QuerySelect
    {
        public List<QuerySelectField> Fields { get; set; } = new List<QuerySelectField>();
    }
}
