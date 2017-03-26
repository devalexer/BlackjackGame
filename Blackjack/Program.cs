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

        //Dealer Logic method -> produces dealer's card total

        public static int DealerEvaluation(List<Card> dealtHand, List<Card> gameDeck)
        {
            int count = 0;
            int value = 0;
            while (GetHandTotal(dealtHand) <= 17)
            {
                dealtHand.Add(gameDeck[0]);
                gameDeck.RemoveAt(0);
                Console.WriteLine($"Here is the dealer's new card: {dealtHand[0]}");
                Console.WriteLine($"The total value is {GetHandTotal(dealtHand)}");
                count++;
            }
            return value;
        }

        /////Player Logic method -> produces player's card total

        //public static int PlayerEvaluation(List<Card> dealtHand, List<Card> gameDeck) 
        //{
        //    int value = 0;
        //    
        //}

        //////Player may request another card logic

        public static int PlayerMayAskForNewCard() 
        {
            count = 0;
            int value = 0;
            while (GetHandTotal(dealtHand) <= 21)
            {
                dealtHand.Add(gameDeck[0]);
                gameDeck.RemoveAt(0);

                Console.WriteLine($"Your new card is {dealtHand[0]}.");
                Console.WriteLine($"Your current card total is {GetHandTotal(dealtHand)}.");
                count++;
                }
            return value;
    }

        //Main
        static void Main(string[] args)
        {

            var gameDeck = CreateAndShuffleDeck();
            var playersHand = new List<Card>();
            var dealersHand = new List<Card>();


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

            Console.WriteLine("Do you want another card? Please enter 1 for yes, 2 for no.");
            var playerhit = Convert.ToInt32(Console.ReadLine());

            if (playerhit == 1)
            {
                Console.WriteLine(PlayerMayAskForNewCard(playersHand));
            }
            
            // elseif ({NEWTOTAL} < 21)
            //        Console.WriteLine($"Your current card total is {NEWTOTALFROM METHOD}.");
            //}
            //else
            //{
            //    compares their total to dealer's total and gives winner
            //}


            //reads response. if no, runs dealer method then compares values and produces win/loss response.
            //if yes, produces new card, evaluates based on rules.

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
