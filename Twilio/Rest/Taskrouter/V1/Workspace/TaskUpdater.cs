using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskUpdater : Updater<TaskResource> {
        private string workspaceSid;
        private string sid;
        private string attributes;
        private TaskResource.Status assignmentStatus;
        private string reason;
        private int? priority;
        private string taskChannel;
    
        /**
         * Construct a new TaskUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public TaskUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public TaskUpdater setAttributes(string attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * The assignment_status
         * 
         * @param assignmentStatus The assignment_status
         * @return this
         */
        public TaskUpdater setAssignmentStatus(TaskResource.Status assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /**
         * The reason
         * 
         * @param reason The reason
         * @return this
         */
        public TaskUpdater setReason(string reason) {
            this.reason = reason;
            return this;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public TaskUpdater setPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * The task_channel
         * 
         * @param taskChannel The task_channel
         * @return this
         */
        public TaskUpdater setTaskChannel(string taskChannel) {
            this.taskChannel = taskChannel;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated TaskResource
         */
        public override async Task<TaskResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return TaskResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated TaskResource
         */
        public override TaskResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return TaskResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (assignmentStatus != null) {
                request.AddPostParam("AssignmentStatus", assignmentStatus.ToString());
            }
            
            if (reason != null) {
                request.AddPostParam("Reason", reason);
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (taskChannel != null) {
                request.AddPostParam("TaskChannel", taskChannel);
            }
        }
    }
}