using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FeedbackSystem
{
    public class VisualizableCar : MonoBehaviour
    {
        public string nameOfTheCar;
        public Color backgroundColorOfCar;
        public Color outlineColorOfCar;

        private void OnEnable()
        {
            CarInfoBar.instance.SetValues(nameOfTheCar, backgroundColorOfCar, outlineColorOfCar);
        }
    } 
}
