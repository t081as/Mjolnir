// The MIT License (MIT)
//
// Copyright © 2017-2020 Tobias Koch
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the “Software”), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using LibGit2Sharp;

namespace Mjolnir.Build.VCS
{
    /// <summary>
    /// Contains tasks generating a version number based on annotated git tags.
    /// </summary>
    public static class GitVersionTasks
    {
        /// <summary>
        /// Gets the text used to describe a development version that is not tagged yet.
        /// </summary>
        public static string DevMarker => "dev";

        /// <summary>
        /// Generates version information based on the latest matching annotated git tag and the current repository state.
        /// </summary>
        /// <param name="repositoryPath">The path of the repository.</param>
        /// <param name="buildNumber">An optional build number provided by the continuous integration system.</param>
        /// <remarks>
        /// This method expects an annotated git tag of the format <c>v[MAJOR].[MINOR].[REVISION]</c> (e.g. "v1.0.1", "v0.3.10", ...).
        /// </remarks>
        /// <returns>
        /// Returns version information in the following formats:
        /// <list type="bullet">
        /// <item>long version: [MAJOR].[MINOR].[BUILD].[REVISION]</item>
        /// <item>short version: [MAJOR].[MINOR].[REVISION]</item>
        /// <item>semantic version: [MAJOR].[MINOR].[REVISION]+[DESCRIPTION]</item>
        /// </list>
        /// </returns>
        public static (string shortVersion, string longVersion, string semanticVersion) GetGitTagVersion(string repositoryPath = "./", ulong buildNumber = 0)
        {
            (ulong major, ulong minor, ulong revision, ulong commits, string shasum) = GetGitTagVersionComponents(repositoryPath);

            string label;

            if (commits == 0)
            {
                label = shasum;
            }
            else
            {
                label = $"{DevMarker}{commits}-{shasum}";
            }

            string shortVersion = $"{major}.{minor}.{revision}";
            string version = $"{major}.{minor}.{buildNumber}.{revision}";
            string semanticVersion = $"{major}.{minor}.{revision}+{label}";

            return (shortVersion, version, semanticVersion);
        }

        /// <summary>
        /// Extracts version information components from the latest matching annotated git tag and the current repository state.
        /// </summary>
        /// <param name="repositoryPath">The path of the repository.</param>
        /// <remarks>
        /// This method expects an annotated git tag of the format <c>v[MAJOR].[MINOR].[REVISION]</c> (e.g. "v1.0.1", "v0.3.10", ...).
        /// </remarks>
        /// <returns>
        /// Returns the following version components extracted from the given git repository:
        /// <list type="bullet">
        /// <item>major: [MAJOR]</item>
        /// <item>minor: [MINOR]</item>
        /// <item>revision: [REVISION]</item>
        /// <item>commits: number of commits since the repository has been tagged</item>
        /// <item>shasum: shasum of the latest commit</item>
        /// </list>
        /// </returns>
        public static (ulong major, ulong minor, ulong revision, ulong commits, string shasum) GetGitTagVersionComponents(string repositoryPath)
        {
            List<string> tags = new List<string>();

            using Repository repository = new Repository(repositoryPath);

            foreach (var tag in repository.Tags)
            {
                if (tag.IsAnnotated && tag.FriendlyName.StartsWith("v", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    tags.Add(tag.FriendlyName);
                }
            }

            tags.Sort();

            DescribeOptions options = new DescribeOptions
            {
                AlwaysRenderLongFormat = true,
                Strategy = DescribeStrategy.Default,
            };

            string description = repository.Describe(repository.Head.Commits.First(), options);
            string latestTag = tags.Last();

            Regex tagQuery = new Regex(@"v(?<major>\d+).(?<minor>\d+).(?<revision>\d+)");
            Regex descriptionQuery = new Regex(@"(?<tag>.*)-(?<commits>\d+)-(?<shasum>.*)");

            var tagMatch = tagQuery.Match(latestTag);
            var descriptionMatch = descriptionQuery.Match(description);

            ulong major = ulong.Parse(tagMatch.Groups["major"].Value, CultureInfo.InvariantCulture);
            ulong minor = ulong.Parse(tagMatch.Groups["minor"].Value, CultureInfo.InvariantCulture);
            ulong revision = ulong.Parse(tagMatch.Groups["revision"].Value, CultureInfo.InvariantCulture);

            ulong commits = ulong.Parse(descriptionMatch.Groups["commits"].Value, CultureInfo.InvariantCulture);
            string shasum = descriptionMatch.Groups["shasum"].Value;

            return (major, minor, revision, commits, shasum);
        }
    }
}
