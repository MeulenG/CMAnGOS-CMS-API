using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMAnGOS_CMS_API.Server.Models.Mangos
{
    [Table("item_template")]
    public class ItemTemplate
    {
        [Key]
        [Column("entry")]
        public uint Entry { get; set; }

        [Column("class")]
        public byte Class { get; set; }

        [Column("subclass")]
        public byte SubClass { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Column("displayid")]
        public uint DisplayId { get; set; }

        [Column("Quality")]
        public byte Quality { get; set; }

        [Column("Flags")]
        public uint Flags { get; set; }

        [Column("BuyCount")]
        public uint BuyCount { get; set; }

        [Column("BuyPrice")]
        public int BuyPrice { get; set; }

        [Column("SellPrice")]
        public uint SellPrice { get; set; }

        [Column("InventoryType")]
        public byte InventoryType { get; set; }

        [Column("AllowableClass")]
        public int AllowableClass { get; set; }

        [Column("AllowableRace")]
        public int AllowableRace { get; set; }

        [Column("ItemLevel")]
        public ushort ItemLevel { get; set; }

        [Column("RequiredLevel")]
        public byte RequiredLevel { get; set; }

        [Column("RequiredSkill")]
        public ushort RequiredSkill { get; set; }

        [Column("RequiredSkillRank")]
        public ushort RequiredSkillRank { get; set; }

        [Column("maxcount")]
        public uint MaxCount { get; set; }

        [Column("stackable")]
        public uint Stackable { get; set; }

        [Column("ContainerSlots")]
        public byte ContainerSlots { get; set; }

        [Column("stat_type1")]
        public byte StatType1 { get; set; }

        [Column("stat_value1")]
        public short StatValue1 { get; set; }

        [Column("stat_type2")]
        public byte StatType2 { get; set; }

        [Column("stat_value2")]
        public short StatValue2 { get; set; }

        [Column("stat_type3")]
        public byte StatType3 { get; set; }

        [Column("stat_value3")]
        public short StatValue3 { get; set; }

        [Column("stat_type4")]
        public byte StatType4 { get; set; }

        [Column("stat_value4")]
        public short StatValue4 { get; set; }

        [Column("stat_type5")]
        public byte StatType5 { get; set; }

        [Column("stat_value5")]
        public short StatValue5 { get; set; }

        [Column("stat_type6")]
        public byte StatType6 { get; set; }

        [Column("stat_value6")]
        public short StatValue6 { get; set; }

        [Column("stat_type7")]
        public byte StatType7 { get; set; }

        [Column("stat_value7")]
        public short StatValue7 { get; set; }

        [Column("stat_type8")]
        public byte StatType8 { get; set; }

        [Column("stat_value8")]
        public short StatValue8 { get; set; }

        [Column("stat_type9")]
        public byte StatType9 { get; set; }

        [Column("stat_value9")]
        public short StatValue9 { get; set; }

        [Column("stat_type10")]
        public byte StatType10 { get; set; }

        [Column("stat_value10")]
        public short StatValue10 { get; set; }

        [Column("dmg_min1")]
        public float DmgMin1 { get; set; }

        [Column("dmg_max1")]
        public float DmgMax1 { get; set; }

        [Column("dmg_type1")]
        public byte DmgType1 { get; set; }

        [Column("armor")]
        public ushort Armor { get; set; }

        [Column("holy_res")]
        public byte HolyRes { get; set; }

        [Column("fire_res")]
        public byte FireRes { get; set; }

        [Column("nature_res")]
        public byte NatureRes { get; set; }

        [Column("frost_res")]
        public byte FrostRes { get; set; }

        [Column("shadow_res")]
        public byte ShadowRes { get; set; }

        [Column("arcane_res")]
        public byte ArcaneRes { get; set; }

        [Column("delay")]
        public ushort Delay { get; set; }

        [Column("ammo_type")]
        public byte AmmoType { get; set; }

        [Column("bonding")]
        public byte Bonding { get; set; }

        [Column("description")]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Column("block")]
        public uint Block { get; set; }

        [Column("socketColor_1")]
        public byte SocketColor1 { get; set; }

        [Column("socketColor_2")]
        public byte SocketColor2 { get; set; }

        [Column("socketColor_3")]
        public byte SocketColor3 { get; set; }
    }
}
