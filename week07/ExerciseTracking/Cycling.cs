using System;

public class Cycling : Activity
{
    private double _speed; // in kilometers per hour
    private double _distance; // in kilometers

    public Cycling(string date, int minutes, double speed, double distance)
        : base(date, minutes)
    {
        _speed = speed;
        _distance = distance;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance() => _distance;

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
