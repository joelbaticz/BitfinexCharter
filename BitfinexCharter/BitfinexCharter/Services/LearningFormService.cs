using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitfinexCharter.Services;
using BitfinexCharter.Models;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace BitfinexCharter.Services
{
    public class LearningFormService
    {
        private bool _isInitialized = false;
        private LearningForm _form;
        private DBContextService _dbService;
        private List<Candle> _candleList;
        private long _currentCandleTimeStamp;
        private bool _isLearning = false;
        private bool _isPredict = false;

        private Button _btnLearn;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _tlblStatus;
        private GroupBox _grpCurrentSet;
        private Label _lblStartRecordActual;
        private PictureBox _picCandleChart;
        private ProgressBar _prgLearn;

        private ComboBox _cbResoltion;
        private ComboBox _cbNoOfCandles;

        private ListBox _lbFeatures;

        private string _resolutionString = "";
        private long _noOfCandles = 0;

        private double _prevMagLevel = 100000000;

        private bool _isLearningGo = false;

        //LEARNING PROPS
        private int _NoOfParams = 5;
        private long _currentCandleToLearn;

        //private class Feature
        //{
        //    public List<double> param = new List<double>();
        //    public long groupNumber = 0;
        //}

        private List<Feature> _featureList = new List<Feature>();
   
        public static class Resolution
        {
            private static long oneMin = 60000;
            public static long GetLong(string resolutionString)
            {
                if (resolutionString == "1m")
                {
                    return oneMin;
                }
                else if (resolutionString == "5m")
                {
                    return 5 * oneMin;
                }
                else if (resolutionString == "15m")
                {
                    return 15 * oneMin;
                }
                else if (resolutionString == "30m")
                {
                    return 30 * oneMin;
                }
                else if (resolutionString == "1h")
                {
                    return 60 * oneMin;
                }
                return 0;
            }
            public static string GetDBMnemonic(string resolutionString)
            {
                if (resolutionString == "1m")
                {
                    return null;
                }
                else
                {
                    return resolutionString;
                }
            }
        }

        public LearningFormService(DBContextService dbService)
        {
            _dbService = dbService;

            _form = new LearningForm(this);
            _btnLearn = (Button)_form.Controls["btnLearn"];
            _statusStrip = (StatusStrip)_form.Controls["statusStrip1"];

            _tlblStatus = new ToolStripStatusLabel();
            _statusStrip.Items.Clear();
            _statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _tlblStatus});

            _grpCurrentSet = (GroupBox)_form.Controls["grpCurrentSet"];
            _lblStartRecordActual = (Label)_grpCurrentSet.Controls["lblStartRecordActual"];
            _prgLearn = (ProgressBar)_form.Controls["prgLearn"];

            _picCandleChart = (PictureBox)_grpCurrentSet.Controls["picCandleChart"];
            _picCandleChart.BackColor = Color.Black;
            
            //_picCandleChart = new PictureBox();
            //_picCandleChart.Location = new System.Drawing.Point(0, 0);
            //_picCandleChart.Name = "picCandleChart";
            //_picCandleChart.Size = new System.Drawing.Size(231, 235);
            _picCandleChart.Paint += new System.Windows.Forms.PaintEventHandler(CandleChartPaint);
            //_grpCurrentSet.Controls.Add(_picCandleChart);

            _cbResoltion = (ComboBox)_form.Controls["cbResolution"];
            _cbNoOfCandles = (ComboBox)_form.Controls["cbNoOfCandles"];

            _lbFeatures = (ListBox)_form.Controls["lbFeatures"];
//            _picCandleChart.Paint += new System.Windows.Forms.PaintEventHandler(CandleChartPaint);

            _btnLearn.Enabled = true;
            _lblStartRecordActual.Text = "(loading...)";
            _tlblStatus.Text = "Initializing...";

            _resolutionString =  _cbResoltion.Text;
            _noOfCandles = long.Parse(_cbNoOfCandles.Text);

            _form.Show();
            _form.Refresh();
                        
            GetDataset();
        }

        public void GetCandleList(long firstTimeStamp, long noOfRecords)
        {

            long lastTimeStamp = firstTimeStamp + (Resolution.GetLong(_resolutionString) * _noOfCandles);
            
            _isInitialized = true;
            var firstTimeStampHumanReadableString = DateTimeService.GetDateTimeFromEpochTime(firstTimeStamp).ToString("yyyy-MM-dd THH:mm:ss.fff");

            //_lblStartRecordActual.Text = firstTimeStampHumanReadableString;
            //_lblStartRecordActual.Refresh();
            LabelService.RefreshLabel(_lblStartRecordActual, firstTimeStampHumanReadableString);

            string DBFilter = Resolution.GetDBMnemonic(_resolutionString);
            _candleList = _dbService.Candles.Where(c => (c.TimeStamp >= firstTimeStamp && c.TimeStamp < lastTimeStamp && c.Type==DBFilter)).OrderBy(c => c.TimeStamp).ToList();

        }

        public void GetDataset()
        {
            _tlblStatus.Text = "Loading DataSet...";
            string DBFilter = Resolution.GetDBMnemonic(_resolutionString);
            Candle firstCandle = _dbService.Candles.Where(c => c.Type == DBFilter).OrderBy(c => c.TimeStamp).FirstOrDefault();
            _currentCandleTimeStamp = firstCandle.TimeStamp; //1471255800000;

            GetCandleList(_currentCandleTimeStamp, _noOfCandles);

            _tlblStatus.Text = "Rendering...";
            _picCandleChart.Refresh();

            _tlblStatus.Text = "No action.";
        }

        public void CandleChartPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            var penBlue = new Pen(Color.DeepSkyBlue, 1);
            var penOrange = new Pen(Color.Orange, 1);
            var penGreen = new Pen(Color.Green, 1);
            var penRed = new Pen(Color.Red, 1);

            var brushBlack = new SolidBrush(Color.Black);
            var brushGreen = new SolidBrush(Color.Green);
            var fontBrush = new SolidBrush(Color.LightGray);
            var learningBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Blue, Color.Green);
            var predictBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Red, Color.Orange);


            var font = new Font("Arial", 13);
         

            var picWidth = _picCandleChart.Width;
            var picHeight = _picCandleChart.Height;

            if (!_isInitialized)
            {
                g.Clear(_picCandleChart.BackColor);
                g.DrawString("Loading...", font, fontBrush, 0, 0);
            }
            else
            {
                g.Clear(_picCandleChart.BackColor);
                g.FillRectangle(brushBlack, 0, 0, picWidth, picHeight);
                g.DrawRectangle(penBlue, 1, 1, picWidth - 1, picHeight - 1);

                double marginH = 20;
                double marginV = 20;
                double oneCandleWidth = (picWidth - (2 * marginH)) / _noOfCandles;
                double viewportV = picHeight - (2 * marginV);
                double viewportH = picWidth - (2 * marginH);
                                
                double maxHigh = (double)_candleList.Max(c => c.PriceHigh);
                double maxLow = (double)_candleList.Min(c => c.PriceLow);


                double magLevel = (viewportV / (maxHigh - maxLow));

                if (magLevel < _prevMagLevel)
                {
                    _prevMagLevel = magLevel;
                }
                else
                {
                    magLevel = _prevMagLevel;
                }

                if (_isLearning)
                {
                    long fromCandle = (_currentCandleToLearn - _currentCandleTimeStamp) / Resolution.GetLong(_resolutionString);
                    long toCandle = fromCandle + _NoOfParams;

                    float x = (float)(marginH + (fromCandle * oneCandleWidth));
                    g.FillRectangle(learningBrush, x, (float)(marginV), (float)(_NoOfParams* oneCandleWidth), (float)(viewportV));


                }

                if (_isPredict)
                {
                    //Go thru the candles.
                    //Check which pattern they are the closest
                    //Put a rectangle around them if matches something with more then 50%

                    for (int i = 0; i < _candleList.Count - _NoOfParams; i++)
                    {
                        long fromCandle = (_candleList[i].TimeStamp - _currentCandleTimeStamp) / Resolution.GetLong(_resolutionString);
                        //long fromCandle = (_candleList[i].TimeStamp) / Resolution.GetLong(_resolutionString);
                        //long toCandle = fromCandle + _NoOfParams;


                        long fromCandleTS = _candleList[i].TimeStamp;
                        long toCandleTS = _candleList[i + _NoOfParams].TimeStamp;
                        //Grab the closest prediction

                        //Create comparing CandleSet

                        List<Candle> candleSet = _candleList.Where(c => c.TimeStamp >= fromCandleTS && c.TimeStamp <= toCandleTS).ToList();

                        Feature feat = MLService.CandleSetToFeature(candleSet);

                        feat = MLService.Normalize(feat);

                        //long closestFeatureIndex = MLService.Compare(_featureList, feat);
                        Feature closestFeat = MLService.Compare(_featureList, feat);



                        //var currentFeature = new Feature();
                        //for (int j = 0; j < _NoOfParams; j++)
                        //{
                        //    var param = _candleList[i+j].PriceClose;
                        //    currentFeature.param.Add(param);
                        //}

                        //Calculate averages
                        //List<double> prices = new List<double>();
                        //double firstItem = (_candleList[i].PriceLow + _candleList[i].PriceHigh) / 2;
                        //for (int j = 0; j < _NoOfParams; j++)
                        //{
                        //    double avg = ((_candleList[i+j].PriceLow + _candleList[i+j].PriceHigh) / 2) / firstItem;
                        //    prices.Add(avg);
                        //}

                        ////Normalize CandleSet
                        //List<double> normalizedParams = new List<double>();
                        //double lastParam = prices[0];
                        //for (int j = 0; j < prices.Count; j++)
                        //{
                        //    double currentParam = prices[j] / lastParam;

                        //    normalizedParams.Add(currentParam);
                        //    lastParam = currentParam;
                        //}


                        //double minDiff = double.MaxValue;
                        //double minDiffPerc = double.MaxValue;
                        //int minDiffIndex = int.MaxValue;

                        //for (int j = 0; j < _featureList.Count; j++)
                        //{
                        //    double currentDiff = 0;
                        //    double currentParamSum = 0;
                        //    double featParamSum = 0;
                        //    for (int k = 0; k < _featureList[j].param.Count; k++)
                        //    {
                        //        double paramDiff = Math.Abs(normalizedParams[k] - _featureList[j].param[k]);

                        //        currentParamSum += normalizedParams[k];
                        //        featParamSum = _featureList[j].param[k];

                        //        currentDiff += paramDiff;
                        //    }
                        //    if (minDiff > currentDiff)
                        //    {
                        //        minDiff = currentDiff;
                        //        minDiffPerc = currentParamSum / featParamSum;
                        //        minDiffIndex = j;
                        //    }
                        //}

                        //if (minDiffPerc < 2)
                        {


                            //float x = (float)(marginH + (fromCandle * oneCandleWidth));
                            ////g.FillRectangle(predictBrush, x, (float)(marginV), (float)(_NoOfParams * oneCandleWidth), (float)(viewportV));
                            //g.DrawRectangle(penOrange, x, (float)(marginV), (float)(_NoOfParams * oneCandleWidth), (float)(viewportV));

                            ////g.DrawString("" + closestFeatureIndex, font, fontBrush, x, (float)(marginV));

                            double prevHeight = 1;
                            float prevX = 0;
                            float prevY = 0;

                            for (int j = 0; j < _NoOfParams; j++)
                            {
                                prevHeight = ((1 - closestFeat.param[j]) * 100000);

                                float x = (float)(marginH + ((fromCandle + j) * oneCandleWidth));
                                float y = (float)(marginV + 200 + (prevHeight));

                                g.DrawRectangle(penRed, x, y, 2 ,2);

                                if (j > 0)
                                {
                                    g.DrawLine(penGreen, prevX, prevY, x, y);
                                }

                                prevX = x;
                                prevY = y;

                            }


                        }
                    }

                  
                }

                for (int i = 0; i < _candleList.Count; i++)
                {
                    double priceLow = (_candleList[i].PriceLow - maxLow) * magLevel;
                    double priceHigh = (_candleList[i].PriceHigh - maxLow) * magLevel;
                    double priceLowHighDiff = Math.Abs(priceHigh - priceLow);
                    
                    double priceOpen = (_candleList[i].PriceOpen - maxLow) * magLevel;
                    double priceClose = (_candleList[i].PriceClose - maxLow) * magLevel;
                    double priceOpenCloseDiff = Math.Abs(priceOpen - priceClose);
                    double priceOpenCloseCenter = (priceOpen + priceClose) / 2;

                    var colorCandle = Color.Red;
                    if (priceOpen < priceClose)
                    {
                        colorCandle = Color.Green;
                        var temp = priceOpen;
                        priceOpen = priceClose;
                        priceClose = temp;
                    }

                    var penCandle = new Pen(colorCandle, 0.5f);
                    var brushCandle = new SolidBrush(colorCandle);

                    float x = (float)(marginH + (i * oneCandleWidth));
                    float y = (float)(marginV + viewportV);

                    //g.DrawRectangle(pen2, x - 1, (float)(priceLow) , 3 , (float)(priceHigh));


                    //g.DrawRectangle(penCandle, x ,y + (float)(priceHigh), 0.5f, (float)(priceLowHighDiff + 1));
                    //g.FillRectangle(brushCandle, x - (oneCandleWidth / 2) + 1, y + (float)(priceOpen), oneCandleWidth - 2, (float)(priceOpenCloseDiff + 1));
                    //g.DrawRectangle(penOrange, x - 1, y + (float)(priceOpen + priceOpenCloseDiff / 2) - 1, 3, 3);

                    g.DrawRectangle(penCandle, (float)(x + (oneCandleWidth / 2)), y - (float)(priceHigh) , 0.5f , (float)(priceLowHighDiff + 1));
                    g.FillRectangle(brushCandle, x + 1, y - (float)(priceOpen), (float)(oneCandleWidth - 2), (float)(priceOpenCloseDiff + 1));

                    g.DrawRectangle(penBlue, x - 1, y - 1, 3, 3);
                    g.DrawRectangle(penOrange, (float)(x + (oneCandleWidth / 2) - 1), y - (float)(priceClose + priceOpenCloseDiff / 2) - 1, 3, 3);



                    //float currentAvgPrice = (float)(_candleList[i].PriceLow + ((_candleList[i].PriceHigh - _candleList[i].PriceLow) / 2));

                    //float candlePosY = centerV + ((currentAvgPrice - firstCandleAvgPrice) * 20);
                    //float candleWickH = (float)(_candleList[i].PriceHigh) - currentAvgPrice;
                    ////float candleHeight = (float)((_candleList[i].PriceHigh - _candleList[i].PriceLow) / candleHeightRatio);

                    //var x = marginH + (i * oneCandleWidth);
                    //var y = (float)(centerV);
                    //g.DrawRectangle(pen2, x, candlePosY, 3, 3);
                    ////g.DrawRectangle(pen2, x, candlePosY- (candleWickH * 120 / 2), 3, candleWickH * 120);
                    //g.DrawRectangle(pen2, x, candlePosY, 3, candleWickH * 120);

                    //g.DrawRectangle(pen, x - 1, y - 1, 3 , 3);


                }
            }


            ////Predict
            //if (!_isLearning && mainBucketList!=null)
            //{
            //    var choosenBucketIndex = LearnCurrentCandleSet();

            //    var choosenBucket = mainBucketList._buckets[choosenBucketIndex];

            //    var isBuy = 0;
            //    var isSell = 0;
            //    var isNone = 0;
            //    for (int i = 0; i < choosenBucket.learntLabels.Count; i++)
            //    {
            //        if (choosenBucket.learntLabels[i] == "Buy")
            //        {
            //            isBuy++;
            //        }
            //        else if (choosenBucket.learntLabels[i] == "Sell")
            //        {
            //            isSell++;
            //        }
            //        else
            //        {
            //            isNone++;
            //        }
            //    }

            //    var msg = "Buys: " + isBuy + ", Sells: " + isSell + ", Inconclusive: " + isNone;

            //    g.DrawString(msg, font, fontBrush, 0, 0);
            //}



            fontBrush.Dispose();
            font.Dispose();
            brushBlack.Dispose();
            penBlue.Dispose();


        }

        public void NextCandle()
        {
            _currentCandleTimeStamp += 60000;
            GetCandleList(_currentCandleTimeStamp, _noOfCandles);
            _picCandleChart.Refresh();
        }

        public void PreviousCandle()
        {
            _currentCandleTimeStamp -= 60000;
            GetCandleList(_currentCandleTimeStamp, _noOfCandles);
            _picCandleChart.Refresh();
        }

        public void Learn()
        {
            _isLearning = true;
            _btnLearn.Enabled = false;

            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += WorkerDoWork;
            worker.RunWorkerCompleted += WorkerCompleted;

            _prgLearn.Style = ProgressBarStyle.Marquee;

            worker.RunWorkerAsync();




            //InitLearningDataStructure();

            //long learntFromTimeStamp = _currentCandleTimeStamp;
            ////long latestCandleTimeStamp = _dbService.Candles.Max(c => c.TimeStamp);
            //long latestCandleTimeStamp = _currentCandleTimeStamp + 10*3600000;


            //while (_currentCandleTimeStamp < latestCandleTimeStamp)
            //{


            //    LearnCurrentCandleSet();

            //    NextCandle();
            //}

            //_currentCandleTimeStamp = learntFromTimeStamp;
            //GetCandleList(_currentCandleTimeStamp, _noOfCandles);

            //_picCandleChart.Refresh();

            //_isLearning = false;
            //_btnLearn.Enabled = true;


        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _isLearningGo = true;
            _currentCandleToLearn = _currentCandleTimeStamp;

            while (_isLearningGo)
            {
                _currentCandleToLearn += Resolution.GetLong(_resolutionString);

                long halfwayTimeStamp = _currentCandleTimeStamp + (Resolution.GetLong(_resolutionString) * _noOfCandles / 2);

                if (_currentCandleToLearn > halfwayTimeStamp)
                {
                    _currentCandleTimeStamp = halfwayTimeStamp;
                    GetCandleList(_currentCandleTimeStamp, _noOfCandles);
                }
                
                //Grab CandleSet to learn
                long lastCandleToLearn = _currentCandleToLearn + (Resolution.GetLong(_resolutionString) * _NoOfParams);

                string dbType = Resolution.GetDBMnemonic(_resolutionString);

                List<Candle> learningCandleSet = _dbService.Candles.Where(
                    c => c.TimeStamp >= _currentCandleToLearn &&
                    c.TimeStamp < lastCandleToLearn &&
                    c.Type == dbType).ToList();

                //Do we have enough candles or we ran out of them (possible end of candles in DB)?
                if (learningCandleSet.Count == _NoOfParams)
                {
                    //We have enough candles!
                    
                    Feature feat = MLService.CandleSetToFeature(learningCandleSet);

                    feat = MLService.Normalize(feat);

                    _featureList.Add(feat);

                    //Update ListBox:                    
                    //LabelService.AddItem(_lbFeatures, featureString);
                    //LabelService.DispatchRefresh(_lbFeatures);
                    
                    //Update ToolStrip
                    LabelService.ToolStripSetText(_tlblStatus, "Learning (Phase 1. / " + _featureList.Count + " features learnt) ...");
                    
                    //Update Chart
                    LabelService.DispatchRefresh(_picCandleChart);
                }
                else _isLearningGo = false;
            }

            MessageBox.Show("Feature learning completed. Acquired " + _featureList.Count + " features.");

            //Phase 2. - Collating / Sorting
            _isLearningGo = true;

            var noOfFeatures = _featureList.Count;
            while (noOfFeatures > 16 && _isLearningGo)
            {
                List<Feature> groupedFeatures = MLService.Sort(_featureList);

                MessageBox.Show("Feature sorting completed. From " + groupedFeatures.Count + " groups extracted.");

                noOfFeatures = groupedFeatures.Count;

                MessageBox.Show("No. of features still in the system: " + noOfFeatures);

                _featureList = groupedFeatures;

            }


        }
        
        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _prgLearn.Style = ProgressBarStyle.Continuous;
            _tlblStatus.Text = "No action.";
            _isLearning = false;
            _btnLearn.Enabled = true;
            _picCandleChart.Refresh();
        }

        public void StopLearning()
        {
            _isLearningGo = false;
            _tlblStatus.Text = "Stopping...";
        }

        public class Bucket
        {
            public long learntHashKey;

            List<long> learntKeys = new List<long>();
            List<long> learntCandleStamps = new List<long>();
            public List<string> learntLabels = new List<string>();

            public Bucket(long learnableHashKey, long candleTimeStamp, string label)
            {
                learntHashKey = learnableHashKey;
                learntKeys.Add(learnableHashKey);
                learntCandleStamps.Add(candleTimeStamp);
                learntLabels.Add(label);
            }

            public void Learn(long learnableHashKey, long candleTimeStamp, string label)
            {
                learntHashKey = (learntHashKey + learnableHashKey) / 2;

                learntKeys.Add(learnableHashKey);
                learntCandleStamps.Add(candleTimeStamp);
                learntLabels.Add(label);
            }

        }

        public class BucketList
        {
            int _maxBuckets; 
            public List<Bucket> _buckets = new List<Bucket>();

            public BucketList(int maxBuckets)
            {
                _maxBuckets = maxBuckets;
            }
            public int Learn(long learnableHashKey, long candleTimeStamp, string label)
            {
                if (_buckets.Count != _maxBuckets)
                {
                    Bucket newBucket = new Bucket(learnableHashKey, candleTimeStamp, label);
                    _buckets.Add(newBucket);
                    return _buckets.Count - 1;
                } 
                else
                {
                    //Search for the closest Bucket value
                    long closestValue = learnableHashKey - _buckets[0].learntHashKey;
                    int closestIndex = 0;
                    for(int i = 0; i < _buckets.Count; i++)
                    {
                        if (learnableHashKey - _buckets[i].learntHashKey < closestValue)
                        {
                            closestValue = learnableHashKey - _buckets[i].learntHashKey;
                            closestIndex = i;
                        }
                    }

                    //Select which one was the closest and make it learn the new value
                    _buckets[closestIndex].Learn(learnableHashKey, candleTimeStamp, label);

                    return closestIndex;
                }
            }
        }

        BucketList mainBucketList;

        public void InitLearningDataStructure()
        {
            mainBucketList = new BucketList(16);
        }

        public int LearnCurrentCandleSet()
        {
            //Create Hash from CandleSet

            double firstPrice = _candleList[0].PriceClose;
            double learnableHash = 0;
            for (int i = 0; i < _candleList.Count/2; i++)
            {
                learnableHash += i * (_candleList[i].PriceClose / firstPrice) * 1000000000;
            }

            long learnableHashKey = (long)learnableHash;

            var candleListLength = _candleList.Count;
            string label = "Inconclusive";
            if (_candleList[candleListLength - 1].PriceHigh / _candleList[candleListLength/2].PriceHigh >= 1.005f)
            {
                label = "Buy";
            }
            else
            if (_candleList[candleListLength - 1].PriceLow / _candleList[candleListLength / 2].PriceLow <= 0.995f)
            {
                label = "Sell";
            }

            if (label!="Inconclusive")
            {
                //MessageBox.Show(label);
            }

            if (!_isLearning)
            {
                label = "Not learning...";
            }

            return mainBucketList.Learn(learnableHashKey, _candleList[0].TimeStamp, label);

        }

        public void ChangeResolution(string resolution)
        {
            _resolutionString = resolution;
            GetDataset();
        }

        public void ChangeNoOfCandles(string noOfCandles)
        {
            _noOfCandles = long.Parse(noOfCandles);
            GetDataset();
        }

        public void WindowSizeChanged()
        {
            _prevMagLevel = 100000000;
        }

        public void SetPredict()
        {
            if (_isPredict == false)
            {
                _isPredict = true;
            }
            else
            {
                _isPredict = false;
            }
        }
    }
}
