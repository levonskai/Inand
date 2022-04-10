using System.Windows;
using System.Windows.Controls.Primitives;

namespace Inand.Controls
{
    /// <summary>
    /// Represents a switch that can be toggled between two states.
    /// </summary>
    public class ToggleSwitch : ToggleButton
    {
        static ToggleSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwitch), new FrameworkPropertyMetadata(typeof(ToggleSwitch)));
        }
    }
}
