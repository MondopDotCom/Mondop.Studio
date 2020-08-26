using Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp;
using Mondop.Guard;
using Mondop.Mockables;
using Mondop.VisualStudio.Solution;
using System;
using System.IO;
using System.Linq;

namespace Mondop.CodeGeneration.VisualStudio
{
    public interface IVisualStudioCodeGenerator
    {
        void GenerateCode(ISolutionManager solutionManager, string targetSolution);
    }

    public class VisualStudioCodeGenerator: IVisualStudioCodeGenerator
    {
        private readonly IVisualStudioProjectGenerator _projectGenerator;
        private readonly IVisualStudioSolutionManager _visualStudioSolutionManager;
        private readonly ICSharpCodeGeneratorFactory _codeGeneratorFactory;
        private readonly IProjectFileNameComposer _projectFileNameComposer;
        private readonly ICompileItemFileNameComposer _compileItemFileNameComposer;
        
        private readonly IDirectory _directory;
        
        public VisualStudioCodeGenerator(IVisualStudioProjectGenerator visualStudioProjectGenerator,
            IVisualStudioSolutionManager visualStudioSolutionManager,
            ICSharpCodeGeneratorFactory codeGeneratorFactory,
            IProjectFileNameComposer projectFileNameComposer,
            ICompileItemFileNameComposer compileItemFileNameComposer,
            IDirectory directory)
        {
            _projectGenerator = Ensure.IsNotNull(visualStudioProjectGenerator, nameof(visualStudioProjectGenerator));
            _visualStudioSolutionManager = Ensure.IsNotNull(visualStudioSolutionManager, nameof(visualStudioSolutionManager));
            _codeGeneratorFactory = Ensure.IsNotNull(codeGeneratorFactory, nameof(codeGeneratorFactory));
            _projectFileNameComposer = Ensure.IsNotNull(projectFileNameComposer, nameof(projectFileNameComposer));
            _compileItemFileNameComposer = Ensure.IsNotNull(compileItemFileNameComposer, nameof(compileItemFileNameComposer));
            _directory = Ensure.IsNotNull(directory, nameof(directory));
        }

        private void CreateProjectConfigurationPlatforms(VisualStudioSolution solution, Guid projectId)
        {
            var solutionConfigurationPlatforms = solution.Global.Sections.FirstOrDefault(x => x.Name.Equals("SolutionConfigurationPlatforms"));
            if (solutionConfigurationPlatforms == null)
                return;

            var projectConfigurationPlatforms = solution.Global.Sections.FirstOrDefault(x => x.Name.Equals("ProjectConfigurationPlatforms"));
            if (projectConfigurationPlatforms == null)
            {
                var index = solution.Global.Sections.IndexOf(solutionConfigurationPlatforms);

                projectConfigurationPlatforms = new GlobalSection
                {
                    Name = "ProjectConfigurationPlatforms",
                    SectionType = "postSolution"
                };

                solution.Global.Sections.Insert(index + 1, projectConfigurationPlatforms);
            }

            projectConfigurationPlatforms.Items.AddRange(
                solutionConfigurationPlatforms.Items.Select(x => new GlobalSectionItem
                {
                    Name = $"{projectId.ToString("B").ToUpperInvariant()}.{x.Name}",
                    Value = x.Value
                }
                ));
        }

        public VisualStudioSolutionProject NewProject(VisualStudioSolution solution, string name, Guid typeId,
            string outputType, string projectFolder, string rootNamespace, string targetFramework)
        {
            var solutionProject = new VisualStudioSolutionProject
            {
                Name = name,
                Solution = solution,
                FileName = _projectFileNameComposer.Compose(solution.SolutionFolder, projectFolder,name,typeId),
                ProjectGuid = Guid.NewGuid(),
                TypeGuid = typeId
            };
            solution.Projects.Add(solutionProject);

            CreateProjectConfigurationPlatforms(solution, solutionProject.ProjectGuid);

            _projectGenerator.CreateNewProject(solutionProject, outputType, rootNamespace, targetFramework);
            _projectGenerator.AddBuildConfigurations(solutionProject.Project);

            return solutionProject;
        }

        private VisualStudioSolutionProject ResolveProject(VisualStudioSolution solution, MondopAssembly assembly)
        {
            VisualStudioSolutionProject project = solution.Projects.FirstOrDefault(
                x => x.Name.Equals(assembly.Name));

            if (project != null)
                return project;

            project = NewProject(solution, assembly.Name, Guid.Parse(VisualStudioSolutionProjectTypeIds.CsProjectGuid), "Library",
                assembly.Folder, assembly.Namespace, "4.6.2");

            return project;
        }

        private VisualStudioProjectNode ResolveProjectNode(VisualStudioSolutionProject project, CompileUnit compileUnit)
        {
            var relativeFileName = _compileItemFileNameComposer.ComposeFileName(compileUnit.Name,project.TypeGuid);

            var node = _projectGenerator.GetCompileItem(project.Project, relativeFileName);

            if (node == null)
            {
                node = _projectGenerator.AddCompileItem(project.Project, relativeFileName);
            }

            return node;
        }

        private string GenerateCode(CompileUnit compileUnit)
        {
            _codeGeneratorFactory.Writer.Reset();
            var codeGenerator = _codeGeneratorFactory.GetCodeGenerator(compileUnit);
            codeGenerator.GenerateCode(compileUnit, _codeGeneratorFactory);

            return _codeGeneratorFactory.Writer.GeneratedCode;

        }

        public void GenerateCode(CodeDom.Project project, string targetSolution)
        {
            if (!_directory.Exists(Path.GetDirectoryName(targetSolution)))
                _directory.CreateDirectory(Path.GetDirectoryName(targetSolution));

            VisualStudioSolution solution = null;
            if (File.Exists(targetSolution))
                solution = _visualStudioSolutionManager.Load(targetSolution, true);
            else
                solution = _visualStudioSolutionManager.CreateNew(targetSolution);


            foreach (var module in project.Modules)
            {
                foreach (var typeDeclaration in module.TypeDeclarations)
                {
                    var vsProject = ResolveProject(solution, typeDeclaration);
                    var vsProjectNode = ResolveProjectNode(vsProject, compileUnit);
                    var data = GenerateCode(compileUnit);

                    vsProjectNode.GeneratedData = data;
                }

                _projectGenerator.AddBuildTargets(vsProject);
            }

            foreach(var application in project.Applications)
            {

            }

            _visualStudioSolutionManager.Save(solution);
        }
    }
}
