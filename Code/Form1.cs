﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LaunchOrder
{
    [Serializable]
    public partial class Form1 : Form
    {
        private Point _mouseDownPos;
        private Point dragStartPoint;
        private string xmlFilePath;

        [Serializable]
        public class OrderRow
        {
            public bool Active { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string Parameters { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string launchOrderPath = Path.Combine(appDataPath, "LaunchOrder");
            Directory.CreateDirectory(launchOrderPath);
            xmlFilePath = Path.Combine(launchOrderPath, "order.xml");

            DataGridViewCheckBoxColumn colActive = new DataGridViewCheckBoxColumn();
            colActive.HeaderText = "Active";
            colActive.Name = "Active";
            colActive.Width = 50;
            colActive.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Name";
            colName.Name = "Name";
            colName.Width = 120;
            colName.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn colValue = new DataGridViewTextBoxColumn();
            colValue.HeaderText = "Value";
            colValue.Name = "Value";
            colValue.MinimumWidth = 300;
            colValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colValue.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn colParameter = new DataGridViewTextBoxColumn();
            colParameter.HeaderText = "Parameters";
            colParameter.Name = "Parameters";
            colParameter.MinimumWidth = 200;
            colParameter.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colParameter.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvOrder.Columns.AddRange(colActive, colName, colValue, colParameter);

            this.dgvOrder.DefaultCellStyle.Font = new Font("Tahoma", 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOrderFromXml(xmlFilePath);
            bool shortcutExists = IsShortcutInAutostart();
            btnSetAutostart.Visible = !shortcutExists;
            btnDelAutostart.Visible = shortcutExists;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string filePath = openFileDialog.FileName;
                dgvOrder.Rows.Add(true, fileName, filePath, "");
            }
        }

        private void btnAddDelay_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Add(true, "-DELAY-", "3", "");
        }

        private void dgvOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hitTest = dgvOrder.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    dragStartPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void dgvOrder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragStartPoint != Point.Empty)
            {
                if (Math.Abs(e.X - dragStartPoint.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - dragStartPoint.Y) > SystemInformation.DragSize.Height)
                {
                    var hitTest = dgvOrder.HitTest(dragStartPoint.X, dragStartPoint.Y);
                    if (hitTest.RowIndex >= 0)
                    {
                        dgvOrder.DoDragDrop(dgvOrder.Rows[hitTest.RowIndex], DragDropEffects.Move);
                        dragStartPoint = Point.Empty;
                    }
                }
            }
        }

        private void dgvOrder_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvOrder_DragDrop(object sender, DragEventArgs e)
        {
            var clientPoint = dgvOrder.PointToClient(new Point(e.X, e.Y));
            var hitTest = dgvOrder.HitTest(clientPoint.X, clientPoint.Y);
            if (hitTest.RowIndex >= 0)
            {
                DataGridViewRow draggedRow = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                if (draggedRow != null)
                {
                    DataGridViewRow newRow = (DataGridViewRow)draggedRow.Clone();
                    for (int i = 0; i < draggedRow.Cells.Count; i++)
                    {
                        newRow.Cells[i].Value = draggedRow.Cells[i].Value;
                    }
                    dgvOrder.Rows.Insert(hitTest.RowIndex, newRow);
                    dgvOrder.Rows.Remove(draggedRow);
                }
            }
        }

        private void dgvOrder_MouseUp(object sender, MouseEventArgs e)
        {
            dragStartPoint = Point.Empty;
        }

        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentCell != null)
            {
                int rowIndex = dgvOrder.CurrentCell.RowIndex;
                int lastIndex = dgvOrder.Rows.Count - 1;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentCell == null)
                return;

            int rowIndex = dgvOrder.CurrentCell.RowIndex;
            if (rowIndex <= 0)
                return;

            SwapRows(rowIndex, rowIndex - 1);
            dgvOrder.ClearSelection();
            dgvOrder.Rows[rowIndex - 1].Selected = true;
            dgvOrder.CurrentCell = dgvOrder.Rows[rowIndex - 1].Cells[dgvOrder.CurrentCell.ColumnIndex];
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentCell == null)
                return;

            int rowIndex = dgvOrder.CurrentCell.RowIndex;
            int lastIndex = dgvOrder.Rows.Count - 1;
            if (rowIndex >= lastIndex)
                return;

            SwapRows(rowIndex, rowIndex + 1);
            dgvOrder.ClearSelection();
            dgvOrder.Rows[rowIndex + 1].Selected = true;
            dgvOrder.CurrentCell = dgvOrder.Rows[rowIndex + 1].Cells[dgvOrder.CurrentCell.ColumnIndex];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentCell == null)
                return;

            int rowIndex = dgvOrder.CurrentCell.RowIndex;
            dgvOrder.Rows.RemoveAt(rowIndex);
        }

        private void SwapRows(int index1, int index2)
        {
            if (index1 < 0 || index2 < 0 || index1 >= dgvOrder.Rows.Count || index2 >= dgvOrder.Rows.Count)
                return;
            DataGridViewRow row1 = dgvOrder.Rows[index1];
            DataGridViewRow row2 = dgvOrder.Rows[index2];
            object[] values1 = new object[row1.Cells.Count];
            object[] values2 = new object[row2.Cells.Count];

            for (int i = 0; i < row1.Cells.Count; i++)
            {
                values1[i] = row1.Cells[i].Value;
                values2[i] = row2.Cells[i].Value;
            }
            for (int i = 0; i < row1.Cells.Count; i++)
            {
                row1.Cells[i].Value = values2[i];
                row2.Cells[i].Value = values1[i];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void btnSetAutostart_Click(object sender, EventArgs e)
        {
            AddToAutostart();
            btnSetAutostart.Visible = false;
            btnDelAutostart.Visible = true;
        }

        private void btnDelAutostart_Click(object sender, EventArgs e)
        {
            RemoveFromAutostart();
            btnSetAutostart.Visible = true;
            btnDelAutostart.Visible = false;
        }

        private void SaveAll()
        {
            SaveOrderToXml(xmlFilePath);
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string batchPath = Path.Combine(appDataPath, "LaunchOrder", "launch.bat");

            Directory.CreateDirectory(Path.GetDirectoryName(batchPath));

            StringBuilder batchContent = new StringBuilder();
            batchContent.AppendLine("@echo off");
            batchContent.AppendLine("setlocal enabledelayedexpansion");
            batchContent.AppendLine("mode con: cols=15 lines=17");
            batchContent.AppendLine("echo.");
            batchContent.AppendLine("echo        .");
            batchContent.AppendLine("echo       / \\");
            batchContent.AppendLine("echo      /   \\");
            batchContent.AppendLine("echo      I   I");
            batchContent.AppendLine("echo      I   I");
            batchContent.AppendLine("echo      I   I");
            batchContent.AppendLine("echo     /I   I\\");
            batchContent.AppendLine("echo    /_I___I_\\");
            batchContent.AppendLine("echo       / \\");
            batchContent.AppendLine("echo      I   I");
            batchContent.AppendLine("echo       ---");
            batchContent.AppendLine("echo      * * *");
            batchContent.AppendLine("echo       * *");
            batchContent.AppendLine("echo        *");
            batchContent.AppendLine();

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;

                bool isActive = row.Cells["Active"].Value != null && Convert.ToBoolean(row.Cells["Active"].Value);
                if (!isActive) continue;

                string name = row.Cells["Name"].Value?.ToString() ?? "";
                string value = row.Cells["Value"].Value?.ToString() ?? "";
                string parameters = row.Cells["Parameters"].Value?.ToString() ?? "";

                if (name.Equals("-DELAY-", StringComparison.OrdinalIgnoreCase))
                {
                    int seconds;
                    if (int.TryParse(value, out seconds))
                    {
                        batchContent.AppendLine($"timeout /t {seconds} /nobreak >nul");
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(parameters))
                    {
                        string paramEscaped = parameters;
                        if (parameters.Contains("\""))
                        {
                            paramEscaped = parameters.Replace("\"", "\\\"");
                        }
                        batchContent.AppendLine($"start \"\" \"{value}\" {paramEscaped}");
                    }
                    else
                    {
                        batchContent.AppendLine($"start \"\" \"{value}\"");
                    }
                }
            }

            File.WriteAllText(batchPath, batchContent.ToString(), Encoding.Default);

            ShowNotify("Saved!", " ", 3000, ToolTipIcon.Info);
        }

        private void LoadOrderFromXml(string filePath)
        {
            dgvOrder.Rows.Clear();

            if (!File.Exists(filePath)) return;

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<OrderRow>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<OrderRow> rows = (List<OrderRow>)serializer.Deserialize(reader);
                foreach (OrderRow row in rows)
                {
                    dgvOrder.Rows.Add(row.Active, row.Name, row.Value, row.Parameters ?? "");
                }
            }
        }

        private void SaveOrderToXml(string filePath)
        {
            List<OrderRow> rows = new List<OrderRow>();
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;
                rows.Add(new OrderRow
                {
                    Active = row.Cells["Active"].Value != null && Convert.ToBoolean(row.Cells["Active"].Value),
                    Name = row.Cells["Name"].Value?.ToString() ?? "",
                    Value = row.Cells["Value"].Value?.ToString() ?? "",
                    Parameters = row.Cells["Parameters"].Value?.ToString() ?? ""
                });
            }
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<OrderRow>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, rows);
            }
        }

        private void AddToAutostart()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string batchPath = Path.Combine(appDataPath, "LaunchOrder", "launch.bat");
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutName = "LaunchOrder.lnk";
            string shortcutPath = Path.Combine(autostartPath, shortcutName);
            string iconPath = Path.Combine(appDataPath, "LaunchOrder", "lo.ico");

            if (!File.Exists(iconPath))
            {
                using (var fs = new FileStream(iconPath, FileMode.Create, FileAccess.Write))
                {
                    Properties.Resources.lo.Save(fs);
                }
            }
            using (StreamWriter writer = new StreamWriter(Path.Combine(Path.GetTempPath(), "launch.vbs")))
            {
                writer.WriteLine("Set oWS = WScript.CreateObject(\"WScript.Shell\")");
                writer.WriteLine($"sLinkFile = \"{shortcutPath.Replace("\\", "\\\\")}\"");
                writer.WriteLine("Set oLink = oWS.CreateShortcut(sLinkFile)");
                writer.WriteLine($"oLink.TargetPath = \"cmd.exe\"");
                writer.WriteLine($"oLink.Arguments = \"/c \"\"{batchPath}\"\"\"");
                writer.WriteLine("oLink.WorkingDirectory = \"\"");
                writer.WriteLine($"oLink.IconLocation = \"{iconPath}\"");
                writer.WriteLine("oLink.Save");
            }
            Process.Start("wscript.exe", Path.Combine(Path.GetTempPath(), "launch.vbs")).WaitForExit();
            File.Delete(Path.Combine(Path.GetTempPath(), "launch.vbs"));
            ShowNotify("Running!", " ", 3000, ToolTipIcon.Info);
        }

        private void RemoveFromAutostart()
        {
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutName = "LaunchOrder.lnk";
            string shortcutPath = Path.Combine(autostartPath, shortcutName);

            if (File.Exists(shortcutPath))
            {
                try
                {
                    File.Delete(shortcutPath);
                    ShowNotify("Stopped!", " ", 3000, ToolTipIcon.Info);
                }
                catch (Exception ex)
                {
                    ShowNotify("Error", ex.Message, 3000, ToolTipIcon.Error);
                }
            }
        }

        private bool IsShortcutInAutostart()
        {
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutName = "LaunchOrder.lnk";
            string shortcutPath = Path.Combine(autostartPath, shortcutName);
            return File.Exists(shortcutPath);
        }

        private void ImportAutostarts()
        {
            string[] autostartPaths = new string[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)
            };

            string myExe = Application.ExecutablePath.ToLower();
            string myBatch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LaunchOrder", "launch.bat").ToLower();

            bool imported = false;

            foreach (string autostartPath in autostartPaths)
            {
                foreach (string lnkFile in Directory.GetFiles(autostartPath, "*.lnk"))
                {
                    try
                    {
                        Type shellType = Type.GetTypeFromProgID("WScript.Shell");
                        object shell = Activator.CreateInstance(shellType);
                        object shortcut = shellType.InvokeMember("CreateShortcut", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { lnkFile });
                        string targetPath = shortcut.GetType().InvokeMember("TargetPath", System.Reflection.BindingFlags.GetProperty, null, shortcut, null) as string ?? "";
                        string arguments = shortcut.GetType().InvokeMember("Arguments", System.Reflection.BindingFlags.GetProperty, null, shortcut, null) as string ?? "";

                        bool isSelf = targetPath.ToLower() == myExe || (targetPath.ToLower().EndsWith("cmd.exe") && arguments.ToLower().Contains(myBatch));
                        if (isSelf)
                            continue;

                        string name = Path.GetFileNameWithoutExtension(lnkFile);
                        dgvOrder.Rows.Add(true, name, targetPath, "");
                        File.Delete(lnkFile);
                        imported = true;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            if (imported)
                ShowNotify(" ", "Autostart folder was successfully transferred.", 3000, ToolTipIcon.Info);
            else
                ShowNotify(" ", "No entries found for import.", 2000, ToolTipIcon.Info);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            openURL();
        }

        private void btnInfo2_Click(object sender, EventArgs e)
        {
            openURL();
        }

        private void openURL()
        {
            string url = "https://github.com/TueftelTyp/LaunchOrder";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownPos = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - _mouseDownPos.X;
                int deltaY = e.Y - _mouseDownPos.Y;
                this.Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportAutostarts();
        }

        private void btnDesroyYes_Click(object sender, EventArgs e)
        {
            RemoveFromAutostart();
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LaunchOrder");
            if (Directory.Exists(appDataPath))
            {
                try
                {
                    Directory.Delete(appDataPath, true);
                    ShowNotify("Cleared", "Program will now be closed.", 3000, ToolTipIcon.Info);
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 10000;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        Application.Exit();
                    };
                    timer.Start();
                }
                catch (Exception ex)
                {
                    ShowNotify("Error", " " + ex.Message, 5000, ToolTipIcon.Error);
                }
            }
        }

        private void btnStartFolder_Click(object sender, EventArgs e)
        {
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            if (Directory.Exists(autostartPath))
            {
                Process.Start("explorer.exe", autostartPath);
            }
            else
            {
                ShowNotify("Error", "Autostart-Folder not found!", 3000, ToolTipIcon.Error);
            }
        }

        private void btnDataFolder_Click(object sender, EventArgs e)
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LaunchOrder");
            if (Directory.Exists(appDataPath))
            {
                Process.Start("explorer.exe", appDataPath);
            }
            else
            {
                ShowNotify("Error", "AppData-Folder not found!", 3000, ToolTipIcon.Error);
            }
        }

        public void ShowNotify(string title, string text, int durationMs = 3000, ToolTipIcon icon = ToolTipIcon.Info)
        {
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.BalloonTipIcon = icon;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(durationMs);
        }
    }
}
