using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] int m_gameTime;
    Subject<Unit> m_title = new Subject<Unit>();
    Subject<Unit> m_gameStart = new Subject<Unit>();
    Subject<Unit> m_inGame = new Subject<Unit>();
    Subject<Unit> m_gameEnd = new Subject<Unit>();
    public ReactiveProperty<int> Point = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> GameTime = new ReactiveProperty<int>();
    //public IObservable<Unit> Title => m_title;
    public IObservable<Unit> GameStart => m_gameStart;
    public IObservable<Unit> InGame => m_inGame;
    public IObservable<Unit> GameEnd => m_gameEnd;

    IDisposable input;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        m_gameStart.Subscribe(_ => StartCoroutine(CountDown())).AddTo(this);
        m_inGame.Subscribe(_ => StartCoroutine(GameTimer())).AddTo(this);
       // m_inGame.Subscribe(_ =>
       //{
       //    input = this.UpdateAsObservable().Where(_2 => Input.GetMouseButtonDown(0)).Subscribe(_2 => Point.Value += 100);
       //}).AddTo(this);
    }
    void Start()
    {
        GameTime.Value = m_gameTime;
        m_gameStart.OnNext(Unit.Default);
    }

    IEnumerator GameTimer()
    { 
        while (GameTime.Value > 0)
        {
            GameTime.Value--;
            //Point.Value += 100;
            yield return new WaitForSeconds(1);
        }
        //input.Dispose();
        m_gameEnd.OnNext(Unit.Default);
        
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(4);
        m_inGame.OnNext(Unit.Default);
    }
}
