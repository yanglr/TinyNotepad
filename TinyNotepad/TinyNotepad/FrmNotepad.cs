using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyNotepad
{
    public partial class FrmNotepad:Form
    {
        public FrmNotepad()
        {
            InitializeComponent();
        }

        private string content = String.Empty;

        private Icon _normal = Properties.Resources.normal;
        private Icon _blank = Properties.Resources.blank;
        private bool _status = true;
        private bool _isBlink = false;

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value; 
                // 在赋值时同时更新窗体标题
                this.Text = Path.GetFileName(value) + " - TinyNotepad";
            }
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;
                try
                {
                    content = File.ReadAllText(FileName);
                    txtEditor.Text = content;
                    lblStatus.Text = "成功打开";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法打开文件");
                }
            }
            
        }

        private void FrmNotepad_Load(object sender, EventArgs e)
        {
            lblTime.Text = String.Empty;
            lblStatus.Text = String.Empty;
            // lblFont.Text = SystemFonts.MessageBoxFont.Name; Default font of OS
            lblFont.Text = $"{txtEditor.Font.Name}, {txtEditor.Font.Style}, {txtEditor.Font.Size}";
            this.Text = "Noname - TinyNotepad";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool needSave = false;

            if (FileName == null)
            {
                if (MessageBox.Show("保存当前内容吗?", "保存文件", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
                    {
                        if (saveFileDialog1.FileName == FileName)
                        {
                            if (MessageBox.Show("文件已存在，替换吗?",
                                    "保存文件",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                WriteAsTxt();
                            }
                        }
                        else
                        {
                            FileName = saveFileDialog1.FileName;
                            needSave = true;
                        }
                    }
                }
            }
            else if (FileName != String.Empty)  // 如果文件名不为空，说明文本框内容是从文件中读取到的
            {
                if (txtEditor.Text != content &&
                    MessageBox.Show("文件已修改，保存吗?", 
                                    "保存文件", 
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    needSave = true;
                }
            }

            if (needSave)
            {
                WriteAsTxt();
            }
            else if (FileName != null)
            {
                lblStatus.Text = "内容未变化，已保存";
            }
            else
            {
                lblStatus.Text = String.Empty;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == FileName)
                {
                    if (MessageBox.Show("文件已存在，替换吗?",
                            "保存文件",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        WriteAsTxt();
                    }
                }
                else
                {
                    FileName = saveFileDialog1.FileName;
                    WriteAsTxt();
                }               
            }
        }

        private void WriteAsTxt()
        {
            try
            {
                File.WriteAllText(FileName, txtEditor.Text);
                content = txtEditor.Text;
                lblStatus.Text = "保存成功";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "文件保存失败";
            }
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName == null) 
            {
                lblStatus.Text = "无文件打开，关闭无效";
            }
            else
            {
                FileName = null;
                txtEditor.Clear();
                this.Text = "Noname - MyNotepad";
                lblStatus.Text = "成功关闭";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmNotepad_FormClosing(object sender, FormClosingEventArgs e) // user has clicked “X” or “Close” button
        {
            if(FileName != null & txtEditor.Text != content &&
               MessageBox.Show("文件已修改，保存吗?",
                   "保存文件",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WriteAsTxt();
                lblStatus.Text = "保存成功";
            }
        }

        private void notifyIconMyNotepad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // this.Close();
            Application.Exit();
        }

        private void backToMainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void BlinkStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_isBlink == false)
            {
                _isBlink = true;
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                _isBlink = false;
                timer1.Stop();
                notifyIconMyNotepad.Icon = _normal;

                notifyIconMyNotepad.ShowBalloonTip(9000, "Hint", "Close blink effect.", ToolTipIcon.Info);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(_status)
                notifyIconMyNotepad.Icon = _normal;
            else
                notifyIconMyNotepad.Icon = _blank;

            _status = !_status;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                txtEditor.Font = fontDlg.Font;
                txtEditor.ForeColor = fontDlg.Color;
                lblFont.Text = $"{fontDlg.Font.Name}, {fontDlg.Font.Style}, {fontDlg.Font.Size}";
            }
        }
    }
}