using TMPro;
using UnityEngine;

namespace Content.Counting.CountChange.UI.View
{
    public class CountChangeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
    
        public void SetText(string text)
        {
            _text.SetText(text);
        }
    }
}
