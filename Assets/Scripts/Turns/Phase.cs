﻿using UnityEngine;
using System.Collections;


namespace SA
{
    public abstract class Phase : ScriptableObject
    {
        public bool forceExit;

        public abstract bool IsComplete();

        [System.NonSerialized]
        protected bool isInit;




         public abstract void OnStartPhase();
         public abstract void OnEndPhase();
        

    }
}