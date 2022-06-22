using System.IO;
using ME = MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System.Globalization;

namespace PhotoArchiver
{
    public partial class MainForm : Form
    {
        private const string EXIF_DATETIME_FORMAT = "yyyy:MM:dd HH:mm:ss";

        // ѡ��
        private class Options
        {
            public static readonly string[][] FILE_TYPES =
            {
                new string[] {"*.jpg", "*.jpe", "*.jpeg", "*.png", "*.tif", "*.tiff"},
                new string[] {"*.*"},
            };

            public enum ArchiveRuleType
            {
                ByExifDateTime,
                ByCreationTime,
                ByLastModifiedTime,
            }

            public enum NoExifProcessType
            {
                Skip,
                ByCreationTime,
                ByLastModifiedTime,
                MoveToSpecifiedFolder,
            }

            public enum RenameRuleType
            {
                AutoRename,
                Overwrite,
                Skip,
            }

            public string? sourceFolder;
            public string? targetFolder;
            public string? specificFolder;
            public int FileTypeIndex = 0;
            public string? ArchiveFolderNameFormat;
            public ArchiveRuleType ArchiveRule = ArchiveRuleType.ByExifDateTime;
            public NoExifProcessType NoExifProcess = NoExifProcessType.ByCreationTime;
            public RenameRuleType RenameRule = RenameRuleType.AutoRename;
            public bool CopyFile = false;
            public bool IncludeSubDirectories = true;
        }

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        // ѡ��
        private Options _options = new();

        // ��ʼ��
        private void Init()
        {
            fileType.SelectedIndex = 0;
            archiveFolderNameFormat.SelectedIndex = 0;
            archiveRule.SelectedIndex = 0;
            noExifProcess.SelectedIndex = 0;
            renameRule.SelectedIndex = 0;
        }

        // �����ļ�����
        private void UpdateFileType()
        {
            _options.FileTypeIndex = fileType.SelectedIndex;
        }

        // ���¹鵵�ļ�����������Ԥ��
        private void UpdateArchiveFolderNamingRule()
        {
            _options.ArchiveFolderNameFormat = archiveFolderNameFormat.Text;
            archiveFolderNamePreview.Text = DateTime.Now.ToString(_options.ArchiveFolderNameFormat);
        }

        // ���¹鵵����
        private void UpdateArchiveRule()
        {
            _options.ArchiveRule = (Options.ArchiveRuleType)archiveRule.SelectedIndex;
            noExif.Enabled = noExifProcess.Enabled = _options.ArchiveRule == Options.ArchiveRuleType.ByExifDateTime;
            UpdateNoExifProcess();
        }

        // ������EXIFʱ������
        private void UpdateNoExifProcess()
        {
            _options.NoExifProcess = (Options.NoExifProcessType)noExifProcess.SelectedIndex;
            specificFolderLabel.Enabled = specificFolder.Enabled = browseSpecificFolder.Enabled =
                _options.ArchiveRule == Options.ArchiveRuleType.ByExifDateTime
                && _options.NoExifProcess == Options.NoExifProcessType.MoveToSpecifiedFolder;
        }

        // ������������
        private void UpdateRenameRule()
        {
            _options.RenameRule = (Options.RenameRuleType)renameRule.SelectedIndex;
        }

        // ���¸����ļ�
        private void UpdateCopyFile()
        {
            _options.CopyFile = copyFile.Checked;
        }

        // ���°������ļ���
        private void UpdateIncludeSubDirectories()
        {
            _options.IncludeSubDirectories = includeSubDirectories.Checked;
        }

        // ����Ƿ���Կ�ʼ
        private bool CanStart()
        {
            return
                !string.IsNullOrEmpty(_options.sourceFolder)
                && !string.IsNullOrEmpty(_options.targetFolder)
                && (_options.ArchiveRule != Options.ArchiveRuleType.ByExifDateTime
                    || _options.NoExifProcess != Options.NoExifProcessType.MoveToSpecifiedFolder
                    || !string.IsNullOrEmpty(_options.specificFolder));
        }

