using Mondop.Expressions;
using System.Collections.Generic;

namespace Mondop.Design.Models.DataAccess
{
    public class QueryCriteria
    {
        public List<Expression> Expression { get; set; } = new List<Expression>();
    }
}
