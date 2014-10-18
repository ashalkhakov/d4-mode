using System;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace MonoDevelop.D4Binding
{
    public class D4LanguageBinding : IDotNetLanguageBinding
    {
        public string BlockCommentEndTag
        {
            get { return "*/"; }
        }

        public string BlockCommentStartTag
        {
            get { return "/*"; }
        }

        public string Language
        {
            get { return "D4"; }
        }

        public string SingleLineCommentTag
        {
            get { return "//"; }
        }

        public FilePath GetFileName(FilePath fileNameWithoutExtension)
        {
            return fileNameWithoutExtension.ChangeExtension(".d4");
        }

        public static bool IsD4File(string fileName)
        {
            return fileName.EndsWith(".d4", System.StringComparison.OrdinalIgnoreCase);
        }

        public bool IsSourceCodeFile(FilePath fileName)
        {
            return IsD4File(fileName);
        }

        public BuildResult Compile(ProjectItemCollection items, DotNetProjectConfiguration configuration, ConfigurationSelector configSelector, IProgressMonitor monitor) {
            return new BuildResult("failed", 1, 1);
        }

        public ConfigurationParameters CreateCompilationParameters(XmlElement projectOptions) {
            return new UnknownCompilationParameters();
        }

        public ProjectParameters CreateProjectParameters(XmlElement projectOptions) {
            return new ProjectParameters();
        }

        public System.CodeDom.Compiler.CodeDomProvider GetCodeDomProvider() {
            return null;
        }

        public ClrVersion[] GetSupportedClrVersions() {
            return new[]{ ClrVersion.Net_4_0 };
        }
            
        public string ProjectStockIcon {
            get { return "md-project"; }
        }
    }
}

