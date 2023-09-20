using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenderDummy : MonoBehaviour
{
    //public delegate void PlayerDied(); // delegate to inform reciever of event occuring
    //public static event PlayerDied playerDiedInfo; // event that the reciever subscribed to

    //public delegate void WithParameters(bool param);
    //public static event WithParameters withParametersInfo;

    //public delegate float WithReturn();
    //public static event WithReturn withReturnInfo;


    // Start is called before the first frame update
   // void Start()
   // {
   //     // this line usually doesn't exist because events are usually triggered after the start function is already done (during gameplay)
   //     Invoke("ExecuteEvent", 5f); // invoke calls the function with the name in first argument after num secs in 2nd argument has passed
   //                                 // from executing this line
   // }

   //private void ExecuteEvent() // our function used to notify any reciever of event
   // {
   //     if(playerDiedInfo != null) // if there exists subscribers
   //     {
   //         playerDiedInfo(); // call on event (notify), this will cause listener in Rx to execute
   //     }

   //     if(withParametersInfo != null)
   //     {
   //         withParametersInfo(true); // pass the argument needed in the listener
   //     }

   //     if (withReturnInfo != null)
   //     {
   //         withReturnInfo();
   //     }
   // }
}
