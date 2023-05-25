using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace V_Mobile
{
    public static class MesDisplayMode
    {
        public static void PourIphone25()
        {
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("iPhone25")
                {
                    ContextCondition = x => x.Request.UserAgent.IndexOf("iphone25", StringComparison.OrdinalIgnoreCase) > -1
                }
                );
        }
    }
}