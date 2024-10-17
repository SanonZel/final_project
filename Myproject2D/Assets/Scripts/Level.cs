using UnityEngine;

public class Level
{
    public char[,] Data { get => _data; }
    private char[,] _data = new char[4, 4];

    public Vector3 OriginPoint { get => _originPoint; }
    private Vector3 _originPoint;

    public Level(Vector3 OriginPoint)
    {
    _originPoint = OriginPoint;
        ResetLevel();
    }
    ~Level()
    {
        _data= null;
    }

    public void SetPlatform(int r, int c)
        => _data[r, c] = '-';

    public override string ToString()
    {
        string result = default;
        result += $"{_data[3,0]} {_data[3,1]} {_data[3,2]} {_data[3,3]}\n";
        result += $"{_data[2,0]} {_data[2,1]} {_data[2,2]} {_data[2,3]}\n";
        result += $"{_data[1,0]} {_data[1,1]} {_data[1,2]} {_data[1,3]}\n";
        result += $"{_data[0,0]} {_data[0,1]} {_data[0,2]} {_data[0,3]}\n";
        return result;
    }

    public void ResetLevel()
    {
        _data = new char[4, 4]{
            {'*', '*', '*', '*' },
            {'*', '*', '*', '*' },
            {'*', '*', '*', '*' },
            {'*', '*', '*', '*' }
        };
    }
}

