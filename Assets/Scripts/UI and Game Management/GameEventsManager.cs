using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    
    /*
    *  This script acts as an intermediary between things triggering events that need to pass a reference.
    */

    private static GameEventsManager _instance;
	[HideInInspector] public static GameEventsManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }  
    }
    
    //Add tracked events and their methods below:



    /* uncomment this and the lines in teh decayable to enable this callback
    public event Action<GameObject> OnDecay;
    public void TriggerDecayEvent(GameObject decayedObject)
    {
        OnDecay?.Invoke(decayedObject);
    }
    */
}
