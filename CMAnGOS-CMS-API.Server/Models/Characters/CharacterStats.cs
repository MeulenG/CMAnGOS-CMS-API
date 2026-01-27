using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMAnGOS_CMS_API.Server.Models.Characters
{
    [Table("character_stats")]
    public class CharacterStats
    {
        [Key]
        [Column("guid")]
        public uint Guid { get; set; }

        [Column("strength")]
        public uint Strength { get; set; }

        [Column("agility")]
        public uint Agility { get; set; }

        [Column("stamina")]
        public uint Stamina { get; set; }

        [Column("intellect")]
        public uint Intellect { get; set; }

        [Column("spirit")]
        public uint Spirit { get; set; }

        [Column("armor")]
        public uint Armor { get; set; }

        [Column("blockPct")]
        public float BlockPct { get; set; }

        [Column("dodgePct")]
        public float DodgePct { get; set; }

        [Column("parryPct")]
        public float ParryPct { get; set; }

        [Column("critPct")]
        public float CritPct { get; set; }

        [Column("rangedCritPct")]
        public float RangedCritPct { get; set; }

        [Column("spellCritPct")]
        public float SpellCritPct { get; set; }

        [Column("attackPower")]
        public uint AttackPower { get; set; }

        [Column("rangedAttackPower")]
        public uint RangedAttackPower { get; set; }

        [Column("spellPower")]
        public uint SpellPower { get; set; }

        [Column("resilience")]
        public uint Resilience { get; set; }
    }
}
