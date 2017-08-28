using UnityEngine;
using System.Collections;

namespace UI
{

    public class NewInputScript : MonoBehaviour
    {

        public string GetInputStringFromKeyCode(KeyCode code)
        {
            switch(code)
            {
                case KeyCode.Q:
                    return "q";
                case KeyCode.W:
                    return "w";
                case KeyCode.E:
                    return "e";
                case KeyCode.R:
                    return "r";
                case KeyCode.T:
                    return "t";
                case KeyCode.Y:
                    return "y";
                case KeyCode.U:
                    return "u";
                case KeyCode.I:
                    return "i";
                case KeyCode.O:
                    return "o";
                case KeyCode.P:
                    return "p";
                case KeyCode.A:
                    return "a";
                case KeyCode.S:
                    return "s";
                case KeyCode.D:
                    return "d";
                case KeyCode.F:
                    return "f";
                case KeyCode.G:
                    return "g";
                case KeyCode.H:
                    return "h";
                case KeyCode.J:
                    return "j";
                case KeyCode.K:
                    return "k";
                case KeyCode.L:
                    return "l";
                case KeyCode.Z:
                    return "z";
                case KeyCode.X:
                    return "x";
                case KeyCode.C:
                    return "c";
                case KeyCode.V:
                    return "v";
                case KeyCode.B:
                    return "b";
                case KeyCode.N:
                    return "n";
                case KeyCode.M:
                    return "m";
                case KeyCode.Comma:
                    return ",";
                case KeyCode.Slash:
                    return "/";
                case KeyCode.Period:
                    return ".";
                case KeyCode.Alpha0:
                    return "0";
                case KeyCode.Alpha1:
                    return "1";
                case KeyCode.Alpha2:
                    return "2";
                case KeyCode.Alpha3:
                    return "3";
                case KeyCode.Alpha4:
                    return "4";
                case KeyCode.Alpha5:
                    return "5";
                case KeyCode.Alpha6:
                    return "6";
                case KeyCode.Alpha7:
                    return "7";
                case KeyCode.Alpha8:
                    return "8";
                case KeyCode.Alpha9:
                    return "9";
                case KeyCode.Minus:
                    return "-";
                case KeyCode.Equals:
                    return "=";
                case KeyCode.LeftBracket:
                    return "[";
                case KeyCode.RightBracket:
                    return "]";
                case KeyCode.Semicolon:
                    return ";";
                case KeyCode.BackQuote:
                    return "'";
                case KeyCode.Hash:
                    return "#";
                case KeyCode.Tab:
                    return "tab";
                case KeyCode.CapsLock:
                    return "caps lock";
                case KeyCode.LeftShift:
                    return "left shift";
                case KeyCode.LeftControl:
                    return "left ctrl";
                case KeyCode.Backslash:
                    return "\\";
                case KeyCode.RightControl:
                    return "right ctrl";
                case KeyCode.Insert:
                    return "insert";
                case KeyCode.Home:
                    return "home";
                case KeyCode.PageUp:
                    return "page up";
                case KeyCode.Delete:
                    return "delete";
                case KeyCode.Space:
                    return "9";
                case KeyCode.End:
                    return "end";
                case KeyCode.PageDown:
                    return "page down";
                case KeyCode.Numlock:
                    return "numlock";
                case KeyCode.Asterisk:
                    return "*";
                case KeyCode.KeypadMinus:
                    return "-";
                case KeyCode.KeypadPlus:
                    return "+";
                case KeyCode.KeypadEnter:
                    return "return";
                case KeyCode.Keypad0:
                    return "0";
                case KeyCode.Keypad1:
                    return "1";
                case KeyCode.Keypad2:
                    return "2";
                case KeyCode.Keypad3:
                    return "3";
                case KeyCode.Keypad4:
                    return "4";
                case KeyCode.Keypad5:
                    return "5";
                case KeyCode.Keypad6:
                    return "6";
                case KeyCode.Keypad7:
                    return "7";
                case KeyCode.Keypad8:
                    return "8";
                case KeyCode.Keypad9:
                    return "9";
                case KeyCode.UpArrow:
                    return "up";
                case KeyCode.DownArrow:
                    return "down";
                case KeyCode.LeftArrow:
                    return "left";
                case KeyCode.RightArrow:
                    return "right";
                case KeyCode.Escape:
                    return "escape";
                case KeyCode.RightAlt:
                    return "right alt";

                default:
                    Debug.Log("KeyNotRecognised");
                    return null;
            }
        }
    }

}