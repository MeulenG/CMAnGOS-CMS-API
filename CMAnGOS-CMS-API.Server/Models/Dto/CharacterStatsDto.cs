namespace CMAnGOS_CMS_API.Server.Models.Dto
{
    public class CharacterStatsDto
    {
        public uint Strength { get; set; }
        public uint Agility { get; set; }
        public uint Stamina { get; set; }
        public uint Intellect { get; set; }
        public uint Spirit { get; set; }
        public uint Armor { get; set; }
        public float BlockPct { get; set; }
        public float DodgePct { get; set; }
        public float ParryPct { get; set; }
        public float CritPct { get; set; }
        public float RangedCritPct { get; set; }
        public float SpellCritPct { get; set; }
        public uint AttackPower { get; set; }
        public uint RangedAttackPower { get; set; }
        public uint SpellPower { get; set; }
        public uint Resilience { get; set; }
    }
}
