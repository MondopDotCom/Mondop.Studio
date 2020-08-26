using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class Database
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; }
        public List<DatabaseQuery> Queries { get; set; }
        public List<DatabaseCommand> Commands { get; set; }
    }
}
