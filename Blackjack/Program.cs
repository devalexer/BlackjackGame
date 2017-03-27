using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        //Sort the deck method

        public static List<Card> CreateAndShuffleDeck()
        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }
            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            return randomDeck;
        }

        //Get total value of hand method

        public static int GetHandTotal(List<Card> hand)
        {
            var sum = 0;
            foreach (var card in hand)
            {
            sum += card.GetCardValue();
            }
            return sum;
        }

        //***********TODO: make sure it writes properly so I can call it in main
        //Dealer Logic method -> produces dealer's final card total

        public static int DealerEvaluation(List<Card> dealtHand, List<Card> gameDeck)
        {
            int value = 0;
            while (GetHandTotal(dealtHand) <= 16)
            {
                dealtHand.Add(gameDeck[0]);
                gameDeck.RemoveAt(0);
            }
            return value;
        }


        //////Player may request another card logic
          public static int PlayerAsksForNewCard(List<Card> dealtHand, List<Card> gameDeck)
          {
            int value = 2;

            for (int i = 0; i < 5; i++)
            {
                if (GetHandTotal(dealtHand) < 21)
                {
                    dealtHand.Add(gameDeck[0]);
                    gameDeck.RemoveAt(0);

                    Console.WriteLine($"Your new card is {dealtHand[0]}.");
                    Console.WriteLine($"Your current card total is {GetHandTotal(dealtHand)}.");
                    Console.WriteLine("Do you want another card? Please enter 1 for yes, 2 for no.");
                    var anotherCard = Convert.ToInt32(Console.ReadLine());

                    if (((GetHandTotal(dealtHand) < 21)) && anotherCard == 1)
                    {

                    }
                    else if ((GetHandTotal(dealtHand) == 21))
                    {
                        Console.WriteLine("Congratulations!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry. You went over. You lost.");
                    }
                }
                
            }
            return value;
          }



        //Main
        static void Main(string[] args)
        {

            var gameDeck = CreateAndShuffleDeck();
            var playersHand = new List<Card>();
            var dealersHand = new List<Card>();
            //int dealersFinalValue = DealerEvaluation();


            Console.WriteLine("Let's play BlackJack!");

            //Produces dealer hand
            dealersHand.Add(gameDeck[0]);
            gameDeck.RemoveAt(0);

            dealersHand.Add(gameDeck[0]);
            gameDeck.RemoveAt(0);
            Console.WriteLine($"Here are the dealer's first two cards: {dealersHand[0]} and {dealersHand[1]}");
            Console.WriteLine($"The total value is {GetHandTotal(dealersHand)}");

            //Produces player hand
            playersHand.Add(gameDeck[0]);
            gameDeck.RemoveAt(0);

            playersHand.Add(gameDeck[0]);
            gameDeck.RemoveAt(0);
            Console.WriteLine($"Here are your first two cards: {playersHand [0]} and {playersHand [1]}");
            Console.WriteLine($"The total value is {GetHandTotal(playersHand)}");

            //Asks user if they want another card
            Console.WriteLine("Do you want another card? Please enter 1 for yes, 2 for no.");
            var playerhit = Convert.ToInt32(Console.ReadLine());

            //If player wants another card, runs player card addition & evaluation loop method to produce final player value
            //If player does not want another card, evaluates final values and declares winnner
            if (playerhit == 1)
            {
                PlayerAsksForNewCard(playersHand, gameDeck);
            }
            //else
            //{
            //    if (GetHandTotal(playersHand) <= dealersFinalValue)
            //        Console.WriteLine("Sorry, you lost.");
            //    else
            //        Console.WriteLine("Congratulations, you won.");
            //}








            //Identify if first and second cards equal 21
            //If player's first and second card equal 21 automatic win
            //Otherwise, ask player if they want another card
            //Read input
            //Print another card if requested(up to 5 cards max total)
            //If allowed by dealer rules, deal another card for dealer(up to 5 cards max total)
            //Each time card is dealt, evaluate if total is 21 or above
            //If both dealer and player cards equal 21, output draw
            //If 21, player wins
            //If above, player loses
            //If neither card totals equal 21, higher value wins, lower value loses
        }
    }
}
