using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Mono.TextEditor;
using Mono.TextEditor.Highlighting;

namespace MonoDevelop.D4Binding
{
    public class D4SyntaxMode : SyntaxMode, IDisposable
    {
        static SyntaxMode _baseMode;

        public D4SyntaxMode()
        {
            var matches = new List<Match>();

            if (_baseMode == null)
            {
                var provider = new ResourceStreamProvider(
                    typeof(D4SyntaxMode).Assembly,
                    typeof(D4SyntaxMode).Assembly.GetManifestResourceNames().First(s => s.Contains("D4SyntaxMode")));
                using (Stream s = provider.Open())
                    _baseMode = SyntaxMode.Read(s);
            }

            this.rules = new List<Rule>(_baseMode.Rules);
            this.keywords = new List<Keywords>(_baseMode.Keywords);
            this.spans = new List<Span>(_baseMode.Spans).ToArray();
            matches.AddRange(_baseMode.Matches);
            this.prevMarker = _baseMode.PrevMarker;
            this.SemanticRules = new List<SemanticRule>(_baseMode.SemanticRules);
            this.keywordTable = _baseMode.keywordTable;
            this.keywordTableIgnoreCase = _baseMode.keywordTableIgnoreCase;
            this.properties = _baseMode.Properties;
            this.matches = matches.ToArray();
        }

        public virtual void Dispose() {
            // nothing as of yet
        }
    }
}

