using Mondop.Expressions;

namespace Mondop.Design.Models.DataAccess
{
    public class QuerySelectField
    {
        public string Name { get; set; }
        public Expression Expression { get; set; }
    }
}
