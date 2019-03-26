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
    public partial class CheckDBForm : Form
    {
        private DBContextService _dbService;

        private bool isWorkerGo = false;

        public CheckDBForm(DBContextService dbService)
        {
            InitializeComponent();

            tlblStatus.Text = "Connecting to Database...";
            _dbService = new DBContextService();
            //_dbService = dbService;
            tlblStatus.Text = "No action.";

        }

        static long oneMinInMilliSeconds = 1000 * 60;
        static long oneHourInMilliSeconds = 60 * oneMinInMilliSeconds;
        static long oneYearInMilliSeconds = 365 * 24 * oneHourInMilliSeconds;

        private void btnStart_Click(object sender, EventArgs e)
        {
            WorkerSetup();
        }

        private void WorkerSetup()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += WorkerDoWork;
            worker.RunWorkerCompleted += WorkerCompleted;

            prgCheck.Style = ProgressBarStyle.Marquee;

            worker.RunWorkerAsync();

         }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            isWorkerGo = true;



            tlblStatus.Text = "Gathering data...";
           
            LabelService.RefreshLabel(lblNoOfCandlesActual, "...");

            Candle earliestCandle = _dbService.Candles.OrderBy(c => c.TimeStamp).FirstOrDefault();
            Candle latestCandle = _dbService.Candles.OrderByDescending(c => c.TimeStamp).FirstOrDefault();

            long earliestTimeStamp = earliestCandle.TimeStamp;
            long latestTimeStamp = latestCandle.TimeStamp;

            long noOfRecords = (latestTimeStamp - earliestTimeStamp) / oneMinInMilliSeconds;
            LabelService.RefreshLabel(lblNoOfCandlesActual, noOfRecords.ToString());

            long noOfProcessedRecords = 0;
            long noOfMissingCandles = 0;
            long noOfDuplicateCandles = 0;
            long noOfFixedCandles = 0;
            LabelService.RefreshLabel(lblNoOfProcessedCandlesActual, "" + noOfProcessedRecords);
            LabelService.RefreshLabel(lblMissingCandlesActual, "" + noOfMissingCandles);
            LabelService.RefreshLabel(lblDuplicateCandlesActual, "" + noOfDuplicateCandles);
            LabelService.RefreshLabel(lblFixedRecordsActual, "" + noOfFixedCandles);

            Candle prevCandle = null;

            tlblStatus.Text = "Checking candles...";

            long i = earliestTimeStamp;
            while (i < latestTimeStamp && isWorkerGo)
            {

                //                List<Candle> candleList = (List<Candle>)(_dbService.Candles.Where(c => c.TimeStamp == i && c.Type==null).ToList());
                List<Candle> candleList = (List<Candle>)(_dbService.Candles.Where(c => c.TimeStamp == i && c.Type == null).ToList());

                if (candleList.Count != 1)
                {
                    if (candleList.Count == 0)
                    {
                        noOfMissingCandles++;
                        if (noOfMissingCandles % 10 == 0)
                            LabelService.RefreshLabel(lblMissingCandlesActual, "" + noOfMissingCandles);

                        Candle fixCandle = new Candle()
                        {
                            CandleId = Guid.NewGuid(),
                            TimeStamp = i,
                            PriceOpen = prevCandle.PriceClose,
                            PriceClose = prevCandle.PriceClose,
                            PriceLow = prevCandle.PriceClose,
                            PriceHigh = prevCandle.PriceClose,
                            Volume = 0
                        };

                        _dbService.Candles.Add((Candle)fixCandle);
                        _dbService.SaveChanges();

                        noOfFixedCandles++;
                        if (noOfFixedCandles % 10 == 0)
                            LabelService.RefreshLabel(lblFixedRecordsActual, "" + noOfFixedCandles);
                    }
                    if (candleList.Count > 1)
                    {
                        noOfDuplicateCandles++;
                        if (noOfDuplicateCandles % 10 == 0)
                            LabelService.RefreshLabel(lblDuplicateCandlesActual, "" + noOfDuplicateCandles);
                    }
                }

                noOfProcessedRecords++;
                if (noOfProcessedRecords % 10 == 0)
                {
                    LabelService.RefreshLabel(lblNoOfProcessedCandlesActual, "" + noOfProcessedRecords);
                    Application.DoEvents();
                }

                if (candleList.FirstOrDefault() != null)
                {
                    prevCandle = candleList.FirstOrDefault();
                }


                i += oneMinInMilliSeconds;

            }
            LabelService.RefreshLabel(lblNoOfProcessedCandlesActual, "" + noOfProcessedRecords);
            LabelService.RefreshLabel(lblMissingCandlesActual, "" + noOfMissingCandles);
            LabelService.RefreshLabel(lblDuplicateCandlesActual, "" + noOfDuplicateCandles);
            LabelService.RefreshLabel(lblFixedRecordsActual, "" + noOfFixedCandles);

            e.Result = "" + noOfProcessedRecords;

        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();

            prgCheck.Style = ProgressBarStyle.Continuous;
            tlblStatus.Text = "No action.";

            if (e.Error != null)
            {
                MessageBox.Show("Error occured while checking: " + e.Result);
            }
            else
            {
                MessageBox.Show(e.Result + " candles checked.");
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isWorkerGo = false;
        }

        private void CheckDBForm_Load(object sender, EventArgs e)
        {

        }
    }
}
