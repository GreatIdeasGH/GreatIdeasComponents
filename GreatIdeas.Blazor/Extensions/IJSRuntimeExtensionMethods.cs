using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace GreatIdeas.Blazor.Extensions
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime js,
            DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        }

        public static ValueTask SaveAs(this IJSRuntime jsRuntime, string fileName, byte[] content)
        {
            return jsRuntime.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(content));
        }

        public static async ValueTask SetBlazorTitle(this IJSRuntime js, string title)
        {
            await js.InvokeVoidAsync("blazorSetTitle", title);
        }

        public static async ValueTask SetBlazorDescription(this IJSRuntime js, string description)
        {
            await js.InvokeVoidAsync("blazorSetDescription", description);
        }
    }
}