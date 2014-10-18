using System;
using System.IO;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace MonoDevelop.D4Binding {
    public class D4ProjectServiceExtension : ProjectServiceExtension {
        public override bool SupportsItem(IBuildTarget item)
        {
            // Extend any D4 project
            return (item is DotNetProject) && (item as DotNetProject).LanguageName == "D4";
        }
    }
}
