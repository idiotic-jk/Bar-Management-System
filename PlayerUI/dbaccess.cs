﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlayerUI
{
    public class dbaccess
    {
        public SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\bharath\Downloads\bar\PlayerUI\law_db.mdf;Integrated Security = True");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader rdr;
        public SqlDataAdapter da;
        public DataTable dt;
        public String username1 = "";
        public String pass = "";
        public String qry = "";
        public String qry1 = "";
        public String qry2 = "";
        public int i = 0;
        public bool b;
        public DataSet ds;

        public void ExecuteQuery(SqlCommand c)
        {
            c.Connection = con;
            con.Open();
            c.ExecuteNonQuery();
            con.Close();
        }
        public DataTable FetchData(String qry)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public bool checkexist(SqlCommand cmd)
        {

            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                con.Close(); return true;
            }
            else
            {
                con.Close(); return false;
            }

        }
        public SqlDataReader passread(SqlCommand pcmd)
        {
            pcmd.Connection= con;
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader read = (pcmd.ExecuteReader());
            return read;

        }
        public int InsertData(SqlCommand cmd)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();

                i = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return i;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "INPUT ERROR"); return i;
            }
        }
        public void dd(ComboBox c, String s, String a)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(s,con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                c.DisplayMember = a;
                c.ValueMember = a;
                DataRow topItem = dtbl.NewRow();
                topItem[0] = null;
                dtbl.Rows.InsertAt(topItem, 0);
                c.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.Message, "Error occured!");
            }
        }


    }
}


