using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{
    public TitleScene ts;
    public OptionsScene os;

    // Use this for initialization
    void Start()
    {
        ts = GameObject.Find("Level").GetComponent<TitleScene>();
        os = GameObject.Find("Level").GetComponent<OptionsScene>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider != null)
            {
                if (ts)
                {
                    ts.selectingItem = hit.collider.GetComponent<TextMesh>().text;
                }
                if (os)
                {

                }

                if (hit.collider.GetComponent<Button>())
                    hit.collider.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

            }
        }

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(transform.position, fwd, 10)) ;



    }
}
