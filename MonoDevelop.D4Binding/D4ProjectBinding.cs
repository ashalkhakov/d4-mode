using System;
using System.Xml;
using System.IO;
using MonoDevelop.Projects;

namespace MonoDevelop.D4Binding
{
    public class D4ProjectBinding : IProjectBinding
    {
        public bool CanCreateSingleFileProject(string sourceFile)
        {
            return D4LanguageBinding.IsD4File(sourceFile);
        }

        public Project CreateProject(ProjectCreateInformation info, XmlElement projectOptions)
        {
            return new D4Project(info,projectOptions);
        }

        public Project CreateSingleFileProject(string sourceFile)
        {
            // Create project information using sourceFile's path
            var info = new ProjectCreateInformation()
            {
                ProjectName = Path.GetFileNameWithoutExtension(sourceFile),
                SolutionPath = Path.GetDirectoryName(sourceFile),
                ProjectBasePath = Path.GetDirectoryName(sourceFile),
            };
            var prj = CreateProject(info, null);
            prj.AddFile(sourceFile);
            return prj;
        }

        public string Name
        {
            get { return "D4"; }
        }
    }
}