        // ���¿�ʼ״̬
        private void UpdateStart()
        {
            start.Enabled = CanStart();
        }

        // ��ʼ�鵵
        private void Start()
        {
            Log("��ʼ�鵵...");
            start.Enabled = false;
            options.Enabled = false;
            browseSourceFolder.Enabled = false;
            browseTargetFolder.Enabled = false;
            progress.Value = 0;
            progress.Visible = true;
            Application.DoEvents();

            try
            {
                // �ռ��ļ��б�
                SearchOption so = _options.IncludeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                List<string> fileList = new();
                foreach (var pattern in Options.FILE_TYPES[_options.FileTypeIndex])
                {
                    var files = Directory.GetFiles(_options.sourceFolder!, pattern, so);
                    fileList.AddRange(files);
                }

                progress.Maximum = fileList.Count;
                progress.Refresh();
                int archived = 0;
                int skipped = 0;
                int renamed = 0;

                // �����ļ�
                foreach (var file in fileList)
                {
                    // ����
                    progress.Value++;
                    progress.Refresh();
                    Application.DoEvents();

                    // ��ȡ�ļ���Ϣ
                    var dir = Path.GetDirectoryName(file);
                    var creationTime = File.GetCreationTime(file);
                    var lastModifiedTime = File.GetLastWriteTime(file);
                    var lastAccessTime = File.GetLastAccessTime(file);
                    DateTime finalDt = creationTime;
                    DateTime? exifDateTime = null;
                    string? destFolder = null;

                    // �鵵����
                    switch (_options.ArchiveRule)
                    {
                        // EXIF
                        case Options.ArchiveRuleType.ByExifDateTime:
                            string? exifDateTimeStr = null;
                            try
                            {
                                var metaDirs = ME.ImageMetadataReader.ReadMetadata(file);
                                var ifdDir = metaDirs?.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                                exifDateTimeStr = ifdDir?.GetDescription(ExifDirectoryBase.TagDateTime);
                                if (string.IsNullOrEmpty(exifDateTimeStr))
                                {
                                    exifDateTimeStr = ifdDir?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);
                                }
                                if (string.IsNullOrEmpty(exifDateTimeStr))
                                {
                                    exifDateTimeStr = ifdDir?.GetDescription(ExifDirectoryBase.TagDateTimeDigitized);
                                }
                            }
                            catch
                            {
                                exifDateTimeStr = null;
                            }
                            if (!string.IsNullOrEmpty(exifDateTimeStr))
                            {
                                if (DateTime.TryParseExact(exifDateTimeStr, EXIF_DATETIME_FORMAT,
                                    CultureInfo.CurrentCulture, DateTimeStyles.None,
                                    out var dt)) exifDateTime = dt;
                            }

                            // �ɹ�
                            if (exifDateTime.HasValue)
                            {
                                finalDt = exifDateTime.Value;
                            }

                            // ʧ�ܴ���
                            else
                            {
                                switch (_options.NoExifProcess)
                                {
                                    case Options.NoExifProcessType.ByCreationTime:
                                        finalDt = creationTime;
                                        break;

                                    case Options.NoExifProcessType.ByLastModifiedTime:
                                        finalDt = lastModifiedTime;
                                        break;

                                    case Options.NoExifProcessType.MoveToSpecifiedFolder:
                                        destFolder = _options.specificFolder;
                                        break;

                                    case Options.NoExifProcessType.Skip:
                                        Skip(file, "δ�ҵ�EXIF��Ϣ");
                                        skipped++;
                                        continue;
                                }
                            }
                            break;

                        // ����ʱ��
                        case Options.ArchiveRuleType.ByCreationTime:
                            finalDt = creationTime;
                            break;

                        // �޸�ʱ��
                        case Options.ArchiveRuleType.ByLastModifiedTime:
                            finalDt = lastModifiedTime;
                            break;
                    }

                    // δȷ��Ŀ���ļ���
                    if (string.IsNullOrEmpty(destFolder))
                    {
                        // ȷ��Ŀ���ļ���
                        var targetFolderName = finalDt.ToString(_options.ArchiveFolderNameFormat);
                        destFolder = Path.Combine(_options.targetFolder!, targetFolderName);
                    }

                    // �����ļ�
                    if (!Directory.Exists(destFolder)) Directory.CreateDirectory(destFolder);
                    var fn = Path.GetFileNameWithoutExtension(file);
                    var ext = Path.GetExtension(file);
                    var destFile = Path.Combine(destFolder, fn + ext);

                    // Ŀ���ļ��Ѵ���
                    if (File.Exists(destFile))
                    {
                        switch (_options.RenameRule)
                        {
                            case Options.RenameRuleType.AutoRename:
                                int count = 1;
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(destFolder, $"{fn}_{count++}{ext}");
                                }
                                renamed++;
                                break;

                            case Options.RenameRuleType.Overwrite:
                                //File.Delete(destFile);
                                break;

                            case Options.RenameRuleType.Skip:
                                Skip(file, "Ŀ���ļ��Ѵ���");
                                skipped++;
                                continue;
                        }
                    }

                    // �ƶ�/���Ʋ�����ʱ���
                    try
                    {
                        if (_options.CopyFile)
                        {
                            File.Copy(file, destFile, true);
                        }
                        else
                        {
                            File.Move(file, destFile, true);
                        }
                        File.SetCreationTime(destFile, creationTime);
                        File.SetLastWriteTime(destFile, lastModifiedTime);
                        File.SetLastAccessTime(destFile, lastAccessTime);
                        Log($"�ɹ��鵵�ļ� [{file}] �� [{destFolder}]");
                        archived++;
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message);
                    }
                }

