using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace btnhom
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbCommandBuilder cb;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           KetNoi.MoKetNoi();
            cmd = new OleDbCommand("select * from MENU", KetNoi.cn);
            ds.Clear();
            da = new OleDbDataAdapter(cmd);
            da.SelectCommand = cmd;
            cb = new OleDbCommandBuilder(da);
            da.Fill(ds, "MENU");
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("Text",ds,"MENU.monID");
            txtTenMon.DataBindings.Clear();
            txtTenMon.DataBindings.Add("Text", ds, "MENU.tenmon");
            txtDonVi.DataBindings.Clear();
            txtDonVi.DataBindings.Add("Text", ds, "MENU.donvi");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", ds, "MENU.dongia");
        }

        private void XoaText()
        {
            txtTenMon.Text=txtMaMon.Text=txtDonVi.Text=txtDonGia.Text="";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            XoaText();
            this.BindingContext[ds, "MENU"].AddNew();

           /* AnHien(true);
            butHuy.Enabled = butSua.Enabled = butLuu.Enabled = true;
            AnHienTienLui(false);*/


        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds, "MENU"].EndCurrentEdit();
            da.Update(ds, "MENU");
           /* AnHien(false);
            AnHienTienLui(true);
            butLuu.Enabled = butHuy.Enabled = false;*/

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            this.BindingContext[ds, "MENU"].RemoveAt(this.BindingContext[ds, "MENU"].Position);
            da.Update(ds, "MENU");

           
           /* AnHien(false);
            AnHienTienLui(true);
            butLuu.Enabled = butHuy.Enabled = false;*/

        }

       /* private void listViewMenu_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtMaMon.Text = e.Item.Text;
            txtTenMon.Text = e.Item.SubItems[1].Text;
            txtDonVi.Text = e.Item.SubItems[2].Text;
            txtDonGia.Text = e.Item.SubItems[3].Text;

        }*/

        private void btnLuu_Click(object sender, EventArgs e)
        {

            BindingContext[ds, "MENU"].EndCurrentEdit();
            da.Update(ds, "MENU");
            /*AnHien(false);
            AnHienTienLui(true);
            butLuu.Enabled = butHuy.Enabled = false;*/


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            this.BindingContext[ds, "MENU"].CancelCurrentEdit();
            Form1_Load(sender, e);


           /* AnHien(true);
            butHuy.Enabled = butSua.Enabled = butLuu.Enabled = true;
            AnHienTienLui(false);*/

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult h = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                this.Close();
        }

        private void butcuoi_Click(object sender, EventArgs e)
        {
            BindingContext[ds, "MENU"].Position = BindingContext[ds, "MENU"].Count - 1;
            


        }

        private void butdau_Click(object sender, EventArgs e)
        {
            BindingContext[ds, "MENU"].Position = 0;
        }

        private void butlui_Click(object sender, EventArgs e)
        {
            if (BindingContext[ds, "MENU"].Position > 0) BindingContext[ds, "MENU"].Position--;
        }

        private void buttien_Click(object sender, EventArgs e)
        {
            if (BindingContext[ds, "MENU"].Position < BindingContext[ds, "MENU"].Count - 1) BindingContext[ds, "MENU"].Position++;
        }







    }
}
