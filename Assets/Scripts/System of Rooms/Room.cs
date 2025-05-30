using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string name;
    public bool hasTimer = false;

    private float _timer = 0f;
    private float _maxTime = 0f;
    private float _secondCounter = 0f;
    private int _secondsElapsed = 0;
    private bool _isTimerRunning = false;

    public Room(string name)
    {
        this.name = name;
    }

    public void InitTimer(float duration)
    {
        _timer = 0f;
        _maxTime = duration;
        _secondCounter = 0f;
        _secondsElapsed = 0;
        _isTimerRunning = true;
        Debug.Log($"Timer started for room: {name} for {duration}");
    }

    public void Tick(float deltaTime)
    {
        if (!_isTimerRunning) return;

        _timer += deltaTime;
        _secondCounter += deltaTime;

        if (_secondCounter >= 1f)
        {
            _secondsElapsed++;
            Debug.Log($"[ROOM DEBUG] Time elapsed in {name}: {_secondsElapsed}s");
            _secondCounter = 0f;
        }

        if (_timer >= _maxTime)
        {
            _isTimerRunning = false;
            Debug.Log($"[ROOM DEBUG] Time ended in {name}");
        }
    }

    public bool IsTimerRunning => _isTimerRunning;
    public bool HasTimer => hasTimer;
}