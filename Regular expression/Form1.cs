using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regular_expression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            lvResult.View = View.Details;
            lvResult.Columns.Add("Value", 500, HorizontalAlignment.Center);
            lvResult.Columns.Add("Index", 300, HorizontalAlignment.Center);
            lvResult.Columns.Add("Length", 300, HorizontalAlignment.Center);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDatetime.Text = "Day " + (int)DateTime.Now.DayOfWeek + " | " + DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Run();
            }
        }

        private void Run()
        {
            lblStatus.Text = DateTime.Now.ToShortTimeString() + ">> Running...";
            Stopwatch top = new Stopwatch();
            lvResult.Items.Clear();
            top.Start();
            try
            {
                Regex rex = new Regex(txtRegex.Text);
                MatchCollection matchs = rex.Matches(txtInput.Text);
                foreach (Match item in matchs)
                {
                    var itemlv = new ListViewItem(item.ToString());
                    itemlv.SubItems.Add(item.Index.ToString());
                    itemlv.SubItems.Add(item.Length.ToString());
                    lvResult.Items.Add(itemlv);
                }
                lblCount.Text = matchs.Count.ToString() + " match(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                top.Stop();
                lblStatus.Text = DateTime.Now.ToShortTimeString() + ">> Done";
                lblTime.Text = top.ElapsedMilliseconds.ToString() + " ms";
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run();
        }
    }
}
