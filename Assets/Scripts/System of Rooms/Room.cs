using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Room
{
    public string roomName;
    private float _timer = 0f;
    private float _maxTime = 100f;
    private float _secondCounter = 0f;
    private int _secondsElapsed = 0;
    private bool _isTimerRunning = false;

    public Room(string name)
    {
        roomName = name;
    }

    public void InitTimer(float duration)
    {
         if (_isTimerRunning) return;

        _timer = 0f;
        _maxTime = duration;
        _secondCounter = 0f;
        _secondsElapsed = 0;
        _isTimerRunning = true;

        Debug.Log($"Timer started for room: {roomName} for {duration} seconds.");
    }

    public void Tick(float deltaTime)
    {
        if (!_isTimerRunning) return;

        _timer += deltaTime;
        _secondCounter += deltaTime;

        if (_secondCounter >= 1f)
        {
            _secondsElapsed++;
            Debug.Log($"[ROOM DEBUG] Time elapsed in {roomName}: {_secondsElapsed}s");
            _secondCounter = 0f;
        }

        if (_timer >= _maxTime)
        {
            _isTimerRunning = false;
            Debug.Log($"[ROOM DEBUG] Time ended in {roomName}");
        }
    }

    public bool IsTimerRunning => _isTimerRunning;
}
