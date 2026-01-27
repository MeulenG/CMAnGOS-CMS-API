import React, { useEffect, useState } from 'react';
import type { CharacterDetail } from '../types/character';
import { RACE_NAMES, CLASS_NAMES } from '../types/character';
import EquipmentSlot from './EquipmentSlot';
import CharacterStatsPanel from './CharacterStatsPanel';

interface CharacterProfileProps {
  characterGuid: number;
  onBack: () => void;
}

const CharacterProfile: React.FC<CharacterProfileProps> = ({ characterGuid, onBack }) => {
  const [character, setCharacter] = useState<CharacterDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCharacter = async () => {
      setLoading(true);
      setError(null);

      try {
        const response = await fetch(`/api/character/${characterGuid}`);
        
        if (!response.ok) {
          if (response.status === 404) {
            throw new Error('Character not found');
          }
          throw new Error('Failed to load character');
        }

        const data = await response.json();
        setCharacter(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
        console.error('Error fetching character:', err);
      } finally {
        setLoading(false);
      }
    };

    fetchCharacter();
  }, [characterGuid]);

  if (loading) {
    return (
      <div className="character-profile">
        <button onClick={onBack} className="back-button">← Back to Search</button>
        <div className="loading">Loading character...</div>
      </div>
    );
  }

  if (error || !character) {
    return (
      <div className="character-profile">
        <button onClick={onBack} className="back-button">← Back to Search</button>
        <div className="error-message">{error || 'Character not found'}</div>
      </div>
    );
  }

  const getEquipmentBySlot = (slot: number) => {
    return character.equipment.find(e => e.slot === slot);
  };

  // Equipment slot layout
  const leftSlots = [0, 2, 4, 8, 9, 10]; // Head, Shoulders, Chest, Wrists, Hands, Finger1
  const rightSlots = [14, 1, 5, 6, 7, 11]; // Back, Neck, Waist, Legs, Feet, Finger2
  const bottomSlots = [12, 13]; // Trinket1, Trinket2
  const weaponSlots = [15, 16, 17]; // Main Hand, Off Hand, Ranged

  return (
    <div className="character-profile">
      <button onClick={onBack} className="back-button">← Back to Search</button>
      
      <div className="character-header">
        <div className="character-portrait">
          <div className="portrait-placeholder">
            {character.name.charAt(0).toUpperCase()}
          </div>
        </div>
        <div className="character-info-header">
          <h2 className="character-name-header">
            {character.name}
            {character.isOnline && <span className="online-badge">Online</span>}
          </h2>
          <div className="character-subtitle">
            Level {character.level} {RACE_NAMES[character.race] || 'Unknown'} {CLASS_NAMES[character.class] || 'Unknown'}
          </div>
          <div className="character-resources">
            <div className="resource-bar health-bar">
              <span>Health: {character.health.toLocaleString()}</span>
            </div>
            <div className="resource-bar mana-bar">
              <span>Mana: {character.mana.toLocaleString()}</span>
            </div>
          </div>
        </div>
      </div>

      <div className="character-content">
        <div className="equipment-section">
          <h3>Equipment</h3>
          <div className="equipment-grid">
            <div className="equipment-column left">
              {leftSlots.map(slot => (
                <EquipmentSlot 
                  key={slot} 
                  slot={slot} 
                  equippedItem={getEquipmentBySlot(slot)} 
                />
              ))}
            </div>
            
            <div className="equipment-center">
              <div className="character-model">
                <div className="model-placeholder">Character Model</div>
              </div>
              <div className="weapon-slots">
                {weaponSlots.map(slot => (
                  <EquipmentSlot 
                    key={slot} 
                    slot={slot} 
                    equippedItem={getEquipmentBySlot(slot)} 
                  />
                ))}
              </div>
            </div>
            
            <div className="equipment-column right">
              {rightSlots.map(slot => (
                <EquipmentSlot 
                  key={slot} 
                  slot={slot} 
                  equippedItem={getEquipmentBySlot(slot)} 
                />
              ))}
            </div>
          </div>
          
          <div className="trinket-slots">
            {bottomSlots.map(slot => (
              <EquipmentSlot 
                key={slot} 
                slot={slot} 
                equippedItem={getEquipmentBySlot(slot)} 
              />
            ))}
          </div>
        </div>

        {character.stats && (
          <CharacterStatsPanel stats={character.stats} />
        )}
      </div>
    </div>
  );
};

export default CharacterProfile;
