using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitfinexCharter.Services;
using BitfinexCharter.Models;

namespace BitfinexCharter
{
    public partial class DatabaseForm : Form
    {
        private DBContextService _dbService;

        public struct FormStatus
        {
            public const string Init = "Initalizing...";
            public const string Connecting = "Connecting to Database...";
            public const string Estabilished = "Connection estabilished.";
            public const string Error = "Connection error.";
        }



        public DatabaseForm(DBContextService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            UpdateDBForm updateProgressForm = new UpdateDBForm(_dbService);
            updateProgressForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteForm deleteForm = new DeleteForm(_dbService);
            deleteForm.Show();
        }

        private void btnCheckDB_Click(object sender, EventArgs e)
        {
            CheckDBForm checkProgressForm = new CheckDBForm(_dbService);
            checkProgressForm.Show();
        }

        private void btnCreateOtherCandles_Click(object sender, EventArgs e)
        {
            CreateCandlesForm createCandlesForm = new CreateCandlesForm(_dbService);
            
            createCandlesForm.Show();
        }





        


        //private void BackgroundDo(sender, args)
        //{

        //}


        private void brnRunBackground_Click(object senderer, EventArgs exc)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, args) =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    //lblStatus.Text = "" + i;
                    
                }
                    args.Result = "macska";
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    lblStatus.Text = "Status: Error";
                }
                else
                {
                    lblStatus.Text = "Status: OK";
                }
            };

            worker.RunWorkerAsync();
            




        }
    }
}
