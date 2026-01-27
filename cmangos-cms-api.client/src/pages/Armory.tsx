import React, { useState } from 'react';
import PageContainer from '../components/PageContainer';
import CharacterSearch from '../components/CharacterSearch';
import CharacterProfile from '../components/CharacterProfile';
import './Armory.css';

const Armory: React.FC = () => {
  const [selectedCharacterGuid, setSelectedCharacterGuid] = useState<number | null>(null);

  const handleCharacterSelect = (guid: number) => {
    setSelectedCharacterGuid(guid);
  };

  const handleBackToSearch = () => {
    setSelectedCharacterGuid(null);
  };

  return (
    <PageContainer>
      <div className="armory-container">
        <h1 className="armory-title">Character Armory</h1>
        <p className="armory-description">
          Search for characters and view their equipment, stats, and more.
        </p>
        
        {selectedCharacterGuid === null ? (
          <CharacterSearch onCharacterSelect={handleCharacterSelect} />
        ) : (
          <CharacterProfile 
            characterGuid={selectedCharacterGuid} 
            onBack={handleBackToSearch}
          />
        )}
      </div>
    </PageContainer>
  );
};

export default Armory;
