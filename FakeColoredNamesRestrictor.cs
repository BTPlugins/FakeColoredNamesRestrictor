using Rocket.API;
using Rocket.Core.Plugins;
using System;
using Logger = Rocket.Core.Logging.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace FakeColoredNamesRestrictor
{
    public partial class FakeColoredNamesRestrictor : RocketPlugin<FakeColoredNamesRestrictorConfiguration>
    {
        public static FakeColoredNamesRestrictor Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("#############################################", ConsoleColor.Yellow);
            Logger.Log("###              FCNR Loaded              ###", ConsoleColor.Yellow);
            Logger.Log("###   Plugin Created By blazethrower320   ###", ConsoleColor.Yellow);
            Logger.Log("###            Join my Discord:           ###", ConsoleColor.Yellow);
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###", ConsoleColor.Yellow);
            Logger.Log("#############################################", ConsoleColor.Yellow);
            U.Events.OnPlayerConnected += onPlayerConnected;
        }

        private void onPlayerConnected(UnturnedPlayer player)
        {
            if (Instance.Configuration.Instance.Enabled && player.CharacterName.Contains("<#"))
            {
                if (Instance.Configuration.Instance.DebugMode)
                {
                    Logger.Log("Kicked " + player.CharacterName + " for having <#HexCode> in their Username");
                }
                player.Kick(Instance.Configuration.Instance.KickMessage);
            }
        }

        protected override void Unload()
        {
            Logger.Log("FakeColoredNamesRestrictor Unloaded");
            Instance = null;
            U.Events.OnPlayerConnected -= onPlayerConnected;
        }
    }
}
