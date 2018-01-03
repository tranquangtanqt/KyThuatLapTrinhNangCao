using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace btnhom
{
    class KetNoi
    {
        public static OleDbConnection cn = new OleDbConnection();
        public static void MoKetNoi()
        {
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=QLTS1.mdb";
              cn.Open();
              MessageBox.Show(cn.State.ToString());
        }
    }
}
