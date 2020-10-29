using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    /*
     *  An in-game world clock, affected by time scale.
     *  Based on: https://www.youtube.com/watch?v=Yn-a1Wd6baw
     *  
     *  Known weaknesses:
     *      - At the moment it doesn't deal with time running way faster than the counter. 
     *        To have a more accurate sense of time scale it would need to advance time,
     *        it would need to keep track of the remaining time units and apply multiples in the checks
     *        (I will look into this if time feels noticably different in sped up and slow down)
     */
    
    private static GameTimeManager _instance;
	[HideInInspector] public static GameTimeManager Instance { get { return _instance; } }
    
    [SerializeField] private float _gameSecondsPerRealMinute = 1; //the amount of minutes each second of game time equals (60s is real time)
    private float _counter;

    [SerializeField] private string[] _seasons = {"Spring", "Summer", "Winter", "Autumn"};

    [SerializeField] private bool _gameTimeActive = true; //used to pause time
     
    public int _minute = 0;
    public int _hour = 6;
    public int _day = 1;
    public int _month = 1;
    public int _season = 0; //Spring
    public int _year = 2020;

    [SerializeField] private int _minutesInHour = 60;
    [SerializeField] private int _hoursInDay = 24;
    [SerializeField] private int _daysInMonth = 30;
    [SerializeField] private int _monthsInSeason = 3;
    [SerializeField] private int _monthsInYear = 12;

   

    // time updates event
	public delegate void GameTimeHandler();
	public event GameTimeHandler GameTimeAdvanced;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Update()
    {
        if (_gameTimeActive)    //only advance time if it's not active (use for pause menus, etc)
            AdvanceTimeCounter();
    }

    private void AdvanceTimeCounter()
    {
        if(_counter >= _gameSecondsPerRealMinute) // every real time second, advance the game minutes by the ratio
        {
            _counter = 0; //reset counter
            _minute ++; //advanced minutes
            CheckAndUpdateTime();
        } else {
            _counter += Time.deltaTime; //advance counter
        }
    }

    private void CheckAndUpdateTime()
    {
        if (_minute >= _minutesInHour) // check if the number of seconds passed  equals a minute
        {
            _minute = 0; //reset minute counter
            _hour++; //advanced hours

            if (_hour >= _hoursInDay)
            {
                _hour = 0;
                _day++;
                    
                if (_day >= _daysInMonth)
                {                        
                    _day = 0;
                    _month++;

                    if (_month % _monthsInSeason == 0)
                    {
                        _season ++;
                        if (_season >  _seasons.Length)
                            _season = 0;
                    }
                    if (_month >= _monthsInYear)
                    {
                        _month = 0; 
                        _year++;
                    }
                }
            }
        }
        GameTimeAdvanced?.Invoke();  //raise time update event
        LogGameTime();
    }

   private void LogGameTime()
   {
        //Debug.Log( "The time is: " + _hour + ":" + _minute + " The date is: " + _day + "/" + _month + "/" + _year + " The season is: " + _seasons[_season] );
   }

   public void GameTimeActive(bool setActive){ //true to turn it on, false to pause the time.
        _gameTimeActive = setActive;
   }


}
