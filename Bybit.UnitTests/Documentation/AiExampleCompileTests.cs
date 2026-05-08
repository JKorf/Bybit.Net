using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.UnitTests.Documentation
{
    [TestFixture]
    public class AiExampleCompileTests
    {
        [Test]
        public async Task AiFriendlyExamples_ShouldCompile()
        {
            var repositoryRoot = FindRepositoryRoot();
            var examplesDirectory = Path.Combine(repositoryRoot, "Examples", "ai-friendly");

            Assert.That(Directory.Exists(examplesDirectory), Is.True, $"Missing examples directory: {examplesDirectory}");

            var exampleFiles = Directory.GetFiles(examplesDirectory, "*.cs").OrderBy(x => x).ToArray();
            Assert.That(exampleFiles, Is.Not.Empty);

            foreach (var exampleFile in exampleFiles)
                await CompileExampleAsync(repositoryRoot, exampleFile).ConfigureAwait(false);
        }

        private static async Task CompileExampleAsync(string repositoryRoot, string exampleFile)
        {
            var exampleName = Path.GetFileNameWithoutExtension(exampleFile);
            var workDirectory = Path.Combine(repositoryRoot, "obj", "ai-example-compile", exampleName);

            if (Directory.Exists(workDirectory))
                Directory.Delete(workDirectory, recursive: true);

            Directory.CreateDirectory(workDirectory);

            File.Copy(exampleFile, Path.Combine(workDirectory, "Program.cs"));
            File.WriteAllText(
                Path.Combine(workDirectory, "Example.csproj"),
                CreateProjectFile(),
                Encoding.UTF8);

            var result = await RunDotnetBuildAsync(workDirectory).ConfigureAwait(false);
            Assert.That(result.ExitCode, Is.EqualTo(0), $"Example {Path.GetFileName(exampleFile)} failed to compile.{Environment.NewLine}{result.Output}");
        }

        private static string CreateProjectFile()
        {
            var assemblyDirectory = AppContext.BaseDirectory;
            var references = Directory.GetFiles(assemblyDirectory, "*.dll")
                .OrderBy(x => x)
                .Select(path => $@"    <Reference Include=""{Path.GetFileNameWithoutExtension(path)}"">
      <HintPath>{path}</HintPath>
    </Reference>");

            return $@"<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <NoWarn>$(NoWarn);CS1998</NoWarn>
  </PropertyGroup>
  <ItemGroup>
{string.Join(Environment.NewLine, references)}
  </ItemGroup>
</Project>
";
        }

        private static async Task<ProcessResult> RunDotnetBuildAsync(string workDirectory)
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "build --nologo /p:UseAppHost=false /p:OutDir=obj/build/",
                WorkingDirectory = workDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var output = new StringBuilder();
            process.OutputDataReceived += (_, args) =>
            {
                if (args.Data != null)
                    output.AppendLine(args.Data);
            };
            process.ErrorDataReceived += (_, args) =>
            {
                if (args.Data != null)
                    output.AppendLine(args.Data);
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            var exited = await Task.Run(() => process.WaitForExit(60000)).ConfigureAwait(false);
            if (!exited)
            {
                process.Kill(entireProcessTree: true);
                return new ProcessResult(-1, output + "dotnet build timed out.");
            }

            return new ProcessResult(process.ExitCode, output.ToString());
        }

        private static string FindRepositoryRoot()
        {
            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            while (directory != null)
            {
                if (File.Exists(Path.Combine(directory.FullName, "ByBit.Net.sln")))
                    return directory.FullName;

                directory = directory.Parent;
            }

            throw new DirectoryNotFoundException("Could not find ByBit.Net.sln in the current directory tree.");
        }

        private readonly record struct ProcessResult(int ExitCode, string Output);
    }
}
