export interface CharacterSearchResult {
  guid: number;
  name: string;
  level: number;
  race: number;
  class: number;
  gender: number;
  isOnline: boolean;
}

export interface ItemStat {
  type: number;
  value: number;
}

export interface Item {
  entry: number;
  name: string;
  quality: number;
  itemLevel: number;
  requiredLevel: number;
  inventoryType: number;
  armor: number;
  stats: ItemStat[];
  dmgMin: number;
  dmgMax: number;
  speed: number;
  description?: string;
}

export interface EquippedItem {
  slot: number;
  item?: Item;
}

export interface CharacterStats {
  strength: number;
  agility: number;
  stamina: number;
  intellect: number;
  spirit: number;
  armor: number;
  blockPct: number;
  dodgePct: number;
  parryPct: number;
  critPct: number;
  rangedCritPct: number;
  spellCritPct: number;
  attackPower: number;
  rangedAttackPower: number;
  spellPower: number;
  resilience: number;
}

export interface CharacterDetail {
  guid: number;
  name: string;
  level: number;
  race: number;
  class: number;
  gender: number;
  health: number;
  mana: number;
  money: number;
  isOnline: boolean;
  stats?: CharacterStats;
  equipment: EquippedItem[];
}

// Helper constants
export const RACE_NAMES: Record<number, string> = {
  1: 'Human',
  2: 'Orc',
  3: 'Dwarf',
  4: 'Night Elf',
  5: 'Undead',
  6: 'Tauren',
  7: 'Gnome',
  8: 'Troll'
};

export const CLASS_NAMES: Record<number, string> = {
  1: 'Warrior',
  2: 'Paladin',
  3: 'Hunter',
  4: 'Rogue',
  5: 'Priest',
  6: 'Death Knight',
  7: 'Shaman',
  8: 'Mage',
  9: 'Warlock',
  11: 'Druid'
};

export const QUALITY_NAMES: Record<number, string> = {
  0: 'Poor',
  1: 'Common',
  2: 'Uncommon',
  3: 'Rare',
  4: 'Epic',
  5: 'Legendary',
  6: 'Artifact'
};

export const QUALITY_COLORS: Record<number, string> = {
  0: '#9d9d9d',
  1: '#ffffff',
  2: '#1eff00',
  3: '#0070dd',
  4: '#a335ee',
  5: '#ff8000',
  6: '#e6cc80'
};

export const SLOT_NAMES: Record<number, string> = {
  0: 'Head',
  1: 'Neck',
  2: 'Shoulders',
  3: 'Shirt',
  4: 'Chest',
  5: 'Waist',
  6: 'Legs',
  7: 'Feet',
  8: 'Wrists',
  9: 'Hands',
  10: 'Finger 1',
  11: 'Finger 2',
  12: 'Trinket 1',
  13: 'Trinket 2',
  14: 'Back',
  15: 'Main Hand',
  16: 'Off Hand',
  17: 'Ranged',
  18: 'Tabard'
};

export const STAT_NAMES: Record<number, string> = {
  0: 'Mana',
  1: 'Health',
  3: 'Agility',
  4: 'Strength',
  5: 'Intellect',
  6: 'Spirit',
  7: 'Stamina',
  12: 'Defense Rating',
  13: 'Dodge Rating',
  14: 'Parry Rating',
  15: 'Block Rating',
  16: 'Hit Melee Rating',
  17: 'Hit Ranged Rating',
  18: 'Hit Spell Rating',
  19: 'Crit Melee Rating',
  20: 'Crit Ranged Rating',
  21: 'Crit Spell Rating',
  28: 'Haste Melee Rating',
  29: 'Haste Ranged Rating',
  30: 'Haste Spell Rating',
  31: 'Hit Rating',
  32: 'Crit Rating',
  36: 'Haste Rating',
  37: 'Expertise Rating',
  38: 'Attack Power',
  39: 'Ranged Attack Power',
  45: 'Spell Power',
  47: 'Spell Penetration'
};
