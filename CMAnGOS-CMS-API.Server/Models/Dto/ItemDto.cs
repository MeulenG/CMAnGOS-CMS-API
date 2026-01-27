namespace CMAnGOS_CMS_API.Server.Models.Dto
{
    public class ItemDto
    {
        public uint Entry { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte Quality { get; set; }
        public ushort ItemLevel { get; set; }
        public byte RequiredLevel { get; set; }
        public byte InventoryType { get; set; }
        public ushort Armor { get; set; }
        public List<ItemStatDto> Stats { get; set; } = new List<ItemStatDto>();
        public float DmgMin { get; set; }
        public float DmgMax { get; set; }
        public ushort Speed { get; set; }
        public string? Description { get; set; }
    }

    public class ItemStatDto
    {
        public byte Type { get; set; }
        public short Value { get; set; }
    }
}
