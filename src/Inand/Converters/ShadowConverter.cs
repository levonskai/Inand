using System;
using System.Globalization;
using System.Windows.Media.Effects;
using System.Windows.Data;
using System.Windows;

namespace Inand.Converters
{
    /// <summary>
    /// Represents a converter that converts the elevation depth into a <see cref="DropShadowEffect" />.
    /// </summary>
    public class ShadowConverter : IValueConverter
    {
        /// <summary>
        /// Provides a converter instance for access from Xaml.
        /// </summary>
        public static ShadowConverter Instance { get; } = new ShadowConverter();


        /// <summary>
        /// Converts the elevation depth into a <see cref="DropShadowEffect" />.
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
        /// The <see cref="DropShadowEffect" />.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int depth)
            {
                if (depth < 0 || depth > 24)
                {
                    return DependencyProperty.UnsetValue;
                }

                return ElevationInfo.s_shadows[depth];
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
