using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;

namespace Website.Helpers
{
    public static class HtmlHelpers
    {
        private static Random _randomGenerator = new Random();

        public static HtmlString GetUGCDataServiceInitializationScript(this IHtmlHelper htmlHelper, int currentUserID = -1) {

            var ugcSettings = Website.Utils.UGCUtils.GetUGCDataServiceInitialization(-1);

			string script = string.Format("<script type='text/javascript'>var _AgilityUGCSettings = {{ 'Url': '{0}', 'AccessKey': '{1}', 'Seconds': '{2}', 'RandomNumber': '{3}', 'ProfileRecordID': '{4}', 'AccessHash': '{5}' }};</script>",
                    ugcSettings.Url,
					ugcSettings.AccessKey,
					ugcSettings.Seconds,
					ugcSettings.RandomNumber,
					ugcSettings.ProfileRecordID,
					ugcSettings.AccessHash
                );

			return new HtmlString(script);
        }
    }
}