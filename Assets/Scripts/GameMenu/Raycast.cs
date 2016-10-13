namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;

    public class Raycast : MonoBehaviour
    {
        public GameObject lookingObject;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (lookingObject = hit.collider.gameObject)
                {
                    // You look any object.
                    if (lookingObject.tag == "Button")
                    {
                        // You look any button.
                        Button3D button = lookingObject.GetComponent<Button3D>();
                        button.Appeal();
                        if (Input.GetMouseButtonDown(0))
                        {
                            button.Push();
                        }

                        //Debug.Log(GetComponent<VRTK.VRTK_ControllerEvents>().IsButtonPressed(VRTK.VRTK_ControllerEvents.ButtonAlias.Touchpad_Touch));
                        //if (GetComponent<VRTK.VRTK_ControllerEvents>().IsButtonPressed(VRTK.VRTK_ControllerEvents.ButtonAlias.Trigger_Hairline))
                        //{
                        //    Debug.Log("Push");
                        //    button.Push();
                        //}
                        //SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
                        //var device = SteamVR_Controller.Input((int)trackedObject.index);

                        //if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
                        //{
                        //    Debug.Log("Push");
                        //    button.Push();
                        //    device.TriggerHapticPulse(1000);
                        //}
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                FadeManager.instance.Wink(0.2f);
            }
        }
    }
}