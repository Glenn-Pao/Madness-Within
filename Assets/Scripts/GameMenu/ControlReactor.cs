namespace MasujimaRyohei
{
    using UnityEngine;

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
            temp = go.text;

            switch (mode)
            {
                case Mode.HandleChange:
                    GetComponent<VRTK.VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
                    HandleChange(GetComponent<VRTK.VRTK_Control>().GetValue(), GetComponent<VRTK.VRTK_Control>().GetNormalizedValue());
                    break;
                case Mode.HandleChangeWithName:
                    GetComponent<VRTK.VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChangeWithName);
                    HandleChangeWithName(GetComponent<VRTK.VRTK_Control>().GetValue(), GetComponent<VRTK.VRTK_Control>().GetNormalizedValue());
                    break;
                case Mode.ForMovementType:
                    GetComponent<VRTK.VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChangeForMovement);
                    HandleChangeForMovement(GetComponent<VRTK.VRTK_Control>().GetValue(), GetComponent<VRTK.VRTK_Control>().GetNormalizedValue());

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