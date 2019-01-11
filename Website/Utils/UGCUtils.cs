using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Website.Utils
{
    public static class UGCUtils
    {
        private static Random _randomGenerator = new Random();

        public class UGCAccess {
            public string Url {get;set;}
            public string AccessKey {get;set;}
            public int Seconds {get;set;}
            public int RandomNumber {get;set;}
            public int ProfileRecordID {get;set;}
            public string AccessHash {get;set;}
        }

        /// <summary>
		/// Get a Hex Encoded SHA1 string
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private static string getSHA1Hash(string input)
		{

			// Create a new instance of the SHA1 object.			
			SHA1 sha1Hasher = SHA1.Create();

			// Convert the input string to a byte array and compute the hash.
			byte[] data = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();


			// Loop through each byte of the hashed data
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}

        /// <summary>
		/// Build a hash from the component parts of the input.
		/// </summary>
		/// <param name="accessKey"></param>
		/// <param name="password"></param>
		/// <param name="profileRecordID"></param>
		/// <param name="seconds"></param>
		/// <param name="random"></param>
		/// <returns></returns>
		internal static string BuildHash(string accessKey, string password, int profileRecordID, int seconds, int random)
		{


			string input = string.Format("{0}.{1}.{2}.{3}.{4}",
						 seconds,
						 profileRecordID,
						 password,
						 accessKey,
						 random);

			//hash the string using MD5
			string hash = getSHA1Hash(input);
			return hash;
		}

        public static UGCAccess GetUGCDataServiceInitialization(int currentUserID = -1) {

            var ugcSettings = Agility.Web.Configuration.Current.Settings.UGC;

            string Agility_API_Key = ugcSettings.Key;
            string Agility_API_Password = ugcSettings.Password;
            string Agility_API_Url = ugcSettings.Url;
            

            int profileRecordID = currentUserID;

			if (string.IsNullOrEmpty(Agility_API_Key)
				|| string.IsNullOrEmpty(Agility_API_Password))
			{
				throw new ApplicationException("The Agility UGC Settings have not been initialized in the web.config.  Please ensure that the Agility_API_Key and the Agility_API_Password appSettings are configured properly.");
			}

			string accessKey = Agility_API_Key;
			string password = Agility_API_Password;


			//get the number of seconds since 1,1,2001
			TimeSpan elapsedSpan = DateTime.Now - new DateTime(2001, 1, 1);
			int seconds = Convert.ToInt32(Math.Floor(elapsedSpan.TotalSeconds));

			int randomNumber = 0;
			lock (_randomGenerator)
			{
				//get a random number between 1 and 1000
				randomNumber = _randomGenerator.Next(1, 1000);
			}

			string url = "https://ugc.agilitycms.com/Agility-UGC-API-JSONP.svc";
			
			if (!string.IsNullOrEmpty(Agility_API_Url))
			{
				url = Agility_API_Url;
				if (url.IndexOf("/", url.IndexOf("://") + 3) > 0)
				{
					url = url.Substring(0, url.IndexOf("/", url.IndexOf("://") + 3));
				}

				url += "/Agility-UGC-API-JSONP.svc";
			}

			//[seconds].[recordID].[password].[accessKey].[random]
			string accessHash = BuildHash(accessKey, password, profileRecordID, seconds, randomNumber);

            return new UGCAccess() {
                Url =  url,
                AccessKey = accessKey,
                Seconds = seconds,
                RandomNumber = randomNumber,
                ProfileRecordID = profileRecordID,
                AccessHash = accessHash
            };
        }
    }
}