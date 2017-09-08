using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck(); // This is calling the constructor. 

            Console.WriteLine("Your deck has {0} cards.", deck.Cards.Length);

            Console.WriteLine("Hit Enter to draw a card.");
            Console.ReadLine();

            // Now draw your card:
            var drawnCard = deck.DrawCard();
            Console.WriteLine("You drew the {0}", drawnCard.GetFullName()); 

            Console.ReadLine();
        }
    }

    class Deck
    {
        /// <summary>
        /// These are private things. the private accessor means that only my Deck class
        /// has access to it. If you call deck(dot) something above in the Main program
        /// you won't see these two things in the list. Go ahead, try it... see? I was right. :D
        /// </summary>
        private string[] _suits = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
        private Random _rnd = new Random();

        /// <summary>
        /// This is a constructor. A constructor is a special built in
        /// method that is used to set up your object. This method gets 
        /// called when you do new Deck(); in your program. This is where I
        /// am going to fill my deck
        /// 
        /// This method is not required and you probably won't create one for most of your methods.
        /// If you omit it, then .Net creates one behind the scenes for you.
        /// 
        /// Notice that the constructor does not have a return type... the reason for this
        /// is because it's actually returning your class. So, the name of the method and the return
        /// object type is the same... so they shortened it.
        /// </summary>
        public Deck()
        {
            // First, I have to initialize my array. This is something that is
            // super common to do in a constructor. If you don't initialize your
            // array, you will get a null reference exception. Nobody likes those. :D
            Cards = new Card[52];

            var counter = 0;
            foreach(var suit in _suits)
            {
                for (int i = 0; i < 13; i++)
                {
                    var card = new Card();
                    card.Value = i + 1;
                    card.Suit = suit;
                    Cards[counter] = card;
                    counter++;
                }
            }
        }

        /// <summary>
        /// Here's a normal property. You can totally make an array out of custom classes
        /// Like I did below with my Card class.
        /// See below for a better explanation of properties. :D
        /// </summary>
        public Card[] Cards { get; set; }

        /// <summary>
        /// This is a normal method (normal being NOT a constructor).
        /// Remember a normal method has 5 pieces.
        /// *public* = accessor. Your options are public, private and internal. Public means everybody can
        /// see it. Private means it's only available to the class. See my private items at the top of the class.
        /// Internal is special and you will learn what it is later... 
        /// *Card* = The data type that is being returned.
        /// *DrawCard* = The name of your method. This can be WHATEVER you want it to be. The alternative to this is void.
        /// Unless you have used void here, your method HAS to have a return.
        /// *()* = This is the portal to the body of your method. You can put parameters here to pass data into the method
        /// *{}* = This is the body of your method. This is where you do the work of your method.
        /// </summary>
        /// <returns></returns>
        public Card DrawCard()
        {
            var cardToDraw = _rnd.Next(Cards.Length - 1); // This should be familiar from the dice game
            return Cards[cardToDraw]; // Here's me returning an object of data type that I said I would return.
        }
    }

    /// <summary>
    /// Notice that I don't have a constructor in this class... But above in the deck class, I can
    /// call var card = new Card(); and it doesn't blow up.
    /// </summary>
    class Card
    {
        /// <summary>
        /// Notice this property only has a getter? and it's contrived off of my Value property?
        /// This means it is read only. You can't go: card.Name = "something" in Main. The compiler
        /// will complain terribly.
        /// </summary>
        public string Name
        {
            get
            {
                if (Value == 1)
                {
                    return "Ace";
                }
                else if (Value == 11)
                {
                    return "Jack";
                }
                else if (Value == 12)
                {
                    return "Queen";
                }
                else if (Value == 13)
                {
                    return "King";
                }
                else
                {
                    return Value.ToString();
                }
            }
        }

        /// <summary>
        /// These next two properties have default getters / setters.
        /// This means you can read and write to them.
        /// Properties have 5 pieces too. And some of them are the same as a method...
        /// *public* - accessor. You have the same accessors here as methods do and they mean the same thing.
        /// *string* - this is the data type that the property holds. This can be one of your custom classes too...
        /// *Suit* - This is the name. It can be anything you want that isn't a reserved word.
        /// *get* - This returns the value of the property. It's used when doing something like this: var mystring = card.Suit;
        /// *set* - This puts the value on the right side of the equals into the property. So... card.Suit = "Hearts" 
        /// </summary>
        public string Suit { get; set; }
        public int Value { get; set; }

        // I totally would have made this a property... but since the requirements asked for a method, a method I give
        public string GetFullName() // Notice that I said I would return a string and below i have a return?
        {
            return string.Format("{0} of {1}", Name, Suit);
        }
    }
}
