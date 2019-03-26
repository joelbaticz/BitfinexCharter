using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitfinexCharter.Services;
using BitfinexCharter.Models;

namespace BitfinexCharter.Services
{
    public static class MLService
    {
     
        public static Feature CandleSetToFeature(List<Candle> candleSet)
        {
            //Calculate averages
            List<double> prices = new List<double>();


            Feature newFeature = new Feature();

            double firstItem = (candleSet[0].PriceLow + candleSet[0].PriceHigh) / 2;
            for (int i = 0; i < candleSet.Count; i++)
            {
                double avg = ((candleSet[i].PriceLow + candleSet[i].PriceHigh) / 2) / firstItem;
                newFeature.param.Add(avg);
            }

            return newFeature;
        }

        public static Feature Normalize(Feature feature)
        {
            Feature normalizedFeature = new Feature();

            //Normalize CandleSet
            double lastParam = feature.param[0];
            for (int i = 0; i < feature.param.Count; i++)
            {
                double currentParam = feature.param[i] / lastParam;

                normalizedFeature.param.Add(currentParam);
                lastParam = currentParam;
            }

            return normalizedFeature;
        }

        public static List<Feature> Sort(List<Feature> featureList)
        {

            //Grab the next (first) Feature from the featureList
            //Go thru the the whole list
            //Pick which is the closest to it
            //Assign the same group to it
            //Feature object should have a group property therefore

            for (int i = 0; i < featureList.Count; i++)
            {
                Feature currentFeature = featureList[i];
                currentFeature.groupNumber = 0;
            }

            long lastGroupId = 0;
            int currentIndex = 0;

            //for (int currentIndex = 0; currentIndex < featureList.Count; currentIndex++)
            while (currentIndex < featureList.Count)
            {
                
                Feature currentFeature = featureList[currentIndex];
                double minDiff = double.MaxValue;
                int minDiffIndex = int.MaxValue;

                for (int i = 0; i < featureList.Count; i++)
                {
                    if (currentIndex != i)
                    {
                        double currentDiff = 0;
                        for (int j = 0; j < featureList[i].param.Count; j++)
                        {
                            double paramDiff = Math.Abs(currentFeature.param[j] - featureList[i].param[j]);

                            currentDiff += paramDiff;
                        }
                        if (minDiff > currentDiff)
                        {
                            minDiff = currentDiff;
                            minDiffIndex = i;
                        }
                    }
                }
                //We got which feature is the closest to it (=> the one with minDiffIndex)
                //Put them in the same group

                if (featureList[minDiffIndex].groupNumber == 0)
                {
                    //Group was not allcated yet to the "compare to" feature
                    //Create new group ID and allocate it to both
                    lastGroupId++;
                    featureList[minDiffIndex].groupNumber = lastGroupId;
                    featureList[currentIndex].groupNumber = lastGroupId;
                }
                else
                {
                    var groupId = featureList[minDiffIndex].groupNumber;
                    featureList[currentIndex].groupNumber = groupId;
                }

                currentIndex++;
            }


            //We put the Group number for every feature
            //Grab the features that belong to the same group
            //Find Mean values for them
            //Put the these Mean values to another Feature List

            int noOfParams = featureList[0].param.Count;

            List<Feature> newFeatureList = new List<Feature>();

            for (int i = 1; i < lastGroupId; i++)
            {
                //Create list with Mean values for this group
                List<Feature> meanList = new List<Feature>();

                //If feature belong to this group copy it to the Mean value list
                for (int j = 0; j < featureList.Count; j++)
                {
                    if (featureList[j].groupNumber == i)
                    {
                        meanList.Add(featureList[j]);
                    }
                }

                //Calculate the mean value for every param
                List<double> meanParams = new List<double>();
                //Init list
                for (int k = 0; k < noOfParams; k++)
                {
                    meanParams.Add(0);
                }

                //Add together all params
                for (int j = 0; j < meanList.Count; j++)
                {
                    for (int k = 0; k < noOfParams; k++)
                    {
                        meanParams[k] += meanList[j].param[k];
                    }
                }

                //Find the average value for all params
                for (int k = 0; k < noOfParams; k++)
                {
                    meanParams[k] = meanParams[k] / meanList.Count;
                }

                //Create and Add new Feature with the Mean Values
                Feature newFeature = new Feature()
                {
                    groupNumber = 0,
                    param = meanParams
                };

                newFeatureList.Add(newFeature);
            }

            return newFeatureList;
        }

        public static Feature Compare(List<Feature> featureList, Feature feature)
        {
            double minDiff = double.MaxValue;
            int minDiffIndex = int.MaxValue;

            for (int i = 0; i < featureList.Count; i++)
            {
                double currentDiff = 0;
                for (int j = 0; j < featureList[i].param.Count; j++)
                {
                    double paramDiff = Math.Abs(feature.param[j] - featureList[i].param[j]);

                    currentDiff += paramDiff;
                }
                if (minDiff > currentDiff)
                {
                    minDiff = currentDiff;
                    minDiffIndex = i;
                }

            }

            //return minDiffIndex;
            return featureList[minDiffIndex];
        }
    }
}
