using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Card")]
    public class Card : ScriptableObject
    {
        public CardType cardType;
       
        public CardProperties[] properties;
        public bool hasCharge = false;
        public int nrAttacks = 1;
        public bool immuneToStatChange = false;
        public int counterType = 1;
        public int attackType = 1;
        public bool hasSpecialAttack = false;
        public bool canAttack = true;
   
        public void ExecuteOnPlay(CardInstance cardinst)
        {
            

            if (this.name == "Among Us")
            {


                int[] colorsUsed = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                string[] cardsGenerated = new string[24]; // 0-11 ->crew  12-23 -> imp

                int xColor, xImp, pImp1, pImp2;


                pImp1 = UnityEngine.Random.Range(0,10);

                pImp2 = UnityEngine.Random.Range(0, 10);

                while (pImp2 == pImp1) pImp2 = UnityEngine.Random.Range(0, 10);

                /*
                
                0-green
                1-lime
                2-blue
                3-cyan
                4-red
                5-purple
                6-pink
                7-orange
                8-yellow
                9-brown
                10-black
                11-white
                  
                */

                cardsGenerated[0] = "Green Crewmate";
                cardsGenerated[1] = "Lime Crewmate";
                cardsGenerated[2] = "Blue Crewmate";
                cardsGenerated[3] = "Cyan Crewmate";
                cardsGenerated[4] = "Red Crewmate";
                cardsGenerated[5] = "Purple Crewmate";
                cardsGenerated[6] = "Pink Crewmate";
                cardsGenerated[7] = "Orange Crewmate";
                cardsGenerated[8] = "Yellow Crewmate";
                cardsGenerated[9] = "Brown Crewmate";
                cardsGenerated[10] = "Black Crewmate";
                cardsGenerated[11] = "White Crewmate";

                cardsGenerated[12] = "Green Impostor";
                cardsGenerated[13] = "Lime Impostor";
                cardsGenerated[14] = "Blue Impostor";
                cardsGenerated[15] = "Cyan Impostor";
                cardsGenerated[16] = "Red Impostor";
                cardsGenerated[17] = "Purple Impostor";
                cardsGenerated[18] = "Pink Impostor";
                cardsGenerated[19] = "Orange Impostor";
                cardsGenerated[20] = "Yellow Impostor";
                cardsGenerated[21] = "Brown Impostor";
                cardsGenerated[22] = "Black Impostor";
                cardsGenerated[23] = "White Impostor";



                ResourcesManager rm = Settings.GetResourcesManager();

                for (int i = 0; i < 10; i++)
                {
                    //get unique new color
                    xColor = UnityEngine.Random.Range(0, 12);

                    while (colorsUsed[xColor] == 1) xColor = UnityEngine.Random.Range(0, 12);

                    colorsUsed[xColor] = 1;

                    //get imp/crew status

                    if (i == pImp1 || i == pImp2) xImp = 1;
                    else xImp = 0;

                    GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                    CardViz v = go.GetComponent<CardViz>();
                    v.LoadCard(rm.GetCardInstance(cardsGenerated[xColor + xImp * 12]));
                    CardInstance inst = go.GetComponent<CardInstance>();
                    inst.currentLogic = Settings.gameManager.currentPlayer.downLogic;


                    if (Settings.gameManager.switchFailSafe == true)
                    {
                        if (i == 0)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid.value.transform);

                        if (i == 1)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid1.value.transform);

                        if (i == 2)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid2.value.transform);

                        if (i == 3)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid3.value.transform);

                        if (i == 4)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid4.value.transform);

                        if (i == 5)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid5.value.transform);

                        if (i == 6)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid6.value.transform);

                        if (i == 7)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid7.value.transform);

                        if (i == 8)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid8.value.transform);

                        if (i == 9)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.playerOneHolder.downGrid9.value.transform);


                    }
                    else
                    {
                        if (i == 0)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid.value.transform);

                        if (i == 1)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid1.value.transform);

                        if (i == 2)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid2.value.transform);

                        if (i == 3)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid3.value.transform);

                        if (i == 4)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid4.value.transform);

                        if (i == 5)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid5.value.transform);

                        if (i == 6)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid6.value.transform);

                        if (i == 7)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid7.value.transform);

                        if (i == 8)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid8.value.transform);

                        if (i == 9)
                            Settings.SetParentForCard(inst.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid9.value.transform);
                    }




                    inst.gameObject.SetActive(true);
                    /// inst.currentLogic =  Settings.gameManager.currentPlayer.cardDownLogic;

                    ////


                    inst.isFlatfooted = true;


                    /// SetParentForCard(c, p);

                    if (inst.isFlatfooted == true)
                    {
                        inst.transform.eulerAngles = new Vector3(0, 0, 90);
                    }



                    Settings.gameManager.currentPlayer.DropCard(inst, i);

                    

                   
                    //////



                }




            }

            if (this.name == "Glitch")
            {


                int j, k;
                for (int i = 0; i < Settings.gameManager.all_players.Length; i++)
                {
                    for (int y = 0; y < 13; y++)
                    {
                        int isCard = 0;

                        if (y == 0) isCard = Settings.gameManager.all_players[i].cardsDown.Count;
                        if (y == 1) isCard = Settings.gameManager.all_players[i].cardsDown1.Count;
                        if (y == 2) isCard = Settings.gameManager.all_players[i].cardsDown2.Count;
                        if (y == 3) isCard = Settings.gameManager.all_players[i].cardsDown3.Count;
                        if (y == 4) isCard = Settings.gameManager.all_players[i].cardsDown4.Count;
                        if (y == 5) isCard = Settings.gameManager.all_players[i].cardsDown5.Count;
                        if (y == 6) isCard = Settings.gameManager.all_players[i].cardsDown6.Count;
                        if (y == 7) isCard = Settings.gameManager.all_players[i].cardsDown7.Count;
                        if (y == 8) isCard = Settings.gameManager.all_players[i].cardsDown8.Count;
                        if (y == 9) isCard = Settings.gameManager.all_players[i].cardsDown9.Count;
                        if (y == 10) isCard = Settings.gameManager.all_players[i].cardsDownB.Count;
                        if (y == 11) isCard = Settings.gameManager.all_players[i].cardsDownB1.Count;
                        if (y == 12) isCard = Settings.gameManager.all_players[i].cardsDownB2.Count;


                        if (isCard == 1)
                        {
                            CardInstance c;

                            if (y == 0) c = Settings.gameManager.all_players[i].cardsDown[0];
                            else if (y == 1) c = Settings.gameManager.all_players[i].cardsDown1[0];
                            else if (y == 2) c = Settings.gameManager.all_players[i].cardsDown2[0];
                            else if (y == 3) c = Settings.gameManager.all_players[i].cardsDown3[0];
                            else if (y == 4) c = Settings.gameManager.all_players[i].cardsDown4[0];
                            else if (y == 5) c = Settings.gameManager.all_players[i].cardsDown5[0];
                            else if (y == 6) c = Settings.gameManager.all_players[i].cardsDown6[0];
                            else if (y == 7) c = Settings.gameManager.all_players[i].cardsDown7[0];
                            else if (y == 8) c = Settings.gameManager.all_players[i].cardsDown8[0];
                            else if (y == 9) c = Settings.gameManager.all_players[i].cardsDown9[0];
                            else if (y == 10) c = Settings.gameManager.all_players[i].cardsDownB[0];
                            else if (y == 11) c = Settings.gameManager.all_players[i].cardsDownB1[0];
                            else c = Settings.gameManager.all_players[i].cardsDownB2[0];

                            j = 0; k = 0;

                            while (k == 0 && j < c.viz.card.properties.Length)
                            {
                                if (c.viz.card.properties[j].element.name == "Class")
                                {
                                    k = 1;
                                    if (c.viz.card.properties[j].StringValue == "Game")
                                    {
                                        c.viz.properties[2].text.text = (Int16.Parse(c.viz.properties[2].text.text) - 300).ToString();
                                    }
                                }

                                j++;
                            }


                            if (Int16.Parse(c.viz.properties[2].text.text) <= 0)
                            {

                                Settings.gameManager.all_players[i].graveyard_cards.Add(c.viz.card.name);


                                if (y == 0) Settings.gameManager.all_players[i].cardsDown.Remove(c);
                                if (y == 1) Settings.gameManager.all_players[i].cardsDown1.Remove(c);
                                if (y == 2) Settings.gameManager.all_players[i].cardsDown2.Remove(c);
                                if (y == 3) Settings.gameManager.all_players[i].cardsDown3.Remove(c);
                                if (y == 4) Settings.gameManager.all_players[i].cardsDown4.Remove(c);
                                if (y == 5) Settings.gameManager.all_players[i].cardsDown5.Remove(c);
                                if (y == 6) Settings.gameManager.all_players[i].cardsDown6.Remove(c); ;
                                if (y == 7) Settings.gameManager.all_players[i].cardsDown7.Remove(c); ;
                                if (y == 8) Settings.gameManager.all_players[i].cardsDown8.Remove(c); ;
                                if (y == 9) Settings.gameManager.all_players[i].cardsDown9.Remove(c); ;
                                if (y == 10) Settings.gameManager.all_players[i].cardsDownB.Remove(c); ;
                                if (y == 11) Settings.gameManager.all_players[i].cardsDownB1.Remove(c); ;
                                if (y == 12) Settings.gameManager.all_players[i].cardsDownB2.Remove(c); ;


                                if(y<=9) Settings.RegisterEvent(Settings.gameManager.all_players[i].username + "'s " + c.viz.card.name + " killed", Settings.gameManager.currentPlayer.playerColor);
                                else Settings.RegisterEvent(Settings.gameManager.all_players[i].username + "'s " + c.viz.card.name + " destroyed", Settings.gameManager.currentPlayer.playerColor);



                                Settings.gameManager.all_players[i].cardsDown.Remove(c);



                                Destroy(c.gameObject);
                            }

                        }

                    }








                }





            }

            if (this.name == "Black Hole")
            {


              
                for (int i = 0; i < Settings.gameManager.all_players.Length; i++)
                {
                    for (int y = 0; y < 13; y++)
                    {
                        int isCard = 0;

                        if (y == 0) isCard = Settings.gameManager.all_players[i].cardsDown.Count;
                        if (y == 1) isCard = Settings.gameManager.all_players[i].cardsDown1.Count;
                        if (y == 2) isCard = Settings.gameManager.all_players[i].cardsDown2.Count;
                        if (y == 3) isCard = Settings.gameManager.all_players[i].cardsDown3.Count;
                        if (y == 4) isCard = Settings.gameManager.all_players[i].cardsDown4.Count;
                        if (y == 5) isCard = Settings.gameManager.all_players[i].cardsDown5.Count;
                        if (y == 6) isCard = Settings.gameManager.all_players[i].cardsDown6.Count;
                        if (y == 7) isCard = Settings.gameManager.all_players[i].cardsDown7.Count;
                        if (y == 8) isCard = Settings.gameManager.all_players[i].cardsDown8.Count;
                        if (y == 9) isCard = Settings.gameManager.all_players[i].cardsDown9.Count;
                        if (y == 10) isCard = Settings.gameManager.all_players[i].cardsDownB.Count;
                        if (y == 11) isCard = Settings.gameManager.all_players[i].cardsDownB1.Count;
                        if (y == 12) isCard = Settings.gameManager.all_players[i].cardsDownB2.Count;


                        if (isCard == 1)
                        {
                            CardInstance c;

                            if (y == 0) c = Settings.gameManager.all_players[i].cardsDown[0];
                            else if (y == 1) c = Settings.gameManager.all_players[i].cardsDown1[0];
                            else if (y == 2) c = Settings.gameManager.all_players[i].cardsDown2[0];
                            else if (y == 3) c = Settings.gameManager.all_players[i].cardsDown3[0];
                            else if (y == 4) c = Settings.gameManager.all_players[i].cardsDown4[0];
                            else if (y == 5) c = Settings.gameManager.all_players[i].cardsDown5[0];
                            else if (y == 6) c = Settings.gameManager.all_players[i].cardsDown6[0];
                            else if (y == 7) c = Settings.gameManager.all_players[i].cardsDown7[0];
                            else if (y == 8) c = Settings.gameManager.all_players[i].cardsDown8[0];
                            else if (y == 9) c = Settings.gameManager.all_players[i].cardsDown9[0];
                            else if (y == 10) c = Settings.gameManager.all_players[i].cardsDownB[0];
                            else if (y == 11) c = Settings.gameManager.all_players[i].cardsDownB1[0];
                            else c = Settings.gameManager.all_players[i].cardsDownB2[0];

                          

                          


                                Settings.gameManager.all_players[i].graveyard_cards.Add(c.viz.card.name);


                                if (y == 0) Settings.gameManager.all_players[i].cardsDown.Remove(c);
                                if (y == 1) Settings.gameManager.all_players[i].cardsDown1.Remove(c);
                                if (y == 2) Settings.gameManager.all_players[i].cardsDown2.Remove(c);
                                if (y == 3) Settings.gameManager.all_players[i].cardsDown3.Remove(c);
                                if (y == 4) Settings.gameManager.all_players[i].cardsDown4.Remove(c);
                                if (y == 5) Settings.gameManager.all_players[i].cardsDown5.Remove(c);
                                if (y == 6) Settings.gameManager.all_players[i].cardsDown6.Remove(c); ;
                                if (y == 7) Settings.gameManager.all_players[i].cardsDown7.Remove(c); ;
                                if (y == 8) Settings.gameManager.all_players[i].cardsDown8.Remove(c); ;
                                if (y == 9) Settings.gameManager.all_players[i].cardsDown9.Remove(c); ;
                                if (y == 10) Settings.gameManager.all_players[i].cardsDownB.Remove(c); ;
                                if (y == 11) Settings.gameManager.all_players[i].cardsDownB1.Remove(c); ;
                                if (y == 12) Settings.gameManager.all_players[i].cardsDownB2.Remove(c); ;


                                if (y <= 9) Settings.RegisterEvent(Settings.gameManager.all_players[i].username + "'s " + c.viz.card.name + " killed", Settings.gameManager.currentPlayer.playerColor);
                                else Settings.RegisterEvent(Settings.gameManager.all_players[i].username + "'s " + c.viz.card.name + " destroyed", Settings.gameManager.currentPlayer.playerColor);



                                Settings.gameManager.all_players[i].cardsDown.Remove(c);



                                Destroy(c.gameObject);
                            

                        }

                    }








                }





            }



            if (this.name == "Containment Breach")
            {

                ResourcesManager rm = Settings.GetResourcesManager();

                int scpLenght=0;
                string[] generatedCards = new string[100];

               

                for (int i = 0; i < rm.allCards.Length; i++)
                {


                    int j, k;

                    j = 0; k = 0;

                    while (k == 0 && j < rm.allCards[i].properties.Length)
                    {
                        if (rm.allCards[i].properties[j].element.name == "Class")
                        {
                            k = 1;
                            if (rm.allCards[i].properties[j].StringValue == "SCP")
                            {
                                generatedCards[scpLenght] = rm.allCards[i].name;
                                scpLenght++;
                            }
                           
                        }

                        j++;
                    }

                }


                for (int i = 1; i <= 3; i++)
                {

                    if (Settings.gameManager.turns[Settings.gameManager.turnIndex].player.handCards.Count <= 10)
                    {
                        

                        int j = UnityEngine.Random.Range(0, scpLenght);

                        


                        GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                        CardViz v = go.GetComponent<CardViz>();
                        v.LoadCard(rm.GetCardInstance( generatedCards[j] ));
                        CardInstance inst = go.GetComponent<CardInstance>();
                        inst.currentLogic = Settings.gameManager.turns[Settings.gameManager.turnIndex].player.handLogic;
                       

                      if(Settings.gameManager.switchFailSafe==true)
                            Settings.SetParentForCard(go.transform, Settings.gameManager.playerOneHolder.handGrid.value.transform);
                        else Settings.SetParentForCard(go.transform, Settings.gameManager.turns[Settings.gameManager.turnIndex].player.currentHolder.handGrid.value.transform);

                        

                        inst.viz = v;

                        Settings.gameManager.turns[Settings.gameManager.turnIndex].player.handCards.Add(inst);



                    }


                }


                PlayerHolder p = Settings.gameManager.all_players[1- Settings.gameManager.turnIndex];

               /// if (p == Settings.gameManager.currentPlayer) p = Settings.gameManager.all_players[1];


                if (p.handCards.Count < 10)
                {
                    int j = UnityEngine.Random.Range(0, scpLenght);


                    GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                    CardViz v = go.GetComponent<CardViz>();
                    v.LoadCard(rm.GetCardInstance(generatedCards[j]));
                    CardInstance inst = go.GetComponent<CardInstance>();
                    inst.currentLogic = p.handLogic;
                   
                    if (Settings.gameManager.switchFailSafe == true)
                        Settings.SetParentForCard(go.transform, Settings.gameManager.playerTwoHolder.handGrid.value.transform);
                    else Settings.SetParentForCard(go.transform, p.currentHolder.handGrid.value.transform);


                    inst.viz = v;

                    p.handCards.Add(inst);

                }




            }



            if (this.name == "Copy Cat")
            {
                if (Settings.gameManager.cardToAttack==null)
                {
                    Settings.gameManager.needToSelect = true;


                    PlayerHolder p = Settings.gameManager.all_players[0];

                if (p == Settings.gameManager.currentPlayer) p = Settings.gameManager.all_players[1];


                if (Settings.gameManager.currentPlayer.NrTroops() + p.NrTroops() > 1)
                {


                    for (int i = 0; i <= 1; i++)
                    {
                        PlayerHolder pl = Settings.gameManager.turns[i].player;


                        foreach (CardInstance c in pl.cardsDown)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown1)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown2)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown3)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown4)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown5)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown6)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown7)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown8)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                        foreach (CardInstance c in pl.cardsDown9)
                            if (c != cardinst) Settings.gameManager.cardsThatCanBeSelected.Add(c);



                    }



                        if (Settings.gameManager.cardsThatCanBeSelected.Count > 0)
                        {
                            Settings.gameManager.StartCoroutine(Settings.gameManager.WaitCondSelectOption(cardinst));
                            Settings.gameManager.WaitCondSelectOption(cardinst);
                        }
                        else Settings.gameManager.needToSelect = false;

                    }
                    else
                    {
                        Settings.gameManager.needToSelect = false;


                    }

                }
                else
                {
                    Settings.gameManager.needToSelect = false;


                    

                    string hpValue="1", atkValue="0";

                    for (int i = 0; i < Settings.gameManager.cardToAttack.viz.properties.Length; i++)
                    {
                        if (Settings.gameManager.cardToAttack.viz.properties[i].element.name == "HP")
                        {
                            hpValue= Settings.gameManager.cardToAttack.viz.properties[i].text.text;
                        }

                        if (Settings.gameManager.cardToAttack.viz.properties[i].element.name == "Attack")
                        {
                            atkValue = Settings.gameManager.cardToAttack.viz.properties[i].text.text;
                        }


                    }


                    ResourcesManager rm = Settings.GetResourcesManager();






                    GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                    CardViz v = go.GetComponent<CardViz>();
                    v.LoadCard(rm.GetCardInstance(Settings.gameManager.cardToAttack.viz.card.name));
                    CardInstance inst = go.GetComponent<CardInstance>();


                    inst.currentLogic = Settings.gameManager.currentPlayer.downLogic;
                    inst.viz = v;


                   


                    if (Settings.gameManager.currentPlayer.cardsDown.Contains(cardinst))
                        {
                            Settings.SetParentForCard(go.transform,
                                Settings.gameManager.currentPlayer.currentHolder.downGrid.value);

                            if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                            {
                                Settings.SetParentForCard(go.transform,
                                       Settings.gameManager.playerOneHolder.downGrid.value);

                            }

                        Settings.gameManager.currentPlayer.cardsDown.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown.Remove(cardinst);
                        }

                    if (Settings.gameManager.currentPlayer.cardsDown1.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid1.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid1.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown1.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown1.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown2.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid2.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid2.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown2.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown2.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown3.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid3.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid3.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown3.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown3.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown4.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid4.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid4.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown4.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown4.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown5.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid5.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid5.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown5.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown5.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown6.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid6.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid6.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown6.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown6.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown7.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid7.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid7.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown7.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown7.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown8.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid8.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid8.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown8.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown8.Remove(cardinst);
                    }

                    if (Settings.gameManager.currentPlayer.cardsDown9.Contains(cardinst))
                    {
                        Settings.SetParentForCard(go.transform,
                            Settings.gameManager.currentPlayer.currentHolder.downGrid9.value);

                        if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                        {
                            Settings.SetParentForCard(go.transform,
                                   Settings.gameManager.playerOneHolder.downGrid9.value);

                        }

                        Settings.gameManager.currentPlayer.cardsDown9.Add(inst);

                        Settings.gameManager.currentPlayer.cardsDown9.Remove(cardinst);
                    }



                    for (int i = 0; i < inst.viz.properties.Length; i++)
                    {
                        if (inst.viz.properties[i].element.name == "HP")
                        {
                            inst.viz.properties[i].text.text = hpValue;

                            
                        }

                        if (Settings.gameManager.cardToAttack.viz.properties[i].element.name == "Attack")
                        {
                            inst.viz.properties[i].text.text = atkValue;
                        }


                    }



                    if (inst.viz.card.hasCharge == false)
                    {

                        inst.isFlatfooted = true;

                        inst.transform.eulerAngles = new Vector3(0, 0, 90);


                    }
                    else inst.isFlatfooted = false;





                    Destroy(cardinst.gameObject);


                    Settings.RegisterEvent( "Copy Cat -> " + Settings.gameManager.cardToAttack.viz.card.name, Settings.gameManager.currentPlayer.playerColor);


                    Settings.gameManager.cardToAttack = null;





                }




            }
             
            if(this.name == "Thanos")
            {

                for(int i=0;i<=1;i++)
                {
                    PlayerHolder p = Settings.gameManager.all_players[i];

                    int l = (p.all_cards.Count + 1) / 2;


                    int n;
                    for(int j=1;j<=l;j++)
                    {
                      n= UnityEngine.Random.Range(0, p.all_cards.Count);

                        p.all_cards.RemoveAt(n);

                    }

                   if(l==1) Settings.RegisterEvent("Destroyed 1 card from " + p.username + "'s deck", Settings.gameManager.currentPlayer.playerColor);
                    else Settings.RegisterEvent("Destroyed " + l + " cards from " + p.username + "'s deck" , Settings.gameManager.currentPlayer.playerColor);

                    p.statsUI.UpdateAll();

                }


            }

        }



        public void ExecuteOnDeath()
        {



        }





        public void ExecuteOnMyCardHealed()
        {



        }


        public void ExecuteOnEnemyCardHealed()
        {



        }


       





        public void ExecuteOnMyCardDamaged()
        {



        }


        public void ExecuteOnEnemyCardDamaged()
        {



        }


       




        public void ExecuteOnMyCardKilled()
        {



        }


        public void ExecuteOnEnemyCardKilled()
        {



        }




        public void ExecuteOnPlayerDraw()
        {



        }


        public void ExecuteOnEnemyDraw()
        {



        }




        public void ExecuteOnThisKills()
        {



        }


        public void ExecuteOnThisAttacks()
        {



        }



        public void ExecuteOnThisAttacksAndKills()
        {



        }




        public void ExecuteOnThisHitsEnemy()
        {



        }





        public void ExecuteOnPlayerPlaysCard()
        {



        }



        public void ExecuteOnEnemyPlaysCard()
        {



        }


        public void ExecuteOnTurnEnd()
        {
   

            if (this.name == "Anti-meme")
            {
                

                int j,k;
                for(int i=0;i<Settings.gameManager.all_players.Length;i++)
                {
                    for (int y = 0; y < 13; y++)
                    {
                        int isCard = 0;

                        if (y == 0) isCard = Settings.gameManager.all_players[i].cardsDown.Count;
                        if (y == 1) isCard = Settings.gameManager.all_players[i].cardsDown1.Count;
                        if (y == 2) isCard = Settings.gameManager.all_players[i].cardsDown2.Count;
                        if (y == 3) isCard = Settings.gameManager.all_players[i].cardsDown3.Count;
                        if (y == 4) isCard = Settings.gameManager.all_players[i].cardsDown4.Count;
                        if (y == 5) isCard = Settings.gameManager.all_players[i].cardsDown5.Count;
                        if (y == 6) isCard = Settings.gameManager.all_players[i].cardsDown6.Count;
                        if (y == 7) isCard = Settings.gameManager.all_players[i].cardsDown7.Count;
                        if (y == 8) isCard = Settings.gameManager.all_players[i].cardsDown8.Count;
                        if (y == 9) isCard = Settings.gameManager.all_players[i].cardsDown9.Count;
                        if (y == 10) isCard = Settings.gameManager.all_players[i].cardsDownB.Count;
                        if (y == 11) isCard = Settings.gameManager.all_players[i].cardsDownB1.Count;
                        if (y == 12) isCard = Settings.gameManager.all_players[i].cardsDownB2.Count;


                        if (isCard==1)
                        {
                            CardInstance c;

                        if (y==0)  c = Settings.gameManager.all_players[i].cardsDown[0];
                       else if (y == 1) c = Settings.gameManager.all_players[i].cardsDown1[0];
                       else if (y == 2) c = Settings.gameManager.all_players[i].cardsDown2[0];
                       else if (y == 3) c = Settings.gameManager.all_players[i].cardsDown3[0];
                        else if (y == 4) c = Settings.gameManager.all_players[i].cardsDown4[0];
                            else if (y == 5) c = Settings.gameManager.all_players[i].cardsDown5[0];
                            else if (y == 6) c = Settings.gameManager.all_players[i].cardsDown6[0];
                            else if (y == 7) c = Settings.gameManager.all_players[i].cardsDown7[0];
                            else if (y == 8) c = Settings.gameManager.all_players[i].cardsDown8[0];
                            else if (y == 9) c = Settings.gameManager.all_players[i].cardsDown9[0];
                            else if (y == 10) c = Settings.gameManager.all_players[i].cardsDownB[0];
                            else if (y == 11) c = Settings.gameManager.all_players[i].cardsDownB1[0];
                            else  c = Settings.gameManager.all_players[i].cardsDownB2[0];

                        j = 0; k = 0;

                        while (k == 0 && j < c.viz.card.properties.Length)
                        {
                            if (c.viz.card.properties[j].element.name == "Class")
                            {
                                k = 1;
                                if (c.viz.card.properties[j].StringValue == "Meme")
                                {
                                    c.viz.properties[2].text.text = (Int16.Parse(c.viz.properties[2].text.text) - 100).ToString();


                                }


                            }

                            j++;
                        }


                        if (Int16.Parse(c.viz.properties[2].text.text) <= 0)
                        {
                                Settings.gameManager.all_players[i].graveyard_cards.Add(c.viz.card.name);


                                if (y == 0) Settings.gameManager.all_players[i].cardsDown.Remove(c);
                            if (y == 1) Settings.gameManager.all_players[i].cardsDown1.Remove(c);
                            if (y == 2) Settings.gameManager.all_players[i].cardsDown2.Remove(c);
                            if (y == 3) Settings.gameManager.all_players[i].cardsDown3.Remove(c);
                            if (y == 4) Settings.gameManager.all_players[i].cardsDown4.Remove(c);
                            if (y == 5) Settings.gameManager.all_players[i].cardsDown5.Remove(c);
                            if (y == 6) Settings.gameManager.all_players[i].cardsDown6.Remove(c); ;
                            if (y == 7) Settings.gameManager.all_players[i].cardsDown7.Remove(c); ;
                            if (y == 8) Settings.gameManager.all_players[i].cardsDown8.Remove(c); ;
                            if (y == 9) Settings.gameManager.all_players[i].cardsDown9.Remove(c); ;
                            if (y == 10) Settings.gameManager.all_players[i].cardsDownB.Remove(c); ;
                            if (y == 11) Settings.gameManager.all_players[i].cardsDownB1.Remove(c); ;
                            if (y == 12) Settings.gameManager.all_players[i].cardsDownB2.Remove(c); ;


                                if (y <= 9) Settings.RegisterEvent(Settings.gameManager.all_players[i].username + "'s " + c.viz.card.name + " killed", Settings.gameManager.currentPlayer.playerColor);
                                else Settings.RegisterEvent(Settings.gameManager.all_players[i].username + "'s " + c.viz.card.name + " destroyed", Settings.gameManager.currentPlayer.playerColor);



                                Destroy(c.gameObject);
                        }

                    }

                    }


                    





                }





            }

            if (this.name == "Cowbelly")
            {

                ResourcesManager rm = Settings.GetResourcesManager();

                int memeLenght = 0;
                string[] generatedCards = new string[100];

                

                for (int i = 0; i < rm.allCards.Length; i++)
                {


                    int j, k;

                    j = 0; k = 0;

                    while (k == 0 && j < rm.allCards[i].properties.Length)
                    {
                        if (rm.allCards[i].properties[j].element.name == "Class")
                        {
                            k = 1;
                            if (rm.allCards[i].properties[j].StringValue == "Meme")
                            {
                                generatedCards[memeLenght] = rm.allCards[i].name;
                                memeLenght++;
                            }

                        }

                        j++;
                    }

                }


              

                    if (Settings.gameManager.currentPlayer.handCards.Count < 10)
                    {
                        int j = UnityEngine.Random.Range(0, memeLenght);



                        GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                        CardViz v = go.GetComponent<CardViz>();
                        v.LoadCard(rm.GetCardInstance(generatedCards[j]));
                        CardInstance inst = go.GetComponent<CardInstance>();
                        inst.currentLogic = Settings.gameManager.currentPlayer.handLogic;

                    
                    if(Settings.gameManager.switchFailSafe==true)
                        Settings.SetParentForCard(go.transform, Settings.gameManager.playerOneHolder.handGrid.value);
                    else Settings.SetParentForCard(go.transform, Settings.gameManager.currentPlayer.currentHolder.handGrid.value);


                    inst.viz = v;

                      Settings.gameManager.currentPlayer.handCards.Add(inst);
                 


                }






            }

            if (this.name == "GAMERULmihai")
            {

                ResourcesManager rm = Settings.GetResourcesManager();

                int Lenght = 0;
                string[] generatedCards = new string[100];



                for (int i = 0; i < rm.allCards.Length; i++)
                {


                    int j, k;

                    j = 0; k = 0;

                    while (k == 0 && j < rm.allCards[i].properties.Length)
                    {
                        if (rm.allCards[i].properties[j].element.name == "Rarity")
                        {
                            k = 1;
                            if (rm.allCards[i].properties[j].sprite.name == "model legendara")
                            {
                                generatedCards[Lenght] = rm.allCards[i].name;
                                Lenght++;
                            }

                        }

                        j++;
                    }

                }




                if (Settings.gameManager.currentPlayer.handCards.Count < 10)
                {
                    int j = UnityEngine.Random.Range(0, Lenght);



                    GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                    CardViz v = go.GetComponent<CardViz>();
                    v.LoadCard(rm.GetCardInstance(generatedCards[j]));
                    CardInstance inst = go.GetComponent<CardInstance>();
                    inst.currentLogic = Settings.gameManager.currentPlayer.handLogic;


                    if (Settings.gameManager.switchFailSafe == true)
                        Settings.SetParentForCard(go.transform, Settings.gameManager.playerOneHolder.handGrid.value);
                    else Settings.SetParentForCard(go.transform, Settings.gameManager.currentPlayer.currentHolder.handGrid.value);


                    inst.viz = v;

                    Settings.gameManager.currentPlayer.handCards.Add(inst);


                    for (int i = 0; i < inst.viz.properties.Length; i++)
                    {
                        if (inst.viz.properties[i].element.name == "Cost")
                        {
                            inst.viz.properties[i].text.text = "0";
                        }

                       


                    }





                }






            }



        }



        public void ExecuteOnTurnStart()
        {




        }

  


        public void ExecuteAbility(CardInstance instance)
        {

            if (this.name == "SCP-914")
            { 

                ///ce se intampla dupa ce dai click pe carte
                if(Settings.gameManager.selectedOption==-50 && Settings.gameManager.cardToAttack==null)
                  {


                Settings.gameManager.needToSelect = true;




                ResourcesManager rm = Settings.GetResourcesManager();




                GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                CardViz v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance("Coarse"));
                CardInstance inst = go.GetComponent<CardInstance>();
                inst.currentLogic = Settings.gameManager.currentPlayer.downLogic;
                Settings.SetParentForCard(go.transform, Settings.gameManager.optionCardsGrid.value);

                inst.viz = v;

                Settings.gameManager.optionCards.Add(inst);
                Settings.gameManager.cardsThatCanBeSelected.Add(inst);




                go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance("1 to 1"));
                inst = go.GetComponent<CardInstance>();
                inst.currentLogic = Settings.gameManager.currentPlayer.downLogic;
                Settings.SetParentForCard(go.transform, Settings.gameManager.optionCardsGrid.value);

                inst.viz = v;


                Settings.gameManager.optionCards.Add(inst);
                Settings.gameManager.cardsThatCanBeSelected.Add(inst);
               


                go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance("Fine"));
                inst = go.GetComponent<CardInstance>();
                inst.currentLogic = Settings.gameManager.currentPlayer.downLogic;
                Settings.SetParentForCard(go.transform, Settings.gameManager.optionCardsGrid.value);

                inst.viz = v;



                Settings.gameManager.optionCards.Add(inst);
                Settings.gameManager.cardsThatCanBeSelected.Add(inst);



                   

                Settings.gameManager.StartCoroutine(Settings.gameManager.WaitCondSelectOption(instance));

                Settings.gameManager.WaitCondSelectOption(instance);



            }
                else
                {
                    ///dupa ce ai selectat modul de upgrade
                    if(Settings.gameManager.selectedOption == -50 && Settings.gameManager.cardToAttack != null)
                    {

                        while (Settings.gameManager.cardsThatCanBeSelected.Count > 0)
                            Settings.gameManager.cardsThatCanBeSelected.Remove(Settings.gameManager.cardsThatCanBeSelected[0]);



                           

                            int rarityChange;


                            if (Settings.gameManager.cardToAttack.viz.card.name == "Coarse") rarityChange = -1;
                            else
                            {
                                if (Settings.gameManager.cardToAttack.viz.card.name == "1 to 1") rarityChange = 0;
                                else rarityChange = 1;

                            }


                            while (Settings.gameManager.optionCards.Count > 0)
                            {
                                CardInstance inst = Settings.gameManager.optionCards[0];


                                Settings.gameManager.optionCards.Remove(inst);

                                Destroy(inst.gameObject);




                                
                            }



                            Settings.gameManager.selectedOption = rarityChange;

                            Settings.gameManager.cardToAttack = null;


                            PlayerHolder p;

                            if (Settings.gameManager.currentPlayer == Settings.gameManager.turns[0].player)
                                p = Settings.gameManager.turns[1].player;
                            else p = Settings.gameManager.turns[0].player;

                            if (Settings.gameManager.currentPlayer.handCards.Count
                                + Settings.gameManager.currentPlayer.NrTroops()
                                + Settings.gameManager.currentPlayer.NrBuldings()
                                + p.NrTroops()
                                + p.NrBuldings()
                                > 1)
                            {


                              for(int i=0;i<=1;i++)
                            {
                                PlayerHolder pl = Settings.gameManager.turns[i].player;


                                foreach (CardInstance c in pl.cardsDown)
                                     Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown1)
                                    Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown2)
                                   Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown3)
                                    Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown4)
                                   Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown5)
                                   Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown6)
                                     Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown7)
                                    Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown8)
                                     Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDown9)
                                     Settings.gameManager.cardsThatCanBeSelected.Add(c);



                                foreach (CardInstance c in pl.cardsDownB)
                                    if (c != instance) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDownB1)
                                    if (c != instance) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                                foreach (CardInstance c in pl.cardsDownB2)
                                    if (c != instance) Settings.gameManager.cardsThatCanBeSelected.Add(c);

                            }


                            foreach (CardInstance c in Settings.gameManager.currentPlayer.handCards)
                                 Settings.gameManager.cardsThatCanBeSelected.Add(c);




                                Settings.gameManager.StartCoroutine(Settings.gameManager.WaitCondSelectOption(instance));
                                Settings.gameManager.WaitCondSelectOption(instance);

                            }
                          
                            /// Settings.gameManager.needToSelect = false;








                    }
                    else
                    {
                        ///dupa ce ai selectat si cartea
                        if(Settings.gameManager.selectedOption != -50)
                        {
                            while (Settings.gameManager.cardsThatCanBeSelected.Count > 0)
                                Settings.gameManager.cardsThatCanBeSelected.Remove(Settings.gameManager.cardsThatCanBeSelected[0]);



                            CardInstance theCard = Settings.gameManager.cardToAttack;
                            Settings.gameManager.cardToAttack = null;
                            string[] rarities = new string[6];
                            string theclass;

                      


                            rarities[0] = "model comuna";
                            rarities[1] = "model necomuna";
                            rarities[2] = "model rara";
                            rarities[3] = "model epica";
                            rarities[4] = "model legendara";
                            rarities[5] = "model godly";

                            int j, k, cardR = 0 ;
                            int option = Settings.gameManager.selectedOption;

                            j = 0; k = 0;
                           
                            theclass = "";

                            while (j < theCard.viz.card.properties.Length)
                            {
                                if (theCard.viz.card.properties[j].element.name == "Rarity")
                                {

                                    for(k=0;k<6;k++)
                                    {
                                        if (theCard.viz.card.properties[j].sprite.name == rarities[k])
                                            cardR = k;

                                    }
 
                                }

                                if (theCard.viz.card.properties[j].element.name == "Class")
                                        theclass = theCard.viz.card.properties[j].StringValue;
                                


                                j++;
                            }

                            

                            if(cardR!=5)
                            {
                                int luck;

                                luck = UnityEngine.Random.Range(0, 4);

                                if ((cardR == 0 && option == -1) || (cardR == 4 && option == 1 && luck < 3))
                                {


                                    if (Settings.gameManager.currentPlayer.IsMyBuilding(theCard) || Settings.gameManager.currentPlayer.IsMyTroop(theCard)
                               || Settings.gameManager.currentPlayer.handCards.Contains(theCard))
                                    {
                                        Settings.RegisterEvent("Destroyed " + Settings.gameManager.currentPlayer.username +
                                              "'s " + theCard.viz.card.name, Settings.gameManager.currentPlayer.playerColor);

                                        if (theCard.viz.card.cardType.name != "Spell") Settings.gameManager.currentPlayer.graveyard_cards.Add(theCard.viz.card.name);


                                    }
                                    else
                                    {
                                        Settings.RegisterEvent("Destroyed " + Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].username +
                                             "'s " + theCard.viz.card.name, Settings.gameManager.currentPlayer.playerColor);


                                        if (theCard.viz.card.cardType.name != "Spell")
                                            Settings.gameManager.all_players[1 - Settings.gameManager.turnIndex].graveyard_cards.Add(theCard.viz.card.name);

                                    }





                                    for (int i = 0; i <= 1; i++)
                                    {
                                        if(Settings.gameManager.all_players[i].cardsDown.Contains(theCard))
                                         Settings.gameManager.all_players[i].cardsDown.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown1.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown1.Remove(theCard);                                   


                                        if (Settings.gameManager.all_players[i].cardsDown2.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown2.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown3.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown3.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown4.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown4.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown5.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown5.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown6.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown6.Remove(theCard);

                                        if (Settings.gameManager.all_players[i].cardsDown7.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown7.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown8.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown8.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDown9.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDown9.Remove(theCard);



                                        if (Settings.gameManager.all_players[i].cardsDownB.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDownB.Remove(theCard);

                                        if (Settings.gameManager.all_players[i].cardsDownB1.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDownB1.Remove(theCard);


                                        if (Settings.gameManager.all_players[i].cardsDownB2.Contains(theCard))
                                            Settings.gameManager.all_players[i].cardsDownB2.Remove(theCard);

                                        if (Settings.gameManager.all_players[i].handCards.Contains(theCard))
                                            Settings.gameManager.all_players[i].handCards.Remove(theCard);



                                    }

       

                           

                                    Destroy(theCard.gameObject);


                                }
                                else {

                                    int sameLenght = 0;
                                    Card[] sameClass = new Card[100];
                                    int diffLenght = 0;
                                    Card[] diffClass = new Card[100];

                                    ResourcesManager rm = Settings.GetResourcesManager();

                             

                                    for (int i = 0; i < rm.allCards.Length; i++)
                                    {



                                        int tipcl = 0;
                                        j = 0; k = 0;

                                        while ( j < rm.allCards[i].properties.Length)
                                        {
                                            if (rm.allCards[i].properties[j].element.name == "Rarity")
                                            {
                                                if (rm.allCards[i].properties[j].sprite.name == rarities[cardR + option])
                                                    k = 1;

                                            }


                                            if (rm.allCards[i].properties[j].element.name == "Rarity")
                                            {
                                                if (rm.allCards[i].properties[j].sprite.name == rarities[cardR + option])
                                                    k = 1;

                                            }


                                            if (rm.allCards[i].properties[j].element.name == "Class")
                                            {
                                                if (rm.allCards[i].properties[j].StringValue == theclass)  tipcl = 1;
                                                else tipcl = 0;

                                            }



                                            j++;
                                        }



                                        if (k == 1 && rm.allCards[i].cardType==theCard.viz.card.cardType)
                                        {
                                            if (tipcl == 1) {
                                                sameClass[sameLenght] = rm.allCards[i];
                                                sameLenght++;

                                            }
                                            else {
                                                diffClass[diffLenght] = rm.allCards[i];
                                                diffLenght++;

                                            }



                                        }



                                    }




                                    if(diffLenght + sameLenght >0)
                                    {
                                        luck = UnityEngine.Random.Range(0, 4);

                                        Card newCard;

                                        if ((luck < 3 && sameLenght > 0) || diffLenght == 0)
                                               newCard = sameClass[UnityEngine.Random.Range(0, sameLenght)];
                                        else newCard = diffClass[UnityEngine.Random.Range(0, diffLenght)];





                                        GameObject go = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
                                        CardViz v = go.GetComponent<CardViz>();
                                        v.LoadCard(rm.GetCardInstance(newCard.name));
                                        CardInstance inst = go.GetComponent<CardInstance>();


                                        if(Settings.gameManager.turns[0].player.IsMyBuilding(theCard) || Settings.gameManager.turns[0].player.IsMyTroop(theCard))
                                          inst.currentLogic = Settings.gameManager.turns[0].player.downLogic;
                                        else
                                        {
                                            if (Settings.gameManager.turns[1].player.IsMyBuilding(theCard) || Settings.gameManager.turns[1].player.IsMyTroop(theCard))
                                                inst.currentLogic = Settings.gameManager.turns[1].player.downLogic;
                                            else inst.currentLogic = Settings.gameManager.currentPlayer.handLogic;

                                        }


                                        inst.viz = v;
  

                                        inst.nrAttacksDone = 0;


                                        if (Settings.gameManager.currentPlayer.handCards.Contains(theCard))
                                            Settings.RegisterEvent(Settings.gameManager.currentPlayer.username + "'s ??? -> ???", Settings.gameManager.currentPlayer.playerColor);
                                        else
                                        {

                                            if(Settings.gameManager.currentPlayer.IsMyBuilding(theCard) || Settings.gameManager.currentPlayer.IsMyTroop(theCard))
                                                Settings.RegisterEvent(Settings.gameManager.currentPlayer.username + "'s " +
                                                    theCard.viz.card.name + " -> " + newCard.name, Settings.gameManager.currentPlayer.playerColor);
                                            else Settings.RegisterEvent(Settings.gameManager.all_players[1- Settings.gameManager.turnIndex].username + "'s " +
                                                    theCard.viz.card.name + " -> " + newCard.name, Settings.gameManager.currentPlayer.playerColor);



                                        }



                                        for (int i =0;i<=1;i++)
                                        {
                                            if (Settings.gameManager.turns[i].player.cardsDown.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex==1)
                                                {
                                                    if(i==0) Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerTwoHolder.downGrid.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid.value);

                                                } 

                                                Settings.gameManager.turns[i].player.cardsDown.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown1.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid1.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid1.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid1.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown1.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown1.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown2.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid2.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid2.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid2.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown2.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown2.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown3.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid3.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid3.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid3.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown3.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown3.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown4.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid4.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid4.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid4.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown4.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown4.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown5.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid5.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid5.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid5.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown5.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown5.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown6.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid6.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid6.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid6.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown6.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown6.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown7.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid7.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid7.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid7.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown7.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown7.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown8.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid8.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid8.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid8.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown8.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown8.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDown9.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGrid9.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGrid9.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGrid9.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDown9.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDown9.Remove(theCard);
                                            }



                                            if (Settings.gameManager.turns[i].player.cardsDownB.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGridB.value);


                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGridB.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGridB.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDownB.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDownB.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDownB1.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGridB1.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGridB1.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGridB1.value);

                                                }



                                                Settings.gameManager.turns[i].player.cardsDownB1.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDownB1.Remove(theCard);
                                            }

                                            if (Settings.gameManager.turns[i].player.cardsDownB2.Contains(theCard))
                                            {
                                                Settings.SetParentForCard(go.transform,
                                                    Settings.gameManager.turns[i].player.currentHolder.downGridB2.value);

                                                if (Settings.gameManager.switchFailSafe == true && Settings.gameManager.turnIndex == 1)
                                                {
                                                    if (i == 0) Settings.SetParentForCard(go.transform,
                                                              Settings.gameManager.playerTwoHolder.downGridB2.value);
                                                    else Settings.SetParentForCard(go.transform,
                                                           Settings.gameManager.playerOneHolder.downGridB2.value);

                                                }


                                                Settings.gameManager.turns[i].player.cardsDownB2.Add(inst);

                                                Settings.gameManager.turns[i].player.cardsDownB2.Remove(theCard);
                                            }




                                        }


                                        if (Settings.gameManager.currentPlayer.handCards.Contains(theCard))
                                        {

                                            if (Settings.gameManager.switchFailSafe == true)
                                            {
                                                 Settings.SetParentForCard(go.transform,
                                                          Settings.gameManager.playerOneHolder.handGrid.value);
                                               

                                            }
                                            else Settings.SetParentForCard(go.transform,
                                              Settings.gameManager.currentPlayer.currentHolder.handGrid.value);


                                            Settings.gameManager.currentPlayer.handCards.Add(inst);

                                            Settings.gameManager.currentPlayer.handCards.Remove(theCard);
                                        }


                                        if (inst.viz.card.hasCharge == false &&
                                            !Settings.gameManager.currentPlayer.handCards.Contains(inst)
                                            )
                                        {
                                            inst.isFlatfooted = true;
                                            inst.transform.eulerAngles = new Vector3(0, 0, 90);
                                        }

                 
                                        Destroy(theCard.gameObject);



                                        ///  Settings.SetParentForCard(go.transform, Settings.gameManager.currentPlayer.currentHolder.downGrid.value);           

                                        ////  Settings.gameManager.currentPlayer.handCards.Add(inst);



                                    }










                                }


                            }






                            Settings.gameManager.cardToAttack = null;
                            Settings.gameManager.needToSelect = false;

                        }


                    }



                }




            }


        }
          
 




    }
}