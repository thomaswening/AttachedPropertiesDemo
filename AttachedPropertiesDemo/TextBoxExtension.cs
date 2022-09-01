using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AttachedPropertiesDemo
{
    public class TextBoxExtension : TextBox // Create a class that inherits from the control to which you want to attach a property
    {
        // Register an attached dependency property for the control as a backing field
        // The dependency property must be named {identfier}Property.

        public static readonly DependencyProperty WasUsedProperty = DependencyProperty.RegisterAttached(

                "WasUsed",                              // The actual name of the property, i.e. {identifier} above
                typeof(bool),                           // Type of the property
                typeof(TextBoxExtension),               // This must always be the type of this class - not TextBox, for example
                new PropertyMetadata(false)             // You can define a default value here
            );

        // Define a getter and a setter which take the control as a parameter
        public static bool GetWasUsed(TextBox target)
        {
            return (bool)target.GetValue(WasUsedProperty);
        }

        public static void SetWasUsed(TextBox target, bool value)
        {
            target.SetValue(WasUsedProperty, value);
        }
    }
}
