using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Solitaire : MonoBehaviour
{
   private const float BOTTOM_CARD_OFFSET = 0.54f;
   private const float Z_OFFSET = 0.03f;
   public GameObject cardPrefab;
   public GameObject[] bottomPositions;
   public GameObject[] topPositions;
   public GameObject[] dealtPositions;
   private Queue<GameObject> deck = new Queue<GameObject>();
   private Queue<GameObject> discard = new Queue<GameObject>();

   // Start is called before the first frame update
   void Start()
   {
      InitializeGame();
   }

   // Update is called once per frame
   void Update()
   {

   }

   private void InitializeGame()
   {
      var unshuffledCards = new List<(Rank rank, Suit suit)>();
      foreach (var rank in Enum.GetValues(typeof(Rank)))
      {
         foreach (var suit in Enum.GetValues(typeof(Suit)))
         {
            unshuffledCards.Add(((Rank rank, Suit suit))(rank, suit));
         }
      }
      var cards = new Stack<(Rank rank, Suit suit)>(unshuffledCards.Randomized());

      float yOffset;
      float zOffset;
      GameObject pile;
      for (int i = 0; i < bottomPositions.Length; i++)
      {
         yOffset = 0f;
         zOffset = Z_OFFSET;
         pile = bottomPositions[i];
         for (int j = 0; j < i + 1; j++)
         {
            var (rank, suit) = cards.Pop();
            var newCardObject = Instantiate(cardPrefab, new Vector3(pile.transform.position.x, pile.transform.position.y - yOffset, pile.transform.position.z - zOffset), Quaternion.identity, pile.transform);
            newCardObject.name = $"{rank}{suit}";
            newCardObject.tag = "Card";
            var newCardScript = newCardObject.GetComponent<Card>();
            newCardScript.rank = rank;
            newCardScript.suit = suit;
            newCardScript.isFaceUp = j == i;

            yOffset += BOTTOM_CARD_OFFSET;
            zOffset += Z_OFFSET;
         }
      }

      while (cards.Any())
      {
         var (rank, suit) = cards.Pop();
         var newCardObject = Instantiate(cardPrefab, transform.position, Quaternion.identity);
         newCardObject.name = $"{rank}{suit}";
         var newCardScript = newCardObject.GetComponent<Card>();
         newCardScript.rank = rank;
         newCardScript.suit = suit;
         newCardScript.isFaceUp = true;
         newCardObject.transform.localScale = Vector3.one;
         newCardObject.SetActive(false);
         deck.Enqueue(newCardObject);
      }
   }

   public void DealCards()
   {
      if (dealtPositions.Any(p => p.transform.childCount > 0))
      {
         foreach (var dealtPosition in dealtPositions.Reverse())
         {
            if (dealtPosition.transform.childCount > 0)
            {
               var dealtCard = dealtPosition.transform.GetChild(0).gameObject;
               dealtCard.transform.parent = null;
               dealtCard.SetActive(false);
               discard.Enqueue(dealtCard);
            }
         }
      }
      else
      {
         while (discard.Any())
         {
            deck.Enqueue(discard.Dequeue());
         }
      }

      foreach (var dealtPosition in dealtPositions.Reverse())
      {
         if (deck.TryDequeue(out var dealtCard))
         {
            dealtCard.transform.SetParent(dealtPosition.transform, true);
            dealtCard.SetActive(true);
            dealtCard.transform.SetPositionAndRotation(dealtPosition.transform.position, Quaternion.identity);
            dealtCard.transform.localScale = Vector3.one;
         }
      }
   }


   public static bool IsACardInABottomPile(GameObject card)
   {
      return HasParentWithTag(card, "Bottom");
   }

   public static bool IsACardInATopPile(GameObject card)
   {
      return HasParentWithTag(card, "Top");
   }

   public static bool IsADealtCard(GameObject card)
   {
      return HasParentWithTag(card, "Dealt");
   }

   public bool IsSelectableDealtCard(GameObject card)
   {
      if (!IsADealtCard(card)) return false;
      foreach (var position in dealtPositions.Reverse())
      {
         var positionChildren = position.transform.GetChildren();
         if (positionChildren.Count() != 1)
         {
            continue;
         }
         return positionChildren.First() == card;
      }
      return false;
   }

   public void MoveCards(List<GameObject> cards, GameObject destination)
   {
      if (!cards.Any()) return;
      if (destination.CompareTag("Card") && !destination.GetComponent<Card>().isFaceUp) return;
      if (destination.transform.parent == cards.FirstOrDefault()?.transform?.parent) return;

      if (IsACardInABottomPile(destination) || destination.CompareTag("Bottom"))
      {
         MoveCardsToBottom(cards, destination);
      }
      else if (IsACardInATopPile(destination) || destination.CompareTag("Top"))
      {
         MoveCardsToTop(cards, destination);
      }
   }

   public void AutoMoveCards(List<GameObject> cards)
   {
      // if (!cards.Any()) return;
      // if (IsACardInABottomPile(cards.First()))
      // {
      //    MoveCardsFromBottom(cards, destination);
      // }
      // else if (IsACardInATopPile(cards.First()))
      // {
      //    MoveCardFromTop(cards, destination);
      // }
      // else if (IsSelectableDealtCard(cards.First()))
      // {
      //    MoveCardFromDealt(cards, destination);
      // }
   }

   private static void MoveCardsToBottom(List<GameObject> cards, GameObject destination)
   {
      Transform newParent;
      bool coverParent;
      var sourceCard = cards.First().GetComponent<Card>();

      if (destination.CompareTag("Card"))
      {
         var destCard = destination.GetComponent<Card>();
         if (!((int)sourceCard.rank == (int)destCard.rank - 1 && sourceCard.suit.Color() != destCard.suit.Color())) return;

         newParent = destination.transform.parent;
         coverParent = false;
      }
      else if (destination.CompareTag("Bottom"))
      {
         if (sourceCard.rank != Rank.King) return;

         newParent = destination.transform;
         coverParent = true;
      }
      else
      {
         return;
      }

      for (int i = 0; i < cards.Count; i++)
      {
         cards[i].transform.SetParent(newParent, true);
         cards[i].transform.position = destination.transform.position + new Vector3(0, -BOTTOM_CARD_OFFSET * (i + (coverParent ? 0 : 1)), -Z_OFFSET * (i + 1));
      }
   }

   private static void MoveCardsToTop(List<GameObject> cards, GameObject destination)
   {
      Transform newParent;
      var sourceCard = cards.First().GetComponent<Card>();

      if (cards.Count != 1) return;
      if (destination.CompareTag("Card"))
      {
         var destCard = destination.GetComponent<Card>();
         if (sourceCard.suit != destCard.suit || (int)sourceCard.rank != (int)destCard.rank + 1) return;

         newParent = destination.transform.parent;
      }
      else if (destination.CompareTag("Top"))
      {
         if (sourceCard.rank != Rank.Ace) return;

         newParent = destination.transform;
      }
      else
      {
         return;
      }

      cards.First().transform.SetParent(newParent, true);
      cards.First().transform.position = destination.transform.position + new Vector3(0, 0, -Z_OFFSET);
   }

   public void FlipCard(GameObject card)
   {
      var cardScript = card.GetComponent<Card>();
      if (IsACardInABottomPile(card) && CardIsOnTopOfThePile(card) && !cardScript.isFaceUp)
      {
         cardScript.isFaceUp = !cardScript.isFaceUp;
      }
   }

   private bool CardIsOnTopOfThePile(GameObject card)
   {
      return card.transform.parent.GetChildren().Last() == card;
   }

   private static bool HasParentWithTag(GameObject card, string tag)
   {
      return card.transform.parent != null && card.transform.parent.gameObject.CompareTag(tag);
   }
}

// public enum CardFaces
// {
//    Two_Spade,
//    Three_Spade,
//    Ace_Spade
// }