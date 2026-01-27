namespace CMAnGOS_CMS_API.Server.Models.Dto
{
    public class CharacterSearchResultDto
    {
        public uint Guid { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte Level { get; set; }
        public byte Race { get; set; }
        public byte Class { get; set; }
        public byte Gender { get; set; }
        public bool IsOnline { get; set; }
    }
}
