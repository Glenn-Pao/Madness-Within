namespace MasujimaRyohei
{
    using UnityEngine;
    using VRTK;

    public class ControlReactor : MonoBehaviour
    {
        public enum Mode
        {
            HandleChange,
            HandleChangeWithName,
            ForMovementType
        }

        public Mode mode;

        public TextMesh go;
        string temp;

        private void Start()
        {
            // I want to save kind name.
            temp = go.text;

            switch (mode)
            {
                case Mode.HandleChange:// Display only the value in text.
                    GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
                    HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
                    break;
                case Mode.HandleChangeWithName:// Display The handle and the value in text.
                    GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChangeWithName);
                    HandleChangeWithName(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
                    break;
                case Mode.ForMovementType:// Display The player movement type in text.
                    GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChangeForMovement);
                    HandleChangeForMovement(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());

                    break;
                default:
                    break;
            }
        }

        private void HandleChange(float value, float normalizedValue)
        {
            go.text = value.ToString() + "(" + normalizedValue.ToString() + "%)";
        }

        private void HandleChangeWithName(float value, float normalizedValue)
        {

            go.text = temp + value.ToString() + "(" + normalizedValue.ToString() + "%)";
        }
        private void HandleChangeForMovement(float value, float normalizedValue)
        {
            PlayerMovementType currentType = (PlayerMovementType)value;
            go.text = temp + currentType.ToString();
        }
    }
}