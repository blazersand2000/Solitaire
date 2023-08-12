using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
   public Suit suit;
   public Rank rank;
   public bool isFaceUp;
   public bool isSelected;
   private Sprite cardFace;
   private Sprite cardBack;
   private SpriteRenderer spriteRenderer;

   // Start is called before the first frame update
   void Start()
   {
      cardFace = FindObjectOfType<CardFaces>().GetSpriteForFace(rank, suit);
      cardBack = GetComponent<CardBack>().cardBack;
      spriteRenderer = GetComponent<SpriteRenderer>();
   }

   // Update is called once per frame
   void Update()
   {
      spriteRenderer.sprite = isFaceUp ? cardFace : cardBack;
      spriteRenderer.color = isSelected ? Color.yellow : Color.white;
   }
}
