using System.Collections.Generic;
using System.Linq;

namespace T4TemplatesInPractice
{
    public class ColumnsMapping
    {
        public string Target { get; private set; }
        public string Source { get; private set; }

        public ColumnsMapping(string target, string source)
        {
            Target = target;
            Source = source;
        }
    }

    public class ColumnsMappingCollection : List<ColumnsMapping>
    {
        public string SourceList
        {
            get { return string.Join(", ", this.Select(map => map.Source)); }
        }

        public string TargeteList
        {
            get { return string.Join(", ", this.Select(map => map.Target)); }
        }
    }
}
