using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Message {

    public class FeedbackCreator : Creator<FeedbackResource> {
        private string accountSid;
        private string messageSid;
        private FeedbackResource.Outcome outcome;
    
        /// <summary>
        /// Construct a new FeedbackCreator.
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        public FeedbackCreator(string messageSid) {
            this.messageSid = messageSid;
        }
    
        /// <summary>
        /// Construct a new FeedbackCreator
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messageSid"> The message_sid </param>
        public FeedbackCreator(string accountSid, string messageSid) {
            this.accountSid = accountSid;
            this.messageSid = messageSid;
        }
    
        /// <summary>
        /// The outcome
        /// </summary>
        ///
        /// <param name="outcome"> The outcome </param>
        /// <returns> this </returns> 
        public FeedbackCreator setOutcome(FeedbackResource.Outcome outcome) {
            this.outcome = outcome;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackResource </returns> 
        public override async Task<FeedbackResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Messages/" + this.messageSid + "/Feedback.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackResource </returns> 
        public override FeedbackResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Messages/" + this.messageSid + "/Feedback.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (outcome != null) {
                request.AddPostParam("Outcome", outcome.ToString());
            }
        }
    }
}