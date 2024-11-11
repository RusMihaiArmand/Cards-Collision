using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SA
{
    public static class Settings
    {

        public static GameManager gameManager;

     

        private static ResourcesManager _resourcesManager;

        private static ConsoleHook _consoleManager;

        

        public static void RegisterEvent(string e, Color color)
        {
            if(_consoleManager == null)
            {
                _consoleManager = Resources.Load("ConsoleHook") as ConsoleHook;
            }



            _consoleManager.RegisterEvent(e, color);



        }

        public static ResourcesManager GetResourcesManager()
        {

            if(_resourcesManager == null)
            {
                _resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
                _resourcesManager.Init();
            }

            return _resourcesManager;
        }

        public static List<RaycastResult> GetUIObjs()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            return results;

        }

        



        public static void DropCreatureCard(Transform c, Transform p, CardInstance cardInst, int location)
        {
            if(!cardInst.viz.card.hasCharge)
             cardInst.isFlatfooted = true;
            else cardInst.isFlatfooted = false;
            //Execute special abilities - "BATTLECRY"

            SetParentForCard(c, p);
            
            if(cardInst.isFlatfooted == true)
            {
                c.eulerAngles = new Vector3(0, 0, 90);


            }



            gameManager.currentPlayer.DropCard(cardInst, location);

        }

        public static void SetParentForCard(Transform c, Transform p)
        {
            c.SetParent(p);
            c.localPosition = Vector3.zero;
            c.localEulerAngles = Vector3.zero;
            c.localScale = new Vector3(0.85f, 0.74f, 0.89f);

        }

    }
}