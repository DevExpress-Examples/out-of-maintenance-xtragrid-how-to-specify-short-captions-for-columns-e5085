using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication42 {
    public partial class Form1 : Form {
        Dictionary<string, string> ShortCaptions;

        public Form1() {
            InitializeComponent();
            ShortCaptions = new Dictionary<string, string>();
            ShortCaptions.Add("CustomerID", "ID");
            ShortCaptions.Add("ContactName", "Name");
            ShortCaptions.Add("ContactTitle", "Title");
            ShortCaptions.Add("CompanyName", "Company");
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.nwindDataSet.Customers);
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e) {
            if (e.Column == null) return;
            SizeF s = e.Appearance.CalcTextSize(e.Cache, e.Info.Caption, e.Info.CaptionRect.Width);
            if (s.Width >= e.Info.CaptionRect.Width) {
                if (ShortCaptions.ContainsKey(e.Column.FieldName)) {
                    e.Info.Caption = ShortCaptions[e.Column.FieldName];
                }
            }
        }
    }
}
