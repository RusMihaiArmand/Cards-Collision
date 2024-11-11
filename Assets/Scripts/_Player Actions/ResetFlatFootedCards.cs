using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Player Actions/Reset Flat Foot")]
    public class ResetFlatFootedCards : PlayerAction
    {
        public override void Execute(PlayerHolder player)
        {
           
            foreach (CardInstance c in player.cardsDown)
            {
                c.nrAttacksDone = 0;
                if(c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown1)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown2)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown3)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown4)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown5)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown6)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown7)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown8)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDown9)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }








            foreach (CardInstance c in player.cardsDownB)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDownB1)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }


            foreach (CardInstance c in player.cardsDownB2)
            {
                c.nrAttacksDone = 0;
                if (c.isFlatfooted)
                {
                    c.viz.transform.localEulerAngles = Vector3.zero;
                    c.isFlatfooted = false;
                }
            }



        }




    }
}