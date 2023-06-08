using System.Collections.Generic;
using System.Text;
using AdvancedStringBuilder;
using Statiq.Common;

namespace Docs.src.Shortcodes
{
    public class TabShortcode : SyncShortcode
    {
        public override ShortcodeResult Execute(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            var information = TabInformation.ParseArguments(args);

            var classSb = new StringBuilder("tab-pane fade");

            if (information.Active)
            {
                classSb.Append(" show active");
            }

            if (information.AllowMultiple)
            {
                classSb.Append(" " + information.Target.TrimStart('.'));
            }

            var div = new StringBuilder()
                .AppendLine()
                .AppendLine("<div")
                .AppendFormat(" class=\"{0}\"", classSb)
                .AppendFormat(" id=\"{0}\"", information.Id)
                .Append(" role=\"tabpanel\"")
                .AppendFormatLine(" aria-labelledby=\"{0}\">", information.LinkId)
                .AppendLine(content)
                .AppendLine("</div>");

            return div.ToString();
        }
    }
}
