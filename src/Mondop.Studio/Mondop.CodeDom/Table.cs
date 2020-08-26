using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class Table
    {
        public string Schema { get; set; }
        public string TableName { get; set; }
        public List<Column> Columns { get; set; }
        public PrimaryKey PrimaryKey { get; set; }
        public List<ForeignKey> Keys { get; set; }
        public List<Index> Indexes { get; set; }
    }
}
