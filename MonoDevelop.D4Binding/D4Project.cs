using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Core.ProgressMonitoring;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace MonoDevelop.D4Binding
{
    public class D4Project : Project, ICustomDataItem
    {
        #region Properties
        public override string[] SupportedLanguages
        {
            get
            {
                return new[]{ "D4", "" };
            }
        }
        public override string[] SupportedPlatforms
        {
            get
            {
                return new[]{ "AnyCPU" };
            }
        }
        public override string ProjectType
        {
            get
            {
                return "d4";
            }
        }

        public override string ToString ()
        {
            return string.Format ("[D4Project: Name={0}]", Name);
        }
        #endregion

        #region Init
        public D4Project (){
        }

        public D4Project (ProjectCreateInformation info, XmlElement projectOptions)
        {
            if (info != null) {
                Name = info.ProjectName;

                BaseDirectory = info.ProjectBasePath;
            }

            if (projectOptions != null)
            {
            }

            var libs = new List<string> ();
            if (projectOptions != null) {
                foreach (XmlNode lib in projectOptions.GetElementsByTagName("Lib"))
                    if (!string.IsNullOrWhiteSpace (lib.InnerText))
                        libs.Add (lib.InnerText);
            }

            // Create a debug configuration
            var cfg = CreateConfiguration ("Debug") as ProjectConfiguration;
            DefaultConfiguration = cfg;

            cfg.DebugMode = true;
            cfg.ExternalConsole = true;

            Configurations.Add (cfg);

            // Create a release configuration
            cfg = CreateConfiguration ("Release") as ProjectConfiguration;

            cfg.DebugMode = false;

            Configurations.Add (cfg);
        }
        #endregion

        #region Build Configurations
        public override SolutionItemConfiguration CreateConfiguration (string name)
        {
            var c = new ProjectConfiguration() { Name=name };
            if (name.Contains("|"))
            {
                c.Platform = name.Substring(name.LastIndexOf('|') + 1);
                name = name.Substring(0, name.IndexOf('|'));
            }

            return c;           
        }
        #endregion

        #region Building
        public override bool IsCompileable (string fileName)
        {
            return D4LanguageBinding.IsD4File (fileName);
        }

        /// <summary>
        /// Returns the absolute file name + path to the link target
        /// </summary>
        public override FilePath GetOutputFileName (ConfigurationSelector configuration)
        {
            var cfg = GetConfiguration (configuration) as ProjectConfiguration;

            return cfg.OutputDirectory.ToAbsolute(BaseDirectory);
        }
        #endregion

        public void Deserialize (ITypeSerializer handler, DataCollection data)
        {
            handler.Deserialize (this, data);
        }
        public DataCollection Serialize (ITypeSerializer handler)
        {
            var ret = handler.Serialize (this);
            return ret;
        }
    }
}

