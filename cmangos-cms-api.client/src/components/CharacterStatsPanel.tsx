import React from 'react';
import type { CharacterStats } from '../types/character';

interface CharacterStatsPanelProps {
  stats: CharacterStats;
}

const CharacterStatsPanel: React.FC<CharacterStatsPanelProps> = ({ stats }) => {
  return (
    <div className="character-stats-panel">
      <h3>Character Statistics</h3>
      
      <div className="stats-grid">
        <div className="stat-category">
          <h4>Attributes</h4>
          <div className="stat-item">
            <span className="stat-name">Strength:</span>
            <span className="stat-value">{stats.strength}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Agility:</span>
            <span className="stat-value">{stats.agility}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Stamina:</span>
            <span className="stat-value">{stats.stamina}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Intellect:</span>
            <span className="stat-value">{stats.intellect}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Spirit:</span>
            <span className="stat-value">{stats.spirit}</span>
          </div>
        </div>

        <div className="stat-category">
          <h4>Defense</h4>
          <div className="stat-item">
            <span className="stat-name">Armor:</span>
            <span className="stat-value">{stats.armor}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Dodge:</span>
            <span className="stat-value">{stats.dodgePct.toFixed(2)}%</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Parry:</span>
            <span className="stat-value">{stats.parryPct.toFixed(2)}%</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Block:</span>
            <span className="stat-value">{stats.blockPct.toFixed(2)}%</span>
          </div>
        </div>

        <div className="stat-category">
          <h4>Offense</h4>
          <div className="stat-item">
            <span className="stat-name">Attack Power:</span>
            <span className="stat-value">{stats.attackPower}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Ranged Attack Power:</span>
            <span className="stat-value">{stats.rangedAttackPower}</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Spell Power:</span>
            <span className="stat-value">{stats.spellPower}</span>
          </div>
        </div>

        <div className="stat-category">
          <h4>Critical Strike</h4>
          <div className="stat-item">
            <span className="stat-name">Melee Crit:</span>
            <span className="stat-value">{stats.critPct.toFixed(2)}%</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Ranged Crit:</span>
            <span className="stat-value">{stats.rangedCritPct.toFixed(2)}%</span>
          </div>
          <div className="stat-item">
            <span className="stat-name">Spell Crit:</span>
            <span className="stat-value">{stats.spellCritPct.toFixed(2)}%</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CharacterStatsPanel;
