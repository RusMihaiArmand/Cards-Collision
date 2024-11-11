using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.GameStates;
using UnityEngine.UI;

namespace SA
{
    public class GameManager : MonoBehaviour
    {
        [System.NonSerialized]
        public PlayerHolder[] all_players;
        public PlayerHolder currentPlayer;
        public CardHolders playerOneHolder;
        public CardHolders playerTwoHolder;

        public bool switchFailSafe = true;

        public State currentState;
        public GameObject cardPrefab;

        public int turnIndex;
        public Turn[] turns;
        public SO.GameEvent onTurnChanged;
        public SO.StringVariable turnText;


        [System.NonSerialized]
        bool justStarted;


        public PlayerStatsUI[] statsUI;

        public static GameManager singleton;

        public CardInstance copyCard;
        public CardInstance cardToAttack;

        [System.NonSerialized]
        public List<CardInstance> optionCards = new List<CardInstance>();

        [System.NonSerialized]
        public List<CardInstance> cardsThatCanBeSelected = new List<CardInstance>();

        public Text endText;

        public SO.TransformVariable optionCardsGrid;
        public int selectedOption;

        //Settings.SetParentForCard(go.transform, Settings.gameManager.optionCardsGrid.value);
        // Settings.gameManager.optionCards.Add(inst);



        public bool needToSelect=false;


        private void Awake()
        {
            singleton = this;

            all_players = new PlayerHolder[turns.Length];

            for(int i = 0; i<turns.Length; i++)
            {
                all_players[i] = turns[i].player;

                all_players[i].Init();

            }

            currentPlayer = turns[0].player;
           

        }



        private void Start()
        {
            endText.text = "";

            Settings.gameManager = this;


            for (int i = 0; i < 2; i++)
            {
                
                turns[i].player.mana = 0;
                turns[i].player.health = 5000;
                turns[i].player.maxHealth = 5000;

            }



            SetupPlayers();

           


            CreateStartingCards();







            turnText.value = turns[turnIndex].player.username;

          

            turns[0].player.mana += 5;
            Settings.gameManager.statsUI[0].mana.text = Settings.gameManager.currentPlayer.mana.ToString();


            onTurnChanged.Raise();

            justStarted = true;

            PickNewCardFromDeck(turns[0].player);
            PickNewCardFromDeck(turns[1].player);

            PickNewCardFromDeck(turns[0].player);
            PickNewCardFromDeck(turns[1].player);

            PickNewCardFromDeck(turns[0].player);
            PickNewCardFromDeck(turns[1].player);

            justStarted = false;

            turns[0].OnTurnStart();
            ///  PickNewCardFromDeck(currentPlayer);
            ///  

            turns[0].player.statsUI.UpdateAll();
            turns[1].player.statsUI.UpdateAll();
        }

        void SetupPlayers()
        {
            for(int i=0; i< all_players.Length; i++)
            {
                if(i==0)
                {
                    all_players[i].currentHolder = playerOneHolder;

                }
                else
                {
                    all_players[i].currentHolder = playerTwoHolder;
                }



                ResourcesManager rm = Settings.GetResourcesManager();

                GameObject go = Instantiate(cardPrefab) as GameObject;
                CardViz v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance("Me Card"));
                CardInstance inst = go.GetComponent<CardInstance>();
                inst.currentLogic = all_players[i].downLogic;
                ///  Settings.SetParentForCard(go.transform, turns[i].player.currentHolder.playerCardGrid.value.transform);



                go.transform.SetParent(all_players[i].currentHolder.playerCardGrid.value.transform);
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = Vector3.zero;
                go.transform.localScale = new Vector3(0.85f, 0.74f, 0.89f);


                inst.viz = v;


                all_players[i].playerCard = inst;

                foreach (Transform child in inst.transform)
                {

                    if (child.name == "CardTemplate") {

                        foreach (Transform child2 in child)
                        {

                            if (child2.name == "Background")
                            {
                                Destroy(child2.gameObject);
                            }



                        }


                    }




                }


                all_players[i].thePlayerCard.Add(inst); ///!

                all_players[i].statsUI = statsUI[i];
                statsUI[i].player.LoadPlayerOnStatsUI();

                


                Settings.gameManager.statsUI[i].mana.text = Settings.gameManager.all_players[i].mana.ToString();

               /// all_players[i].Init();
            }



        }

        void CreateStartingCards()
        {
          ///  ResourcesManager rm = Settings.GetResourcesManager();

            for (int p = 0; p < all_players.Length; p++)
            {

                /*
              for (int i = 0; i < all_players[p].startingCards.Length; i++)
               {
                GameObject go = Instantiate(cardPrefab) as GameObject;
                CardViz v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance(all_players[p].startingCards[i]));
                CardInstance inst = go.GetComponent<CardInstance>();
                inst.currentLogic = all_players[p].handLogic;
                Settings.SetParentForCard(go.transform, all_players[p].currentHolder.handGrid.value);

                all_players[p].handCards.Add(inst);

               }
               */



                all_players[p].currentHolder.LoadPlayer(all_players[p] , all_players[p].statsUI );
                 
            }

        }

