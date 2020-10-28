using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace scg.Services
{
    class NugetService
    {
        private readonly SourceRepository _repository = Repository.Factory.GetCoreV3(@"D:\Github\GlassRoadChallengeGenerator");

        public async Task<IEnumerable<PackageInfo>> Search()
        {
            var searchResource = await _repository.GetResourceAsync<PackageSearchResource>();
            var searchFilter = new SearchFilter(true)
            {
                IncludeDelisted = true
            };

            var search = await searchResource.SearchAsync("scg.Games", searchFilter, 0, 10, NullLogger.Instance, CancellationToken.None);
            return search.Select(p => new PackageInfo(p.Identity.Id, p.GetVersionsAsync().Result.FirstOrDefault().Version)).ToImmutableList();
        }

        public async Task Download(string packageId, NuGetVersion packageVersion)
        {
            ILogger logger = NullLogger.Instance;
            CancellationToken cancellationToken = CancellationToken.None;

            SourceCacheContext cache = new SourceCacheContext();
            FindPackageByIdResource resource = await _repository.GetResourceAsync<FindPackageByIdResource>();

            using MemoryStream packageStream = new MemoryStream();

            await resource.CopyNupkgToStreamAsync(
                packageId,
                packageVersion,
                packageStream,
                cache,
                logger,
                cancellationToken);

            Console.WriteLine($"Downloaded package {packageId} {packageVersion}");

            using PackageArchiveReader reader = new PackageArchiveReader(packageStream);
            foreach (var file in reader.GetFiles().Where(p => p.Contains("scg.Games.") && p.EndsWith(".dll")))
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Path.GetFileName(file));
                reader.ExtractFile(file, path, NullLogger.Instance);
            }
        }
    }

    public class PackageInfo
    {
        public string PackageId { get; }
        public NuGetVersion PackageVersion { get; }

        public PackageInfo(string packageId, NuGetVersion packageVersion)
        {
            PackageId = packageId;
            PackageVersion = packageVersion;
        }
    }
}
