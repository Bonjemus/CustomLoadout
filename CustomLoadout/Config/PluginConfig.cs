using CustomLoadout.Config.Types;
using Neuron.Core.Meta;
using Syml;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomLoadout
{
    [Automatic]
    [DocumentSection("CustomLoadout")]
    public sealed class PluginConfig : IDocumentSection
    {
        [Description("Loadout configuration")]
        public List<Loadout> RoleInventory { get; set; } = new List<Loadout>()
        {
            new Loadout()
        };
    }
}