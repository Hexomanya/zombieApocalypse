# Lend Me a Leg!

![Title Screen](Docs/lendMeALeg_titleImage.png)

**Lend Me a Leg!** is a zombie strategy game built in Unity as part of a university "Game Design" course. The project challenged us to design and execute a complete game concept following a rigorous iterative prototyping workflow, moving from strict design constraints to a fully playable digital prototype.

**The Team:** Antonia, Luca, Jannik, Benjamin

> *Our Pitch: Trade and collect body parts, build a custom zombie horde, and unleash the global apocalypse.*

---

## The Development Journey

The core objective of the course was to experience the full pipeline of game creation, strictly iterating through major design milestones:

1. **Randomized Parameters (The Constraint):** Every team started with randomly assigned parameters to kickstart ideation. Our constraints were:
   * **Challenge:** Full Body
   * **Gameplay Mechanic:** Buy, Sell, Trade
   * **Setting:** Apocalypse
2. **Paper Prototyping:** Before writing a single line of code, we designed and tested the game as a tabletop/paper prototype. This allowed us to iterate rapidly on the core balancing of trading limb stats without getting bogged down by technical execution.
3. **Box & Core System Prototyping:** We then moved into Unity, replacing paper elements with simple box placeholders ("greyboxing"). During this stage, we focused heavily on establishing fundamental systems like the pathfinding framework and the actor state machines.
4. **Final Game Prototype:** Finally, we integrated custom sprites, a drag-and-drop user interface, tooltips, and audio. We refined this iteration using player feedback from targeted playtests to arrive at the current finished vertical slice.

---

## Gameplay

The game loops through two alternating phases:

### 1. The Zombie Editor
Before launching a level, you assemble your undead horde using the body parts you have collected. 
* **Stat Mechanics:** Every individual part (heads, arms, legs, torsos) carries distinct stats: *Damage, Health, Speed, Intelligence, Sight, and Attack Cooldown*.
* **Strategy:** You must constantly make trade-offs between crafting a few elite "super-zombies" or managing a massive, low-intelligence horde.

![Zombie Editor](Docs/lendMeALeg_buildInterface.png)

### 2. Tactical Levels
Deploy your creations into the map to take over human strongholds.
* **Indirect Control:** You only issue a single click-to-move command. How efficiently your zombies interpret and execute that command depends entirely on their constructed *Intelligence* stat.
* **Harvesting Resources:** The goal is to devour all humans on the map. Defeated humans drop new body parts as loot, which you carry back into the editor to fuel your next simulation phase.

![Level Gameplay](Docs/lendMeALeg_levelDesign.png)

---

## Technical Details

* **Engine:** Unity
* **AI & Behavior:** A custom-built **Actor StateMachine** using modular decision trees (*Idle, Follow Command, Search, Engage, Melee*) to dynamically control both human survivors and zombie actors.
* **Pathfinding:** Built using the [A* Pathfinding Project by Aron Granberg](https://arongranberg.com/astar/) to handle tactical navigation across obstacles.
* **UI/UX:** Created a comprehensive UI suite featuring a drag-and-drop zombie assembler, granular stat tooltips, a persistent inventory bar, and a real-time notification/message system for limb pickups.
* **Audio:** High-quality spatial sound effects sourced via [Epidemic Sound](https://www.epidemicsound.com/).

---

## Development Post-Mortem
The core loop works and we stayed close to the original pitch, which we're happy about given the time constraints.
What didn't make it in: turret enemies, a minimap, a dynamic light system, proper animations, and a deeper balance pass. The Actor State Machine also grew more complex than anticipated, and Unity builds caused some friction along the way.