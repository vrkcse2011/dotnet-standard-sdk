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

using Newtonsoft.Json;

namespace IBM.Watson.Discovery.v1.Model
{
    /// <summary>
    /// Object describing the current status of the wordlist.
    /// </summary>
    public class TokenDictStatusResponse
    {
        /// <summary>
        /// Current wordlist status for the specified collection.
        /// </summary>
        public class StatusEnumValue
        {
            /// <summary>
            /// Constant ACTIVE for active
            /// </summary>
            public const string ACTIVE = "active";
            /// <summary>
            /// Constant PENDING for pending
            /// </summary>
            public const string PENDING = "pending";
            /// <summary>
            /// Constant NOT_FOUND for not found
            /// </summary>
            public const string NOT_FOUND = "not found";
            
        }

        /// <summary>
        /// Current wordlist status for the specified collection.
        /// Constants for possible values can be found using TokenDictStatusResponse.StatusEnumValue
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        /// <summary>
        /// The type for this wordlist. Can be `tokenization_dictionary` or `stopwords`.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

}
