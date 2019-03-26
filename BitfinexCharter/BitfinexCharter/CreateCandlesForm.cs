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
using System.Data.Entity;

namespace BitfinexCharter
{
    public partial class CreateCandlesForm : Form
    {
        private DBContextService _dbService;

        //Label lblRecordsToBeMadeActual;

        bool isWorkerGo = false;

        public CreateCandlesForm(DBContextService dbService)
        {
            InitializeComponent();

            tlblStatus.Text = "Connecting to Database...";
            _dbService = new DBContextService();
            //_dbService = dbService;
            tlblStatus.Text = "No action.";

            //lblRecordsToBeMadeActual = new Label();
            //lblRecordsToBeMadeActual.Text = "...";
            //lblRecordsToBeMadeActual.Visible = true;
            //lblRecordsToBeMadeActual.Parent = this;
            //lblRecordsToBeMadeActual.Left = 0;
            //lblRecordsToBeMadeActual.Top = 100;
            //this.Controls.Add(lblRecordsToBeMadeActual);
        }

        private void CreateCandlesForm_Load(object sender, EventArgs e)
        {

        }

        long oneMinInMilliSecs = 60000;
        long fiveMinInMilliSecs = 300000;
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (sourceType=="1m" && destType=="5m")
            {
                WorkerSetup(sourceType, destType);
            }
            else
            {
                MessageBox.Show("Invalid Conversion!" + sourceType + ", " + destType);
            }
        }

        private void WorkerSetup(string sourceType, string destType)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += WorkerDoWork;
            worker.RunWorkerCompleted += WorkerCompleted;

            prgCreate.Style = ProgressBarStyle.Marquee;

            worker.RunWorkerAsync();
        }


    

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            isWorkerGo = true;

            //prgCreate.Style = ProgressBarStyle.Marquee;

            //Delete old records
            //tlblStatus.Text = "Deleting old records...";

            //var toDelete = _dbService.Candles.Where(c => c.Type == "5m");
            //_dbService.Candles.RemoveRange(toDelete);
            //_dbService.SaveChanges();

            tlblStatus.Text = "Continuing from last time...";
            long lastRecordCreated = 0;

            IQueryable<Candle> destCandles = _dbService.Candles.Where(c => c.Type == destType);

            if (destCandles.Count() > 0)
            {
                lastRecordCreated = destCandles.Max(c => c.TimeStamp);
            }

            //Create new records
            tlblStatus.Text = "Creating records...";

            long latest = _dbService.Candles.Max(c => c.TimeStamp);
            long earliest = _dbService.Candles.Min(c => c.TimeStamp);

            long noOfCandles = (latest - earliest) / 60000;

           // lblSourceRecordsActual.Text = "" + noOfCandles;

            long start = (earliest + destGranurality) / destGranurality;
            long end = (latest - destGranurality) / destGranurality;
            if ((lastRecordCreated + destGranurality) / destGranurality > start)
            {
                start = (lastRecordCreated + destGranurality) / destGranurality;
            }
            long recordsToBeMade = end - start;
            long recordsCreated = 0;

            long startActual = start * destGranurality;
            long endActual = end * destGranurality;

            ////lblRecordsToBeMadeActual.Text = "" + recordsToBeMade;
            //if (lblRecordsToBeMadeActual.InvokeRequired)
            //{
            //    //MessageBox.Show("damn");
            //    SetTextCallback callback = new SetTextCallback(WorkerDoWork);



            //}

            //SetText("" + recordsToBeMade);

            LabelService.RefreshLabel(lblRecordsToBeMadeActual, "" + recordsToBeMade);

            //for (long i = startActual; i < endActual; i += destGranurality)
            long i = startActual;
            while (i < endActual && isWorkerGo)
            {
                long collect = destGranurality / sourceGranurality;

                Candle newCandle = new Candle
                {
                    CandleId = Guid.NewGuid(),
                    TimeStamp = i,
                    PriceOpen = 0,
                    PriceClose = 100000,
                    PriceLow = 100000,
                    PriceHigh = 0,
                    Volume = 0,
                    Type = "5m"
                };

                for (long j = 0; j < collect * sourceGranurality; j += sourceGranurality)
                {
                    var candleToGet = i + j;
                    var wantedCandle = _dbService.Candles.Where(c => c.TimeStamp == candleToGet && c.Type == null).FirstOrDefault();

                    if (j == 0) newCandle.PriceOpen = wantedCandle.PriceOpen;
                    newCandle.PriceClose = wantedCandle.PriceClose;

                    if (newCandle.PriceLow > wantedCandle.PriceLow) newCandle.PriceLow = wantedCandle.PriceLow;
                    if (newCandle.PriceHigh < wantedCandle.PriceHigh) newCandle.PriceHigh = wantedCandle.PriceHigh;

                    newCandle.Volume += wantedCandle.Volume;
                                       
                }

                _dbService.Candles.Add(newCandle);
                _dbService.SaveChanges();

                recordsToBeMade--;
                
                LabelService.RefreshLabel(lblRecordsToBeMadeActual, "" + recordsToBeMade);

                i += destGranurality;
                recordsCreated++;
            }

            e.Result = "" + recordsCreated;
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();

            prgCreate.Style = ProgressBarStyle.Continuous;
            tlblStatus.Text = "No action";

            if (e.Error != null)
            {
                MessageBox.Show("Error occured while creating: " + e.Result);
            }
            else
            {
                MessageBox.Show(e.Result + " candles created.");
            }

        }

        string sourceType="1m";
        string destType="5m";

        long sourceGranurality=60000;
        long destGranurality=300000;

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbSource.Text;

            if (text=="1 minute")
            {
                sourceType = "1m";
                sourceGranurality = 60000;
            }
            else if (text == "5 minutes")
            {
                sourceType = "5m";
                sourceGranurality = 300000;
            }
            if (text == "15 minutes")
            {
                sourceType = "15m";
                sourceGranurality = 900000;
            }
            if (text == "30 minutes")
            {
                sourceType = "30m";
                sourceGranurality = 1800000;
            }
            if (text == "1 hour")
            {
                sourceType = "1h";
                sourceGranurality = 3600000;
            }
        }

        private void cbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbDestination.Text;

            if (text == "1 minute")
            {
                destType="1m";
                destGranurality = 60000;
            }
            else if (text == "5 minutes")
            {
                destType = "5m";
                destGranurality = 300000;
            }
            else if (text == "15 minutes")
            {
                destType = "15m";
                destGranurality = 900000;
            }
            else if (text == "30 minutes")
            {
                destType = "30m";
                destGranurality = 1800000;
            }
            else if (text == "1 hour")
            {
                destType = "1h";
                destGranurality = 3600000;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isWorkerGo = false;
            tlblStatus.Text = "Stopping...";
        }
    }
}
