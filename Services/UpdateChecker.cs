using DiscordStatusRotationUI.Models;
using DiscordStatusRotationUI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Services
{
    public class UpdateChecker
    {
        private static readonly string _repoOwner = "LolghElmo";
        private static readonly string _repoName = "DiscordStatusRotation";
        private static readonly string _apiUrl = $"https://api.github.com/repos/{_repoOwner}/{_repoName}/releases/latest";


        public async Task<(bool IsNewVersionAvailable, string DownloadUrl, string LatestVersion)> CheckForUpdates(string currentVersion)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

                    HttpResponseMessage response = await client.GetAsync(_apiUrl);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    JObject release = JObject.Parse(json);

                    string latestVersion = release["tag_name"].ToString().TrimStart('v');

                    if (IsNewerVersion(currentVersion, latestVersion))
                    {
                        string downloadUrl = release["assets"][0]["browser_download_url"].ToString();
                        return (true, downloadUrl, latestVersion);
                    }
                    else
                    {
                        return (false, null, latestVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking for updates: {ex.Message}");
                return (false, null, null);
            }
        }

        private bool IsNewerVersion(string currentVersion, string latestVersion)
        {
            Version current = new Version(currentVersion);
            Version latest = new Version(latestVersion);
            return latest.CompareTo(current) > 0;
        }

        public async Task<bool> DownloadAndUpdate(string downloadUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(downloadUrl);
                    string tempFilePath = Path.Combine(Path.GetTempPath(), "update.zip");
                    File.WriteAllBytes(tempFilePath, fileBytes);
                    string extractPath = Path.Combine(Path.GetTempPath(), "update");
                    ExtractZip(tempFilePath, extractPath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading update: {ex.Message}");
                return false;
            }
        }

        private void ExtractZip(string zipPath, string extractPath)
        {
            try
            {
                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true);
                }

                ZipFile.ExtractToDirectory(zipPath, extractPath);
                string[] extractedDirectories = Directory.GetDirectories(extractPath);

                if (extractedDirectories.Length == 1)
                {
                    string innerFolder = extractedDirectories[0];

                    string targetDirectory = Application.StartupPath;

                    foreach (var file in Directory.GetFiles(innerFolder))
                    {
                        string destFile = Path.Combine(targetDirectory, Path.GetFileName(file));
                        File.Copy(file, destFile, true);
                    }

                    foreach (var directory in Directory.GetDirectories(innerFolder))
                    {
                        string destDirectory = Path.Combine(targetDirectory, Path.GetFileName(directory));
                        CopyDirectory(directory, destDirectory);
                    }
                    Console.WriteLine($"Extracted to {Application.StartupPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting update: {ex.Message}");
            }
        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(targetDir, Path.GetFileName(directory));
                CopyDirectory(directory, destSubDir);
            }
        }
    }
}
