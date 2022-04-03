using System.Collections.Generic;
using System.Windows.Media.Effects;

namespace Inand.Converters
{
    internal static class ElevationInfo
    {
        internal static readonly IDictionary<int, DropShadowEffect> s_shadows = new Dictionary<int, DropShadowEffect>
        {
            { 0, null },
            { 1, new DropShadowEffect { BlurRadius = 3, ShadowDepth = .6, Opacity = .38, Direction = 270 } },
            { 2, new DropShadowEffect { BlurRadius = 4, ShadowDepth = 1.2, Opacity = .38, Direction = 270 } },
            { 3, new DropShadowEffect { BlurRadius = 5, ShadowDepth = 1.8, Opacity = .38, Direction = 270 } },
            { 4, new DropShadowEffect { BlurRadius = 6, ShadowDepth = 2, Opacity = .38, Direction = 270 } },
            { 5, new DropShadowEffect { BlurRadius = 7, ShadowDepth = 2.5, Opacity = .38, Direction = 270 } },
            { 6, new DropShadowEffect { BlurRadius = 8, ShadowDepth = 2.5, Opacity = .38, Direction = 270 } },
            { 7, new DropShadowEffect { BlurRadius = 9, ShadowDepth = 3, Opacity = .38, Direction = 270 } },
            { 8, new DropShadowEffect { BlurRadius = 11, ShadowDepth = 3.5, Opacity = .38, Direction = 270 } },
            { 9, new DropShadowEffect { BlurRadius = 12, ShadowDepth = 3.75, Opacity = .38, Direction = 270 } },
            { 10, new DropShadowEffect { BlurRadius = 13, ShadowDepth = 4, Opacity = .38, Direction = 270 } },
            { 11, new DropShadowEffect { BlurRadius = 14, ShadowDepth = 4.25, Opacity = .38, Direction = 270 } },
            { 12, new DropShadowEffect { BlurRadius = 15, ShadowDepth = 4.5, Opacity = .38, Direction = 270 } },
            { 13, new DropShadowEffect { BlurRadius = 16, ShadowDepth = 4.75, Opacity = .38, Direction = 270 } },
            { 14, new DropShadowEffect { BlurRadius = 17, ShadowDepth = 5, Opacity = .38, Direction = 270 } },
            { 15, new DropShadowEffect { BlurRadius = 18, ShadowDepth = 5.25, Opacity = .38, Direction = 270 } },
            { 16, new DropShadowEffect { BlurRadius = 19, ShadowDepth = 5.5, Opacity = .38, Direction = 270 } },
            { 17, new DropShadowEffect { BlurRadius = 20, ShadowDepth = 5.75, Opacity = .38, Direction = 270 } },
            { 18, new DropShadowEffect { BlurRadius = 21, ShadowDepth = 6, Opacity = .38, Direction = 270 } },
            { 19, new DropShadowEffect { BlurRadius = 22, ShadowDepth = 6.25, Opacity = .38, Direction = 270 } },
            { 20, new DropShadowEffect { BlurRadius = 23, ShadowDepth = 6.5, Opacity = .38, Direction = 270 } },
            { 21, new DropShadowEffect { BlurRadius = 24, ShadowDepth = 6.75, Opacity = .38, Direction = 270 } },
            { 22, new DropShadowEffect { BlurRadius = 25, ShadowDepth = 7, Opacity = .38, Direction = 270 } },
            { 23, new DropShadowEffect { BlurRadius = 26, ShadowDepth = 7.25, Opacity = .38, Direction = 270 } },
            { 24, new DropShadowEffect { BlurRadius = 27, ShadowDepth = 7.5, Opacity = .38, Direction = 270 } }
        };


        internal static readonly IDictionary<int, double> s_overlays = new Dictionary<int, double>
        {
            { 0, .0 },
            { 1, .05 },
            { 2, .07 },
            { 3, .08 },
            { 4, .09 },
            { 5, .1 },
            { 6, .11 },
            { 7, .115 },
            { 8, .12 },
            { 9, .125 },
            { 10, .13 },
            { 11, .135 },
            { 12, .14 },
            { 13, .1425 },
            { 14, .145 },
            { 15, .1475 },
            { 16, .15 },
            { 17, .15 },
            { 18, .1525 },
            { 19, .1525 },
            { 20, .155 },
            { 21, .155 },
            { 22, .1575 },
            { 23, .1575 },
            { 24, .16 }
        };
    }
}
