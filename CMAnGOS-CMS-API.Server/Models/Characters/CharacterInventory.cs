using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMAnGOS_CMS_API.Server.Models.Characters
{
    [Table("character_inventory")]
    public class CharacterInventory
    {
        [Key]
        [Column("guid")]
        public uint Guid { get; set; }

        [Column("bag")]
        public uint Bag { get; set; }

        [Column("slot")]
        public byte Slot { get; set; }

        [Column("item")]
        public uint Item { get; set; }

        [Column("item_template")]
        public uint ItemTemplate { get; set; }
    }
}
