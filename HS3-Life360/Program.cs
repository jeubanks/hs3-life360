using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using GetBearer;
using GetCircles;
using GetMembers;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GetBearer;
//
//    var bearer = Bearer.FromJson(jsonString);
namespace GetBearer
{
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Bearer
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("onboarding")]
        public string Onboarding { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("cobranding")]
        public object[] Cobranding { get; set; }

        [JsonProperty("promotions")]
        public object[] Promotions { get; set; }

        [JsonProperty("state")]
        public object State { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("loginEmail")]
        public string LoginEmail { get; set; }

        [JsonProperty("loginPhone")]
        public string LoginPhone { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("created")]
        public System.DateTimeOffset Created { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("communications")]
        public Communication[] Communications { get; set; }

        [JsonProperty("cobranding")]
        public object[] Cobranding { get; set; }
    }

    public partial class Communication
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Settings
    {
        [JsonProperty("map")]
        public Map Map { get; set; }

        [JsonProperty("alerts")]
        public Alerts Alerts { get; set; }

        [JsonProperty("zendrive")]
        public Zendrive Zendrive { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("unitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [JsonProperty("dateFormat")]
        public string DateFormat { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }

    public partial class Alerts
    {
        [JsonProperty("crime")]
        public string Crime { get; set; }

        [JsonProperty("sound")]
        public string Sound { get; set; }
    }

    public partial class Map
    {
        [JsonProperty("police")]
        public string Police { get; set; }

        [JsonProperty("fire")]
        public string Fire { get; set; }

        [JsonProperty("hospital")]
        public string Hospital { get; set; }

        [JsonProperty("sexOffenders")]
        public string SexOffenders { get; set; }

        [JsonProperty("crime")]
        public string Crime { get; set; }

        [JsonProperty("crimeDuration")]
        public string CrimeDuration { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("advisor")]
        public string Advisor { get; set; }

        [JsonProperty("placeRadius")]
        public string PlaceRadius { get; set; }

        [JsonProperty("memberRadius")]
        public string MemberRadius { get; set; }
    }

    public partial class Zendrive
    {
        [JsonProperty("sdk_enabled")]
        public string SdkEnabled { get; set; }
    }

    public partial class Bearer
    {
        public static Bearer FromJson(string json) => JsonConvert.DeserializeObject<Bearer>(json, GetBearer.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Bearer self) => JsonConvert.SerializeObject(self, GetBearer.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GetCircles;
//
//    var circlesRoot = CirclesRoot.FromJson(jsonString);
namespace GetCircles
{
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CirclesRoot
    {
        [JsonProperty("circles")]
        public List<Circle> Circle { get; set; }
    }

    public partial class Circle
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("memberCount")]
        public string MemberCount { get; set; }

        [JsonProperty("unreadMessages")]
        public string UnreadMessages { get; set; }

        [JsonProperty("unreadNotifications")]
        public string UnreadNotifications { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }
    }

    public partial class Features
    {
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        [JsonProperty("skuId")]
        public long SkuId { get; set; }

        [JsonProperty("premium")]
        public string Premium { get; set; }

        [JsonProperty("locationUpdatesLeft")]
        public long LocationUpdatesLeft { get; set; }

        [JsonProperty("priceMonth")]
        public string PriceMonth { get; set; }

        [JsonProperty("priceYear")]
        public string PriceYear { get; set; }

        [JsonProperty("skuTier")]
        public long SkuTier { get; set; }
    }

    public partial class CirclesRoot
    {
        public static CirclesRoot FromJson(string json) => JsonConvert.DeserializeObject<CirclesRoot>(json, GetCircles.Converter.Settings);
        //public static CirclesRoot FromJson(string json) => JsonConvert.DeserializeObject<List<CirclesRoot>>(json)//, GetCircles.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CirclesRoot self) => JsonConvert.SerializeObject(self, GetCircles.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GetMembers;
//
//    var members = Members.FromJson(jsonString);
namespace GetMembers
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Members
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("memberCount")]
        public string MemberCount { get; set; }

        [JsonProperty("unreadMessages")]
        public string UnreadMessages { get; set; }

        [JsonProperty("unreadNotifications")]
        public string UnreadNotifications { get; set; }

        [JsonProperty("features")]
        public MembersFeatures Features { get; set; }

        [JsonProperty("members")]
        public Member[] MembersMembers { get; set; }
    }

    public partial class MembersFeatures
    {
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        [JsonProperty("skuId")]
        public long SkuId { get; set; }

        [JsonProperty("premium")]
        public string Premium { get; set; }

        [JsonProperty("locationUpdatesLeft")]
        public long LocationUpdatesLeft { get; set; }

        [JsonProperty("priceMonth")]
        public string PriceMonth { get; set; }

        [JsonProperty("priceYear")]
        public string PriceYear { get; set; }

        [JsonProperty("skuTier")]
        public long SkuTier { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("features")]
        public MemberFeatures Features { get; set; }

        [JsonProperty("issues")]
        public Issues Issues { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("communications")]
        public Communication[] Communications { get; set; }

        [JsonProperty("medical")]
        public object Medical { get; set; }

        [JsonProperty("relation")]
        public object Relation { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("activity")]
        public object Activity { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("loginEmail")]
        public string LoginEmail { get; set; }

        [JsonProperty("loginPhone")]
        public string LoginPhone { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("isAdmin")]
        public string IsAdmin { get; set; }

        [JsonProperty("pinNumber")]
        public object PinNumber { get; set; }
    }

    public partial class Communication
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class MemberFeatures
    {
        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("smartphone")]
        public string Smartphone { get; set; }

        [JsonProperty("nonSmartphoneLocating")]
        public string NonSmartphoneLocating { get; set; }

        [JsonProperty("geofencing")]
        public string Geofencing { get; set; }

        [JsonProperty("shareLocation")]
        public string ShareLocation { get; set; }

        [JsonProperty("shareOffTimestamp")]
        public object ShareOffTimestamp { get; set; }

        [JsonProperty("disconnected")]
        public string Disconnected { get; set; }

        [JsonProperty("pendingInvite")]
        public string PendingInvite { get; set; }

        [JsonProperty("mapDisplay")]
        public string MapDisplay { get; set; }
    }

    public partial class Issues
    {
        [JsonProperty("disconnected")]
        public string Disconnected { get; set; }

        [JsonProperty("type")]
        public object Type { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("dialog")]
        public object Dialog { get; set; }

        [JsonProperty("action")]
        public object Action { get; set; }

        [JsonProperty("troubleshooting")]
        public string Troubleshooting { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("startTimestamp")]
        public long StartTimestamp { get; set; }

        [JsonProperty("endTimestamp")]
        public string EndTimestamp { get; set; }

        [JsonProperty("since")]
        public long Since { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("placeType")]
        public object PlaceType { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("shortAddress")]
        public string ShortAddress { get; set; }

        [JsonProperty("inTransit")]
        public string InTransit { get; set; }

        [JsonProperty("tripId")]
        public object TripId { get; set; }

        [JsonProperty("driveSDKStatus")]
        public object DriveSdkStatus { get; set; }

        [JsonProperty("battery")]
        public string Battery { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }

        [JsonProperty("wifiState")]
        public string WifiState { get; set; }

        [JsonProperty("speed")]
        public long Speed { get; set; }

        [JsonProperty("isDriving")]
        public string IsDriving { get; set; }
    }

    public enum Channel { Email, Voice };

    public partial class Members
    {
        public static Members FromJson(string json) => JsonConvert.DeserializeObject<Members>(json, GetMembers.Converter.Settings);
    }

    static class ChannelExtensions
    {
        public static Channel? ValueForString(string str)
        {
            switch (str)
            {
                case "Email": return Channel.Email;
                case "Voice": return Channel.Voice;
                default: return null;
            }
        }

        public static Channel ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Channel value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Channel.Email: serializer.Serialize(writer, "Email"); break;
                case Channel.Voice: serializer.Serialize(writer, "Voice"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Members self) => JsonConvert.SerializeObject(self, GetMembers.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Channel) || t == typeof(Channel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Channel))
                return ChannelExtensions.ReadJson(reader, serializer);
            if (t == typeof(Channel?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ChannelExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Channel))
            {
                ((Channel)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

namespace HS3_Life360
{
    class Program
    {
        static void SetPresence(string DeviceRef, string DeviceState)
        {
            if (DeviceRef == "000")
            {
                Console.WriteLine("No Device Reference Specified");
            }
            else
            {
                string HS3Url = ConfigurationSettings.AppSettings["HS3Url"];
                var controlJson = "/JSON?request=controldevicebylabel&ref=" + DeviceRef + "&label=" + DeviceState;
                var client = new RestClient(HS3Url + controlJson);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
            }
        }

        static void Main(string[] args)
        {
            string Username = ConfigurationSettings.AppSettings["Username"];
            string Password = ConfigurationSettings.AppSettings["Password"];

            var baseUrl = "https://api.life360.com/v3";
            var tokenUrl = "/oauth2/token.json";
            var circlesUrl = "/circles.json";
            var membersUrl = baseUrl + "/circles/"; // This is dynamic and set later

            // Authenticate to Life360
            var client1 = new RestClient(baseUrl + tokenUrl);
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("Authorization", "Basic cFJFcXVnYWJSZXRyZTRFc3RldGhlcnVmcmVQdW1hbUV4dWNyRUh1YzptM2ZydXBSZXRSZXN3ZXJFQ2hBUHJFOTZxYWtFZHI0Vg==");
            request1.AddParameter("grant_type", "password");
            request1.AddParameter("username", Username);
            request1.AddParameter("password", Password);
            IRestResponse response = client1.Execute(request1);
            var bearer = Bearer.FromJson(json: response.Content);
            var bearerToken = "Bearer " + bearer.AccessToken;

            // Get Life360 Circles
            var client2 = new RestClient(baseUrl + circlesUrl);
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("Authorization", bearerToken);
            IRestResponse response2 = client2.Execute(request2);
            var circles = CirclesRoot.FromJson(json: response2.Content);
            var circleCount = circles.Circle.Count;

            if (circleCount > 1)
            {
                Console.WriteLine("Circle Count: " + circleCount);
                Console.WriteLine("Multiple Circles are not implemented yet");
            }

            var circleId = circles.Circle[0].Id;
            var circleName = circles.Circle[0].Name;

            // Get Life360 Members
            var client3 = new RestClient(membersUrl + circleId);
            var request3 = new RestRequest(Method.GET);
            request3.AddHeader("Accept", "application/json");
            request3.AddHeader("cache-control", "no-cache");
            request3.AddHeader("Authorization", bearerToken);
            IRestResponse response3 = client3.Execute(request3);
            var member = Members.FromJson(json: response3.Content);
            int mCount = member.MembersMembers.Length;

            for (int i = 0; i < mCount; i++)
            {
                //Get Life360 Member First Name
                string[] firstName = member.MembersMembers[i].FirstName.Split(' ');

                //Get Life360 Member Location
                string locationName = member.MembersMembers[i].Location.Name;

                string DeviceRef = ConfigurationSettings.AppSettings[firstName[0]];
                if (!String.IsNullOrEmpty(DeviceRef))
                {
                    if (locationName == "Home")
                    {
                        SetPresence(DeviceRef, "on");
                    }
                    else
                    {
                        SetPresence(DeviceRef, "off");
                    }
                }
                else
                {
                    Console.WriteLine(firstName[0] +": " + "Has no config entry...Adding.");
                    //Add missing member to config
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Add(firstName[0], "000");
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
    }
}