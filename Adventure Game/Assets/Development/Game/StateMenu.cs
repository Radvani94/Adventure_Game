using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpace
{
    
    public class StateMenu : GenericState
    {
        public void StateEntry()
        {
            Debug.Log("MENU ENTRY");
        }

        public void StateUpdate()
        {
           
        }

        public void StateExit()
        {
            Debug.Log("MENU EXIT");
        }
    }
}
