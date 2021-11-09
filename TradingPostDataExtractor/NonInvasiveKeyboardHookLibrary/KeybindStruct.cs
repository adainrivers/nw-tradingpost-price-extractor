using System;
using System.Collections.Generic;

namespace TradingPostDataExtractor.NonInvasiveKeyboardHookLibrary
{
    /// <summary>
    /// A struct to represent a keybind (key + modifiers)
    /// When the keybind struct is compared to another keybind struct, the equality is based on the
    /// modifiers and the virtual key code.
    /// </summary>
    internal class KeybindStruct
    {
        public readonly int VirtualKeyCode;
        public readonly HashSet<ModifierKeys> Modifiers;
        public readonly Guid? Identifier;

        public KeybindStruct(IEnumerable<ModifierKeys> modifiers, int virtualKeyCode, Guid? identifier = null)
        {
            VirtualKeyCode = virtualKeyCode;
            Modifiers = new HashSet<ModifierKeys>(modifiers);
            Identifier = identifier;
        }
    }
}
