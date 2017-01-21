using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[Obsolete("No longer spawning using audio")]
public class AudioBasedSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnPrefab;
    [SerializeField, Range(-9, -10)]
    private float _beatSpawnRate = 9.5f;
    [SerializeField, Range(0, .5f)]
    private float _spawnTimer = .05f;

    private bool _canSpawn = true;

    private void Update()
    {
        if (!_canSpawn) return;

        var spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            if (spectrum[i - 1] - 10 >= _beatSpawnRate)
            {
                Instantiate(_spawnPrefab);
                _canSpawn = false;
                Observable.Timer(TimeSpan.FromSeconds(_spawnTimer))
                    .Subscribe(_ => _canSpawn = true);
                return;
            }
        }
    }
}
