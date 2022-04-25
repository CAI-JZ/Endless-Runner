using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Pause : MonoBehaviour
{
    [SerializeField] GameObject DefaultSelect;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DefaultSelect);
    }


}
