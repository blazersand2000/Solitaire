using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CardFaces : MonoBehaviour
{
   [SerializeField] private Sprite aceOfHearts;
   [SerializeField] private Sprite twoOfHearts;
   [SerializeField] private Sprite threeOfHearts;
   [SerializeField] private Sprite fourOfHearts;
   [SerializeField] private Sprite fiveOfHearts;
   [SerializeField] private Sprite sixOfHearts;
   [SerializeField] private Sprite sevenOfHearts;
   [SerializeField] private Sprite eightOfHearts;
   [SerializeField] private Sprite nineOfHearts;
   [SerializeField] private Sprite tenOfHearts;
   [SerializeField] private Sprite jackOfHearts;
   [SerializeField] private Sprite queenOfHearts;
   [SerializeField] private Sprite kingOfHearts;

   [SerializeField] private Sprite aceOfDiamonds;
   [SerializeField] private Sprite twoOfDiamonds;
   [SerializeField] private Sprite threeOfDiamonds;
   [SerializeField] private Sprite fourOfDiamonds;
   [SerializeField] private Sprite fiveOfDiamonds;
   [SerializeField] private Sprite sixOfDiamonds;
   [SerializeField] private Sprite sevenOfDiamonds;
   [SerializeField] private Sprite eightOfDiamonds;
   [SerializeField] private Sprite nineOfDiamonds;
   [SerializeField] private Sprite tenOfDiamonds;
   [SerializeField] private Sprite jackOfDiamonds;
   [SerializeField] private Sprite queenOfDiamonds;
   [SerializeField] private Sprite kingOfDiamonds;

   [SerializeField] private Sprite aceOfClubs;
   [SerializeField] private Sprite twoOfClubs;
   [SerializeField] private Sprite threeOfClubs;
   [SerializeField] private Sprite fourOfClubs;
   [SerializeField] private Sprite fiveOfClubs;
   [SerializeField] private Sprite sixOfClubs;
   [SerializeField] private Sprite sevenOfClubs;
   [SerializeField] private Sprite eightOfClubs;
   [SerializeField] private Sprite nineOfClubs;
   [SerializeField] private Sprite tenOfClubs;
   [SerializeField] private Sprite jackOfClubs;
   [SerializeField] private Sprite queenOfClubs;
   [SerializeField] private Sprite kingOfClubs;

   [SerializeField] private Sprite aceOfSpades;
   [SerializeField] private Sprite twoOfSpades;
   [SerializeField] private Sprite threeOfSpades;
   [SerializeField] private Sprite fourOfSpades;
   [SerializeField] private Sprite fiveOfSpades;
   [SerializeField] private Sprite sixOfSpades;
   [SerializeField] private Sprite sevenOfSpades;
   [SerializeField] private Sprite eightOfSpades;
   [SerializeField] private Sprite nineOfSpades;
   [SerializeField] private Sprite tenOfSpades;
   [SerializeField] private Sprite jackOfSpades;
   [SerializeField] private Sprite queenOfSpades;
   [SerializeField] private Sprite kingOfSpades;

   // Start is called before the first frame update
   void Start()
   {
      //SerializedDictionary
   }

   // Update is called once per frame
   void Update()
   {

   }

   public Sprite GetSpriteForFace(string face)
   {
      var card = CardFromString(face);
      return GetSpriteForFace(card.rank, card.suit);
   }

   public Sprite GetSpriteForFace(Rank rank, Suit suit)
   {
      Sprite sprite = null;

      switch (suit)
      {
         case Suit.Heart:
            switch (rank)
            {
               case Rank.Ace:
                  sprite = aceOfHearts;
                  break;
               case Rank.Two:
                  sprite = twoOfHearts;
                  break;
               case Rank.Three:
                  sprite = threeOfHearts;
                  break;
               case Rank.Four:
                  sprite = fourOfHearts;
                  break;
               case Rank.Five:
                  sprite = fiveOfHearts;
                  break;
               case Rank.Six:
                  sprite = sixOfHearts;
                  break;
               case Rank.Seven:
                  sprite = sevenOfHearts;
                  break;
               case Rank.Eight:
                  sprite = eightOfHearts;
                  break;
               case Rank.Nine:
                  sprite = nineOfHearts;
                  break;
               case Rank.Ten:
                  sprite = tenOfHearts;
                  break;
               case Rank.Jack:
                  sprite = jackOfHearts;
                  break;
               case Rank.Queen:
                  sprite = queenOfHearts;
                  break;
               case Rank.King:
                  sprite = kingOfHearts;
                  break;
            }
            break;
         case Suit.Diamond:
            switch (rank)
            {
               case Rank.Ace:
                  sprite = aceOfDiamonds;
                  break;
               case Rank.Two:
                  sprite = twoOfDiamonds;
                  break;
               case Rank.Three:
                  sprite = threeOfDiamonds;
                  break;
               case Rank.Four:
                  sprite = fourOfDiamonds;
                  break;
               case Rank.Five:
                  sprite = fiveOfDiamonds;
                  break;
               case Rank.Six:
                  sprite = sixOfDiamonds;
                  break;
               case Rank.Seven:
                  sprite = sevenOfDiamonds;
                  break;
               case Rank.Eight:
                  sprite = eightOfDiamonds;
                  break;
               case Rank.Nine:
                  sprite = nineOfDiamonds;
                  break;
               case Rank.Ten:
                  sprite = tenOfDiamonds;
                  break;
               case Rank.Jack:
                  sprite = jackOfDiamonds;
                  break;
               case Rank.Queen:
                  sprite = queenOfDiamonds;
                  break;
               case Rank.King:
                  sprite = kingOfDiamonds;
                  break;
            }
            break;
         case Suit.Club:
            switch (rank)
            {
               case Rank.Ace:
                  sprite = aceOfClubs;
                  break;
               case Rank.Two:
                  sprite = twoOfClubs;
                  break;
               case Rank.Three:
                  sprite = threeOfClubs;
                  break;
               case Rank.Four:
                  sprite = fourOfClubs;
                  break;
               case Rank.Five:
                  sprite = fiveOfClubs;
                  break;
               case Rank.Six:
                  sprite = sixOfClubs;
                  break;
               case Rank.Seven:
                  sprite = sevenOfClubs;
                  break;
               case Rank.Eight:
                  sprite = eightOfClubs;
                  break;
               case Rank.Nine:
                  sprite = nineOfClubs;
                  break;
               case Rank.Ten:
                  sprite = tenOfClubs;
                  break;
               case Rank.Jack:
                  sprite = jackOfClubs;
                  break;
               case Rank.Queen:
                  sprite = queenOfClubs;
                  break;
               case Rank.King:
                  sprite = kingOfClubs;
                  break;
            }
            break;
         case Suit.Spade:
            switch (rank)
            {
               case Rank.Ace:
                  sprite = aceOfSpades;
                  break;
               case Rank.Two:
                  sprite = twoOfSpades;
                  break;
               case Rank.Three:
                  sprite = threeOfSpades;
                  break;
               case Rank.Four:
                  sprite = fourOfSpades;
                  break;
               case Rank.Five:
                  sprite = fiveOfSpades;
                  break;
               case Rank.Six:
                  sprite = sixOfSpades;
                  break;
               case Rank.Seven:
                  sprite = sevenOfSpades;
                  break;
               case Rank.Eight:
                  sprite = eightOfSpades;
                  break;
               case Rank.Nine:
                  sprite = nineOfSpades;
                  break;
               case Rank.Ten:
                  sprite = tenOfSpades;
                  break;
               case Rank.Jack:
                  sprite = jackOfSpades;
                  break;
               case Rank.Queen:
                  sprite = queenOfSpades;
                  break;
               case Rank.King:
                  sprite = kingOfSpades;
                  break;
            }
            break;
         default:
            break;
      }

      if (sprite == null)
      {
         throw new UnmappedSpriteException($"Sprite not assigned for {rank} of {suit}.");
      }

      return sprite;
   }

   public static (Rank rank, Suit suit) CardFromString(string card)
   {
      Rank rank;
      var suit = card[^1] switch
      {
         'H' or 'h' => Suit.Heart,
         'D' or 'd' => Suit.Diamond,
         'C' or 'c' => Suit.Club,
         'S' or 's' => Suit.Spade,
         _ => throw new ArgumentException($"Cannot determine suit for card '{card}'."),
      };
      ;

      var rankString = card.Substring(0, card.Length - 1);
      switch (rankString)
      {
         case "A" or "a":
            rank = Rank.Ace;
            break;
         case "J" or "j":
            rank = Rank.Jack;
            break;
         case "Q" or "q":
            rank = Rank.Queen;
            break;
         case "K" or "k":
            rank = Rank.King;
            break;
         default:
            if (int.TryParse(rankString, out int rankInt) && Enum.IsDefined(typeof(Rank), rankInt))
            {
               rank = (Rank)rankInt;
               break;
            }
            else
            {
               throw new ArgumentException($"Cannot determine rank for card '{card}'.");
            }
      }

      return (rank, suit);
   }
}

public enum Suit
{
   Heart,
   Diamond,
   Club,
   Spade
}

public enum Rank
{
   Ace = 1,
   Two = 2,
   Three = 3,
   Four = 4,
   Five = 5,
   Six = 6,
   Seven = 7,
   Eight = 8,
   Nine = 9,
   Ten = 10,
   Jack = 11,
   Queen = 12,
   King = 13
}

public enum SuitColor
{
   Red,
   Black
}

public static class CardExtensions
{
   public static SuitColor Color(this Suit suit)
   {
      if (suit == Suit.Heart || suit == Suit.Diamond)
      {
         return SuitColor.Red;
      }
      return SuitColor.Black;
   }
}

public class UnmappedSpriteException : Exception
{
   public UnmappedSpriteException() : base() { }
   public UnmappedSpriteException(string message) : base(message) { }
   public UnmappedSpriteException(string message, Exception innerException) : base(message, innerException) { }
}

