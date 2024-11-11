using UnityEngine;
using System.Collections;

namespace SA.GameElements
{

    [CreateAssetMenu(menuName ="Game Elements/My Hand Card")]
    public class HandCard : GE_Logic
    {
        public SO.GameEvent onCurrentCardSelected;   
        public CardVariable currentCard;
        public SA.GameStates.State holdingCard;

        public override void OnClick(CardInstance inst)
        {


            if (Settings.gameManager.needToSelect == false)
            {
                Settings.gameManager.copyCard = inst;

                if (Settings.gameManager.currentPlayer.handCards.Contains(inst))
                {
                    Settings.gameManager.cardToAttack = null;
                    currentCard.Set(inst);
                    Settings.gameManager.SetState(holdingCard);
                    onCurrentCardSelected.Raise();
                }


            }
            else Settings.gameManager.cardToAttack = inst;
        }

        

        public override void OnHighlight(CardInstance inst)
        {
          
        }
    }
}