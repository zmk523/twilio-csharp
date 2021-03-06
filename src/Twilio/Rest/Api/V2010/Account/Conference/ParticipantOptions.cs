/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    /// <summary>
    /// Fetch an instance of a participant
    /// </summary>
    public class FetchParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string PathConferenceSid { get; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }

        /// <summary>
        /// Construct a new FetchParticipantOptions
        /// </summary>
        /// <param name="pathConferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="pathCallSid"> The call_sid </param>
        public FetchParticipantOptions(string pathConferenceSid, string pathCallSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Update the properties of this participant
    /// </summary>
    public class UpdateParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string PathConferenceSid { get; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// Indicates if the participant should be muted
        /// </summary>
        public bool? Muted { get; set; }
        /// <summary>
        /// Specifying true will hold the participant, while false will un-hold.
        /// </summary>
        public bool? Hold { get; set; }
        /// <summary>
        /// The 'HoldUrl' attribute lets you specify a URL for music that plays when a participant is held.
        /// </summary>
        public Uri HoldUrl { get; set; }
        /// <summary>
        /// Specify GET or POST, defaults to GET
        /// </summary>
        public Twilio.Http.HttpMethod HoldMethod { get; set; }
        /// <summary>
        /// The announce_url
        /// </summary>
        public Uri AnnounceUrl { get; set; }
        /// <summary>
        /// The announce_method
        /// </summary>
        public Twilio.Http.HttpMethod AnnounceMethod { get; set; }

        /// <summary>
        /// Construct a new UpdateParticipantOptions
        /// </summary>
        /// <param name="pathConferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="pathCallSid"> The call_sid </param>
        public UpdateParticipantOptions(string pathConferenceSid, string pathCallSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString().ToLower()));
            }

            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.Value.ToString().ToLower()));
            }

            if (HoldUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("HoldUrl", Serializers.Url(HoldUrl)));
            }

            if (HoldMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("HoldMethod", HoldMethod.ToString()));
            }

            if (AnnounceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("AnnounceUrl", Serializers.Url(AnnounceUrl)));
            }

            if (AnnounceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("AnnounceMethod", AnnounceMethod.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// CreateParticipantOptions
    /// </summary>
    public class CreateParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The conference_sid
        /// </summary>
        public string PathConferenceSid { get; }
        /// <summary>
        /// number, client id
        /// </summary>
        public Types.PhoneNumber From { get; }
        /// <summary>
        /// number, client id, sip address
        /// </summary>
        public Types.PhoneNumber To { get; }
        /// <summary>
        /// absolute url
        /// </summary>
        public Uri StatusCallback { get; set; }
        /// <summary>
        /// GET, POST
        /// </summary>
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        /// <summary>
        /// initiated, ringing, answered, completed
        /// </summary>
        public List<string> StatusCallbackEvent { get; set; }
        /// <summary>
        /// 5-600
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// true, false
        /// </summary>
        public bool? Record { get; set; }
        /// <summary>
        /// true, false
        /// </summary>
        public bool? Muted { get; set; }
        /// <summary>
        /// true, false, onEnter, onExit
        /// </summary>
        public string Beep { get; set; }
        /// <summary>
        /// true, false
        /// </summary>
        public bool? StartConferenceOnEnter { get; set; }
        /// <summary>
        /// true, false
        /// </summary>
        public bool? EndConferenceOnExit { get; set; }
        /// <summary>
        /// absolute url
        /// </summary>
        public Uri WaitUrl { get; set; }
        /// <summary>
        /// GET, POST
        /// </summary>
        public Twilio.Http.HttpMethod WaitMethod { get; set; }
        /// <summary>
        /// true, false
        /// </summary>
        public bool? EarlyMedia { get; set; }
        /// <summary>
        /// 2-10
        /// </summary>
        public int? MaxParticipants { get; set; }
        /// <summary>
        /// true, false, record-from-start, do-not-record
        /// </summary>
        public string ConferenceRecord { get; set; }
        /// <summary>
        /// trim-silence or do-not-trim
        /// </summary>
        public string ConferenceTrim { get; set; }
        /// <summary>
        /// absolute url
        /// </summary>
        public Uri ConferenceStatusCallback { get; set; }
        /// <summary>
        /// GET, POST
        /// </summary>
        public Twilio.Http.HttpMethod ConferenceStatusCallbackMethod { get; set; }
        /// <summary>
        /// start end join leave mute hold speaker
        /// </summary>
        public List<string> ConferenceStatusCallbackEvent { get; set; }
        /// <summary>
        /// mono, dual
        /// </summary>
        public string RecordingChannels { get; set; }
        /// <summary>
        /// absolute url
        /// </summary>
        public Uri RecordingStatusCallback { get; set; }
        /// <summary>
        /// GET, POST
        /// </summary>
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }
        /// <summary>
        /// sip username
        /// </summary>
        public string SipAuthUsername { get; set; }
        /// <summary>
        /// sip password
        /// </summary>
        public string SipAuthPassword { get; set; }
        /// <summary>
        /// us1, ie1, de1, sg1, br1, au1, jp1
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// absolute url
        /// </summary>
        public Uri ConferenceRecordingStatusCallback { get; set; }
        /// <summary>
        /// GET, POST
        /// </summary>
        public Twilio.Http.HttpMethod ConferenceRecordingStatusCallbackMethod { get; set; }
        /// <summary>
        /// The recording_status_callback_event
        /// </summary>
        public List<string> RecordingStatusCallbackEvent { get; set; }
        /// <summary>
        /// The conference_recording_status_callback_event
        /// </summary>
        public List<string> ConferenceRecordingStatusCallbackEvent { get; set; }

        /// <summary>
        /// Construct a new CreateParticipantOptions
        /// </summary>
        /// <param name="pathConferenceSid"> The conference_sid </param>
        /// <param name="from"> number, client id </param>
        /// <param name="to"> number, client id, sip address </param>
        public CreateParticipantOptions(string pathConferenceSid, Types.PhoneNumber from, Types.PhoneNumber to)
        {
            PathConferenceSid = pathConferenceSid;
            From = from;
            To = to;
            StatusCallbackEvent = new List<string>();
            ConferenceStatusCallbackEvent = new List<string>();
            RecordingStatusCallbackEvent = new List<string>();
            ConferenceRecordingStatusCallbackEvent = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }

            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }

            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
            }

            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }

            if (StatusCallbackEvent != null)
            {
                p.AddRange(StatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("StatusCallbackEvent", prop)));
            }

            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.Value.ToString()));
            }

            if (Record != null)
            {
                p.Add(new KeyValuePair<string, string>("Record", Record.Value.ToString().ToLower()));
            }

            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString().ToLower()));
            }

            if (Beep != null)
            {
                p.Add(new KeyValuePair<string, string>("Beep", Beep));
            }

            if (StartConferenceOnEnter != null)
            {
                p.Add(new KeyValuePair<string, string>("StartConferenceOnEnter", StartConferenceOnEnter.Value.ToString().ToLower()));
            }

            if (EndConferenceOnExit != null)
            {
                p.Add(new KeyValuePair<string, string>("EndConferenceOnExit", EndConferenceOnExit.Value.ToString().ToLower()));
            }

            if (WaitUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitUrl", Serializers.Url(WaitUrl)));
            }

            if (WaitMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitMethod", WaitMethod.ToString()));
            }

            if (EarlyMedia != null)
            {
                p.Add(new KeyValuePair<string, string>("EarlyMedia", EarlyMedia.Value.ToString().ToLower()));
            }

            if (MaxParticipants != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxParticipants", MaxParticipants.Value.ToString()));
            }

            if (ConferenceRecord != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecord", ConferenceRecord));
            }

            if (ConferenceTrim != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceTrim", ConferenceTrim));
            }

            if (ConferenceStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceStatusCallback", Serializers.Url(ConferenceStatusCallback)));
            }

            if (ConferenceStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceStatusCallbackMethod", ConferenceStatusCallbackMethod.ToString()));
            }

            if (ConferenceStatusCallbackEvent != null)
            {
                p.AddRange(ConferenceStatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("ConferenceStatusCallbackEvent", prop)));
            }

            if (RecordingChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingChannels", RecordingChannels));
            }

            if (RecordingStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallback", Serializers.Url(RecordingStatusCallback)));
            }

            if (RecordingStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallbackMethod", RecordingStatusCallbackMethod.ToString()));
            }

            if (SipAuthUsername != null)
            {
                p.Add(new KeyValuePair<string, string>("SipAuthUsername", SipAuthUsername));
            }

            if (SipAuthPassword != null)
            {
                p.Add(new KeyValuePair<string, string>("SipAuthPassword", SipAuthPassword));
            }

            if (Region != null)
            {
                p.Add(new KeyValuePair<string, string>("Region", Region));
            }

            if (ConferenceRecordingStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecordingStatusCallback", Serializers.Url(ConferenceRecordingStatusCallback)));
            }

            if (ConferenceRecordingStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecordingStatusCallbackMethod", ConferenceRecordingStatusCallbackMethod.ToString()));
            }

            if (RecordingStatusCallbackEvent != null)
            {
                p.AddRange(RecordingStatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("RecordingStatusCallbackEvent", prop)));
            }

            if (ConferenceRecordingStatusCallbackEvent != null)
            {
                p.AddRange(ConferenceRecordingStatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("ConferenceRecordingStatusCallbackEvent", prop)));
            }

            return p;
        }
    }

    /// <summary>
    /// Kick a participant from a given conference
    /// </summary>
    public class DeleteParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string PathConferenceSid { get; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }

        /// <summary>
        /// Construct a new DeleteParticipantOptions
        /// </summary>
        /// <param name="pathConferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="pathCallSid"> The call_sid </param>
        public DeleteParticipantOptions(string pathConferenceSid, string pathCallSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Retrieve a list of participants belonging to the account used to make the request
    /// </summary>
    public class ReadParticipantOptions : ReadOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string PathConferenceSid { get; }
        /// <summary>
        /// Filter by muted participants
        /// </summary>
        public bool? Muted { get; set; }
        /// <summary>
        /// Only show participants that are held or unheld.
        /// </summary>
        public bool? Hold { get; set; }

        /// <summary>
        /// Construct a new ReadParticipantOptions
        /// </summary>
        /// <param name="pathConferenceSid"> The string that uniquely identifies this conference </param>
        public ReadParticipantOptions(string pathConferenceSid)
        {
            PathConferenceSid = pathConferenceSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString().ToLower()));
            }

            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.Value.ToString().ToLower()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}