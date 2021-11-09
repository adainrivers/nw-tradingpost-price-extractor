using System;
using System.Collections.Generic;

namespace TradingPostDataExtractor.NonInvasiveKeyboardHookLibrary
{
    internal class KeybindStructComparer : IEqualityComparer<KeybindStruct>
    {
        public bool Equals(KeybindStruct x, KeybindStruct y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (x == y)
            {
                return true;
            }
            return x.VirtualKeyCode == y.VirtualKeyCode && y.Modifiers.SetEquals(y.Modifiers);
        }

        public int GetHashCode(KeybindStruct obj)
        {
            var hash = obj.VirtualKeyCode;

            foreach (var objModifier in obj.Modifiers)
            {
                hash = HashCode.Combine(objModifier.GetHashCode());
            }
            return hash;
        }
    }
}