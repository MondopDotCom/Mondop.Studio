using Mondop.CodeDom;
using Mondop.Guard;
using System.Linq;

namespace Mondop.Core.Rendering
{
    public interface IProjectManager
    {
        Database GetDatabase(string name);
    }

    public class ProjectManager: IProjectManager
    {
        private readonly Project project;

        public ProjectManager(Project project)
        {
            this.project = Ensure.IsNotNull(project, nameof(project));
        }

        public Database GetDatabase(string name)
        {
            return project.Databases.SingleOrDefault(d => d.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
