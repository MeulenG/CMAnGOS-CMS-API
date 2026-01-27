# CMAnGOS-CMS-API

A modern Content Management System and web interface for CMAnGOS Classic WoW private servers.

## Features

### Account Management
- Create new game accounts
- Account authentication using SRP6 password hashing
- Secure account management

### Character Armory
- **Search for characters** by name with partial match support
- **View detailed character information** including:
  - Basic character info (name, level, race, class, faction)
  - Character statistics (strength, agility, stamina, intellect, spirit, armor, etc.)
  - Complete equipment layout with all gear slots
  - Item tooltips with full item details (stats, quality, item level, damage, armor)
  - Character resources (health and mana)
  - Online status indicator

### Server Management
- Database connection testing
- Multi-expansion support (Classic, TBC, WotLK)
- Automatic expansion detection

## Technology Stack

### Backend
- **Framework**: .NET 8 / ASP.NET Core Web API
- **Database**: MySQL with Entity Framework Core 8
- **ORM**: Pomelo.EntityFrameworkCore.MySql
- **API Documentation**: Swagger/OpenAPI

### Frontend
- **Framework**: React 19
- **Language**: TypeScript 5.9
- **Build Tool**: Vite 7
- **Routing**: React Router 7
- **Styling**: CSS Modules

## Getting Started

### Prerequisites
- .NET 8 SDK
- Node.js 20+ and npm
- MySQL 8.0+
- CMAnGOS database (realmd, characters, and mangos databases)

### Configuration

1. Update `appsettings.json` with your database connection strings:

```json
{
  "ConnectionStrings": {
    "RealmdDatabase": "Server=localhost;Database={prefix}realmd;User=root;Password=yourpassword;",
    "CharactersDatabase": "Server=localhost;Database={prefix}characters;User=root;Password=yourpassword;",
    "MangosDatabase": "Server=localhost;Database={prefix}mangos;User=root;Password=yourpassword;"
  }
}
```

The `{prefix}` placeholder will be automatically replaced based on expansion detection (e.g., `classic_`, `bc_`, `wrath_`).

### Running the Application

#### Development Mode

```bash
# Build and run the entire solution (backend + frontend)
dotnet run --project CMAnGOS-CMS-API.Server
```

The application will be available at:
- Backend API: `https://localhost:7258`
- Frontend: `https://localhost:61091`

#### Backend Only

```bash
cd CMAnGOS-CMS-API.Server
dotnet run
```

#### Frontend Only

```bash
cd cmangos-cms-api.client
npm install
npm run dev
```

### Building for Production

```bash
# Build backend
cd CMAnGOS-CMS-API.Server
dotnet build -c Release

# Build frontend
cd ../cmangos-cms-api.client
npm run build
```

## API Endpoints

### Account Management
- `GET /api/account` - Get list of accounts (paginated)
- `GET /api/account/{id}` - Get account by ID
- `POST /api/account/create` - Create new account
- `PUT /api/account/{id}` - Change account password
- `DELETE /api/account/{id}` - Delete account

### Character Armory
- `GET /api/character/search?name={name}&limit={limit}` - Search for characters by name
- `GET /api/character/{guid}` - Get detailed character information

### Database
- `GET /api/database/status` - Get database statistics
- `GET /api/database/test-connection` - Test database connectivity

## Database Schema

The application connects to three CMAnGOS databases:

### Realmd Database
- `account` - User accounts with SRP6 authentication

### Characters Database
- `characters` - Character data (name, level, race, class, position, etc.)
- `character_inventory` - Character equipment and inventory
- `character_stats` - Character statistics

### Mangos Database
- `item_template` - Item definitions and properties

## Architecture

### Backend Structure
```
CMAnGOS-CMS-API.Server/
├── Controllers/          # API endpoints
├── Data/                 # Entity Framework DbContexts
├── Models/
│   ├── Characters/       # Character entity models
│   ├── Mangos/          # World database models
│   ├── Realmd/          # Account/realm models
│   └── Dto/             # Data transfer objects
├── Services/            # Business logic
└── Helpers/             # Utility functions
```

### Frontend Structure
```
cmangos-cms-api.client/
├── src/
│   ├── components/      # Reusable React components
│   ├── pages/           # Page components
│   ├── types/           # TypeScript type definitions
│   └── assets/          # Static assets
```

## Contributing

Contributions are welcome! Please ensure:
- Code follows existing patterns and conventions
- TypeScript types are properly defined
- Backend changes include proper error handling
- Frontend components are responsive
- Tests pass (if applicable)

## License

This project is open source and available under the MIT License.

## Acknowledgments

- Built for CMAnGOS (Classic Massive Network Game Object Server)
- Based on the original World of Warcraft game mechanics