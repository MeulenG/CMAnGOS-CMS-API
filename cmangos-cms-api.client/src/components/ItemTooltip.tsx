import React from 'react';
import type { Item } from '../types/character';
import { QUALITY_NAMES, QUALITY_COLORS, STAT_NAMES } from '../types/character';

interface ItemTooltipProps {
  item: Item;
}

const ItemTooltip: React.FC<ItemTooltipProps> = ({ item }) => {
  const qualityName = QUALITY_NAMES[item.quality] || 'Common';
  const qualityColor = QUALITY_COLORS[item.quality] || '#ffffff';

  return (
    <div className="item-tooltip">
      <div className="tooltip-header" style={{ color: qualityColor }}>
        {item.name}
      </div>
      
      <div className="tooltip-content">
        <div className="tooltip-row">
          <span className="tooltip-label">Item Level:</span>
          <span className="tooltip-value">{item.itemLevel}</span>
        </div>
        
        {item.requiredLevel > 0 && (
          <div className="tooltip-row">
            <span className="tooltip-label">Requires Level:</span>
            <span className="tooltip-value">{item.requiredLevel}</span>
          </div>
        )}
        
        {item.armor > 0 && (
          <div className="tooltip-row">
            <span className="tooltip-label">Armor:</span>
            <span className="tooltip-value">{item.armor}</span>
          </div>
        )}
        
        {item.dmgMin > 0 && item.dmgMax > 0 && (
          <>
            <div className="tooltip-row">
              <span className="tooltip-label">Damage:</span>
              <span className="tooltip-value">{item.dmgMin.toFixed(0)} - {item.dmgMax.toFixed(0)}</span>
            </div>
            {item.speed > 0 && (
              <div className="tooltip-row">
                <span className="tooltip-label">Speed:</span>
                <span className="tooltip-value">{(item.speed / 1000).toFixed(2)}</span>
              </div>
            )}
          </>
        )}
        
        {item.stats.length > 0 && (
          <div className="tooltip-stats">
            {item.stats.map((stat, index) => (
              <div key={index} className="tooltip-row stat-row">
                <span className="stat-modifier">+{stat.value}</span>
                <span className="stat-name">{STAT_NAMES[stat.type] || `Stat ${stat.type}`}</span>
              </div>
            ))}
          </div>
        )}
        
        {item.description && (
          <div className="tooltip-description">
            <em>"{item.description}"</em>
          </div>
        )}
        
        <div className="tooltip-footer" style={{ color: qualityColor }}>
          {qualityName}
        </div>
      </div>
    </div>
  );
};

export default ItemTooltip;
