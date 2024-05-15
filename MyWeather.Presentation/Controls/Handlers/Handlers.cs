using System.Diagnostics;
#if ANDROID
using Android.Widget;
using Microsoft.Maui.Controls.Platform;
#endif
using Microsoft.Maui.Handlers;

namespace MyWeather.Presentation.Controls.Handlers;

public static class Handlers
{
    public static void RegisterHandlers()
    {
        ConfigureSearchBar();
    }

    private static void ConfigureSearchBar()
    {
        SearchBarHandler.Mapper.AppendToMapping(nameof(SearchBarHandler),
            (handler, view) =>
            {
                try
                {
                    if (view is SearchBar)
                    {
#if ANDROID
                        LinearLayout linearLayout =  handler.PlatformView.GetChildAt(0) as Android.Widget.LinearLayout;  
                        linearLayout = linearLayout.GetChildAt(2) as Android.Widget.LinearLayout;  
                        linearLayout = linearLayout.GetChildAt(1) as Android.Widget.LinearLayout;  
                        linearLayout.Background = null;  
#elif IOS || MACCATALYST
         
#elif WINDOWS
        
#endif
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }
            });
    }
}