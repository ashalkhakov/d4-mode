using System;
using System.Linq;

using MonoDevelop.Ide.Gui.Components;

namespace MonoDevelop.D4Binding
{
    class D4ProjectNodeBuilder: NodeBuilderExtension
    {
        public override bool CanBuildNode (Type dataType)
        {
            return typeof(D4Project).IsAssignableFrom (dataType);
        }

        public override Type CommandHandlerType {
            get { return typeof(D4ProjectCommandHandler); }
        }

        public override bool HasChildNodes (ITreeBuilder builder, object dataObject)
        {
            return true;
        }
        public override void BuildChildNodes (ITreeBuilder treeBuilder, object dataObject)
        {
            var project = (D4Project)dataObject;
            //treeBuilder.AddChild (project.AddinReferences);
        }
        public override void OnNodeAdded (object dataObject)
        {
            var project = (D4Project)dataObject;
            //project.AddinReferenceAdded += OnReferencesChanged;
            //project.AddinReferenceRemoved += OnReferencesChanged;
            base.OnNodeAdded (dataObject);
        }
        public override void OnNodeRemoved (object dataObject)
        {
            var project = (D4Project)dataObject;
            //project.AddinReferenceAdded -= OnReferencesChanged;
            //project.AddinReferenceRemoved -= OnReferencesChanged;
            base.OnNodeRemoved (dataObject);
        }
        class D4ProjectCommandHandler : NodeCommandHandler
        {
        }
    }
}