﻿using VitPro.Engine;
using VitPro;
using System;

[Serializable]
class Bonus : IUpdateable, IRenderable
{
    public bool Alive = true;

    public Vec2 Size = new Vec2(5, 5);
    public Vec2 Position;
    double Speed = 100;

    public virtual void Get()
    { }

    void Collision()
    {
        Box box = new Box(Position, Size);
        if (box.CollideBool(World.Current.Platform.Box))
        {
            Alive = false;
            Get();
        }
    }

    public static Bonus RandomBonus()
    {
        switch(Program.Random.Next(8))
        {
            case 0:
                {
                    return new ExtraBall();
                }
            case 1:
                {
                    return new PlatformStretch();
                }
            case 2:
                {
                    return new PlatformShrink();
                }
            case 3:
                {
                    return new PlatformSpeedDown();
                }
            case 4:
                {
                    return new PlatformSpeedUp();
                }
            case 5:
                {
                    return new SpeedDown();
                }
            case 6:
                {
                    return new SpeedUp();
                }
            case 7:
                {
                    return new ExtraLife();
                }
        }
        return new ExtraBall();
    }

    public void Update(double dt)
    {
        Position += new Vec2(0, -Speed) * dt;
        Collision();
    }

    public virtual void Render()
    {
    }

}