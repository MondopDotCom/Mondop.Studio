using Mondop.Design.Models;
using Mondop.Design.Models.Types;
using Mondop.Guard;
using System;
using System.Collections.Generic;

namespace Mondop.Core.Rendering.Renderers
{
    public class RenderersFactory: IRenderersFactory
    {
        private readonly Dictionary<string, ICodeDomRenderer> _renderers = new Dictionary<string, ICodeDomRenderer>();

        private readonly IRenderLogger _renderLogger;
        private readonly IProjectManager _projectManager;

        public RenderersFactory(IRenderLogger renderLogger, IProjectManager projectManager)
        {
            _renderLogger = Ensure.IsNotNull(renderLogger, nameof(renderLogger));
            _projectManager = Ensure.IsNotNull(projectManager, nameof(projectManager));
        }

        public ICodeDomRenderer GetRenderer(DesignObject objectToRender)
        {
            var result = ResolveRenderer(objectToRender);
            if (result == null)
                throw new InvalidOperationException($"Unable to resolve renderer for object: {objectToRender}");

            return result;
        }

        public void Register(ICodeDomRenderer renderer, bool replaceExisting = false)
        {
            renderer.RenderLogger = _renderLogger;
            renderer.ProjectManager = _projectManager;

            if (_renderers.ContainsKey(renderer.Type))
            {
                if (!replaceExisting)
                    throw new InvalidOperationException("Can not register renderer because it is already registered. " +
                        "Use replaceExisting=true to replace an already registered renderer.");

                _renderers[renderer.Type] = renderer;
            }
            else
                _renderers.Add(renderer.Type, renderer);
        }

        private string GetRendererType(DesignObject objectToRender)
        {
            if (objectToRender is TypeDeclaration)
                return RendererTypes.TypeDeclaration;

            throw new InvalidOperationException($"Unable to resolve renderer type for object: {objectToRender}");
        }

        private ICodeDomRenderer ResolveRenderer(DesignObject objectToRender)
        {
            var rendererName = $"{GetRendererType(objectToRender)}::{objectToRender.QualifiedName}";

            if (_renderers.ContainsKey(rendererName))
                return _renderers[rendererName];

            if(objectToRender is TypeDeclaration typeDeclaration)
            {
                if (typeDeclaration.Extends != null)
                    return ResolveRenderer(typeDeclaration.Extends.Reference);
            }

            throw new InvalidOperationException($"Unable to resolve renderer for object: {objectToRender}");
        }
    }
}
