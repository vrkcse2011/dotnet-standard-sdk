/**
* (C) Copyright IBM Corp. 2018, 2019.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using IBM.Cloud.SDK.Core.Authentication;
using IBM.Cloud.SDK.Core.Http;
using IBM.Cloud.SDK.Core.Service;
using IBM.Watson.NaturalLanguageUnderstanding.v1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace IBM.Watson.NaturalLanguageUnderstanding.v1
{
    public partial class NaturalLanguageUnderstandingService : IBMService, INaturalLanguageUnderstandingService
    {
        const string serviceName = "natural_language_understanding";
        private const string defaultServiceUrl = "https://gateway.watsonplatform.net/natural-language-understanding/api";
        public string VersionDate { get; set; }

        public NaturalLanguageUnderstandingService(string versionDate) : this(versionDate, ConfigBasedAuthenticatorFactory.GetAuthenticator(serviceName)) { }
        public NaturalLanguageUnderstandingService(IClient httpClient) : base(serviceName, httpClient) { }

        public NaturalLanguageUnderstandingService(string versionDate, IAuthenticator authenticator) : base(serviceName, authenticator)
        {
            if (string.IsNullOrEmpty(versionDate))
            {
                throw new ArgumentNullException("versionDate cannot be null.");
            }
            
            VersionDate = versionDate;

            if (string.IsNullOrEmpty(ServiceUrl))
            {
                SetServiceUrl(defaultServiceUrl);
            }
        }

        /// <summary>
        /// Analyze text.
        ///
        /// Analyzes text, HTML, or a public webpage for the following features:
        /// - Categories
        /// - Concepts
        /// - Emotion
        /// - Entities
        /// - Keywords
        /// - Metadata
        /// - Relations
        /// - Semantic roles
        /// - Sentiment
        /// - Syntax (Experimental).
        /// </summary>
        /// <param name="parameters">An object containing request parameters. The `features` object and one of the
        /// `text`, `html`, or `url` attributes are required.</param>
        /// <returns><see cref="AnalysisResults" />AnalysisResults</returns>
        public DetailedResponse<AnalysisResults> Analyze(Features features, string text = null, string html = null, string url = null, bool? clean = null, string xpath = null, bool? fallbackToRaw = null, bool? returnAnalyzedText = null, string language = null, long? limitTextCharacters = null)
        {
            if (features == null)
            {
                throw new ArgumentNullException("`features` is required for `Analyze`");
            }

            if (string.IsNullOrEmpty(VersionDate))
            {
                throw new ArgumentNullException("versionDate cannot be null.");
            }

            DetailedResponse<AnalysisResults> result = null;

            try
            {
                IClient client = this.Client;
                SetAuthentication();

                var restRequest = client.PostAsync($"{this.Endpoint}/v1/analyze");

                restRequest.WithArgument("version", VersionDate);
                restRequest.WithHeader("Accept", "application/json");
                restRequest.WithHeader("Content-Type", "application/json");

                JObject bodyObject = new JObject();
                if (features != null)
                {
                    bodyObject["features"] = JToken.FromObject(features);
                }
                if (!string.IsNullOrEmpty(text))
                {
                    bodyObject["text"] = text;
                }
                if (!string.IsNullOrEmpty(html))
                {
                    bodyObject["html"] = html;
                }
                if (!string.IsNullOrEmpty(url))
                {
                    bodyObject["url"] = url;
                }
                if (clean != null)
                {
                    bodyObject["clean"] = JToken.FromObject(clean);
                }
                if (!string.IsNullOrEmpty(xpath))
                {
                    bodyObject["xpath"] = xpath;
                }
                if (fallbackToRaw != null)
                {
                    bodyObject["fallback_to_raw"] = JToken.FromObject(fallbackToRaw);
                }
                if (returnAnalyzedText != null)
                {
                    bodyObject["return_analyzed_text"] = JToken.FromObject(returnAnalyzedText);
                }
                if (!string.IsNullOrEmpty(language))
                {
                    bodyObject["language"] = language;
                }
                if (limitTextCharacters != null)
                {
                    bodyObject["limit_text_characters"] = JToken.FromObject(limitTextCharacters);
                }
                var httpContent = new StringContent(JsonConvert.SerializeObject(bodyObject), Encoding.UTF8, HttpMediaType.APPLICATION_JSON);
                restRequest.WithBodyContent(httpContent);

                restRequest.WithHeaders(Common.GetSdkHeaders("natural-language-understanding", "v1", "Analyze"));
                restRequest.WithHeaders(customRequestHeaders);
                ClearCustomRequestHeaders();

                result = restRequest.As<AnalysisResults>().Result;
                if (result == null)
                {
                    result = new DetailedResponse<AnalysisResults>();
                }
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
        /// <summary>
        /// List models.
        ///
        /// Lists Watson Knowledge Studio [custom entities and relations
        /// models](https://cloud.ibm.com/docs/services/natural-language-understanding?topic=natural-language-understanding-customizing)
        /// that are deployed to your Natural Language Understanding service.
        /// </summary>
        /// <returns><see cref="ListModelsResults" />ListModelsResults</returns>
        public DetailedResponse<ListModelsResults> ListModels()
        {

            if (string.IsNullOrEmpty(VersionDate))
            {
                throw new ArgumentNullException("versionDate cannot be null.");
            }

            DetailedResponse<ListModelsResults> result = null;

            try
            {
                IClient client = this.Client;
                SetAuthentication();

                var restRequest = client.GetAsync($"{this.Endpoint}/v1/models");

                restRequest.WithArgument("version", VersionDate);
                restRequest.WithHeader("Accept", "application/json");

                restRequest.WithHeaders(Common.GetSdkHeaders("natural-language-understanding", "v1", "ListModels"));
                restRequest.WithHeaders(customRequestHeaders);
                ClearCustomRequestHeaders();

                result = restRequest.As<ListModelsResults>().Result;
                if (result == null)
                {
                    result = new DetailedResponse<ListModelsResults>();
                }
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        /// <summary>
        /// Delete model.
        ///
        /// Deletes a custom model.
        /// </summary>
        /// <param name="modelId">Model ID of the model to delete.</param>
        /// <returns><see cref="DeleteModelResults" />DeleteModelResults</returns>
        public DetailedResponse<DeleteModelResults> DeleteModel(string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
            {
                throw new ArgumentNullException("`modelId` is required for `DeleteModel`");
            }
            else
            {
                modelId = Uri.EscapeDataString(modelId);
            }

            if (string.IsNullOrEmpty(VersionDate))
            {
                throw new ArgumentNullException("versionDate cannot be null.");
            }

            DetailedResponse<DeleteModelResults> result = null;

            try
            {
                IClient client = this.Client;
                SetAuthentication();

                var restRequest = client.DeleteAsync($"{this.Endpoint}/v1/models/{modelId}");

                restRequest.WithArgument("version", VersionDate);
                restRequest.WithHeader("Accept", "application/json");

                restRequest.WithHeaders(Common.GetSdkHeaders("natural-language-understanding", "v1", "DeleteModel"));
                restRequest.WithHeaders(customRequestHeaders);
                ClearCustomRequestHeaders();

                result = restRequest.As<DeleteModelResults>().Result;
                if (result == null)
                {
                    result = new DetailedResponse<DeleteModelResults>();
                }
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
    }
}
