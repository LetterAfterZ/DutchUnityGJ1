﻿using UnityEngine;

public class Decayable : MonoBehaviour
{
    [SerializeField] private float _decay = 100f;
    [SerializeField] private float _decayRate = 5f;
    private IDecayAction _decayAction = null;
    
    [SerializeField] private bool requireTrigger = false; // require an external action to trigger this decay or just start decaying immediately
    private bool _decayEnabled = true;
    
    private void Start()
    {
        if (requireTrigger)
            _decayEnabled = false;

        _decayAction = GetComponent<IDecayAction>();
    }

    private void Update()
    {
        if (_decayEnabled)
		    TickDecay();
    }

    private void TickDecay()
    {
		_decay -= Time.deltaTime * _decayRate;
		if (_decay <= 0)
			TriggerDecay();		
	}

	private void TriggerDecay()
    {        
        _decayAction.Decay();
    }

    public void EnableDecay(GameObject decayObject)
    {
        if(decayObject == this.gameObject)
            _decayEnabled = true;
    }

}