using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        
    }

    void Update()
    {
        ManageState();
        
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        // var = State[] --> posso usar o var quando eu declaro uma variável e a inicializo também

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
            textComponent.text = state.GetStateStory();
            
        }
    }
}
