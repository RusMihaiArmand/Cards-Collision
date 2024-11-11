using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SA.GameStates;
using UnityEngine.EventSystems;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/SelectCardsToAttack")]
    public class SelectCardsToAttack : Action
    {
        public override void Execute(float d)
        {



            if (Input.GetMouseButtonDown(0))
            {
                List<RaycastResult> results = Settings.GetUIObjs();

                foreach (RaycastResult r in results)
                {
                    CardInstance inst = r.gameObject.GetComponentInParent<CardInstance>();


                    if (!Settings.gameManager.currentPlayer.cardsDown.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown2.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown3.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown4.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown5.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown6.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown7.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown8.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDown9.Contains(inst)

                        && !Settings.gameManager.currentPlayer.cardsDownB.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDownB1.Contains(inst)
                        && !Settings.gameManager.currentPlayer.cardsDownB2.Contains(inst)
                        )
                       return;


                    if (inst.CanAttack())
                    {




                    }




                }

            }








        }






    }
}