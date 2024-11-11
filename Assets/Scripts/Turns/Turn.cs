using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Turns/Turn")]
    public class Turn : ScriptableObject
    {
        //[System.NonSerialized]
       // public int index = 0;
        //public Phase[] phases;


        public bool forceExit;

        // public abstract bool IsComplete();

        public PlayerHolder player;




        [System.NonSerialized]
        protected bool isInit;

        public GameStates.State playerControlState;


        public PlayerAction[] turnStartActions;


        public void OnTurnStart()
        {

            if (turnStartActions == null) return;


            for(int i=0; i<turnStartActions.Length; i++)
            {
                turnStartActions[i].Execute(player);


            }


        }



        public bool Execute()
        {

            /*
            bool result = false;


            phases[index].OnStartPhase();



            bool phaseIsComplete = phases[index].IsComplete();

            if(phaseIsComplete)
            {
                phases[index].OnEndPhase();

                index++;

                if(index>phases.Length-1)
                {
                    index = 0;
                    result = true;
                }

            }

            return result;
            */


            bool result = false;


            OnStartTurn();



            bool turnIsComplete = IsCompleteT();

            if (turnIsComplete)
            {
                OnEndTurn();

                result = true;

            }

            return result;

        }



        public bool IsCompleteT()
        {
            if (forceExit)
            {
                forceExit = false;
                return true;
            }

            return false;
        }


        public void OnEndTurn()
        {

            if (isInit)
            {
                Settings.gameManager.SetState(null);

                isInit = false;

            }


        }

        public void OnStartTurn()
        {
            
            if (!isInit)
            {

                Settings.gameManager.SetState(playerControlState);


                isInit = true;

            }

        }



    }
}