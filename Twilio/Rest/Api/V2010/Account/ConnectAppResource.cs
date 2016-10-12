using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ConnectAppResource : SidResource {
        public sealed class Permission : IStringEnum {
            public const string GET_ALL="get-all";
            public const string POST_ALL="post-all";
        
            private string value;
            
            public Permission() { }
            
            public Permission(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Permission(string value) {
                return new Permission(value);
            }
            
            public static implicit operator string(Permission value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique connect-app Sid </param>
        /// <returns> ConnectAppFetcher capable of executing the fetch </returns> 
        public static ConnectAppFetcher Fetcher(string accountSid, string sid) {
            return new ConnectAppFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ConnectAppFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique connect-app Sid </param>
        /// <returns> ConnectAppFetcher capable of executing the fetch </returns> 
        public static ConnectAppFetcher Fetcher(string sid) {
            return new ConnectAppFetcher(sid);
        }
    
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ConnectAppUpdater capable of executing the update </returns> 
        public static ConnectAppUpdater Updater(string accountSid, string sid) {
            return new ConnectAppUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ConnectAppUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ConnectAppUpdater capable of executing the update </returns> 
        public static ConnectAppUpdater Updater(string sid) {
            return new ConnectAppUpdater(sid);
        }
    
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ConnectAppReader capable of executing the read </returns> 
        public static ConnectAppReader Reader(string accountSid) {
            return new ConnectAppReader(accountSid);
        }
    
        /// <summary>
        /// Create a ConnectAppReader to execute read.
        /// </summary>
        ///
        /// <returns> ConnectAppReader capable of executing the read </returns> 
        public static ConnectAppReader Reader() {
            return new ConnectAppReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a ConnectAppResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConnectAppResource object represented by the provided JSON </returns> 
        public static ConnectAppResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConnectAppResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("authorize_redirect_url")]
        private readonly Uri authorizeRedirectUrl;
        [JsonProperty("company_name")]
        private readonly string companyName;
        [JsonProperty("deauthorize_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod deauthorizeCallbackMethod;
        [JsonProperty("deauthorize_callback_url")]
        private readonly Uri deauthorizeCallbackUrl;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("homepage_url")]
        private readonly Uri homepageUrl;
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly List<ConnectAppResource.Permission> permissions;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public ConnectAppResource() {
        
        }
    
        private ConnectAppResource([JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("authorize_redirect_url")]
                                   Uri authorizeRedirectUrl, 
                                   [JsonProperty("company_name")]
                                   string companyName, 
                                   [JsonProperty("deauthorize_callback_method")]
                                   Twilio.Http.HttpMethod deauthorizeCallbackMethod, 
                                   [JsonProperty("deauthorize_callback_url")]
                                   Uri deauthorizeCallbackUrl, 
                                   [JsonProperty("description")]
                                   string description, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("homepage_url")]
                                   Uri homepageUrl, 
                                   [JsonProperty("permissions")]
                                   List<ConnectAppResource.Permission> permissions, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("uri")]
                                   string uri) {
            this.accountSid = accountSid;
            this.authorizeRedirectUrl = authorizeRedirectUrl;
            this.companyName = companyName;
            this.deauthorizeCallbackMethod = deauthorizeCallbackMethod;
            this.deauthorizeCallbackUrl = deauthorizeCallbackUrl;
            this.description = description;
            this.friendlyName = friendlyName;
            this.homepageUrl = homepageUrl;
            this.permissions = permissions;
            this.sid = sid;
            this.uri = uri;
        }
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> URIL Twilio sends requests when users authorize </returns> 
        public Uri GetAuthorizeRedirectUrl() {
            return this.authorizeRedirectUrl;
        }
    
        /// <returns> The company name set for this Connect App. </returns> 
        public string GetCompanyName() {
            return this.companyName;
        }
    
        /// <returns> HTTP method Twilio WIll use making requests to the url </returns> 
        public Twilio.Http.HttpMethod GetDeauthorizeCallbackMethod() {
            return this.deauthorizeCallbackMethod;
        }
    
        /// <returns> URL Twilio will send a request when a user de-authorizes this app </returns> 
        public Uri GetDeauthorizeCallbackUrl() {
            return this.deauthorizeCallbackUrl;
        }
    
        /// <returns> A more detailed human readable description </returns> 
        public string GetDescription() {
            return this.description;
        }
    
        /// <returns> A human readable name for the Connect App. </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The URL users can obtain more information </returns> 
        public Uri GetHomepageUrl() {
            return this.homepageUrl;
        }
    
        /// <returns> The set of permissions that your ConnectApp requests. </returns> 
        public List<ConnectAppResource.Permission> GetPermissions() {
            return this.permissions;
        }
    
        /// <returns> A string that uniquely identifies this connect-apps </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}