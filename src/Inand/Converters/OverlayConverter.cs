using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Inand.Converters
{
    /// <summary>
    /// Represents a converter that converts the elevation depth into a semi-transparent overlay.
    /// </summary>
    public class OverlayConverter : IValueConverter
    {
        /// <summary>
        /// Provides a converter instance for access from Xaml.
        /// </summary>
        public static OverlayConverter Instance { get; } = new OverlayConverter();


        /// <summary>
        /// Converts the elevation depth into a semi-transparent overlay.
        /// </summary>
        /// <param name="value">
        /// The elevation depth (<see cref="int" />).
        /// </param>
        /// <param name="targetType">
        /// This parameter is not used.
        /// </param>
        /// <param name="parameter">
        /// This parameter is not used.
        /// </param>
        /// <param name="culture">
        /// This parameter is not used.
        /// </param>
        /// <returns>
        /// The semi-transparent overlay (<see cref="double" />).
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int depth)
            {
                if (depth < 0 || depth > 24)
                {
                    return DependencyProperty.UnsetValue;
                }

                return ElevationInfo.s_overlays[depth];
            }

            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="value">
        /// This parameter is not used.
        /// </param>
        /// <param name="targetType">
        /// This parameter is not used.
        /// </param>
        /// <param name="parameter">
        /// This parameter is not used.
        /// </param>
        /// <param name="culture">
        /// This parameter is not used.
        /// </param>
        /// <exception cref="NotSupportedException">
        /// The method is called.
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
