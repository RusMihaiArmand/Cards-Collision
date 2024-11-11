using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Holders/Card Holder")]
    public class CardHolders : ScriptableObject
    {

        public SO.TransformVariable handGrid;

        public SO.TransformVariable downGrid;
        public SO.TransformVariable downGrid1;
        public SO.TransformVariable downGrid2;
        public SO.TransformVariable downGrid3;
        public SO.TransformVariable downGrid4;
        public SO.TransformVariable downGrid5;
        public SO.TransformVariable downGrid6;
        public SO.TransformVariable downGrid7;
        public SO.TransformVariable downGrid8;
        public SO.TransformVariable downGrid9;

        public SO.TransformVariable downGridB;
        public SO.TransformVariable downGridB1;
        public SO.TransformVariable downGridB2;


        public SO.TransformVariable playerCardGrid;

        [System.NonSerialized]
        public PlayerHolder playerHolder;


       

        public void LoadPlayer(PlayerHolder p, PlayerStatsUI statsUI)
        {

            if (p == null) return;

            playerHolder = p;

            foreach (CardInstance c in p.cardsDown)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }

            foreach (CardInstance c in p.cardsDown1)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid1.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }

            foreach (CardInstance c in p.cardsDown2)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid2.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }

            foreach (CardInstance c in p.cardsDown3)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid3.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }


            foreach (CardInstance c in p.cardsDown4)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid4.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }



            foreach (CardInstance c in p.cardsDown5)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid5.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }



            foreach (CardInstance c in p.cardsDown6)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid6.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }



            foreach (CardInstance c in p.cardsDown7)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid7.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }

            foreach (CardInstance c in p.cardsDown8)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid8.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }

            foreach (CardInstance c in p.cardsDown9)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGrid9.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }











            foreach (CardInstance c in p.cardsDownB)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGridB.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }


            foreach (CardInstance c in p.cardsDownB1)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGridB1.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }


            foreach (CardInstance c in p.cardsDownB2)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, downGridB2.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }


            foreach (CardInstance c in p.thePlayerCard)
            {
                Settings.SetParentForCard(c.viz.gameObject.transform, playerCardGrid.value.transform);
                if (c.isFlatfooted) c.viz.transform.localEulerAngles = new Vector3(0, 0, 90);
            }



            foreach (CardInstance c in p.handCards)
            {
                if (c.viz == null) Debug.Log("HoldUP");
                else
                {
                  
                    Settings.SetParentForCard(c.viz.gameObject.transform, handGrid.value.transform);
                }
            }


            p.statsUI = statsUI;
            p.LoadPlayerOnStatsUI();


        }


    }
}