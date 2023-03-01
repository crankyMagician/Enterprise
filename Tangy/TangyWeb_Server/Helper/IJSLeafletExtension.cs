using Microsoft.JSInterop;

namespace TangyWeb_Server.Helper
{
    public static class IJSLeafletExtension
    {
        public static async ValueTask CreateMap(this IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("createMap");
        }

        public static async ValueTask PlacePin(this IJSRuntime jsRuntime, double lat, double lon)
        {
            await jsRuntime.InvokeVoidAsync("addMarker", lat, lon);
        }

        public static  async Task PlacePolygon(this IJSRuntime jsRuntime, Tuple<double, double>[] points)
        {
            // Convert the points list to an array of arrays for JavaScript
            var jsPoints = points.Select(p => new object[] { p.Item1, p.Item2 }).ToArray();
            await jsRuntime.InvokeVoidAsync("placePolygon", jsPoints);
        }

    }
}
