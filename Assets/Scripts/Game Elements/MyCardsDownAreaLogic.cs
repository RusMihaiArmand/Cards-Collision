using UnityEngine;
using System.Collections;
using System;

namespace SA
{

    [CreateAssetMenu(menuName ="Areas/MyCardsDownWhenHoldingCard")]
    public class MyCardsDownAreaLogic : AreaLogic
    {
        public CardVariable card;
        public CardType creatureType;
        public SO.TransformVariable areaGrid;
        public GameElements.GE_Logic cardDownLogic;

        public override void Execute()
        {
            if (card.value == null) return;

           // Card c = card.value.viz.card;

            if(card.value.viz.card.cardType==creatureType)
            {
                Settings.gameManager.cardToAttack = null;

                bool canUse = Settings.gameManager.currentPlayer.CanUseCard(card.value);

                int location = areaGrid.locationNumber;


                if (location == 0 && Settings.gameManager.currentPlayer.cardsDown.Count == 1) canUse = false;
                if (location == 1 && Settings.gameManager.currentPlayer.cardsDown1.Count == 1) canUse = false;
                if (location == 2 && Settings.gameManager.currentPlayer.cardsDown2.Count == 1) canUse = false;
                if (location == 3 && Settings.gameManager.currentPlayer.cardsDown3.Count == 1) canUse = false;
                if (location == 4 && Settings.gameManager.currentPlayer.cardsDown4.Count == 1) canUse = false;
                if (location == 5 && Settings.gameManager.currentPlayer.cardsDown5.Count == 1) canUse = false;
                if (location == 6 && Settings.gameManager.currentPlayer.cardsDown6.Count == 1) canUse = false;
                if (location == 7 && Settings.gameManager.currentPlayer.cardsDown7.Count == 1) canUse = false;
                if (location == 8 && Settings.gameManager.currentPlayer.cardsDown8.Count == 1) canUse = false;
                if (location == 9 && Settings.gameManager.currentPlayer.cardsDown9.Count == 1) canUse = false;

                if (location == 10 && Settings.gameManager.currentPlayer.cardsDownB.Count == 1) canUse = false;
                if (location == 11 && Settings.gameManager.currentPlayer.cardsDownB1.Count == 1) canUse = false;
                if (location == 12 && Settings.gameManager.currentPlayer.cardsDownB2.Count == 1) canUse = false;



                if (canUse)
                {
                    Settings.RegisterEvent(Settings.gameManager.currentPlayer.username + " played " + card.value.viz.card.name, Settings.gameManager.currentPlayer.playerColor);

                    Settings.SetParentForCard(card.value.transform, areaGrid.value.transform);
               
                    card.value.gameObject.SetActive(true);
                    card.value.currentLogic = cardDownLogic;



                    int cardcost = 0;


                    for (int i = 0; i < card.value.viz.properties.Length; i++)
                    {
                        if (card.value.viz.properties[i].element.name == "Cost")
                        {
                            cardcost = Int16.Parse(card.value.viz.properties[i].text.text);
                        }



                    }




                    ///  Settings.gameManager.currentPlayer.mana -= card.value.viz.card.cost;
                    Settings.gameManager.currentPlayer.mana -= cardcost;



                    

                    Settings.gameManager.statsUI[0].mana.text = Settings.gameManager.currentPlayer.mana.ToString();


                   /// Settings.gameManager.playerMana[Settings.gameManager.turnIndex].value = Settings.gameManager.currentPlayer.mana;

                    ///  Settings.gameManager.onTurnChanged.Raise();



                    Settings.DropCreatureCard(card.value.transform, areaGrid.value.transform, card.value , areaGrid.locationNumber);

                    /*
                    Settings.DropCreatureCard(card.value.transform, areaGrid.value.transform, card.value);

                    card.value.gameObject.SetActive(true);
                    */


                    card.value.viz.card.ExecuteOnPlay(card.value);


                }
               
                    card.value.gameObject.SetActive(true);



                




            }
            else
            {
                if(card.value.viz.card.cardType.name == "Spell" &&
                        Settings.gameManager.currentPlayer.CanUseCard(card.value))
                {

                    Settings.RegisterEvent(Settings.gameManager.currentPlayer.username + " played " + card.value.viz.card.name, Settings.gameManager.currentPlayer.playerColor);




                    int cardcost = 0;


                    for (int i = 0; i < card.value.viz.properties.Length; i++)
                    {
                        if (card.value.viz.properties[i].element.name == "Cost")
                        {
                            cardcost = Int16.Parse(card.value.viz.properties[i].text.text);
                        }



                    }



                    Settings.gameManager.currentPlayer.mana -= cardcost;




                    Settings.gameManager.statsUI[0].mana.text = Settings.gameManager.currentPlayer.mana.ToString();


                    ///  Settings.gameManager.playerMana[Settings.gameManager.turnIndex].value = Settings.gameManager.currentPlayer.mana;


                    ///   Settings.gameManager.onTurnChanged.Raise();



                    card.value.viz.card.ExecuteOnPlay(card.value);


                    //Settings.DropCreatureCard(card.value.transform, areaGrid.value.transform, card.value, areaGrid.locationNumber);

                    if (Settings.gameManager.currentPlayer.handCards.Contains(card.value))
                        Settings.gameManager.currentPlayer.handCards.Remove(card.value);


                    Destroy(card.value.gameObject);


                }




            }


        }


    }
}