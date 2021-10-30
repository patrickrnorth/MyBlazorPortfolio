namespace Client.Static
{
    public class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:5003";

#else
        interal const string ServerBaseUrl = "https://appname.azurewebsites.net";
#endif

        internal readonly static string s_categories = $"{ServerBaseUrl}/api/categories";
    }
}
