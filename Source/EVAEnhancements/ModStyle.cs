/*
	This file is part of EVA Enhancements /L Unleashed
		© 2023 LisiasT
		© 2016-2023 LinuxGuruGamer
		© 2015 Sean McDougall

	EVA Enhancements /L Unleashed is licensed as follows:
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	EVA Enhancements /L Unleashed is distributed in the hope that it will be useful, but
	WITHOUT ANY WARRANTY; without even the implied warranty ofMERCHANTABILITY
	or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 2.0
	along with EVA Enhancements /L Unleashed . If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EVAEnhancements
{
    public class ModStyle
    {
        public GUISkin skin;
        public Dictionary<string, GUIStyle> guiStyles;
        public int fontSize = 12;
        public int minWidth = 110;
        public int minHeight = 100;

        public ModStyle()
        {
            guiStyles = new Dictionary<string, GUIStyle>();

            skin = GameObject.Instantiate(HighLogic.Skin) as GUISkin;

            skin.button.padding = new RectOffset() { left = 3, right = 3, top = 3, bottom = 3 };
            skin.button.wordWrap = true;
            skin.button.fontSize = fontSize;

            skin.label.padding.top = 0;
            skin.label.fontSize = fontSize;

            skin.toggle.padding.top = 0;
           // skin.toggle.alignment = TextAnchor.UpperLeft;
            skin.toggle.fontSize = fontSize;


            skin.verticalScrollbar.fixedWidth = 10f;

            skin.window.onNormal.textColor = skin.window.normal.textColor = XKCDColors.Green_Yellow;
            skin.window.onHover.textColor = skin.window.hover.textColor = XKCDColors.YellowishOrange;
            skin.window.onFocused.textColor = skin.window.focused.textColor = Color.red;
            skin.window.onActive.textColor = skin.window.active.textColor = Color.blue;
            skin.window.padding.left = skin.window.padding.right = skin.window.padding.bottom = 2;
            skin.window.fontSize = (fontSize + 2);
            skin.window.padding = new RectOffset() { left = 1, top = 5, right = 1, bottom = 1 };

            Texture2D blackBackground = new Texture2D(1, 1);
            blackBackground.SetPixel(0, 0, Color.black);
            blackBackground.Apply();

            guiStyles["titleLabel"] = new GUIStyle();
            guiStyles["titleLabel"].name = "titleLabel";
            guiStyles["titleLabel"].fontSize = fontSize + 3;
            guiStyles["titleLabel"].fontStyle = FontStyle.Bold;
            guiStyles["titleLabel"].alignment = TextAnchor.MiddleCenter;
            guiStyles["titleLabel"].wordWrap = true;
            guiStyles["titleLabel"].normal.textColor = Color.yellow;
            guiStyles["titleLabel"].padding = new RectOffset() { left = 20, right = 20, top = 0, bottom = 0 };

            guiStyles["tooltip"] = new GUIStyle();
            guiStyles["tooltip"].name = "tooltip";
            guiStyles["tooltip"].fontSize = fontSize + 3;
            guiStyles["tooltip"].wordWrap = true;
            guiStyles["tooltip"].alignment = TextAnchor.MiddleCenter;
            guiStyles["tooltip"].normal.textColor = Color.yellow;
            guiStyles["tooltip"].normal.background = blackBackground;

        }

        public Texture2D GetImage(String path, int width, int height)
        {
            Texture2D img = new Texture2D(width, height, TextureFormat.ARGB32, false);
            img = GameDatabase.Instance.GetTexture(path, false);
            return img;
        }

    }
}
