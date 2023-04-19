using UnityEngine;
using UnityEngine.UIElements;

namespace Content.Counting.CountData.UI.View
{
    public class CountDataView : MonoBehaviour
    {
        private UIDocument _document;

        private Label _countLabel;

        private void Awake()
        {
            _document = GetComponent<UIDocument>();
            VisualElement root = _document.rootVisualElement;

            _countLabel = root.Q<Label>("Counter");
        }

        public void SetText(string text)
        {
            _countLabel.text = text;
        }
    }
}
