using Neuron.Core.Plugins;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Events;

namespace CustomLoadout
{
    [Plugin(
        Author = "AlmightyLks updated by Bonjemus",
        Description = "Configure roles' inventories.",
        Name = "CustomLoadout",
        Version = "2.0.1",
        Repository = "https://github.com/Bonjemus/CustomLoadout",
        Website = "https://discord.gg/TmYJ9PhrmC"
        )]
    public class CustomLoadout : ReloadablePlugin
    {
        public PluginConfig Config { get; private set; }

        public PluginEventHandler EventHandler { get; private set; }

        public override void EnablePlugin()
        {
            EventHandler = Synapse.GetEventHandler<PluginEventHandler>();
            Logger.Info("CustomLoadout loaded.");
        }
        public override void Reload(ReloadEvent _ = null) => Config = Synapse.Get<PluginConfig>();
    }
}