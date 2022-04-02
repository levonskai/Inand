using System.Windows;

namespace Inand.Assists
{
    /// <summary>
    /// Provides attached properties for setting the <see cref="CornerRadius" />.
    /// </summary>
    public static class CornerRadiusAssist
    {
        #region Attached Property: CornerRadius
        /// <summary>
        /// Identifies the <see cref="CornerRadiusAssist" />.CornerRadius attached property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius",
            typeof(CornerRadius),
            typeof(CornerRadiusAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="CornerRadiusAssist" />.CornerRadius attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="CornerRadiusAssist" />.CornerRadius attached property.
        /// </returns>
        public static CornerRadius GetCornerRadius(UIElement element) => (CornerRadius)element.GetValue(CornerRadiusProperty);

        /// <summary>
        /// Sets the value of the <see cref="CornerRadiusAssist" />.CornerRadius attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="CornerRadiusAssist" />.CornerRadius attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetCornerRadius(UIElement element, CornerRadius value) => element.SetValue(CornerRadiusProperty, value);
        #endregion
    }
}
