using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Common;
using Statiq.Common;

namespace Docs.src.Shortcodes
{
    public class TabInformation
    {
        public bool Active { get; set; }
        public bool AllowMultiple { get; set; }
        public string Id { get; set; }
        public string LinkId { get; set; }
        public bool NoHash { get; set; }
        public string Target { get; set; }
        public string Title { get; set; }

        internal static TabInformation ParseArguments(KeyValuePair<string, string>[] args)
        {
            var arguments = args.ToDictionary(nameof(Active), nameof(AllowMultiple), nameof(Id), nameof(Target), nameof(Title), nameof(NoHash));
            var information = new TabInformation
            {
                AllowMultiple = arguments.GetBool(nameof(AllowMultiple), defaultValue: false),
                Active = arguments.GetBool(nameof(Active)),
                NoHash = arguments.GetBool(nameof(NoHash), false)
            };

            if (information.AllowMultiple)
            {
                arguments.RequireKeys(nameof(Title), nameof(Id));
            }
            else
            {
                arguments.RequireKeys(nameof(Title));
            }

            information.Title = arguments.GetString(nameof(Title));

            var baseId = GenerateIdentifier(information.Title);

            information.Id = arguments.GetString(nameof(Id), baseId);

            if (information.Id != baseId)
            {
                information.Id = GenerateIdentifier(information.Id);
            }

            information.LinkId = information.Id + "-tab";

            // When supported, the id should be baseId when AllowMultiple is used.
            var targetId = information.Id;

            information.Target = arguments.GetString(nameof(Target), targetId);

            if (information.Target != targetId)
            {
                information.Target = GenerateIdentifier(information.Target);
            }
            
            if (information.AllowMultiple)
            {
                information.Target = "." + information.Target;
            }
            else
            {
                information.Target = "#" + information.Target;
            }

            return information;
        }

        private static string GenerateIdentifier(in ReadOnlySpan<char> title)
        {
            Span<char> newId = stackalloc char[title.Length];

            var previousDash = true;

            var length = 0;

            for (int i = 0; i < title.Length; i++)
            {
                if (char.IsLetterOrDigit(title[i]))
                {
                    newId[length] = char.ToLowerInvariant(title[i]);
                    previousDash = false;
                    length++;
                }
                else if (!previousDash)
                {
                    newId[length] = '-';
                    previousDash = true;
                    length++;
                }
            }

            if (previousDash)
            {
                return new string(newId[..(length - 1)]);
            }
            else
            {
                return new string(newId[..length]);
            }
        }
    }
}
