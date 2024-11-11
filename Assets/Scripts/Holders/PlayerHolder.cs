using SA.GameElements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    [CreateAssetMenu(menuName ="Holders/Player Holder")]
    public class PlayerHolder : ScriptableObject
    {
        public string username;
        public Color playerColor;
        public int mana = 0;
       /// public string[] startingCards;

        public List<string> startingDeck = new List<string>();

        [System.NonSerialized]
        public List<string> all_cards = new List<string>();

        [System.NonSerialized]
        public List<string> graveyard_cards = new List<string>();
        

        [System.NonSerialized]
        public int fatiqueDmg;

        public bool isHumanPlayer;


        public Sprite head;
        public Sprite eyes;
        public Sprite beard;
        public Sprite ears;
        public Sprite eyebrows;
        public Sprite hat;
        public Sprite moustache;
        public Sprite mouth;
        public Sprite nose;

        public int health = 5000;
        public int maxHealth = 5000;


        public PlayerStatsUI statsUI;

        public GE_Logic handLogic;
        public GE_Logic downLogic;


        [System.NonSerialized]
        public CardHolders currentHolder;



        [System.NonSerialized]
        public List<CardInstance> handCards = new List<CardInstance>();

        [System.NonSerialized]
        public List<CardInstance> cardsDown = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown1 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown2 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown3 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown4 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown5 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown6 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown7 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown8 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDown9 = new List<CardInstance>();


        [System.NonSerialized]
        public List<CardInstance> cardsDownB = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDownB1 = new List<CardInstance>();
        [System.NonSerialized]
        public List<CardInstance> cardsDownB2 = new List<CardInstance>();


        [System.NonSerialized]
        public List<CardInstance> thePlayerCard = new List<CardInstance>();


        public CardInstance playerCard;


        public void TemporaryDeckMaker()
        {
            ///a fi folosti doar pana fac optiunea de a crea pachet.dupa da-i delete
            ///p.s. I'm awesome

            startingDeck.Clear();


            ResourcesManager rm = Settings.GetResourcesManager();

            List<string> adeableCards = new List<string>();
            int l = 0;

            int i, j;

            for ( i = 0; i < rm.allCards.Length; i++)
            {


                int  k,nrcop=0;

                j = 0; k = 1;

                if (rm.allCards[i].name == "Black Crewmate" || rm.allCards[i].name == "Black Impostor" ||
                    rm.allCards[i].name == "Blue Crewmate" || rm.allCards[i].name == "Blue Impostor" ||
                    rm.allCards[i].name == "Brown Crewmate" || rm.allCards[i].name == "Brown Impostor" ||
                    rm.allCards[i].name == "Cyan Crewmate" || rm.allCards[i].name == "Cyan Impostor" ||
                    rm.allCards[i].name == "Green Crewmate" || rm.allCards[i].name == "Green Impostor" ||
                    rm.allCards[i].name == "Lime Crewmate" || rm.allCards[i].name == "Lime Impostor" ||
                    rm.allCards[i].name == "Orange Crewmate" || rm.allCards[i].name == "Orange Impostor" ||
                    rm.allCards[i].name == "Pink Crewmate" || rm.allCards[i].name == "Pink Impostor" ||
                    rm.allCards[i].name == "Purple Crewmate" || rm.allCards[i].name == "Purple Impostor" ||
                    rm.allCards[i].name == "Red Crewmate" || rm.allCards[i].name == "Red Impostor" ||
                    rm.allCards[i].name == "White Crewmate" || rm.allCards[i].name == "White Impostor" ||
                    rm.allCards[i].name == "Yellow Crewmate" || rm.allCards[i].name == "Yellow Impostor")
                    k = 0;




                while (k == 1 && j < rm.allCards[i].properties.Length)
                {
                    if (rm.allCards[i].properties[j].element.name == "Rarity")
                    {
                        nrcop = 0;

                        if (rm.allCards[i].properties[j].sprite.name == "model comuna") nrcop = 5;
                        if (rm.allCards[i].properties[j].sprite.name == "model necomuna") nrcop = 4;
                        if (rm.allCards[i].properties[j].sprite.name == "model rara") nrcop = 3;
                        if (rm.allCards[i].properties[j].sprite.name == "model epica") nrcop = 2;
                        if (rm.allCards[i].properties[j].sprite.name == "model legendara") nrcop = 1;


                        if (nrcop == 0) k = 0;
                    }







                    j++;
                }


                for (j = 1; j <= nrcop; j++)
                    adeableCards.Add( rm.allCards[i].name);
                       
                
            }

            l = adeableCards.Count;


            if (l <= 30) startingDeck = adeableCards;
            else
            {
                int l2;

                for(i=1;i<=30;i++)
                {
                    l2 = UnityEngine.Random.Range(0, l);

                    startingDeck.Add(adeableCards[l2]);

                    adeableCards.RemoveAt(l2);

                    l--;



                }
                


            }

        }


        public void Init()
        {

          ///  all_cards.AddRange(startingDeck);
            
             fatiqueDmg=100;
            graveyard_cards.Clear();

            TemporaryDeckMaker(); //to be removed at a later point

            int L = startingDeck.Count;

            int[] shuffled = new int[50];

            for (int i = 0; i < L; i++)
                shuffled[i] = 0;

            int x;
            for (int i = 0; i < L; i++)
            {
                x= UnityEngine.Random.Range(0, L);

                while(shuffled[x]==1) x = UnityEngine.Random.Range(0, L);

                shuffled[x] = 1;

                all_cards.Add(startingDeck[x]);


            }



        }
      

        public bool IsMyTroop(CardInstance c)
        {
            if (cardsDown.Contains(c) ||
                cardsDown1.Contains(c) ||
                cardsDown2.Contains(c) ||
                cardsDown3.Contains(c) ||
                cardsDown4.Contains(c) ||
                cardsDown5.Contains(c) ||
                cardsDown6.Contains(c) ||
                cardsDown7.Contains(c) ||
                cardsDown8.Contains(c) ||
                cardsDown9.Contains(c)
                  ) return true;
            else return false;

        }


        public bool IsFrontTroop(CardInstance c)
        {
            if (cardsDown.Contains(c) ||
                cardsDown1.Contains(c) ||
                cardsDown2.Contains(c) ||
                cardsDown3.Contains(c) ||
                cardsDown4.Contains(c)
                  ) return true;
            else return false;

        }


        public bool IsBackTroop(CardInstance c)
        {
            if ( cardsDown5.Contains(c) ||
                cardsDown6.Contains(c) ||
                cardsDown7.Contains(c) ||
                cardsDown8.Contains(c) ||
                cardsDown9.Contains(c)
                  ) return true;
            else return false;

        }


        public bool IsBackBuilding(CardInstance c)
        {
            if (cardsDownB2.Contains(c)) return true;
            else return false;

        }


        public bool IsFrontBuilding(CardInstance c)
        {
            if (cardsDownB.Contains(c) || cardsDownB1.Contains(c)) return true;
            else return false;

        }



        public bool HasFrontTroops()
        {
            if (cardsDown.Count + cardsDown1.Count + cardsDown2.Count + cardsDown3.Count + cardsDown4.Count >0 )
                return true;
            else return false;

        }


        public bool HasFrontBuildings()
        {
            if (cardsDownB.Count + cardsDownB1.Count > 0)
                return true;
            else return false;

        }



        public bool IsMyBuilding(CardInstance c)
        {
            if (cardsDownB.Contains(c) ||  cardsDownB1.Contains(c) ||  cardsDownB2.Contains(c) ) return true;
            else return false;
        }


        public int NrTroops()
        {
            int nr = 0;


            nr += cardsDown.Count;
            nr += cardsDown1.Count;
            nr += cardsDown2.Count;
            nr += cardsDown3.Count;
            nr += cardsDown4.Count;
            nr += cardsDown5.Count;
            nr += cardsDown6.Count;
            nr += cardsDown7.Count;
            nr += cardsDown8.Count;
            nr += cardsDown9.Count;

            return nr;
        }

        public int NrBuldings()
        {
            int nr = 0;


            nr += cardsDownB.Count;
            nr += cardsDownB1.Count;
            nr += cardsDownB2.Count;
            

            return nr;
        }



        public bool CanUseCard(CardInstance inst)
        {
            bool result = false;


            int cardcost = 0;


            for (int i = 0; i < inst.viz.properties.Length; i++)
            {
                if (inst.viz.properties[i].element.name == "Cost")
                {
                    cardcost = Int16.Parse(inst.viz.properties[i].text.text);
                }



            }





            if (cardcost <= mana)
                result = true;



            if (inst.viz.card.name == "Among Us") {

                if (this.NrTroops() > 0) return false;

            }










            return result;
        }

        public void DropCard(CardInstance inst, int location)
        {
            if (handCards.Contains(inst))
                handCards.Remove(inst);

            if (location==0) cardsDown.Add(inst);
            if (location ==1) cardsDown1.Add(inst);
            if (location ==2) cardsDown2.Add(inst);
            if (location ==3) cardsDown3.Add(inst);
            if (location ==4) cardsDown4.Add(inst);
            if (location ==5) cardsDown5.Add(inst);
            if (location ==6) cardsDown6.Add(inst);
            if (location ==7) cardsDown7.Add(inst);
            if (location ==8) cardsDown8.Add(inst);
            if (location ==9) cardsDown9.Add(inst);
            if (location ==10) cardsDownB.Add(inst);
            if (location ==11) cardsDownB1.Add(inst);
            if (location ==12) cardsDownB2.Add(inst);



            
        }

        public void LoadPlayerOnStatsUI()
        {
            if (statsUI != null)
            {
                statsUI.player = this;
                statsUI.UpdateAll();


            }

        }

    }
}