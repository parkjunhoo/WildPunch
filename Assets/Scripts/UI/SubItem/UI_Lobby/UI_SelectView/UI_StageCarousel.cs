using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StageCarousel
{
    public class UI_StageCarousel : MonoBehaviour
    {
        bool _isSet;

        public static int Index;

        [SerializeField]
        RectTransform _root;
        [SerializeField]
        GridLayoutGroup _grid;

        RectTransform _rt;

        public int cellSizeX;

        private void Awake()
        {
            _rt = transform as RectTransform;
        }

        private void OnGUI()
        {
            if (_isSet) return;
            Setting();
        }

        public void Setting()
        {
            _isSet = true;
            _grid.cellSize = _root.sizeDelta;
            _rt.anchoredPosition = new Vector2(_grid.cellSize.x * -Index, _rt.anchoredPosition.y);
        }

        private void Update()
        {
            _rt.anchoredPosition = new Vector2(Mathf.Lerp(_rt.anchoredPosition.x, -Index * _grid.cellSize.x, 15f * Time.deltaTime), _rt.anchoredPosition.y);
        }
    }
}
