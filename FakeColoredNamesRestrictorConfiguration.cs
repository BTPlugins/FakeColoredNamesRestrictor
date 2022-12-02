using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FakeColoredNamesRestrictor
{
    public class FakeColoredNamesRestrictorConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled { get; set; }
        public string KickMessage { get; set; }
        public bool DebugMode { get; set; }
        public void LoadDefaults()
        {
            Enabled = true;
            KickMessage = "Please Remove <#HexCode> From your name to Re-Join";
            DebugMode = false;
        }
    }
}
