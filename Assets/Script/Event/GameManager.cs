using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] int m_gameTime;
    Subject<Unit> m_gameStart = new Subject<Unit>();
    Subject<Unit> m_inGame = new Subject<Unit>();
    Subject<Unit> m_gameEnd = new Subject<Unit>();
    public ReactiveProperty<int> Point = new ReactiveProperty<int>(0);

    public IObservable<Unit> GameStart => m_gameStart;
    public IObservable<Unit> InGame => m_inGame;
    public IObservable<Unit> GameEnd => m_gameEnd;
    //IObservable<Unit> GamePlay => this.UpdateAsObservable();
    // Start is called before the first frame update
    private void Awake()
    {
        m_gameStart.Subscribe(_ => StartCoroutine(CountDown())).AddTo(this);
        m_inGame.Subscribe(_ => StartCoroutine(GameTime())).AddTo(this);
        
    }
    void Start()
    {
        
        m_gameStart.OnNext(Unit.Default);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTime()
    { 
        while (m_gameTime > 0)
        {
            m_gameTime--;
            Point.Value += 100;
            yield return new WaitForSeconds(1);
        }
        m_gameEnd.OnNext(Unit.Default);
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(4);
        m_inGame.OnNext(Unit.Default);
    }
}
