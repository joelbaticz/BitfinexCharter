using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.Web;
using System.IO;
using System.Net;
using BitfinexCharter.Models;

namespace BitfinexCharter.Services
{
    public class WebService
    {
        public class CandleDataResponse
        {
            public string StatusMessage;
            public int NoOfCandleSticks;
            public List<Candle> CandleList;
        }


     

        public static CandleDataResponse GetCandleData(long timeStampFrom, long timeStampTo)
        {
            System.Threading.Thread.Sleep(20000); //simulate a half second delay for the server to process 

            string urlAddress = "https://api.bitfinex.com/v2/candles/trade:1m:tBTCUSD/hist?start=" + timeStampFrom + "&end=" + timeStampTo;



            //var request = WebRequest.Create("http://www.stackoverflow.com");

            //var response = (HttpWebResponse)await Task.Factory
            //    .FromAsync<WebResponse>(request.BeginGetResponse,
            //                            request.EndGetResponse,
            //                            null);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    CandleDataResponse responseDataError = new CandleDataResponse()
            //    {
            //        StatusMessage = "It was cool",
            //        NoOfCandleSticks = 0,
            //        CandleList = null
            //    };

            //    return responseDataError;
            //}
            //else
            //{
            //    CandleDataResponse responseDataError = new CandleDataResponse()
            //    {
            //        StatusMessage = "Shit",
            //        NoOfCandleSticks = 0,
            //        CandleList = null
            //    };
            //    return responseDataError;
            //}
            

            

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlAddress);
            webRequest.Timeout = 10000;
            webRequest.KeepAlive = false;
            //webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
            //webRequest.UserAgent = ".NET Framework Test Client";

            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = webResponse.GetResponseStream();
                    StreamReader readStream = null;
                    if (webResponse.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(webResponse.CharacterSet));
                    string data = readStream.ReadToEnd();
                    webResponse.Close();
                    readStream.Close();

                    CandleDataResponse responseDataError = new CandleDataResponse()
                    {
                        StatusMessage = "Data Error: " + data,
                        NoOfCandleSticks = 0,
                        CandleList = null
                    };

                    if (data == null) return responseDataError;

                    if (data.Substring(0, 2) == "[]" || data.Substring(0, 7) == "[\"error")
                    {
                        return responseDataError;

                    }
                    
                    var deserializedObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data);

                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //User user = jss.Deserialize<User>(jsonResponse);

                    List<Candle> candleList = new List<Candle>();

         
                    foreach (var newCandleJson in deserializedObj)
                    {
                        Candle newCandle = new Candle()
                        {
                            CandleId = Guid.NewGuid(),
                            TimeStamp = newCandleJson[0],
                            PriceOpen = newCandleJson[1],
                            PriceClose = newCandleJson[2],
                            PriceHigh = newCandleJson[3],
                            PriceLow = newCandleJson[4],
                            Volume = newCandleJson[5]
                        };
                        candleList.Add(newCandle);
                    }

                    long noOfRecords = (timeStampTo - timeStampFrom) / 60000;

                    if (candleList.Count != noOfRecords)
                    {
                        //Console.WriteLine("Query for " + noOfRecords + " resulted in " + candleList.Count + " records.\n" + data);
                    }


                    CandleDataResponse responseOK = new CandleDataResponse()
                    {
                        StatusMessage = "OK",
                        NoOfCandleSticks = candleList.ToArray().Length,
                        CandleList = candleList
                    };

                    return responseOK;

                }

                CandleDataResponse responseHTTPError = new CandleDataResponse()
                {
                    StatusMessage = "HTTP Error: (" + webResponse.StatusCode + ") - " + webResponse.StatusDescription,
                    NoOfCandleSticks = 0,
                    CandleList = null
                };

                webResponse.Close();
                return responseHTTPError;



            }

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            //request.KeepAlive = false;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        }
    }  
}
