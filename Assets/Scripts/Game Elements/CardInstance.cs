using UnityEngine;
using System.Collections;


namespace SA
{
    public class CardInstance : MonoBehaviour, IClickable
    {
        public CardViz viz;
        public SA.GameElements.GE_Logic currentLogic;
        public bool isFlatfooted;
        public int nrAttacksDone = 0;
  

        void Start()
        {
            viz = GetComponent<CardViz>();
        }


        public bool CanAttack()
        {
            bool result = true;


            if (isFlatfooted)
                return false;



            if(this.viz.card.name=="SCP-173")
            {
                PlayerHolder p = Settings.gameManager.currentPlayer;
                PlayerHolder enemy = Settings.gameManager.all_players[0];

                if(enemy==Settings.gameManager.currentPlayer) enemy = Settings.gameManager.all_players[1];

                /// 0-5  cu 4-9
                if ((p.cardsDown.Contains(this) || p.cardsDown5.Contains(this))
                    && (enemy.cardsDown4.Count> 0 || enemy.cardsDown9.Count > 0))
                    return false;



                /// 1-6  cu 3-8
                if ((p.cardsDown1.Contains(this) || p.cardsDown6.Contains(this))
                   && (enemy.cardsDown3.Count > 0 || enemy.cardsDown8.Count > 0))
                    return false;



                /// 2-7  cu 2-7
                if ((p.cardsDown2.Contains(this) || p.cardsDown7.Contains(this))
                    && (enemy.cardsDown2.Count > 0 || enemy.cardsDown7.Count > 0))
                    return false;



                /// 3-8  cu 1-6
                if ((p.cardsDown3.Contains(this) || p.cardsDown8.Contains(this))
                    && (enemy.cardsDown1.Count > 0 || enemy.cardsDown6.Count > 0))
                    return false;



                /// 4-9  cu 0-5
                if ((p.cardsDown4.Contains(this) || p.cardsDown9.Contains(this))
                   && (enemy.cardsDown.Count > 0 || enemy.cardsDown5.Count > 0))
                    return false;





            }

            



            return result;

        }



        public void OnClick()
        {
            if (currentLogic == null) return;


            currentLogic.OnClick(this);
        }

        public void OnHighlight()
        {
            if (currentLogic == null) return;

           
            currentLogic.OnHighlight(this);
        }

    }
}