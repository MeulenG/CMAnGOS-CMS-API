import React, { useState } from 'react';
import type { EquippedItem } from '../types/character';
import { SLOT_NAMES } from '../types/character';
import ItemTooltip from './ItemTooltip';

interface EquipmentSlotProps {
  slot: number;
  equippedItem?: EquippedItem;
}

const EquipmentSlot: React.FC<EquipmentSlotProps> = ({ slot, equippedItem }) => {
  const [showTooltip, setShowTooltip] = useState(false);

  const slotName = SLOT_NAMES[slot] || `Slot ${slot}`;
  const hasItem = equippedItem?.item !== undefined;

  return (
    <div 
      className={`equipment-slot ${hasItem ? 'has-item' : 'empty'}`}
      onMouseEnter={() => setShowTooltip(true)}
      onMouseLeave={() => setShowTooltip(false)}
    >
      <div className="slot-content">
        {hasItem ? (
          <>
            <div className="item-icon">{equippedItem.item?.name.charAt(0)}</div>
            <div className="slot-label">{slotName}</div>
          </>
        ) : (
          <div className="empty-slot-label">{slotName}</div>
        )}
      </div>
      
      {showTooltip && hasItem && equippedItem.item && (
        <ItemTooltip item={equippedItem.item} />
      )}
    </div>
  );
};

export default EquipmentSlot;
