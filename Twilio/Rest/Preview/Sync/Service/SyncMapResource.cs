using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service {

    public class SyncMapResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SyncMapFetcher capable of executing the fetch </returns> 
        public static SyncMapFetcher Fetcher(string serviceSid, string sid) {
            return new SyncMapFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SyncMapDeleter capable of executing the delete </returns> 
        public static SyncMapDeleter Deleter(string serviceSid, string sid) {
            return new SyncMapDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> SyncMapCreator capable of executing the create </returns> 
        public static SyncMapCreator Creator(string serviceSid) {
            return new SyncMapCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> SyncMapReader capable of executing the read </returns> 
        public static SyncMapReader Reader(string serviceSid) {
            return new SyncMapReader(serviceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncMapResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapResource object represented by the provided JSON </returns> 
        public static SyncMapResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SyncMapResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("unique_name")]
        private readonly string uniqueName;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
        [JsonProperty("revision")]
        private readonly string revision;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("created_by")]
        private readonly string createdBy;
    
        public SyncMapResource() {
        
        }
    
        private SyncMapResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("unique_name")]
                                string uniqueName, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links, 
                                [JsonProperty("revision")]
                                string revision, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("created_by")]
                                string createdBy) {
            this.sid = sid;
            this.uniqueName = uniqueName;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.url = url;
            this.links = links;
            this.revision = revision;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The unique_name </returns> 
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    
        /// <returns> The links </returns> 
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    
        /// <returns> The revision </returns> 
        public string GetRevision() {
            return this.revision;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The created_by </returns> 
        public string GetCreatedBy() {
            return this.createdBy;
        }
    }
}