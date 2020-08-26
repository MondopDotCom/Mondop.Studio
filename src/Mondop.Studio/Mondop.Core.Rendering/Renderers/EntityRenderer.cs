using Mondop.CodeDom;
using Mondop.Design.Models;
using Mondop.Design.Models.Types;
using Mondop.Guard;
using System.Linq;

namespace Mondop.Core.Rendering.Renderers
{
    public class EntityRenderer : ICodeDomRenderer
    {
        public string Type => $"{RendererTypes.TypeDeclaration}::Mondop.System.Entity";
        public IRenderLogger RenderLogger { get; set; }
        public IProjectManager ProjectManager { get; set; }

        public void Render(CodeDom.CodeObject target, DesignObject designObject)
        {
            var module = Ensure.Is<CodeDom.Module>(target, nameof(target));

            var entityDeclaration = Ensure.Is<Entity>(designObject,nameof(designObject));
            RenderPoco(module, entityDeclaration);
                        
            var database = ProjectManager.GetDatabase(entityDeclaration.Database);

            RenderTable(database, entityDeclaration);
            RenderRepository(database, entityDeclaration);
        }

        private void RenderPoco(CodeDom.Module target, Entity entityDeclaration)
        {
            var entity = new EntityDeclaration
            {
                Name = entityDeclaration.Name
            };
            entity.Scope = entityDeclaration.Scope.Convert();
            target.TypeDeclarations.Add(entity);

            foreach (var member in entityDeclaration.Properties)
            {
                var entityField = new EntityField();
                entityField.Scope = member.Scope.Convert();
                entityField.Name = member.Name;
                entityField.Type = member.Type.Convert();
                entityField.Required = member.Required;
                entityField.ReadOnly = member.ReadOnly;

                entity.Fields.Add(entityField);
            }
        }

        private void RenderTable(CodeDom.Database database, Entity entityDeclaration)
        {
            var table = database.Tables.SingleOrDefault(x => x.Schema.Equals(entityDeclaration.Schema) &&
            x.TableName.Equals(entityDeclaration.TableName));

           if(table==null)
            {
                table = new Table
                {
                    Schema = entityDeclaration.Schema,
                    TableName = entityDeclaration.TableName
                };
                database.Tables.Add(table);
            }
        }

        private void RenderRepository(CodeDom.Database database, Entity entityDeclaration)
        {
            RenderInsert(database,entityDeclaration);
            RenderUpdate(database,entityDeclaration);
            RenderDelete(database,entityDeclaration);
        }

        private void RenderInsert(CodeDom.Database database, Entity entity)
        {
            var insertCommand = new InsertDatabaseCommand
            {
                Schema = entity.Schema,
                TableName = entity.TableName,
                AutoInsertType= true,
                Type = new CodeDom.TypeReference { Namespace = entity.Namespace, Type = entity.Name}
            };
            database.Commands.Add(insertCommand);
        }

        private void RenderUpdate(CodeDom.Database database, Entity entity)
        {
            var updateCommand = new UpdateDatabaseCommand
            {
                Schema = entity.Schema,
                TableName = entity.TableName,
                AutoUpdateType = true,
                Type = new CodeDom.TypeReference { Namespace = entity.Namespace, Type = entity.Name }
            };
            database.Commands.Add(updateCommand);
        }

        private void RenderDelete(CodeDom.Database database, Entity entity)
        {
            var deleteCommand = new DeleteDatabaseCommand
            {
                Schema = entity.Schema,
                TableName = entity.TableName,
                AutoDeleteType = true,
                Type = new CodeDom.TypeReference { Namespace = entity.Namespace, Type = entity.Name }
            };
            database.Commands.Add(deleteCommand);
        }
    }
}
