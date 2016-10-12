using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ConferenceReader : Reader<ConferenceResource> {
        private string accountSid;
        private string dateCreated;
        private string dateUpdated;
        private string friendlyName;
        private ConferenceResource.Status status;
    
        /// <summary>
        /// Construct a new ConferenceReader.
        /// </summary>
        public ConferenceReader() {
        }
    
        /// <summary>
        /// Construct a new ConferenceReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public ConferenceReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// Only show conferences that started on this date, given as YYYY-MM-DD. You can also specify inequality such as
        /// DateCreated&lt;=YYYY-MM-DD
        /// </summary>
        ///
        /// <param name="dateCreated"> Filter by date created </param>
        /// <returns> this </returns> 
        public ConferenceReader ByDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        /// <summary>
        /// Only show conferences that were last updated on this date, given as YYYY-MM-DD. You can also specify inequality such
        /// as DateUpdated&gt;=YYYY-MM-DD
        /// </summary>
        ///
        /// <param name="dateUpdated"> Filter by date updated </param>
        /// <returns> this </returns> 
        public ConferenceReader ByDateUpdated(string dateUpdated) {
            this.dateUpdated = dateUpdated;
            return this;
        }
    
        /// <summary>
        /// Only show results who's friendly name exactly matches the string
        /// </summary>
        ///
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <returns> this </returns> 
        public ConferenceReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// A string representing the status of the conference. May be `init`, `in-progress`, or `completed`.
        /// </summary>
        ///
        /// <param name="status"> The status of the conference </param>
        /// <returns> this </returns> 
        public ConferenceReader ByStatus(ConferenceResource.Status status) {
            this.status = status;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ConferenceResource ResourceSet </returns> 
        public override Task<ResourceSet<ConferenceResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ConferenceResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ConferenceResource ResourceSet </returns> 
        public override ResourceSet<ConferenceResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ConferenceResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<ConferenceResource> NextPage(Page<ConferenceResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of ConferenceResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<ConferenceResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ConferenceResource read failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (dateCreated != null) {
                request.AddQueryParam("DateCreated", dateCreated);
            }
            
            if (dateUpdated != null) {
                request.AddQueryParam("DateUpdated", dateUpdated);
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (status != null) {
                request.AddQueryParam("Status", status.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}