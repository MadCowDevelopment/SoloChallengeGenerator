using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Resolver;
using NuGet.Versioning;

namespace scg.Services
{
    public class NugetService2
    {
        private SourceRepository _repository = Repository.Factory.GetCoreV3(@"D:\Github\SoloChallengeGenerator");
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

        public async Task Install(string packageId, NuGetVersion packageVersion)
        {
            var nuGetFramework = NuGetFramework.ParseFolder("netcoreapp3.1");
            var settings = Settings.LoadDefaultSettings(root: null);

            var repositories = new List<SourceRepository> {_repository};

            using (var cacheContext = new SourceCacheContext())
            {
                var availablePackages = new HashSet<SourcePackageDependencyInfo>(PackageIdentityComparer.Default);
                await GetPackageDependencies(
                    new PackageIdentity(packageId, packageVersion),
                    nuGetFramework, cacheContext, NullLogger.Instance, repositories, availablePackages);

                var resolverContext = new PackageResolverContext(
                    DependencyBehavior.Lowest,
                    new[] { packageId },
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<PackageReference>(),
                    Enumerable.Empty<PackageIdentity>(),
                    availablePackages,
                    repositories.Select(s => s.PackageSource),
                    NullLogger.Instance);

                var resolver = new PackageResolver();
                var packagesToInstall = resolver.Resolve(resolverContext, CancellationToken.None)
                    .Select(p => availablePackages.Single(x => PackageIdentityComparer.Default.Equals(x, p)));
                var packagePathResolver = new PackagePathResolver(Path.GetFullPath("packages"));
                var packageExtractionContext = new PackageExtractionContext(
                    PackageSaveMode.Defaultv3,
                    XmlDocFileSaveMode.None,
                    ClientPolicyContext.GetClientPolicy(settings, NullLogger.Instance),
                    NullLogger.Instance);
                var frameworkReducer = new FrameworkReducer();

                foreach (var packageToInstall in packagesToInstall)
                {
                    PackageReaderBase packageReader;
                    var installedPath = packagePathResolver.GetInstalledPath(packageToInstall);
                    if (installedPath == null)
                    {
                        var downloadResource =
                            await packageToInstall.Source.GetResourceAsync<DownloadResource>(CancellationToken.None);
                        var downloadResult = await downloadResource.GetDownloadResourceResultAsync(
                            packageToInstall,
                            new PackageDownloadContext(cacheContext),
                            SettingsUtility.GetGlobalPackagesFolder(settings),
                            NullLogger.Instance, CancellationToken.None);

                        await PackageExtractor.ExtractPackageAsync(
                            downloadResult.PackageSource,
                            downloadResult.PackageStream,
                            packagePathResolver,
                            packageExtractionContext,
                            CancellationToken.None);

                        packageReader = downloadResult.PackageReader;
                    }
                    else
                    {
                        packageReader = new PackageFolderReader(installedPath);
                    }

                    var libItems = packageReader.GetLibItems();
                    var nearest = frameworkReducer.GetNearest(nuGetFramework, libItems.Select(x => x.TargetFramework));
                    Console.WriteLine(string.Join("\n", libItems
                        .Where(x => x.TargetFramework.Equals(nearest))
                        .SelectMany(x => x.Items)));

                    var frameworkItems = packageReader.GetFrameworkItems();
                    nearest = frameworkReducer.GetNearest(nuGetFramework,
                        frameworkItems.Select(x => x.TargetFramework));
                    Console.WriteLine(string.Join("\n", frameworkItems
                        .Where(x => x.TargetFramework.Equals(nearest))
                        .SelectMany(x => x.Items)));
                }
            }
        }

        async Task GetPackageDependencies(PackageIdentity package,
            NuGetFramework framework,
            SourceCacheContext cacheContext,
            ILogger logger,
            IEnumerable<SourceRepository> repositories,
            ISet<SourcePackageDependencyInfo> availablePackages)
        {
            if (availablePackages.Contains(package)) return;

            foreach (var sourceRepository in repositories)
            {
                var dependencyInfoResource = await sourceRepository.GetResourceAsync<DependencyInfoResource>();
                var dependencyInfo = await dependencyInfoResource.ResolvePackage(
                    package, framework, cacheContext, logger, CancellationToken.None);

                if (dependencyInfo == null) continue;

                availablePackages.Add(dependencyInfo);
                foreach (var dependency in dependencyInfo.Dependencies)
                {
                    await GetPackageDependencies(
                        new PackageIdentity(dependency.Id, dependency.VersionRange.MinVersion),
                        framework, cacheContext, logger, repositories, availablePackages);
                }
            }
        }
    }
}