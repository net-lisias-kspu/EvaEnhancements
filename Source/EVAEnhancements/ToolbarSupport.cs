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
using UnityEngine;
using KSP.UI.Screens;

using KSPe.Annotations;
using Toolbar = KSPe.UI.Toolbar;
using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

namespace EVAEnhancements
{
	[KSPAddon(KSPAddon.Startup.MainMenu, true)]
	public class ToolbarController : MonoBehaviour
	{
		internal interface Events
		{
			bool IsWindowVisible { get; }
			void ShowWindow();
			void HideWindow();
		}

		private static ToolbarController INSTANCE = null;
		internal static ToolbarController Instance => INSTANCE;
		private Toolbar.Toolbar Controller => Toolbar.Controller.Instance.Get<ToolbarController>();

		[UsedImplicitly]
		private void Awake() => INSTANCE = this;

		[UsedImplicitly]
		private void Start()
		{
			Toolbar.Controller.Instance.Register<ToolbarController>(Version.FriendlyName);
		}

		private Toolbar.Button button = null;
		private Events handler;
		internal void addLauncherButtons(Events handler)
		{
			this.handler = handler;
			if (null == this.button)
			{
				this.button = Toolbar.Button.Create(this
						, ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.MAPVIEW
						, UI.icon.button.stockToolbar
						, UI.icon.button.blizzyToolbar
					);
				;

				button.Toolbar
					.Add(Toolbar.Button.ToolbarEvents.Kind.Active,
						new Toolbar.Button.Event(this.handler.ShowWindow, this.handler.HideWindow)
					);
				;

				this.Controller.Add(button);
			}
		}

		internal void removeLauncherButtons()
		{
			if (null != this.button)
			{
				this.Controller.Destroy();
				this.button = null;
			}
		}

		internal void toggleWindow()
		{
			if (this.handler.IsWindowVisible)	this.handler.HideWindow();
			else								this.handler.ShowWindow();
		}
	}
}
