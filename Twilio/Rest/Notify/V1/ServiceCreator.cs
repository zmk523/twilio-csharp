using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1 {

    public class ServiceCreator : Creator<ServiceResource> {
        private string friendlyName;
        private string apnCredentialSid;
        private string gcmCredentialSid;
        private string messagingServiceSid;
        private string facebookMessengerPageId;
        private string defaultApnNotificationProtocolVersion;
        private string defaultGcmNotificationProtocolVersion;
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public ServiceCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The apn_credential_sid
        /// </summary>
        ///
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <returns> this </returns> 
        public ServiceCreator setApnCredentialSid(string apnCredentialSid) {
            this.apnCredentialSid = apnCredentialSid;
            return this;
        }
    
        /// <summary>
        /// The gcm_credential_sid
        /// </summary>
        ///
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <returns> this </returns> 
        public ServiceCreator setGcmCredentialSid(string gcmCredentialSid) {
            this.gcmCredentialSid = gcmCredentialSid;
            return this;
        }
    
        /// <summary>
        /// The messaging_service_sid
        /// </summary>
        ///
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <returns> this </returns> 
        public ServiceCreator setMessagingServiceSid(string messagingServiceSid) {
            this.messagingServiceSid = messagingServiceSid;
            return this;
        }
    
        /// <summary>
        /// The facebook_messenger_page_id
        /// </summary>
        ///
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <returns> this </returns> 
        public ServiceCreator setFacebookMessengerPageId(string facebookMessengerPageId) {
            this.facebookMessengerPageId = facebookMessengerPageId;
            return this;
        }
    
        /// <summary>
        /// The default_apn_notification_protocol_version
        /// </summary>
        ///
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <returns> this </returns> 
        public ServiceCreator setDefaultApnNotificationProtocolVersion(string defaultApnNotificationProtocolVersion) {
            this.defaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion;
            return this;
        }
    
        /// <summary>
        /// The default_gcm_notification_protocol_version
        /// </summary>
        ///
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <returns> this </returns> 
        public ServiceCreator setDefaultGcmNotificationProtocolVersion(string defaultGcmNotificationProtocolVersion) {
            this.defaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ServiceResource </returns> 
        public override async Task<ServiceResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
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
            
            return ServiceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ServiceResource </returns> 
        public override ServiceResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
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
            
            return ServiceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apnCredentialSid != null) {
                request.AddPostParam("ApnCredentialSid", apnCredentialSid);
            }
            
            if (gcmCredentialSid != null) {
                request.AddPostParam("GcmCredentialSid", gcmCredentialSid);
            }
            
            if (messagingServiceSid != null) {
                request.AddPostParam("MessagingServiceSid", messagingServiceSid);
            }
            
            if (facebookMessengerPageId != null) {
                request.AddPostParam("FacebookMessengerPageId", facebookMessengerPageId);
            }
            
            if (defaultApnNotificationProtocolVersion != null) {
                request.AddPostParam("DefaultApnNotificationProtocolVersion", defaultApnNotificationProtocolVersion);
            }
            
            if (defaultGcmNotificationProtocolVersion != null) {
                request.AddPostParam("DefaultGcmNotificationProtocolVersion", defaultGcmNotificationProtocolVersion);
            }
        }
    }
}