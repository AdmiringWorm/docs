using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Statiq.Common;

namespace Docs.src.Shortcodes
{
    public class TabContainerShortcode : SyncMultiShortcode
    {
        private const string NoHash = nameof(TabInformation.NoHash);

        public override IEnumerable<ShortcodeResult> Execute(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            var linkContainer = new XElement(
                "ul",
                new XAttribute("class", "nav nav-tabs"),
                new XAttribute("role", "tablist"));

            const string ExpectedShortcode = "<?# Tab ";
            var array = content.Split('\r', '\n');

            var arguments = args.ToDictionary(NoHash);
            var noHash = arguments.GetBool(NoHash, false);

            for (int i = 0; i < array.Length; i++)
            {
                var link = array[i];
                var start = link.IndexOf(ExpectedShortcode);

                if (start < 0)
                {
                    continue;
                }

                start += ExpectedShortcode.Length;
                var end = link.LastIndexOf("?>");

                var splitArguments = ShortcodeHelper.SplitArguments(link[..end], start)
                    .ToList();

                if (!splitArguments.Any(a => string.Equals(a.Key, NoHash)))
                {
                    splitArguments.Add(new KeyValuePair<string, string>(NoHash, noHash.ToString()));
                }

                var information = TabInformation.ParseArguments(splitArguments.ToArray());

                var li = new XElement(
                    "li",
                    new XAttribute("class", "nav-item"));

                var classNames = new StringBuilder("nav-link");

                if (information.Active)
                {
                    classNames.Append(" active");
                }

                if (information.NoHash)
                {
                    classNames.Append(" d-hash-none");
                }

                var a = new XElement(
                    information.AllowMultiple ? "button" : "a",
                    new XAttribute("class", classNames.ToString()),
                    new XAttribute("id", information.LinkId),
                    new XAttribute("data-bs-toggle", "tab"),
                    new XAttribute(information.AllowMultiple ? "data-bs-target" : "href", information.Target),
                    new XAttribute("role", "tab"),
                    new XAttribute("aria-controls", information.Id),
                    new XAttribute("aria-selected", information.Active),
                    information.Title);

                li.Add(a);
                linkContainer.Add(li);
            }

            var sb = new StringBuilder()
                .AppendLine("<div class=\"tab-content text-bg-theme-elevation-1 p-3 mb-3 border-start border-end border-bottom rounded-bottom\">")
                .AppendLine(content)
                .AppendLine("</div>");

            return new[]
            {
                new ShortcodeResult(linkContainer.ToString()),
                new ShortcodeResult(sb.ToString())
            };
        }
    }
}
