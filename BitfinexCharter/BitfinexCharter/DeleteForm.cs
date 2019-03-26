using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using BitfinexCharter.Services;
using BitfinexCharter.Models;


namespace BitfinexCharter
{
    public partial class DeleteForm : Form
    {
        private DBContextService _dbService;

        public DeleteForm(DBContextService dbService)
        {
            InitializeComponent();

            tlblStatus.Text = "Connecting to Database...";
            _dbService = new DBContextService();
            //_dbService = dbService;
            tlblStatus.Text = "No action.";
        }

        private async Task DeleteBackground(string type)
        {
            var rangeToDelete = _dbService.Candles.Where(c => c.Type == type);

            _dbService.Candles.RemoveRange(rangeToDelete);
            await _dbService.SaveChangesAsync();
        }


        private void StartInBackground(string type)
        {
            //Setting up Worker thread

            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (sender, args) =>
            {
                tlblStatus.Text = "Deleting records...";

                IQueryable<Candle> candlesToClear;
                if (type == "All")
                    candlesToClear = _dbService.Candles.Where(c => c.Type == null);
                else
                    candlesToClear = _dbService.Candles.Where(c => c.Type == type);

                _dbService.Candles.RemoveRange(candlesToClear);
                _dbService.SaveChangesAsync();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                prgDelete.Style = ProgressBarStyle.Continuous;

                if (e.Error != null)
                {
                    MessageBox.Show("Error occured while deleting: " + e.Result);
                }
                else
                {
                    MessageBox.Show("" + type + " candles have been deleted.");
                }

            };

            btnDelete.Enabled = false;
            prgDelete.Style = ProgressBarStyle.Marquee;

            worker.RunWorkerAsync();

  

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {  

            
            string type = "None";

            if (cmbType.Text == "1 minute") type = "1m";
            if (cmbType.Text == "5 minutes") type = "5m";
            if (cmbType.Text == "15 minutes") type = "15m";
            if (cmbType.Text == "30 minutes") type = "30m";
            if (cmbType.Text == "1 hour") type = "1h";
            if (cmbType.Text == "All") type = "All";

            if (type!="None")
            {
                if (type == "All" || type == "5m")
                {
                    StartInBackground(type);
                }
                else if (type == "1m")
                {
                    MessageBox.Show("Can't delete 1m candles.");
                }
                else
                {
                    MessageBox.Show("Not implemented yet.");
                }
            }
        }
    }
}