        public void PickNewCardFromDeck(PlayerHolder p)
        {
            if (p.all_cards.Count == 0)
            {
                if (justStarted == false)
                {
                    bool itf = false;



                    foreach (CardInstance c in p.cardsDownB)
                        if (c.viz.card.name == "Gym") itf = true;


                    foreach (CardInstance c in p.cardsDownB1)
                        if (c.viz.card.name == "Gym") itf = true;


                    foreach (CardInstance c in p.cardsDownB2)
                        if (c.viz.card.name == "Gym") itf = true;




                    if (itf == true) {

                        Settings.RegisterEvent(p.username + " blocked " +
                           p.fatiqueDmg + " fatique damage", p.playerColor);




                    }
                    else {
                        p.health -= p.fatiqueDmg;

                        Settings.RegisterEvent(p.username + " took " +
                            p.fatiqueDmg + " fatique damage", p.playerColor);
                    }
                    


                    p.fatiqueDmg += 50;


                    p.statsUI.health.text = p.health.ToString();
                }

            }
            else
            {
                string cardId = p.all_cards[0];
                p.all_cards.RemoveAt(0);


                if(p.handCards.Count>=10)
                    Settings.RegisterEvent(p.username + "'s " +  cardId + " burned " , p.playerColor);
                else {

                    ResourcesManager rm = Settings.GetResourcesManager();


                    GameObject go = Instantiate(cardPrefab) as GameObject;
                    CardViz v = go.GetComponent<CardViz>();
                    v.LoadCard(rm.GetCardInstance(cardId));
                    CardInstance inst = go.GetComponent<CardInstance>();
                    inst.currentLogic = p.handLogic;

                    Settings.SetParentForCard(go.transform, p.currentHolder.handGrid.value);

                    p.handCards.Add(inst);

                    if (justStarted == false)
                    {
                        if (Settings.gameManager.switchFailSafe == true)
                            Settings.SetParentForCard(go.transform, Settings.gameManager.playerOneHolder.handGrid.value.transform);
                        else Settings.SetParentForCard(go.transform, Settings.gameManager.turns[Settings.gameManager.turnIndex].player.currentHolder.handGrid.value.transform);



                    }
                    else Settings.SetParentForCard(go.transform, p.currentHolder.handGrid.value.transform);



                }




            }


            p.statsUI.UpdateAll();



        }



        public void LoadPlayerOnActive(PlayerHolder p)
        {

            if (playerOneHolder.playerHolder != p)
            {
                PlayerHolder prevPlayer = playerOneHolder.playerHolder;

                LoadPlayerOnHolder(prevPlayer, playerTwoHolder, statsUI[1]);

                LoadPlayerOnHolder(p, playerOneHolder, statsUI[0]);
            }




        }




        public void LoadPlayerOnHolder(PlayerHolder p,CardHolders h, PlayerStatsUI ui)
        {
            h.LoadPlayer(p, ui);

        }





        public bool switchPlayer;
      ///  int switchState = 0;


        private void Update()
        {
            
            if(all_players[0].health<=0 || all_players[1].health<=0)
            {
                needToSelect = true;


                //p0 castiga
                if (all_players[0].health > 0 && all_players[1].health <= 0)
                {
                    endText.text = all_players[0].username + " WON";
                    endText.color = all_players[0].playerColor;
                }


                if (all_players[1].health > 0 && all_players[0].health <= 0)
                {
                    endText.text = all_players[1].username + " WON";
                    endText.color = all_players[1].playerColor;
                }



                if (all_players[0].health <= 0 && all_players[1].health <= 0)
                    endText.text = "TIE";



            }



            bool isComplete = turns[turnIndex].Execute();

            if (isComplete)
            {

                
                turnIndex++;
                
                if (turnIndex > turns.Length -1)
                {
                    turnIndex = 0;
                }
                turns[turnIndex].player.mana += 5;

                statsUI[0].mana.text = all_players[turnIndex].mana.ToString();
                ///statsUI[1].mana.text = all_players[1-turnIndex].mana.ToString();


                currentPlayer = turns[turnIndex].player;
                turns[turnIndex].OnTurnStart();

                turnText.value = turns[turnIndex].player.username;
              
                onTurnChanged.Raise();


              //  PickNewCardFromDeck(currentPlayer);


            }

            if (currentState != null)
            currentState.Tick(Time.deltaTime);

        }


        public void SetState(State state)
        {
            currentState = state;

        }


        public bool mustEndTurn = false;


        public void TheTurnEnd()
        {

            StartCoroutine(EndingTurn());

            EndingTurn();

        }


        public IEnumerator EndingTurn()
        {

            mustEndTurn = true;

            yield return new WaitUntil(() => needToSelect == false);

            EndCurrentTurn();

        }


        public void EndCurrentTurn()
        {
            

            foreach (CardInstance c in currentPlayer.cardsDown)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown1)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown2)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown3)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown4)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown5)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown6)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown7)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown8)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDown9)
                c.viz.card.ExecuteOnTurnEnd();



            foreach (CardInstance c in currentPlayer.cardsDownB)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDownB1)
                c.viz.card.ExecuteOnTurnEnd();

            foreach (CardInstance c in currentPlayer.cardsDownB2)
                c.viz.card.ExecuteOnTurnEnd();





            mustEndTurn = false;
            turns[turnIndex].forceExit = true;
            switchPlayer = true;
            cardToAttack = null;
        }


        public IEnumerator WaitCondSelectOption(CardInstance instance)
        {



            yield return new WaitUntil(() => (cardToAttack != null && cardsThatCanBeSelected.Contains(cardToAttack) ) ||mustEndTurn==true );

            if (mustEndTurn == true) cardToAttack = cardsThatCanBeSelected[UnityEngine.Random.Range(0, cardsThatCanBeSelected.Count)];



           if(instance.viz.card.cardType.name=="Building") instance.viz.card.ExecuteAbility(instance);
               else instance.viz.card.ExecuteOnPlay(instance);
        }


 


    }
}