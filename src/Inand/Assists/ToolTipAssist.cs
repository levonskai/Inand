using System.Windows;
using System.Windows.Controls.Primitives;

namespace Inand.Assists
{
    /// <summary>
    /// Provides attached properties and events for setting the behavior of the tooltip.
    /// </summary>
    public static class ToolTipAssist
    {
        /// <summary>
        /// Provides a method for custom positioning of the tooltip.
        /// </summary>
        public static CustomPopupPlacementCallback ToolTipPlacementCallback => PlaceToolTip;

        private static CustomPopupPlacement[] PlaceToolTip(Size pSize, Size tSize, Point offset)
        {
            return new[]
            {
                new CustomPopupPlacement(new Point(tSize.Width/2 - pSize.Width/2, tSize.Height + 8), PopupPrimaryAxis.Horizontal)
            };
        }
    }
}
