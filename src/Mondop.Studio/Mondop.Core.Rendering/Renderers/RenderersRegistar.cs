using Mondop.Guard;

namespace Mondop.Core.Rendering.Renderers
{

    public class DefaultRenderersRegistar: IRenderersRegistar
    {
        private readonly IRenderersFactory _renderersFactory;
         
        public DefaultRenderersRegistar(IRenderersFactory renderersFactory)
        {
            _renderersFactory = Ensure.IsNotNull(renderersFactory, nameof(renderersFactory));
        }

        public void Register()
        {
            _renderersFactory.Register(new EnumerationRenderer());
            _renderersFactory.Register(new ClassRenderer());
            _renderersFactory.Register(new EntityRenderer());
            _renderersFactory.Register(new InterfaceRenderer());
        }
    }
}
