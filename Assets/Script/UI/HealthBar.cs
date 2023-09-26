using PoketZone;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Unit _canBeDamaged;
        protected Slider Slider { get => _slider; set => value = _slider; }

        private void OnEnable()
        {
            _canBeDamaged.OnUnitHealtChanged += OnValueChanged;
            _slider.value = 1;
        }
        public void OnValueChanged(int value, int maxValue)
        {
            Slider.value = (float) value/maxValue;
        }
        private void OnDisable() 
        {
            _canBeDamaged.OnUnitHealtChanged -= OnValueChanged;
        }
    }
}
