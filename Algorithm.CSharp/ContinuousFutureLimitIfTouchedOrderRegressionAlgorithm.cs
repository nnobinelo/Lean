/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using QuantConnect.Data;
using QuantConnect.Orders;
using QuantConnect.Interfaces;
using QuantConnect.Securities;
using System.Collections.Generic;
using QuantConnect.Securities.Future;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Continuous Futures Regression algorithm reproducing GH issue #6490 asserting limit if touched order works as expected
    /// </summary>
    public class ContinuousFutureLimitIfTouchedOrderRegressionAlgorithm : QCAlgorithm, IRegressionAlgorithmDefinition
    {
        private OrderTicket _ticket;
        private Future _continuousContract;

        /// <summary>
        /// Initialise the data and resolution required, as well as the cash and start-end dates for your algorithm. All algorithms must initialized.
        /// </summary>
        public override void Initialize()
        {
            SetStartDate(2013, 10, 6);
            SetEndDate(2013, 10, 10);

            _continuousContract = AddFuture(Futures.Indices.SP500EMini,
                dataNormalizationMode: DataNormalizationMode.BackwardsRatio,
                dataMappingMode: DataMappingMode.LastTradingDay
            );
        }

        /// <summary>
        /// OnData event is the primary entry point for your algorithm. Each new data point will be pumped in here.
        /// </summary>
        /// <param name="data">Slice object keyed by symbol containing the stock data</param>
        public override void OnData(Slice data)
        {
            if (_ticket == null)
            {
                _ticket = LimitIfTouchedOrder(_continuousContract.Mapped, -1, _continuousContract.Price, _continuousContract.Price);
            }
        }

        public override void OnEndOfAlgorithm()
        {
            if (_ticket == null || _ticket.Status != OrderStatus.Filled)
            {
                throw new Exception("Order ticket was not placed or filled!");
            }
        }

        /// <summary>
        /// This is used by the regression test system to indicate if the open source Lean repository has the required data to run this algorithm.
        /// </summary>
        public bool CanRunLocally { get; } = true;

        /// <summary>
        /// This is used by the regression test system to indicate which languages this algorithm is written in.
        /// </summary>
        public Language[] Languages { get; } = { Language.CSharp };

        /// <summary>
        /// Data Points count of all timeslices of algorithm
        /// </summary>
        public long DataPoints => 64065;

        /// <summary>
        /// Data Points count of the algorithm history
        /// </summary>
        public int AlgorithmHistoryDataPoints => 0;

        /// <summary>
        /// This is used by the regression test system to indicate what the expected statistics are from running the algorithm
        /// </summary>
        public Dictionary<string, string> ExpectedStatistics => new Dictionary<string, string>
        {
            {"Total Trades", "1"},
            {"Average Win", "0%"},
            {"Average Loss", "0%"},
            {"Compounding Annual Return", "-98.962%"},
            {"Drawdown", "6.200%"},
            {"Expectancy", "0"},
            {"Net Profit", "-6.066%"},
            {"Sharpe Ratio", "-2.143"},
            {"Probabilistic Sharpe Ratio", "32.231%"},
            {"Loss Rate", "0%"},
            {"Win Rate", "0%"},
            {"Profit-Loss Ratio", "0"},
            {"Alpha", "-0.237"},
            {"Beta", "-0.662"},
            {"Annual Standard Deviation", "0.161"},
            {"Annual Variance", "0.026"},
            {"Information Ratio", "-1.265"},
            {"Tracking Error", "0.403"},
            {"Treynor Ratio", "0.523"},
            {"Total Fees", "$1.85"},
            {"Estimated Strategy Capacity", "$710000000.00"},
            {"Lowest Capacity Asset", "ES VMKLFZIH2MTD"},
            {"Fitness Score", "0.018"},
            {"Kelly Criterion Estimate", "0"},
            {"Kelly Criterion Probability Value", "0"},
            {"Sortino Ratio", "-2.218"},
            {"Return Over Maximum Drawdown", "-16.972"},
            {"Portfolio Turnover", "0.165"},
            {"Total Insights Generated", "0"},
            {"Total Insights Closed", "0"},
            {"Total Insights Analysis Completed", "0"},
            {"Long Insight Count", "0"},
            {"Short Insight Count", "0"},
            {"Long/Short Ratio", "100%"},
            {"Estimated Monthly Alpha Value", "$0"},
            {"Total Accumulated Estimated Alpha Value", "$0"},
            {"Mean Population Estimated Insight Value", "$0"},
            {"Mean Population Direction", "0%"},
            {"Mean Population Magnitude", "0%"},
            {"Rolling Averaged Population Direction", "0%"},
            {"Rolling Averaged Population Magnitude", "0%"},
            {"OrderListHash", "de931c9003e11617ffc012f9ee41093e"}
        };
    }
}
