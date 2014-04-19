using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace ABS_CSV_Loader
{
    public partial class frmMain : Form
    {
        public int numFiles = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            lstCompleted.Items.Clear();
            lstPending.Items.Clear();
            numFiles = 0;
            refreshcount();
            dlgFolderBrowser.ShowDialog();
            txtFolder.Text = dlgFolderBrowser.SelectedPath;
            getdirectory(dlgFolderBrowser.SelectedPath);
        }

        private void getdirectory(string strPath)
        {
            DirectoryInfo directoryInfo= new DirectoryInfo(strPath); 
            if(directoryInfo.Exists)
            {
                try
                {
                    FileInfo[] fileInfo = directoryInfo.GetFiles("*.csv");
                    foreach (FileInfo file in fileInfo)
                    {
                        lstPending.Items.Add(file.FullName);
                        numFiles++;
                        refreshcount();
                    }                   
                }catch(Exception ex)
                {
                    txtFileName.Text = ex.Message;
                    txtFileName.Refresh();
                }
                try
                {
                    DirectoryInfo[] subdirectoryInfo = directoryInfo.GetDirectories();
                    foreach (DirectoryInfo subDirectory in subdirectoryInfo)
                    {
                        getdirectory(subDirectory.FullName);
                    }
                }
                catch (Exception ex)
                {
                    txtFileName.Text = ex.Message;
                    txtFileName.Refresh();
                }
            }                      
        }

        private void refreshcount()
        {
            txtCount.Text = numFiles.ToString() + " files in queue";
            this.Refresh();
        }

        private void lstPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFileName.Text = lstPending.SelectedItem.ToString();
        }

        private void lstCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFileName.Text = lstCompleted.SelectedItem.ToString();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var items = new System.Collections.ArrayList(lstPending.Items);
            foreach (var item in items)
            {
                string strItemString = item.ToString();
                string strPath = strItemString.Substring(0, strItemString.LastIndexOf("\\")) + "\\";
                string strFileName = strItemString.Substring(strItemString.LastIndexOf("\\") + 1);
                processfile(strPath, strFileName);
                numFiles--;
                refreshcount();
                lstCompleted.Items.Add(item);
                lstCompleted.Refresh();
                lstPending.Items.Remove(item);
                lstPending.Refresh();
            }
        }

        private void processfile(string strPath, string strFileName)
        {
            txtFileName.Text = "Processing " + strFileName;
            this.Refresh();
            
            string strTableName = "tbl" + strFileName.Replace(".csv","");


            string strConnection = "Server=" + txtServer.Text.Trim() + " ;Database=" + txtDatabase.Text.Trim() + ";Uid=" + txtUid.Text.Trim() +";Pwd=" + txtPwd.Text.Trim();
            MySqlConnection conn = new MySqlConnection(strConnection);
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                string line;
                int counter = 0;
                int numcols = 0;

                System.IO.StreamReader file = new System.IO.StreamReader(strPath + strFileName);
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    string SQLCommand = "";
                    if (counter == 1)
                    {
                        string[] arrHeader = line.Split(',');
                        numcols = arrHeader.Length;

                        /*Create target table*/
                        txtFileName.Text = "Creating target table " + strTableName;
                        this.Refresh();

                        SQLCommand = "create table if not exists " + strTableName + " (";
                        for (int i = 0; i < numcols; i++)
                        {
                            if (i != 0) { SQLCommand = SQLCommand + ","; }
                            SQLCommand = SQLCommand + "A" + i.ToString() + " text";
                        }
                        SQLCommand = SQLCommand + ");";
                        cmd.CommandText = SQLCommand;
                        cmd.ExecuteNonQuery();

                        /*Add Metadata*/
                        txtFileName.Text = "Udating meta info ... ";
                        this.Refresh();


                        SQLCommand = "delete from tblMeta where tblName = '" + strTableName + "' ;";
                        cmd.CommandText = SQLCommand;
                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < numcols; i++)
                        {
                            SQLCommand = "insert into tblMeta (tblName,tblfield,tblFieldDesc) values ('" + strTableName + "','" + "A" + i.ToString() + "','" + arrHeader[i] + "');";
                            cmd.CommandText = SQLCommand;
                            cmd.ExecuteNonQuery();
                        }

                        txtFileName.Text = "Purging " + strTableName;
                        this.Refresh();

                        /*Purge target table*/
                        SQLCommand = "delete from " + strTableName + ";";
                        cmd.CommandText = SQLCommand;
                        cmd.ExecuteNonQuery();
                    }
                    else 
                    {
                        txtFileName.Text = "Importing data into " + strTableName + " - " + counter.ToString() + " rows processed";
                        this.Refresh();

                        string[] arrHeader = line.Split(',');
                        if (arrHeader.Length == numcols) 
                        {
                            /*insert row*/
                            SQLCommand = "Insert into " + strTableName + " values (";
                            for (int i = 0; i < numcols; i++)
                            {
                                if (i != 0) { SQLCommand = SQLCommand + ","; }
                                SQLCommand = SQLCommand + "'" + arrHeader[i] +"'" ;
                            }
                            SQLCommand = SQLCommand + ");";
                            cmd.CommandText = SQLCommand;
                            cmd.ExecuteNonQuery();
                        }
                    
                    }

                }
                file.Close();
                txtFileName.Text = "Finished processing " + strFileName;
                this.Refresh();
            }
            catch (Exception ex)
            {
                txtFileName.Text = ex.Message;
                this.Refresh();
            }
            finally 
            {
                txtFileName.Text = "";
                this.Refresh();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


    }
}

