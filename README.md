
# CoinCollection_WARONGKON

**CoinCollection_WARONGKON** is a simple coin collection game developed in Unity. It utilizes an Object Pooling System for managing coins, includes a game timer, moving platforms, a damage-over-time system, and a danger zone to add challenge for players.

## Features

- **Coin Collection System**: Players can collect coins to increase their score.
- **Object Pooling for Coins**: Uses Object Pooling to respawn coins without Instantiate/Destroy for optimized performance.
- **Game Timer**: A countdown timer shows the remaining time for the game session.
- **Moving Platforms**: Platforms that move back and forth to add challenge in coin collection.
- **Damage Over Time & Invulnerability**: A danger zone that reduces player health over time, with an invulnerability period after taking damage.

## Getting Started

### Prerequisites

- Unity 2022.3.4 or newer
- Git (for cloning the repository)

### Installation

1. Clone this repository from GitHub:
   ```bash
   git clone https://github.com/jkstudio99/CoinCollection_WARONGKON.git
   ```

2. Open Unity Hub and import the project by selecting the cloned folder.

3. Open the project in Unity and make sure there are no errors in the Console.

## How to Play

1. Use arrow keys or W, A, S, D to control player movement.
2. Press Space to jump.
3. Collect coins appearing in the scene to increase your score.
4. Avoid danger zones, which will decrease your health.
5. Try to collect as many coins as possible before time runs out.

## Project Structure

- **Scripts/** - Contains scripts for player movement, coin management, timer, and health management.
  - `Moveball.cs` - Controls player movement and coin collection.
  - `CoinPool.cs` - Manages Object Pooling for coins.
  - `PlayerHealth.cs` - Manages player health when in the Danger Zone.
  - `Timer.cs` - Game timer.
  - `MovingPlatform.cs` - Script for moving platforms.
- **Prefabs/** - Contains prefabs for coins and platforms.
- **Scenes/** - Contains the game scene.

## Dependencies

- **TextMeshPro** - Used for displaying score and timer.
- **ProBuilder** - Used for level design within Unity.

## Customization

- **Coin Pool Size**: Adjust the number of coins in the Object Pool in the `CoinPool` component in the Unity Inspector.
- **Timer Duration**: Adjust the game session duration in the `Timer` script component on the relevant GameObject.
- **Moving Platform Speed**: Adjust the speed of the platforms in the `MovingPlatform` script component.

## Known Issues

- Sometimes coins may respawn in hard-to-reach areas or close to the Danger Zone.
- If the Player stays continuously in the Danger Zone, health might deplete quickly.

## Contributors

- [jkstudio99](https://github.com/jkstudio99) - Project Developer

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT) - feel free to use and modify.
