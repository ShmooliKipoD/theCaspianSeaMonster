# The Caspian Sea Monster

A 2D game based on the Soviet ekranoplan concept, featuring physics-based movement with rotation and thrust mechanics.

## Game Overview

The Caspian Sea Monster is a 2D game that simulates the movement and physics of a ground effect vehicle (ekranoplan). The game features:

- Physics-based movement with rotation and thrust mechanics
- Advanced lighting with dynamic shadows using Penumbra
- Entity Component System (ECS) architecture for efficient game object management
- WASD controls for ship movement

## Architecture

The game is built using MonoGame with .NET 8.0 and follows an Entity Component System (ECS) architecture.

### Technology Stack

- **Framework**: MonoGame with .NET 8.0
- **Extensions**: 
  - MonoGame.Extended (for ECS implementation)
  - Penumbra (for advanced lighting and dynamic shadows)
  - Autofac (for dependency injection)
  - SimplexNoise (for procedural generation)

### Project Structure

```
src/
├── BL/                     # Business Logic
│   ├── Background.cs       # Background rendering
│   ├── EntityFactory.cs    # Factory for creating game entities
│   └── GameMain.cs         # Main game loop and initialization
├── Collisions/             # Physics and collision handling
│   └── Body.cs             # Physical body component
├── Content/                # Game assets and content
├── Entities/               # Entity definitions
│   └── Player.cs           # Player entity
├── Interfaces/             # Interface definitions
│   └── Game.cs             # Game interface
├── Systems/                # Game systems
│   ├── PlayerSystem.cs     # Player movement and input handling
│   └── RenderSystem.cs     # Rendering system
└── .vscode/                # VS Code configuration
    └── tasks.json          # Build tasks
```

### Core Components

#### Entity Component System (ECS)

The game uses an ECS architecture where:

- **Entities** are game objects represented by a unique ID
- **Components** are data containers attached to entities (e.g., Body, Sprite, AnimatedSprite)
- **Systems** process entities with specific component combinations

Key components include:

1. **Body**: Handles physics properties
   - Position, velocity, size
   - Static or dynamic body types

2. **Sprite/AnimatedSprite**: Visual representation
   - Handles animations and rendering

#### Systems

1. **PlayerSystem**
   - Processes entities with Body, Sprite, and AnimatedSprite components
   - Handles player input for movement (WASD controls)
   - Manages ship rotation and thrust

2. **RenderSystem**
   - Renders all visible entities to the screen
   - Manages camera positioning and following

#### Lighting

The game features advanced lighting using the Penumbra lighting system:

- Dynamic shadows cast by game objects
- Point lights and spotlights
- Ambient lighting

### Game Mechanics

- **Ship Movement**: Physics-based with rotation and thrust
  - W: Increase thrust
  - S: Decrease thrust
  - A: Rotate left
  - D: Rotate right

- **Camera**: Follows the player entity

## Known Issues

- Animation system bug: There's an issue with the animation system where certain functions are not being called correctly.

## Development

### Building and Running

The project includes VS Code tasks for building and running:

- **build**: Builds the project
- **run**: Runs the game
- **publish**: Publishes the game for distribution
- **clean**: Cleans build artifacts
- **build-mgcb**: Builds MonoGame content

To run these tasks in VS Code, press `Ctrl+Shift+P` (or `Cmd+Shift+P` on Mac) and select "Tasks: Run Task".

## Future Enhancements

- Complete physics implementation
- Enhanced lighting effects
- Additional game mechanics
- Level design and progression
