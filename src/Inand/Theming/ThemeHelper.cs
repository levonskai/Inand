using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Inand.Theming
{
    /// <summary>
    /// Provides methods for theming.
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// Gets or sets a collection of theme key, theme <see cref="ResourceDictionary" /> pairs.
        /// </summary>
        /// <remarks>
        /// The <see cref="BaseTheme" /> elements are set by default.
        /// </remarks>
        public static IDictionary<object, Uri> ThemeDictionaries { get; set; } = new Dictionary<object, Uri>
        {
            { BaseTheme.Light, new Uri("pack://application:,,,/Inand;component/Themes/Light.xaml") },
            { BaseTheme.Dark, new Uri("pack://application:,,,/Inand;component/Themes/Dark.xaml") }
        };


        /// <summary>
        /// Gets the key of contained theme <see cref="ResourceDictionary" />.
        /// </summary>
        /// <param name="root">
        /// The root <see cref="ResourceDictionary" /> to get theme.
        /// </param>
        /// <returns>
        /// The theme key from the <see cref="ThemeDictionaries" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="root" /> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The theme <see cref="ResourceDictionary" /> not found.
        /// </exception>
        public static object GetTheme(this ResourceDictionary root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            ResourceDictionary actualTheme = root.FindThemeOrNull();

            if (actualTheme == null)
            {
                throw new InvalidOperationException($"The theme { nameof(ResourceDictionary) } was not found.");
            }

            return ThemeDictionaries.FirstOrDefault(td => td.Value.Equals(actualTheme.Source)).Key;
        }

        /// <summary>
        /// Sets the theme <see cref="ResourceDictionary" /> by specified <paramref name="key" />.
        /// </summary>
        /// <param name="root">
        /// The root <see cref="ResourceDictionary" /> to set theme.
        /// </param>
        /// <param name="key">
        /// The theme key from the <see cref="ThemeDictionaries" />.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="root" /> or <paramref name="key" /> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The theme <paramref name="key" /> not found in the <see cref="ThemeDictionaries" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The theme <see cref="ResourceDictionary" /> is found, but could not be removed.
        /// </exception>
        public static void SetTheme(this ResourceDictionary root, object key)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!ThemeDictionaries.ContainsKey(key))
            {
                throw new ArgumentException($"The given theme key was not defined. Key: '{ key }'.");
            }

            ResourceDictionary actualTheme = root.FindThemeOrNull();

            root.MergedDictionaries.Add(new ResourceDictionary { Source = ThemeDictionaries[key] });

            if (actualTheme != null && !root.MergedDictionaries.Remove(actualTheme))
            {
                throw new InvalidOperationException($"The theme { nameof(ResourceDictionary) } was found, but could not be removed.");
            }
        }


        private static ResourceDictionary FindThemeOrNull(this ResourceDictionary root)
        {
            return root.MergedDictionaries.FirstOrDefault(dict => ThemeDictionaries.Values.Contains(dict.Source));
        }
    }
}
