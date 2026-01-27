using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMAnGOS_CMS_API.Server.Models.Characters
{
    [Table("characters")]
    public class Character
    {
        [Key]
        [Column("guid")]
        public uint Guid { get; set; }

        [Column("account")]
        public uint Account { get; set; }

        [Column("name")]
        [MaxLength(12)]
        public string Name { get; set; } = string.Empty;

        [Column("race")]
        public byte Race { get; set; }

        [Column("class")]
        public byte Class { get; set; }

        [Column("gender")]
        public byte Gender { get; set; }

        [Column("level")]
        public byte Level { get; set; }

        [Column("xp")]
        public uint Xp { get; set; }

        [Column("money")]
        public uint Money { get; set; }

        [Column("health")]
        public uint Health { get; set; }

        [Column("power1")]
        public uint Power1 { get; set; } // Mana

        [Column("power2")]
        public uint Power2 { get; set; } // Rage

        [Column("power3")]
        public uint Power3 { get; set; } // Focus

        [Column("power4")]
        public uint Power4 { get; set; } // Energy

        [Column("power5")]
        public uint Power5 { get; set; } // Happiness

        [Column("map")]
        public ushort Map { get; set; }

        [Column("position_x")]
        public float PositionX { get; set; }

        [Column("position_y")]
        public float PositionY { get; set; }

        [Column("position_z")]
        public float PositionZ { get; set; }

        [Column("orientation")]
        public float Orientation { get; set; }

        [Column("totaltime")]
        public uint TotalTime { get; set; }

        [Column("leveltime")]
        public uint LevelTime { get; set; }

        [Column("online")]
        public uint Online { get; set; }
    }
}
