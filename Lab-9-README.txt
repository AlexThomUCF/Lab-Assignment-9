In our project, we used the Builder Pattern in the EnemyStats class to easily create enemies with different attributes such as health, speed, and score. 
This allowed us to build customized stat objects at runtime without relying on multiple constructors or cluttered initialization code.

We implemented the Observer Pattern in our ScoreManager, where different parts of the game, like the UI, can subscribe to score updates. 
Whenever the score changes, the manager automatically notifies all observers, keeping our code modular and reducing dependencies between systems.


We also incorporated the Object Pooling Pattern to efficiently projectile instances instead of repeatedly instantiating and destroying them.
This approach improved our game’s performance by minimizing memory allocations and reducing runtime lag.