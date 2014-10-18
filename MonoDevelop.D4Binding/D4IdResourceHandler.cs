using System;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Formats.MSBuild;

namespace MonoDevelop.D4Binding {
    public class D4ResourceIdBuilder : MSBuildResourceHandler {
        public override string GetDefaultResourceId(ProjectFile pf) {
            return base.GetDefaultResourceId(pf);
        }
    }
}


