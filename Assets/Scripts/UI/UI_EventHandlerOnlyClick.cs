using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandlerOnlyClick : MonoBehaviour, IPointerClickHandler
{
    public Action<PointerEventData> OnOnlyClickHandler = null;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (OnOnlyClickHandler != null)
            OnOnlyClickHandler.Invoke(eventData);
	}
}
