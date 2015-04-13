# Project3
## Part 1

---------------

In poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:

+ **High Card**: Highest value card.
+ **One Pair**: Two cards of the same value.
+ **Two Pairs**: Two different pairs.
+ **Three-of-a-kind**: Three cards of the same value.
+ **Straight**: All cards are consecutive values.
+ **Flush**: All cards of the same suit.
+ **Full House**: Three of a kind and a pair.
+ **Four-of-a-kind**: Four cards of the same value.
+ **Straight Flush**: A straight of the same suit.
+ **Royal Flush**: A straight flush made up of all face-cards (T,J,Q,K,A).

The cards are valued in the order:
2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.

If two players have the same ranked hands then the rank made up of the highest value wins; for example, a pair of eights beats a pair of fives (see example 1 below). But if two ranks tie, for example, both players have a pair of queens, then highest cards in each hand are compared (see example 4 below); if the highest cards tie then the next highest cards are compared, and so on.

As an example, consider the five hands dealt to two players in the file `pokerhands.png` in the `resources` directory:


![poker hands](https://raw.githubusercontent.com/Claim-Academy/Project1-Java022815/master/src/resources/pokerhands.png)


**Part 1:** Start by hard-coding valid hands for three players into your project solution and evaluating hand winners from each set of hands. Make sure that there are no duplicate card types or invalid hands between the three players.

**Part 2:** Implement a means of generating random hands (that are still valid) for three players. You should be able to repeat hand-generation after prompting from user input. 

-----------------------

##Part 2

---------------------

Now's your chance to expand your poker hands solution into a full-fledged application. Your mission for this part of the project is to create a text-based Poker application that generates hands for all players, allows you to place a round of bets, and keeps track of your winnings over the course of the game.

We've also learned a lot about user stories and application testing. To make sure that the application that you've built is robust enough for production deployment, you'll also build a test suite for your poker application.

As usual, these problems will not be formally graded, but you might be asked to share your solutions with the class. Any time on Saturday not spend working through this problem in workshop format will be spent presenting solutions to the class.

**Save your project files under a new directory called `FirstnameLastname` (using your first and last name, obviously).**


-------------

#### When a player begins the program, they should be able to interact with a text-based menu of options.

The options should include:

- Start Poker game
- Exit program

The customer should be able to select any of these options.

-------------

#### A player should be able to choose game parameters before a game starts.

The application should default to a five-card draw format with "antes" instead of blinds (if you aren't sure what that means, don't worry about it just yet). This means that players are dealt 5 cards all at once, followed by a round of betting, followed by revealing the hands dealt to players and awarding the total amount bet by players to the winning hand. When a player decides to start a new game, the following options need to be specified:

- Player Name (for human player)
- Number of Players (int value > 2, but < 5)
- Ante size in $ (Takes any int value > 0)
- Wallet size in $ (Takes any int value > ante*3 ... this way, we know that we'll have enough money for at least three rounds of antes!)

"Player Name" will be the name displayed for the human player.
"Number of Players" will define the number of computer-generated players for each game, including the human player inputting values through the console.
"Ante size" will define the value of the ante that must be paid before each round. The ante is a forced bet made by every player before cards are dealt. This encourages participation in hands and ensures that every game eventually has an end-point, even if players fold (or quit) every hand without participating in the round of betting.
"Wallet size" will define the total amount of cash that players have at any moment. This value will change every hand, as antes are deducted before hands are dealt, and winnings or losses are added to or subtracted from the wallet after every betting round.

-------------

#### After players input all parameters, the game should begin.

Each game should follow the same process. Games will progress as follows:

1. **Player names should be displayed with current wallet values next to each player.** Player name is input for the human player, and either pre-defined or application-generated for the computer players.
2. **A "dealer" is assigned.** Each round of betting will start with a different player each hand, and will cycle through players as if they were all sitting at the same table. There should be some kind of visual indication which player is the "dealer" at the beginning of each round.
3. **All players will pay the "ante" value into the "pot" before any cards are dealt.** New player wallet values should be displayed, as should pot size.
4. **Hands will be dealt.** The human player will have their hand displayed on the screen, while the computer players' hands will remain hidden.
5. **Display the winner**
6. **Ask users if they want to continue to play**
7. **Check Ante money balance for each player and then continue else display error message to eliminate player who do not have enough Ante money.**
8. **Continue steps 5 to 7 until no one has left Ante money except for one player.**

-------------

#### End the game and repeat.

After a game has completed, make sure that you return the user to the first menu, prompting the user to restart the game with new parameters or exit.


-------------

#### Unit Testing

Now that you've built your application, it's up time to test the project using scripts. Your test suite must include the following:

1. **Create a folder named `FirstnameLastname` (with your First Name and Last Name, of course), in the `com.junit` directory.**
2. **A Setup Method for adding a player name.**
3. **A test script for each method and class.**
4. **A generalized test suite for running all test cases together.**

Be sure that you've followed unit testing naming conventions throughout!

**Save your test files for your test suite in your `FirstnameLastname` folder in the `com.test` directory. Please label the file as `testsuite`.**


