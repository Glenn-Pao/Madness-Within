namespace VRTK.Examples
{
    using UnityEngine;

    public class ControlReactor : MonoBehaviour
    {
        // Masujima
        public enum DisplayMode
        {
            HandleChange,
            HandleChangeWithTextName
        }

        public TextMesh go;
        private string temp;

        // Masujima
        public DisplayMode mode;

        private void Start()
        {
            temp = go.text;


            // Masujima
            switch (mode)
            {
                case DisplayMode.HandleChange:
                    GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
                    HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
                    break;
                case DisplayMode.HandleChangeWithTextName:
                    GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChangeWithTextName);
                    HandleChangeWithTextName(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
                    break;
                default:
                    break;
            }
        }

        private void HandleChange(float value, float normalizedValue)
        {
           go.text = value.ToString() + "(" + normalizedValue.ToString() + "%)";
        }
        // Masujima
        private void HandleChangeWithTextName(float value, float normalizedValue)
        {
            go.text = temp + " " + value.ToString() + "(" + normalizedValue.ToString() + "%)";
        }
    }
}