                // ���
                Log($"������ɣ��鵵: {archived}, ������: {renamed}, ����: {skipped}");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
            finally
            {
                start.Enabled = true;
                options.Enabled = true;
                browseSourceFolder.Enabled = true;
                browseTargetFolder.Enabled = true;
                progress.Visible = false;
            }
        }

        private void Skip(string file, string reason)
        {
            Log($"{reason}, �����ļ� [{file}]");
        }

        private void Log(string msg)
        {
            log.Items.Add($"[{DateTime.Now:yyyyMMdd-HH:mm:ss.fff}] {msg}");
            log.TopIndex = log.Items.Count - 1;
        }

        private void ArchiveFolderNamingRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateArchiveFolderNamingRule();
        }

        private void ArchiveRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateArchiveRule();
            UpdateStart();
        }

        private void NoExifProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNoExifProcess();
            UpdateStart();
        }

        private void FileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFileType();
        }

        private void RenameRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRenameRule();
        }

        private void CopyFile_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCopyFile();
        }

        private void BrowseSourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            if (!string.IsNullOrEmpty(sourceFolder.Text)) dialog.SelectedPath = sourceFolder.Text;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            sourceFolder.Text = dialog.SelectedPath;
            _options.sourceFolder = dialog.SelectedPath;
            if (string.IsNullOrEmpty(targetFolder.Text))
            {
                targetFolder.Text = dialog.SelectedPath;
                _options.targetFolder = dialog.SelectedPath;
            }
            UpdateStart();
        }

        private void BrowseTargetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            if (!string.IsNullOrEmpty(targetFolder.Text)) dialog.SelectedPath = targetFolder.Text;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            targetFolder.Text = dialog.SelectedPath;
            _options.targetFolder = dialog.SelectedPath;
            UpdateStart();
        }

        private void BrowseSpecificFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            if (!string.IsNullOrEmpty(specificFolder.Text)) dialog.SelectedPath = specificFolder.Text;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            specificFolder.Text = dialog.SelectedPath;
            _options.specificFolder = dialog.SelectedPath;
            UpdateStart();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void IncludeSubDirectories_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIncludeSubDirectories();
        }
    }
}