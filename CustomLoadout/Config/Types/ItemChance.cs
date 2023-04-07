using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Item;

namespace CustomLoadout.Config.Types
{
    public sealed class ItemChance
    {
        public SerializedItem Item { get; set; }
        public float Chance { get; set; }
        public ItemChance()
        {
            Item = new SynapseItem(ItemType.None);
            Chance = 100.0f;
        }
        public ItemChance(SerializedItem item, float chance)
        {
            Item = item;
            Chance = chance;
        }
    }
}