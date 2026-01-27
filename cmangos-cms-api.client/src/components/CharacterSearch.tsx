import React, { useState } from 'react';
import type { CharacterSearchResult } from '../types/character';
import { RACE_NAMES, CLASS_NAMES } from '../types/character';

interface CharacterSearchProps {
  onCharacterSelect: (guid: number) => void;
}

const CharacterSearch: React.FC<CharacterSearchProps> = ({ onCharacterSelect }) => {
  const [searchTerm, setSearchTerm] = useState('');
  const [searchResults, setSearchResults] = useState<CharacterSearchResult[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSearch = async () => {
    if (!searchTerm.trim()) {
      setError('Please enter a character name');
      return;
    }

    setLoading(true);
    setError(null);

    try {
      const response = await fetch(`/api/character/search?name=${encodeURIComponent(searchTerm)}`);
      
      if (!response.ok) {
        throw new Error('Failed to search characters');
      }

      const data = await response.json();
      setSearchResults(data);

      if (data.length === 0) {
        setError('No characters found');
      }
    } catch (err) {
      setError('An error occurred while searching. Please try again.');
      console.error('Search error:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleKeyPress = (e: React.KeyboardEvent) => {
    if (e.key === 'Enter') {
      handleSearch();
    }
  };

  return (
    <div className="character-search">
      <div className="search-input-container">
        <input
          type="text"
          placeholder="Enter character name..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          onKeyPress={handleKeyPress}
          className="search-input"
        />
        <button 
          onClick={handleSearch} 
          disabled={loading}
          className="search-button"
        >
          {loading ? 'Searching...' : 'Search'}
        </button>
      </div>

      {error && <div className="error-message">{error}</div>}

      {searchResults.length > 0 && (
        <div className="search-results">
          <h3>Search Results</h3>
          <div className="results-list">
            {searchResults.map((character) => (
              <div
                key={character.guid}
                className="character-result-item"
                onClick={() => onCharacterSelect(character.guid)}
              >
                <div className="character-info">
                  <div className="character-name">
                    {character.name}
                    {character.isOnline && <span className="online-indicator">●</span>}
                  </div>
                  <div className="character-details">
                    Level {character.level} {RACE_NAMES[character.race] || 'Unknown'} {CLASS_NAMES[character.class] || 'Unknown'}
                  </div>
                </div>
                <div className="view-arrow">→</div>
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default CharacterSearch;
