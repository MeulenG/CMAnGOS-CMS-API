namespace CMAnGOS_CMS_API.Server.Models.Dto
{
    public class EquippedItemDto
    {
        public byte Slot { get; set; }
        public ItemDto? Item { get; set; }
    }

    public class CharacterDetailDto
    {
        public uint Guid { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte Level { get; set; }
        public byte Race { get; set; }
        public byte Class { get; set; }
        public byte Gender { get; set; }
        public uint Health { get; set; }
        public uint Mana { get; set; }
        public uint Money { get; set; }
        public bool IsOnline { get; set; }
        public CharacterStatsDto? Stats { get; set; }
        public List<EquippedItemDto> Equipment { get; set; } = new List<EquippedItemDto>();
    }
}
