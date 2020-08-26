using Mondop.CodeDom;
using Mondop.Design.Models;
using Mondop.Design.Models.Types;

namespace Mondop.Core.Rendering.Renderers
{
    public class ClassRenderer : ICodeDomRenderer
    {
        public string Type => $"{RendererTypes.TypeDeclaration}::Mondop.System.Class";
        public IRenderLogger RenderLogger { get; set; }
        public IProjectManager ProjectManager { get; set; }

        public void Render(CodeDom.CodeObject target, DesignObject designObject)
        {
            var classDeclaration = (Class)designObject;

            var classCodeObject = new ClassDeclaration
            {
                Name = classDeclaration.Name
            };
            classCodeObject.Scope = classDeclaration.Scope.Convert();
            (target as CodeDom.Module).TypeDeclarations.Add(classCodeObject);

            foreach(var member in classDeclaration.Properties)
            {
                var propertyDeclaration = new PropertyDeclaration
                {
                    Scope = member.Scope.Convert(),
                    Name = member.Name,
                    Type = member.Type.Convert(),
                    Nullable = !member.Required,
                    ReadOnly = member.ReadOnly
                };

                classCodeObject.Properties.Add(propertyDeclaration);
            }
        }
    }
}
