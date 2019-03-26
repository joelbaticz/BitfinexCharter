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
    public partial class UpdateDBForm : Form
    {
        private DBContextService _dbService;
        private bool isWorkerGo = false;

        public UpdateDBForm(DBContextService dbService)
        {
            InitializeComponent();

            tlblStatus.Text = "Connecting to Database...";
            _dbService = new DBContextService();
            //_dbService = dbService;
            tlblStatus.Text = "No action.";
        }

        private void UpdateDBProgressForm_Load(object sender, EventArgs e)
        {

        }

        static long oneMinInMilliSeconds = 1000 * 60;
        static long oneHourInMilliSeconds = 60 * oneMinInMilliSeconds;
        static long oneYearInMilliSeconds = 365 * 24 * oneHourInMilliSeconds;


        long GetCandleRange(long start, long end)
        {

            tlblStatus.Text = "Downloading data...";

            long oneBatch = oneHourInMilliSeconds; // * 2

            long batchStart=0;
            long batchEnd=0;

            long current = start;
            long recordsFetched = 0;
            bool go = true;
            while (go)
            {

                batchStart = current;
                batchEnd = current + oneBatch;

                //Check if these Candles are already present
                //If any of them in an 60 minute block is missing grab the whole 60 min batch
                //bool allPresent = true;
                //for (long candleTS = batchStart; candleTS < batchEnd; candleTS+=oneMinInMilliSeconds)
                //{
                //    if (_dbService.Candles.Where(c => c.TimeStamp == candleTS).FirstOrDefault() == null)
                //    {
                //        allPresent = false;
                //        break;
                //    }
                //}

                //if (!allPresent)
                {

                    //WebService.CandleDataResponse response=null;

                    //while (response==null)
                    //{
                    //    var task = WebService.GetCandleData(batchStart, batchEnd);
                    //    if (task.Status == TaskStatus.RanToCompletion)
                    //    {
                    //        response = task.Result;
                    //    }

                    //}

                    var response = WebService.GetCandleData(batchStart, batchEnd);

                    if (response.StatusMessage == "OK")
                    {
                        //Insert candles

                        if (response.NoOfCandleSticks != 120)
                        {
                            //MessageBox.Show("Candles in response: " + response.NoOfCandleSticks);
                            
                        }

                        foreach (var candle in response.CandleList)
                        {
                            //Check if candle exists, if yes modify, otherwise create

                            

                            if (_dbService.Candles.Where(c => c.TimeStamp == candle.TimeStamp).FirstOrDefault() == null)
                            {
                                _dbService.Candles.Add(candle);
                            }
                        }
                        _dbService.SaveChanges();

                        recordsFetched += response.NoOfCandleSticks;
                        LabelService.RefreshLabel(lblRecordsProcessedActual, "" + recordsFetched);

                        var timeStampHumanReadable = DateTimeService.GetDateTimeFromEpochTime(batchEnd);
                        LabelService.RefreshLabel(lblLatestTimeStampActual, timeStampHumanReadable.ToString("yyyy-MM-dd HH:mm:ss.ffff"));


                    }
                    else
                    {
                        MessageBox.Show(response.StatusMessage);
                        go = false;
                    }
                }

                current += oneBatch;

                if (current > end) go = false;
                if (isWorkerGo == false) go = false;
            }

            return recordsFetched;

        }



        public void ProcessUpdate()
        {
          






            //long latestCandleTimeStamp=0;
            //long earliestCandleTimeStamp = 0;

            //while (latestCandleTimeStamp<roundedTimeStampNow)
            //{
            //    latestCandleTimeStamp = GetCandleBatch();

            //    Candle latestCandle = _dbService.Candles.OrderByDescending(c => c.TimeStamp).FirstOrDefault();
            //    Candle earliestCandle = _dbService.Candles.OrderBy(c => c.TimeStamp).FirstOrDefault();

            //    latestCandleTimeStamp = latestCandle.TimeStamp;
            //    earliestCandleTimeStamp = earliestCandle.TimeStamp;

            //    LabelService.RefreshLabel(lblLatestTimeStampActual, "" + latestCandleTimeStamp);
            //    LabelService.RefreshLabel(lblEarliestTimeStampActual, "" + earliestCandleTimeStamp);
            //}
            
            //return;
            
            
            //long recordsProcessed = 0;
            //long candleUpToDate = 0;
                
            //long batchStart;
            //long batchEnd; 


            ////for (long i = 0; i < 2; i++) //batchesToFetch; i++)
            //long i = roundedTimeStampNow;
            //bool go = true;
            //while (go)
            //{

            //    batchStart = i - oneHourInMilliSeconds;
            //    batchEnd = i;

            //    //Check if these Candles are already present
            //    //If any of them in an 60 minute block is missing grab the whole 60 min batch
            //    bool allPresent = true;
            //    //for (long candleTS = batchStart; candleTS < batchEnd; candleTS+=oneMinInMilliSeconds)
            //    //{
            //    //    if (_dbService.Candles.Where(c => c.TimeStamp == candleTS).FirstOrDefault() == null)
            //    //    {
            //    //        allPresent = false;
            //    //        break;
            //    //    }
            //    //}

            //    //if (!allPresent)
            //    {
                    
            //        var response = WebService.GetCandleData(batchStart, batchEnd);

            //        if (response.StatusMessage == "OK")
            //        {
            //            //Insert candles
            //            foreach (var candle in response.CandleList)
            //            {
            //                //Check if candle exists, if yes modify, otherwise create

            //                if (_dbService.Candles.Where(c => c.TimeStamp == candle.TimeStamp).FirstOrDefault() == null)
            //                {
            //                    _dbService.Candles.Add(candle);
            //                }
            //            }
            //            _dbService.SaveChanges();


            //            //i = i - (response.NoOfCandleSticks * oneMinInMilliSeconds);

            //            candleUpToDate = i;
            //            recordsProcessed += response.NoOfCandleSticks;

            //            LabelService.RefreshLabel(lblLatestTimeStampActual, candleUpToDate.ToString());
            //            LabelService.RefreshLabel(lblEarliestTimeStampActual, DateTimeService.GetDateTimeFromEpochTime(candleUpToDate).ToString("yyyy-MM-dd THH:mm:ss.fff"));

            //            LabelService.RefreshLabel(lblRecordsProcessedActual, recordsProcessed.ToString());


                        
            //        }
            //        else
            //        {
            //            MessageBox.Show(response.StatusMessage);
            //            go = false;
            //        }
            //    }

            //    i -= oneHourInMilliSeconds;

            //    if (i > latestCandleTimeStamp) go = false;
            //}

            //MessageBox.Show("Last Candle gathered:" + i.ToString());


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += WorkerDoWork;
            worker.RunWorkerCompleted += WorkerCompleted;

            prgUpdate.Style = ProgressBarStyle.Marquee;

            btnUpdate.Enabled = false;
            btnStop.Enabled = true;
            worker.RunWorkerAsync();

        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            isWorkerGo = true;
            
            tlblStatus.Text = "Gathering info...";

            LabelService.RefreshLabel(lblRecordsProcessedActual, "-");

            Candle earliestCandle = _dbService.Candles.OrderBy(c => c.TimeStamp).FirstOrDefault();
            Candle latestCandle = _dbService.Candles.OrderByDescending(c => c.TimeStamp).FirstOrDefault();

            long recordsFetched = 0;

            if (latestCandle == null)
            {
                //No Candles present
                long timeStampNow = DateTimeService.GetEpochTimeNow();
                long roundedTimeStampNow = (timeStampNow / oneMinInMilliSeconds) * oneMinInMilliSeconds;

                long start = roundedTimeStampNow - (1 * oneYearInMilliSeconds);
                long end = roundedTimeStampNow;

                var timeStampHumanReadable = DateTimeService.GetDateTimeFromEpochTime(start);
                LabelService.RefreshLabel(lblEarliestTimeStampActual, timeStampHumanReadable.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

                recordsFetched = GetCandleRange(start, end);
            }
            else
            {
                //Continue from last time
                long timeStampNow = DateTimeService.GetEpochTimeNow();
                long roundedTimeStampNow = (timeStampNow / oneMinInMilliSeconds) * oneMinInMilliSeconds;

                long start = latestCandle.TimeStamp;
                long end = roundedTimeStampNow;

                var timeStampHumanReadable = DateTimeService.GetDateTimeFromEpochTime(earliestCandle.TimeStamp);
                LabelService.RefreshLabel(lblEarliestTimeStampActual, timeStampHumanReadable.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

                recordsFetched = GetCandleRange(start, end);
            }

            e.Result = "" + recordsFetched;
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();

            prgUpdate.Style = ProgressBarStyle.Continuous;
            tlblStatus.Text = "No action.";
            btnUpdate.Enabled = true;
            btnStop.Enabled = false;

            if (e.Error != null)
            {
                MessageBox.Show("Error occured while updating: " + e.Result);
            }
            else
            {
                MessageBox.Show(e.Result + " candles updated.");
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isWorkerGo = false;
            tlblStatus.Text = "Stopping...";
        }
    }
}
