using System.Windows;
using System.Windows.Media;

namespace Inand.Assists
{
    /// <summary>
    /// Provides attached properties for setting the bullet of toggle controls.
    /// </summary>
    public static class BulletAssist
    {
        #region Attached Property: CheckedFill
        /// <summary>
        /// Identifies the <see cref="BulletAssist" />.CheckedFill attached property.
        /// </summary>
        public static readonly DependencyProperty CheckedFillProperty = DependencyProperty.RegisterAttached(
            "CheckedFill",
            typeof(Brush),
            typeof(BulletAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="BulletAssist" />.CheckedFill attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="BulletAssist" />.CheckedFill attached property.
        /// </returns>
        public static Brush GetCheckedFill(UIElement element) => (Brush)element.GetValue(CheckedFillProperty);

        /// <summary>
        /// Sets the value of the <see cref="BulletAssist" />.CheckedFill attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="BulletAssist" />.CheckedFill attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetCheckedFill(UIElement element, Brush value) => element.SetValue(CheckedFillProperty, value);
        #endregion


        #region Attached Property: OnOnCheckedFill
        /// <summary>
        /// Identifies the <see cref="BulletAssist" />.OnCheckedFill attached property.
        /// </summary>
        public static readonly DependencyProperty OnCheckedFillProperty = DependencyProperty.RegisterAttached(
            "OnCheckedFill",
            typeof(Brush),
            typeof(BulletAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="BulletAssist" />.OnCheckedFill attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="BulletAssist" />.OnCheckedFill attached property.
        /// </returns>
        public static Brush GetOnCheckedFill(UIElement element) => (Brush)element.GetValue(OnCheckedFillProperty);

        /// <summary>
        /// Sets the value of the <see cref="BulletAssist" />.OnCheckedFill attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="BulletAssist" />.OnCheckedFill attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetOnCheckedFill(UIElement element, Brush value) => element.SetValue(OnCheckedFillProperty, value);
        #endregion
    }
}
