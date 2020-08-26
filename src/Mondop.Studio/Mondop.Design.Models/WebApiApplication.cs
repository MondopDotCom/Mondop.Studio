using Mondop.Design.Models.Api;
using System.Collections.Generic;

namespace Mondop.Design.Models
{
    public class WebApiApplication: Application
    {
        public List<WebApiController> Controllers { get; set; }
    }
}
