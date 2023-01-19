using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carousel : MonoBehaviour
{
    [SerializeField]
    RectTransform _root;
    [SerializeField]
    GridLayoutGroup _grid;

    private void OnGUI()
    {
        _grid.cellSize = _root.sizeDelta;
    }
}
