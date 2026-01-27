using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMAnGOS_CMS_API.Server.Data;
using CMAnGOS_CMS_API.Server.Models.Dto;
using CMAnGOS_CMS_API.Server.Models.Characters;
using CMAnGOS_CMS_API.Server.Models.Mangos;

namespace CMAnGOS_CMS_API.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharactersContext _charactersContext;
        private readonly MangosContext _mangosContext;
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(
            CharactersContext charactersContext,
            MangosContext mangosContext,
            ILogger<CharacterController> logger)
        {
            _charactersContext = charactersContext;
            _mangosContext = mangosContext;
            _logger = logger;
        }

        // GET: api/character/search?name=xxx
        [HttpGet("search")]
        public async Task<IActionResult> SearchCharacters([FromQuery] string name, [FromQuery] int limit = 20)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest(new { message = "Search name cannot be empty" });
                }

                var characters = await _charactersContext.Characters
                    .Where(c => c.Name.Contains(name))
                    .Take(limit)
                    .OrderBy(c => c.Name)
                    .Select(c => new CharacterSearchResultDto
                    {
                        Guid = c.Guid,
                        Name = c.Name,
                        Level = c.Level,
                        Race = c.Race,
                        Class = c.Class,
                        Gender = c.Gender,
                        IsOnline = c.Online > 0
                    })
                    .ToListAsync();

                return Ok(characters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching for characters with name: {Name}", name);
                return StatusCode(500, new { message = "An error occurred while searching for characters" });
            }
        }

        // GET: api/character/{guid}
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetCharacterDetail(uint guid)
        {
            try
            {
                var character = await _charactersContext.Characters
                    .FirstOrDefaultAsync(c => c.Guid == guid);

                if (character == null)
                {
                    return NotFound(new { message = "Character not found" });
                }

                // Get character stats (may not exist for all characters)
                var stats = await _charactersContext.CharacterStats
                    .FirstOrDefaultAsync(cs => cs.Guid == guid);

                // Get equipped items (bag = 0 means equipped items, slots 0-18 are equipment slots)
                var equippedItems = await _charactersContext.CharacterInventories
                    .Where(ci => ci.Guid == guid && ci.Bag == 0 && ci.Slot <= 18)
                    .ToListAsync();

                // Get item templates for equipped items
                var itemTemplateIds = equippedItems.Select(ei => ei.ItemTemplate).Distinct().ToList();
                var itemTemplates = await _mangosContext.ItemTemplates
                    .Where(it => itemTemplateIds.Contains(it.Entry))
                    .ToListAsync();

                var itemTemplateDict = itemTemplates.ToDictionary(it => it.Entry);

                var equipmentList = new List<EquippedItemDto>();
                foreach (var equippedItem in equippedItems)
                {
                    if (itemTemplateDict.TryGetValue(equippedItem.ItemTemplate, out var template))
                    {
                        equipmentList.Add(new EquippedItemDto
                        {
                            Slot = equippedItem.Slot,
                            Item = MapItemTemplateToDto(template)
                        });
                    }
                }

                var characterDetail = new CharacterDetailDto
                {
                    Guid = character.Guid,
                    Name = character.Name,
                    Level = character.Level,
                    Race = character.Race,
                    Class = character.Class,
                    Gender = character.Gender,
                    Health = character.Health,
                    Mana = character.Power1,
                    Money = character.Money,
                    IsOnline = character.Online > 0,
                    Stats = stats != null ? new CharacterStatsDto
                    {
                        Strength = stats.Strength,
                        Agility = stats.Agility,
                        Stamina = stats.Stamina,
                        Intellect = stats.Intellect,
                        Spirit = stats.Spirit,
                        Armor = stats.Armor,
                        BlockPct = stats.BlockPct,
                        DodgePct = stats.DodgePct,
                        ParryPct = stats.ParryPct,
                        CritPct = stats.CritPct,
                        RangedCritPct = stats.RangedCritPct,
                        SpellCritPct = stats.SpellCritPct,
                        AttackPower = stats.AttackPower,
                        RangedAttackPower = stats.RangedAttackPower,
                        SpellPower = stats.SpellPower,
                        Resilience = stats.Resilience
                    } : null,
                    Equipment = equipmentList
                };

                return Ok(characterDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting character detail for guid: {Guid}", guid);
                return StatusCode(500, new { message = "An error occurred while retrieving character details" });
            }
        }

        private ItemDto MapItemTemplateToDto(ItemTemplate template)
        {
            var stats = new List<ItemStatDto>();

            if (template.StatType1 > 0) stats.Add(new ItemStatDto { Type = template.StatType1, Value = template.StatValue1 });
            if (template.StatType2 > 0) stats.Add(new ItemStatDto { Type = template.StatType2, Value = template.StatValue2 });
            if (template.StatType3 > 0) stats.Add(new ItemStatDto { Type = template.StatType3, Value = template.StatValue3 });
            if (template.StatType4 > 0) stats.Add(new ItemStatDto { Type = template.StatType4, Value = template.StatValue4 });
            if (template.StatType5 > 0) stats.Add(new ItemStatDto { Type = template.StatType5, Value = template.StatValue5 });
            if (template.StatType6 > 0) stats.Add(new ItemStatDto { Type = template.StatType6, Value = template.StatValue6 });
            if (template.StatType7 > 0) stats.Add(new ItemStatDto { Type = template.StatType7, Value = template.StatValue7 });
            if (template.StatType8 > 0) stats.Add(new ItemStatDto { Type = template.StatType8, Value = template.StatValue8 });
            if (template.StatType9 > 0) stats.Add(new ItemStatDto { Type = template.StatType9, Value = template.StatValue9 });
            if (template.StatType10 > 0) stats.Add(new ItemStatDto { Type = template.StatType10, Value = template.StatValue10 });

            return new ItemDto
            {
                Entry = template.Entry,
                Name = template.Name,
                Quality = template.Quality,
                ItemLevel = template.ItemLevel,
                RequiredLevel = template.RequiredLevel,
                InventoryType = template.InventoryType,
                Armor = template.Armor,
                Stats = stats,
                DmgMin = template.DmgMin1,
                DmgMax = template.DmgMax1,
                Speed = template.Delay,
                Description = template.Description
            };
        }
    }
}
