using MEC;
using System.Linq;
using Synapse3.SynapseModule.Events;
using Neuron.Core.Events;
using CustomLoadout.Config.Types;
using Synapse3.SynapseModule.Item;
using Synapse3.SynapseModule.Enums;

namespace CustomLoadout
{
    public class PluginEventHandler : Listener
    {
        private readonly CustomLoadout customLoadout;

        public PluginEventHandler(PlayerEvents playerEvents, CustomLoadout plugin)
        {
            playerEvents.SetClass.Subscribe(SetClassEvent);
            customLoadout = plugin;
        }

        private void SetClassEvent(SetClassEvent ev)
        {
            Timing.CallDelayed(0.01f, () =>
            {
                if (customLoadout.Config.RoleInventory.Any((_) => _.RoleID == ev.Player.RoleID))
                {
                    Loadout loadout = customLoadout.Config.RoleInventory.FirstOrDefault((_) => _.RoleID == ev.Player.RoleID);
                    if (loadout is null)
                        return;


                    ushort ammo9 = ev.Player.Inventory.AmmoBox[AmmoType.Ammo9X19];
                    ushort ammo5 = ev.Player.Inventory.AmmoBox[AmmoType.Ammo556X45];
                    ushort ammo7 = ev.Player.Inventory.AmmoBox[AmmoType.Ammo762X39];
                    ushort ammo12 = ev.Player.Inventory.AmmoBox[AmmoType.Ammo12Gauge];
                    ushort ammo44 = ev.Player.Inventory.AmmoBox[AmmoType.Ammo44Cal];
                    if (loadout.AmmoConfig.ReplaceAmmo)
                    {
                        ammo9 = loadout.AmmoConfig.Ammo5;
                        ammo5 = loadout.AmmoConfig.Ammo7;
                        ammo7 = loadout.AmmoConfig.Ammo9;
                        ammo12 = loadout.AmmoConfig.Ammo12;
                        ammo44 = loadout.AmmoConfig.Ammo44;
                    }


                    if (loadout.ReplaceDefault)
                        ev.Player.Inventory.Clear();



                    foreach (ItemChance item in loadout.Items)
                    {
                        if (UnityEngine.Random.Range(0f, 100f) > item.Chance)
                            continue;
                        
                        SynapseItem parsedItem = item.Item.Parse();
                        parsedItem.Scale = new UnityEngine.Vector3(item.Item.XSize, item.Item.YSize, item.Item.ZSize);
                        ev.Player.Inventory.GiveItem(parsedItem);
                        if (parsedItem.ItemCategory == ItemCategory.Firearm)
                        {
                            if (parsedItem.FireArm.Attachments == 0)
                                parsedItem.FireArm.Attachments = ev.Player.GetPreference(parsedItem.ItemType);
                            if (parsedItem.FireArm.Durability == 0)
                                parsedItem.FireArm.Durability = parsedItem.FireArm.DefaultMaxAmmo;
                        }
                    }



                    ev.Player.Inventory.AmmoBox[AmmoType.Ammo9X19] = ammo9;
                    ev.Player.Inventory.AmmoBox[AmmoType.Ammo556X45] = ammo5;
                    ev.Player.Inventory.AmmoBox[AmmoType.Ammo762X39] = ammo7;
                    ev.Player.Inventory.AmmoBox[AmmoType.Ammo12Gauge] = ammo12;
                    ev.Player.Inventory.AmmoBox[AmmoType.Ammo44Cal] = ammo44;
                }
            });
        }
    }
}