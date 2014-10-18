using System;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace MonoDevelop.D4Binding
{
    public class D4LanguageBinding : ILanguageBinding
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
    }
}

