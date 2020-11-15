﻿using MEC;
using Synapse.Api.Events.SynapseEventArguments;
using Synapse.Api.Items;
using System.Linq;

namespace CustomLoadout
{
    internal class PluginEventHandler
    {
        public PluginEventHandler()
            => Synapse.Api.Events.EventHandler.Get.Player.PlayerSetClassEvent += Player_PlayerSetClassEvent;
        private void Player_PlayerSetClassEvent(PlayerSetClassEventArgs ev)
        {
            Timing.CallDelayed(0.01f, () =>
            {
                if (CustomLoadout.Config.RoleInventory.Any((_) => _.RoleID == ev.Player.RoleID))
                {
                    var loadout = CustomLoadout.Config.RoleInventory.FirstOrDefault((_) => _.RoleID == ev.Player.RoleID);
                    if (loadout is null)
                        return;

                    if (loadout.ReplaceDefault)
                        ev.Player.Inventory.Clear();

                    foreach (var item in loadout.Items)
                        ev.Player.Inventory.AddItem(item.Item.Parse());

                }
            });
        }
    }
}
