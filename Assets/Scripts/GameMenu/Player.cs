using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    private bool _isEnemyExist = false;

    public float sensitivityX = 15F;
    public float runSpeed = 5.0f,
                    sprintSpeed = 20,
                    force = 100f;

    private Transform cameraTransform;

    public int enemyLast;
    public Text enemyNumberLast;

    private GameObject _parent;

    public enum Hands
    {
        RIGHT,
        LEFT,
        NUM
    }
    public GameObject[] hands;

    // Use this for initialization
    void Start()
    {
        hands = new GameObject[(int)Hands.NUM];


        hands[(int)Hands.LEFT] = null;
        hands[(int)Hands.RIGHT] = null;

        //hands[(int)Hands.LEFT] = GameObject.Find("Sword");
        //hands[(int)Hands.RIGHT] = GameObject.Find("Gun");

        cameraTransform = Camera.main.transform;
        enemyLast = 0;

        if (_parent = GameObject.Find("Enemies"))
            _isEnemyExist = true;

        if (_isEnemyExist)
            foreach (Transform child in _parent.transform)
            {
                Debug.Log(child);
                enemyLast++;
            }
    }

    // Update is called once per frame
    void Update()
    {
        #region [ FOR_MOVE ]
        // h = Horizontal.
        Vector3 hForward, hRight;
        cameraTransform.forward.Normalize();
        hForward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
        hRight = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z);

        if (Input.GetKey("w"))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += cameraTransform.forward * (Time.deltaTime * sprintSpeed);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 80, 2 * Time.deltaTime);
            }
            else
            {
                transform.position += (hForward / runSpeed);
            }
        }

        if (Input.GetKey("s"))
        {
            transform.position -= (hForward / runSpeed);
        }
        if (Input.GetKey("a"))
        {
            transform.position -= (hRight / runSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.position += (hRight / runSpeed);
        }

        ////////////////////////////////////////////////

        //float x = Input.GetAxisRaw("Horizontal");
        //float z = Input.GetAxisRaw("Vertical");

        //Vector3 direction = new Vector3(x, 0f, z).normalized;

        //GetComponent<Rigidbody>().AddForce(direction * force);
        //GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, runSpeed);
        #endregion



        if (Input.GetMouseButtonDown(0))
        {
            if (hands[(int)Hands.LEFT] != null)
                if (hands[(int)Hands.LEFT].GetComponent<Item>()._itemType == Item.ItemType.EMPTY)
                {
                    grabItem(Hands.LEFT);
                }
                else
                {
                    hands[(int)Hands.LEFT].GetComponent<Item>().UseItem();
                }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (hands[(int)Hands.RIGHT] != null)
                if (hands[(int)Hands.RIGHT].GetComponent<Item>()._itemType == Item.ItemType.EMPTY)
                {
                    grabItem(Hands.RIGHT);
                }
                else
                {
                    hands[(int)Hands.RIGHT].GetComponent<Item>().UseItem();
                }
        }

        if (_isEnemyExist)
        {
            int temp = 0;
            foreach (Transform child in _parent.transform)
            {
                Debug.Log(child);
                temp++;
                enemyLast = temp;
            }

            if (enemyNumberLast)
                enemyNumberLast.text = "Enemy : " + enemyLast;
        }
    }

    void grabItem(Hands hand)
    {
        //hands[(int)hand] = ;
    }

}
