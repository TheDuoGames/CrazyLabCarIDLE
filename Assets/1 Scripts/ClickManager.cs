using UnityEngine;
using UnityEngine.Events;
namespace CoreInput
{
    public class ClickManager : MonoBehaviour
    {
        public static UnityEvent OnDropAvaible = new UnityEvent();
        private float dropRate = 0.01f;
        private float timer = -0.5f;
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= dropRate)
            {
                timer = 0;
                OnDropAvaible.Invoke();
            }
            if (Input.GetMouseButtonDown(0))
            {
                timer = 0;
                OnDropAvaible.Invoke();
            }
        }
    }
}
