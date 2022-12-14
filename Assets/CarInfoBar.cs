using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace FeedbackSystem
{
    public class CarInfoBar : MonoBehaviour
    {
        [SerializeField] Image backgroundImage;
        [SerializeField] Outline outline;
        [SerializeField] TextMeshProUGUI nameTMP;
        public static CarInfoBar instance;
        private void Awake() => instance = this;
        public void SetValues(string name, Color backgroundColor, Color outlineColor)
        {
            nameTMP.text = name;
            backgroundImage.color = backgroundColor;
            outline.effectColor = outlineColor;
        }
    } 
}
