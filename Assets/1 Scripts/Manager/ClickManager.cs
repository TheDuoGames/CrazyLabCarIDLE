using UnityEngine;
using UnityEngine.Events;
namespace CoreInput
{
    public class ClickManager : MonoBehaviour
    {
        public static UnityEvent OnDropAvaible = new UnityEvent();
        private float dropRate => 1 / UpgradeManager.Instance.currentSpeedBonus;
        private float timer = -0.1f;
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
