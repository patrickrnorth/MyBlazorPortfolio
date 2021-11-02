﻿namespace Client.Static
{
    public class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:5003";

#else
        internal const string ServerBaseUrl = "https://patricknorthserver.azurewebsites.net";
#endif

        internal readonly static string s_categories = $"{ServerBaseUrl}/api/categories";
    }
}
