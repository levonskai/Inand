using System.Windows;

namespace Inand.Assists
{
    /// <summary>
    /// Provides attached properties for setting the depth of surface along the Z-axis.
    /// </summary>
    public static class ElevationAssist
    {
        #region Attached Property: Depth
        /// <summary>
        /// Identifies the <see cref="ElevationAssist" />.Depth attached property.
        /// </summary>
        public static readonly DependencyProperty DepthProperty = DependencyProperty.RegisterAttached(
            "Depth",
            typeof(int),
            typeof(ElevationAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="ElevationAssist" />.Depth attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="ElevationAssist" />.Depth attached property.
        /// </returns>
        public static int GetDepth(UIElement element) => (int)element.GetValue(DepthProperty);

        /// <summary>
        /// Sets the value of the <see cref="ElevationAssist" />.Depth attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="ElevationAssist" />.Depth attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetDepth(UIElement element, int value) => element.SetValue(DepthProperty, value);
        #endregion
    }
}
