using UnityEngine;

public class DecayAction : MonoBehaviour, IDecayAction
{   

    /* SCRIPTBALE EVENT METHOD: uncomment this and the _onDecayEvent raise action below to enable the schell scriptable events method. 
     * Use this if you don't need a reference to what decayed
    */
    //[SerializeField] protected GameEvent _onDecayEvent = null;
    
    public void Decay(){
        
        /* SCRIPTBALE EVENT METHOD: uncomment this and the serialized field above to enable the schell scriptable events method */
        /*
        if (_onDecayEvent != null)
        {
            _onDecayEvent?.Raise();
        } else {
            Debug.Log("No decay event set on this decayable.");
        }
        */

        /*  EVENT MANAGE METHOD: Uncomment to enable the game events manager singleton method - use this if you want a reference to what decayed. */
        //  GameEventsManager.Instance.TriggerDecayEvent(gameObject);

        Destroy(gameObject); //destroy this game object
    }
}
