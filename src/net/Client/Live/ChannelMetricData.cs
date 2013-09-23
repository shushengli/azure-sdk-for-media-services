﻿// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Services.Common;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal class ChannelMetricData : RestEntity<ChannelMetricData>, IChannelMetric, ICloudMediaContextInit
    {
        /// <summary>
        /// Gets service name of the channel metric
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets metric last modification timestamp.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets the <see cref="IngestMetrics"/> object containing the ingest metrics of the channel.
        /// </summary>
        public List<IngestMetric> IngestMetrics { get; set; }

        /// <summary>
        /// Gets the <see cref="ProgramMetrics"/> object containing the program metrics of the channel.
        /// </summary>
        public List<ProgramMetric> ProgramMetrics { get; set; }

        /// <summary>
        /// Gets the <see cref="IngestMetrics"/> object containing the ingest metrics of the channelsink.
        /// </summary>
        ReadOnlyCollection<IngestMetric> IChannelMetric.IngestMetrics
        {
            get
            {
                return IngestMetrics.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the <see cref="ProgramMetrics"/> object containing the program metrics of the channelsink.
        /// </summary>
        ReadOnlyCollection<ProgramMetric> IChannelMetric.ProgramMetrics
        {
            get
            {
                return ProgramMetrics.AsReadOnly();
            }
        }

        #region ICloudMediaContextInit Members

        /// <summary>
        /// Initializes the cloud media context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        #endregion

        protected override string EntitySetName
        {
            get { return ChannelMetricBaseCollection.ChannelMetricSet; }
        }
    }
}
