using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEventSo : ScriptableObject
{
    [Header("¨Æ¥ó")]
    public UnityAction<Character> onEventRaised;

    public void RaiseEvent(Character character) 
    {
        onEventRaised?.Invoke(character);
    }
}
