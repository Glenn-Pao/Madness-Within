using UnityEngine;
using System.Collections;

public class TimeManager : SingletonMonoBehavior<TimeManager> {

    private int _h,_m,_s;
    private int _increaseTime = 0;
    private int _reduceTime = 0;
    private bool _isUsingStopwatch = false;
    private bool _isUsingTimer = false;
    void Awake()
    {
        if (this != instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update()
    {
        string time = System.DateTime.Now.TimeOfDay.ToString();

        _h = int.Parse(time.Split(':')[0]);
        _m = int.Parse(time.Split(':')[1]);
        _s = (int)float.Parse(time.Split(':')[2]);
    }

    int GetHour12()
    {
        int temp;
        temp = _h;
        if (_h < 12)
            return temp;
        else
            return temp - 12; 
    }

    void StartStopwatch()
    {
        _isUsingStopwatch = true;
        StartCoroutine("CountUpTimer");
    }

    private IEnumerator CountUpTimer()
    {
        while (_isUsingStopwatch)
        {
            _increaseTime++;
            yield return new WaitForSeconds(1.0f);
        }
    }

    void StopStopwatch()
    {
        StopCoroutine("CountUpTimer");
        _isUsingStopwatch = false;
    }

    int GetTimeOfStopwatch()
    {
        return _increaseTime;
    }

    bool SetTimer(int time)
    {
        _reduceTime = time;
        return false;
    }

    private IEnumerator CountDownTimer()
    {
        while (_isUsingTimer)
        {
            _reduceTime--;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
