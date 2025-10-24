Carnival Shooting Game – Design Patterns & Controls

Controls:

A / D → Move player left/right

Space → Shoot

S → Save game

L → Load game

Design Patterns Used:

1. object pool pattern

ObjectPool is used to manage bullets.

avoids creating/destroying bullets constantly by reusing inactive bullet objects.

2. observer pattern

ScoreManager notifies ScoreDisplay when the score changes.

ScoreDisplay implements IScoreObserver to update the ui automatically.

3. interface pattern

ISaveable defines SaveData and LoadData methods.

player and other objects could implement this interface to make saving/loading consistent.

4. save/load management

GameManager_SaveLoad + TransformSaver handle saving and loading game state (player, enemies, ships, and score).

GameData and MovableData are used to store the serializable data.

summary:

object pool improves performance, observer keeps ui in sync, interfaces give consistent behavior, and centralized save/load makes it easy to expand later.
