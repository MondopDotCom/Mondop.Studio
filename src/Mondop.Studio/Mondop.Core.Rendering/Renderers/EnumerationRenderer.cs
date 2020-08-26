using Mondop.CodeDom;
using Mondop.Design.Models;
using Mondop.Design.Models.Types;

namespace Mondop.Core.Rendering.Renderers
{
    public class RenderEnumDeclarationEventArgs
    {
        public EnumerationDeclaration Declaration { get; set; }
    }

    public class RenderEnumMemberDeclarationEventArgs
    {
        public EnumMemberDeclaration Declaration { get; set; }
    }

    public delegate void RenderEnumDeclarationEventHander(object sender, RenderEnumDeclarationEventArgs args);
    public delegate void RenderEnumMemberDeclarationEventHandler(object sender, RenderEnumMemberDeclarationEventArgs args);

    public class EnumerationRenderer : ICodeDomRenderer
    {
        protected virtual void OnRenderEnumDeclaration(EnumerationDeclaration declaration)
        {
            RenderEnumDeclaration?.Invoke(this, new RenderEnumDeclarationEventArgs { Declaration = declaration });
        }

        protected virtual void OnAfterRenderEnumDeclaration(EnumerationDeclaration declaration)
        {
            AfterRenderEnumDeclaration?.Invoke(this, new RenderEnumDeclarationEventArgs { Declaration = declaration });
        }

        protected virtual void OnRenderEnumMemberDeclaration(EnumMemberDeclaration declaration)
        {
            RenderEnumMemberDeclaration?.Invoke(this, new RenderEnumMemberDeclarationEventArgs { Declaration = declaration });
        }

        public void Render(CodeDom.CodeObject target, DesignObject designObject)
        {
            var enumeration = (Enumeration)designObject;

            var enumCodeObject = new EnumerationDeclaration
            {
                Name = enumeration.Name
            };
            (target as CodeDom.Module).TypeDeclarations.Add(enumCodeObject);
            enumCodeObject.Scope = enumeration.Scope.Convert();

            OnRenderEnumDeclaration(enumCodeObject);

            foreach (var member in enumeration.Values)
            {
                var memberDeclaration = new EnumMemberDeclaration
                {
                    Name = member.Name,
                    Value = member.Value
                };

                OnRenderEnumMemberDeclaration(memberDeclaration);

                enumCodeObject.Values.Add(memberDeclaration);
            }

            OnAfterRenderEnumDeclaration(enumCodeObject);
        }

        public event RenderEnumDeclarationEventHander RenderEnumDeclaration;
        public event RenderEnumDeclarationEventHander AfterRenderEnumDeclaration;
        public event RenderEnumMemberDeclarationEventHandler RenderEnumMemberDeclaration;

        public IRenderLogger RenderLogger { get; set; }
        public IProjectManager ProjectManager { get; set; }
        public string Type => $"{RendererTypes.TypeDeclaration}::Mondop.System.Enum";
    }
}
