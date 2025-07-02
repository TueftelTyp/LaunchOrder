using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchOrder
{
    [Serializable]
    

    public partial class Form1 : Form
    {
        private Point _mouseDownPos;

        public class OrderRow
        {
            public bool Active { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
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
            dgvOrder.Columns.AddRange(colActive, colName, colValue);
            this.dgvOrder.DefaultCellStyle.Font = new Font("Tahoma", 10);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOrderFromXml(xmlFilePath);
            bool shortcutExists = IsShortcutInAutostart();
            btnSetAutostart.Visible = !shortcutExists;
            btnDelAutostart.Visible = shortcutExists;
        }
        private string xmlFilePath;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string filePath = openFileDialog.FileName;
                dgvOrder.Rows.Add(true, fileName, filePath);
            }
        }

        private void btnAddDelay_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Add(true, "-DELAY-", "3");
        }

        private Point dragStartPoint;
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
                // Prüfe, ob die Maus weit genug gezogen wurde
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
            var hitTest = dgvOrder.HitTest(dgvOrder.PointToClient(new Point(e.X, e.Y)).X, dgvOrder.PointToClient(new Point(e.X, e.Y)).Y);
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
            {
                if (dgvOrder.CurrentCell != null)
                {
                    int rowIndex = dgvOrder.CurrentCell.RowIndex;
                    int lastIndex = dgvOrder.Rows.Count - 1;
                }
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
            // Pfad zur Batch-Datei im AppData-Ordner
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string batchPath = Path.Combine(appDataPath, "LaunchOrder", "launch.bat");

            // Verzeichnis anlegen, falls nicht vorhanden
            Directory.CreateDirectory(Path.GetDirectoryName(batchPath));

            // Batch-Inhalt zusammenstellen
            StringBuilder batchContent = new StringBuilder();
            batchContent.AppendLine("@echo off");
            batchContent.AppendLine("setlocal enabledelayedexpansion");

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                // Prüfen, ob die Zeile leer oder neu ist (keine Zellen)
                if (row.IsNewRow) continue;

                // Prüfen, ob die Zeile aktiv ist (Checkbox in erster Spalte)
                bool isActive = row.Cells["Active"].Value != null && Convert.ToBoolean(row.Cells["Active"].Value);
                if (!isActive) continue;

                string name = row.Cells["Name"].Value?.ToString() ?? "";
                string value = row.Cells["Value"].Value?.ToString() ?? "";

                // Delay-Zeile: Timeout einbauen
                if (name.Equals("-DELAY-", StringComparison.OrdinalIgnoreCase))
                {
                    // Wert als Sekunden nehmen
                    int seconds;
                    if (int.TryParse(value, out seconds))
                    {
                        batchContent.AppendLine($"timeout /t {seconds} /nobreak >nul");
                    }
                }
                else
                {
                    // Normale Zeile: Programm starten
                    batchContent.AppendLine($"start \"\" \"{value}\"");
                }
            }

            // Batch-Datei schreiben
            File.WriteAllText(batchPath, batchContent.ToString(), Encoding.Default);

            MessageBox.Show($"Batch-Datei wurde erstellt:\n{batchPath}", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void LoadOrderFromXml(string filePath)
        {
            dgvOrder.Rows.Clear();

            if (!File.Exists(filePath)) return;

            // Deserialisieren
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<OrderRow>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<OrderRow> rows = (List<OrderRow>)serializer.Deserialize(reader);

                foreach (OrderRow row in rows)
                {
                    dgvOrder.Rows.Add(row.Active, row.Name, row.Value);
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
                    Value = row.Cells["Value"].Value?.ToString() ?? ""
                });
            }

            // Serialisieren
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<OrderRow>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, rows);
            }
        }

        

        private void AddToAutostart() 
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string batchPath = Path.Combine(appDataPath, "LaunchOrder", "launch.bat");
            // Pfad zum Autostart-Ordner
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            // Name der Verknüpfung (kann beliebig gewählt werden)
            string shortcutName = "LaunchOrder.lnk";
            string shortcutPath = Path.Combine(autostartPath, shortcutName);
            // Verknüpfung erstellen
            using (StreamWriter writer = new StreamWriter(Path.Combine(Path.GetTempPath(), "launch.vbs")))
            {
                writer.WriteLine("Set oWS = WScript.CreateObject(\"WScript.Shell\")");
                writer.WriteLine($"sLinkFile = \"{shortcutPath.Replace("\\", "\\\\")}\"");
                writer.WriteLine("Set oLink = oWS.CreateShortcut(sLinkFile)");
                writer.WriteLine($"oLink.TargetPath = \"cmd.exe\"");
                writer.WriteLine($"oLink.Arguments = \"/c \"\"{batchPath}\"\"\"");
                writer.WriteLine("oLink.WorkingDirectory = \"\"");
                writer.WriteLine("oLink.Save");
            }
            // VBS-Script ausführen, um die Verknüpfung zu erstellen
            Process.Start("wscript.exe", Path.Combine(Path.GetTempPath(), "launch.vbs")).WaitForExit();
            // Temporäre VBS-Datei löschen
            File.Delete(Path.Combine(Path.GetTempPath(), "launch.vbs"));
        }
        private void RemoveFromAutostart()
        {
            // Pfad zum Autostart-Ordner
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutName = "LaunchOrder.lnk";
            string shortcutPath = Path.Combine(autostartPath, shortcutName);

            if (File.Exists(shortcutPath))
            {
                File.Delete(shortcutPath);}
            }
        private bool IsShortcutInAutostart()
        {
            string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutName = "LaunchOrder.lnk";
            string shortcutPath = Path.Combine(autostartPath, shortcutName);
            return File.Exists(shortcutPath);
        }

        private void btnInfo_Click(object sender, EventArgs e)
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
    }
}
