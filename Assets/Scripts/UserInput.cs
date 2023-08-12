using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core;
using UnityEngine;

public class UserInput : MonoBehaviour
{
   private Solitaire solitaire;
   private List<GameObject> _selectedCards = null;
   private float? cardSelectTime = null;
   private const float doubleClickTime = 0.3f;

   // Start is called before the first frame update
   void Start()
   {
      solitaire = FindObjectOfType<Solitaire>();
   }

   // Update is called once per frame
   void Update()
   {
      GetMouseClick();
   }

   private void GetMouseClick()
   {
      if (Input.GetMouseButtonDown(0))
      {
         var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
         var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

         if (hit.collider == null)
         {
            return;
         }

         if (hit.collider.CompareTag("Deck"))
         {
            solitaire.DealCards();
         }
         else if (hit.collider.CompareTag("Card"))
         {
            var card = hit.collider.gameObject;
            ClickCard(card);
         }
         else if (hit.collider.CompareTag("Top"))
         {
            var top = hit.collider.gameObject;
            ClickBottomOrTop(top);

         }
         else if (hit.collider.CompareTag("Bottom"))
         {
            var bottom = hit.collider.gameObject;
            ClickBottomOrTop(bottom);
         }

      }
   }

   private void ClickCard(GameObject card)
   {
      var previouslySelectedCards = GetAndResetSelectedCards();

      if (previouslySelectedCards is null)
      {
         if (!card.GetComponent<Card>().isFaceUp)
         {
            solitaire.FlipCard(card);
         }
         else
         {
            cardSelectTime = Time.time;
            SelectCard(card);
         }
      }
      else
      {
         var isDoubleClick = cardSelectTime != null && Time.time <= cardSelectTime + doubleClickTime;
         var clickedTheSameCard = previouslySelectedCards.Count > 0 && previouslySelectedCards.First() == card;
         cardSelectTime = null;

         if (isDoubleClick && clickedTheSameCard)
         {
            solitaire.AutoMoveCards(previouslySelectedCards);
         }
         else
         {
            solitaire.MoveCards(previouslySelectedCards, card);
         }
      }
   }

   private void ClickBottomOrTop(GameObject destination)
   {
      var selectedCards = GetAndResetSelectedCards();
      if (selectedCards is null || !selectedCards.Any())
      {
         return;
      }

      solitaire.MoveCards(selectedCards, destination);
   }

   private List<GameObject> GetAndResetSelectedCards()
   {
      var selectedCards = _selectedCards?.ToList();
      UnselectCards();
      return selectedCards;
   }

   private void SelectCard(GameObject card)
   {
      if (Solitaire.IsACardInABottomPile(card))
      {
         var cardsInPile = card.transform.parent.GetChildren().ToList();
         var cardIndex = cardsInPile.IndexOf(card);
         _selectedCards = cardsInPile.Skip(cardIndex).ToList();
         _selectedCards.ForEach(c => c.GetComponent<Card>().isSelected = true);
      }
      else if (Solitaire.IsACardInATopPile(card))
      {
         var cardsInPile = card.transform.parent.GetChildren().ToList();
         var cardIndex = cardsInPile.IndexOf(card);
         if (cardIndex != cardsInPile.Count - 1) return;

         _selectedCards = new List<GameObject> { card };
         card.GetComponent<Card>().isSelected = true;
      }
      else if (solitaire.IsSelectableDealtCard(card))
      {
         _selectedCards = new List<GameObject> { card };
         card.GetComponent<Card>().isSelected = true;
      }
   }

   private void UnselectCards()
   {
      _selectedCards?.ForEach(card => card.GetComponent<Card>().isSelected = false);
      _selectedCards = null;
   }
}
