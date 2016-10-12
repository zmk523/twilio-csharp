using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.IpAccessControlList {

    public class IpAddressCreator : Creator<IpAddressResource> {
        private string accountSid;
        private string ipAccessControlListSid;
        private string friendlyName;
        private string ipAddress;
    
        /**
         * Construct a new IpAddressCreator.
         * 
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param friendlyName The friendly_name
         * @param ipAddress The ip_address
         */
        public IpAddressCreator(string ipAccessControlListSid, string friendlyName, string ipAddress) {
            this.ipAccessControlListSid = ipAccessControlListSid;
            this.friendlyName = friendlyName;
            this.ipAddress = ipAddress;
        }
    
        /**
         * Construct a new IpAddressCreator
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param friendlyName The friendly_name
         * @param ipAddress The ip_address
         */
        public IpAddressCreator(string accountSid, string ipAccessControlListSid, string friendlyName, string ipAddress) {
            this.accountSid = accountSid;
            this.ipAccessControlListSid = ipAccessControlListSid;
            this.friendlyName = friendlyName;
            this.ipAddress = ipAddress;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAddressResource
         */
        public override async Task<IpAddressResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/IpAccessControlLists/" + this.ipAccessControlListSid + "/IpAddresses.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAddressResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return IpAddressResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAddressResource
         */
        public override IpAddressResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/IpAccessControlLists/" + this.ipAccessControlListSid + "/IpAddresses.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAddressResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return IpAddressResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (ipAddress != null) {
                request.AddPostParam("IpAddress", ipAddress);
            }
        }
    }
}