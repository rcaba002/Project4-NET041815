# Project3
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


