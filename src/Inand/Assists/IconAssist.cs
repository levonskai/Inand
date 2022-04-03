using System.Windows;
using System.Windows.Media;

namespace Inand.Assists
{
    /// <summary>
    /// Provides attached properties for setting the <see cref="Geometry" /> of icon.
    /// </summary>
    public static class IconAssist
    {
        #region Attached Property: Geometry
        /// <summary>
        /// Identifies the <see cref="IconAssist" />.Geometry attached property.
        /// </summary>
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.RegisterAttached(
            "Geometry",
            typeof(Geometry),
            typeof(IconAssist),
            new PropertyMetadata(OnGeometryChanged)
        );

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.Geometry attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.Geometry attached property.
        /// </returns>
        public static Geometry GetGeometry(UIElement element) => (Geometry)element.GetValue(GeometryProperty);

        /// <summary>
        /// Sets the value of the <see cref="IconAssist" />.Geometry attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="IconAssist" />.Geometry attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetGeometry(UIElement element, Geometry value) => element.SetValue(GeometryProperty, value);

        private static void OnGeometryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            obj.SetValue(HasGeometryPropertyKey, e.NewValue != null);
        }
        #endregion


        #region Read Only Attached Property: HasGeometry
        private static readonly DependencyPropertyKey HasGeometryPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
            "HasGeometry",
            typeof(bool),
            typeof(IconAssist),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// Identifies the <see cref="IconAssist" />.HasGeometry read only attached property.
        /// </summary>
        public static readonly DependencyProperty HasGeometryProperty = HasGeometryPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.HasGeometry read only attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.HasGeometry attached property.
        /// </returns>
        public static bool GetHasGeometry(UIElement element) => (bool)element.GetValue(HasGeometryProperty);
        #endregion


        #region Attached Property: Fill
        /// <summary>
        /// Identifies the <see cref="IconAssist" />.Fill attached property.
        /// </summary>
        public static readonly DependencyProperty FillProperty = DependencyProperty.RegisterAttached(
            "Fill",
            typeof(Brush),
            typeof(IconAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.Fill attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.Fill attached property.
        /// </returns>
        public static Brush GetFill(UIElement element) => (Brush)element.GetValue(FillProperty);

        /// <summary>
        /// Sets the value of the <see cref="IconAssist" />.Fill attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="IconAssist" />.Fill attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetFill(UIElement element, Brush value) => element.SetValue(FillProperty, value);
        #endregion


        #region Attached Property: Stretch
        /// <summary>
        /// Identifies the <see cref="IconAssist" />.Stretch attached property.
        /// </summary>
        public static readonly DependencyProperty StretchProperty = DependencyProperty.RegisterAttached(
            "Stretch",
            typeof(Stretch),
            typeof(IconAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.Stretch attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.Stretch attached property.
        /// </returns>
        public static Stretch GetStretch(UIElement element) => (Stretch)element.GetValue(StretchProperty);

        /// <summary>
        /// Sets the value of the <see cref="IconAssist" />.Stretch attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="IconAssist" />.Stretch attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetStretch(UIElement element, Stretch value) => element.SetValue(StretchProperty, value);
        #endregion


        #region Attached Property: Width
        /// <summary>
        /// Identifies the <see cref="IconAssist" />.Width attached property.
        /// </summary>
        public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached(
            "Width",
            typeof(double),
            typeof(IconAssist),
            new PropertyMetadata(double.NaN)
        );

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.Width attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.Width attached property.
        /// </returns>
        public static double GetWidth(UIElement element) => (double)element.GetValue(WidthProperty);

        /// <summary>
        /// Sets the value of the <see cref="IconAssist" />.Width attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="IconAssist" />.Width attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetWidth(UIElement element, double value) => element.SetValue(WidthProperty, value);
        #endregion


        #region Attached Property: Height
        /// <summary>
        /// Identifies the <see cref="IconAssist" />.Height attached property.
        /// </summary>
        public static readonly DependencyProperty HeightProperty = DependencyProperty.RegisterAttached(
            "Height",
            typeof(double),
            typeof(IconAssist),
            new PropertyMetadata(double.NaN)
        );

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.Height attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.Height attached property.
        /// </returns>
        public static double GetHeight(UIElement element) => (double)element.GetValue(HeightProperty);

        /// <summary>
        /// Sets the value of the <see cref="IconAssist" />.Height attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="IconAssist" />.Height attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetHeight(UIElement element, double value) => element.SetValue(HeightProperty, value);
        #endregion


        #region Attached Property: Margin
        /// <summary>
        /// Identifies the <see cref="IconAssist" />.Margin attached property.
        /// </summary>
        public static readonly DependencyProperty MarginProperty = DependencyProperty.RegisterAttached(
            "Margin",
            typeof(Thickness),
            typeof(IconAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="IconAssist" />.Margin attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="IconAssist" />.Margin attached property.
        /// </returns>
        public static Thickness GetMargin(UIElement element) => (Thickness)element.GetValue(MarginProperty);

        /// <summary>
        /// Sets the value of the <see cref="IconAssist" />.Margin attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="IconAssist" />.Margin attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetMargin(UIElement element, Thickness value) => element.SetValue(MarginProperty, value);
        #endregion
    }
}
