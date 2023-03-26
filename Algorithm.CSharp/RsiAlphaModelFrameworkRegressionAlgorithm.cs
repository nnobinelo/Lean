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

using System.Collections.Generic;
using QuantConnect.Algorithm.Framework.Alphas;

namespace QuantConnect.Algorithm.CSharp
{
    /// <summary>
    /// Regression algorithm to assert the behavior of <see cref="RsiAlphaModel"/>.
    /// </summary>
    public class RsiAlphaModelFrameworkRegressionAlgorithm : BaseFrameworkRegressionAlgorithm
    {
        public override void Initialize()
        {
            base.Initialize();
            SetAlpha(new RsiAlphaModel());
        }

        public override void OnEndOfAlgorithm()
        {
        }

        public override long DataPoints => 772;

        public override int AlgorithmHistoryDataPoints => 56;

        /// <summary>
        /// This is used by the regression test system to indicate what the expected statistics are from running the algorithm
        /// </summary>
        public override Dictionary<string, string> ExpectedStatistics => new()
        {
            {"Total Trades", "39"},
            {"Average Win", "0.15%"},
            {"Average Loss", "-0.03%"},
            {"Compounding Annual Return", "5.782%"},
            {"Drawdown", "1.900%"},
            {"Expectancy", "1.032"},
            {"Net Profit", "0.463%"},
            {"Sharpe Ratio", "0.879"},
            {"Probabilistic Sharpe Ratio", "48.163%"},
            {"Loss Rate", "65%"},
            {"Win Rate", "35%"},
            {"Profit-Loss Ratio", "4.81"},
            {"Alpha", "0.113"},
            {"Beta", "-0.359"},
            {"Annual Standard Deviation", "0.048"},
            {"Annual Variance", "0.002"},
            {"Information Ratio", "-1.972"},
            {"Tracking Error", "0.079"},
            {"Treynor Ratio", "-0.117"},
            {"Total Fees", "$73.32"},
            {"Estimated Strategy Capacity", "$31000000.00"},
            {"Lowest Capacity Asset", "NB R735QTJ8XC9X"},
            {"Portfolio Turnover", "14.62%"},
            {"OrderListHash", "c634d0d85427db6c3e525e1408efa39e"}
        };
    }
}
