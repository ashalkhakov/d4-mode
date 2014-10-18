using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Projects;

namespace MonoDevelop.D4Binding
{
    class D4Project : DotNetProject
    {
        public D4Project() {
            // nothing
        }

        public D4Project(ProjectCreateInformation info, XmlElement options) : base("D4", info, options) {

        }

        public override SolutionItemConfiguration CreateConfiguration (string name)
        {
            var cfg = new D4ProjectConfiguration (name);
            cfg.CopyFrom (base.CreateConfiguration (name));
            return cfg;
        }
        /*
        protected override ExecutionCommand CreateExecutionCommand (ConfigurationSelector configSel, DotNetProjectConfiguration configuration)
        {
            var cmd = (DotNetExecutionCommand) base.CreateExecutionCommand (configSel, configuration);
            cmd.Command = Assembly.GetEntryAssembly ().Location;
            cmd.Arguments = "--no-redirect";
            cmd.EnvironmentVariables["MONODEVELOP_DEV_ADDINS"] = GetOutputFileName (configSel).ParentDirectory;
            cmd.EnvironmentVariables ["MONODEVELOP_CONSOLE_LOG_LEVEL"] = "All";
            return cmd;
        }

        protected override bool OnGetCanExecute (ExecutionContext context, ConfigurationSelector configuration)
        {
            return true;
        }*/

        public override bool IsLibraryBasedProjectType {
            get { return true; }
        }
    }
}