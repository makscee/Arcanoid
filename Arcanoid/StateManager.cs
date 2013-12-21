﻿using VitPro;
using VitPro.Engine;
using System;

class MyManager : StateManager
{
    public MyManager(State a)
        : base(a)
    {
    }
    double t = 1;

    public override void Update(double dt)
    {
        base.Update(dt);
        t -= 5 * dt;
        if (t < 0)
            t = 0;
    }

    public override void StateChanged()
    {
        base.StateChanged();
        t = 1;
        if (tex != null)
        {
            back = tex.Copy();
        }
    }

    Texture tex = null, back = null;

    public override void Render()
    {
        if (tex == null || tex.Width != Draw.Width || tex.Height != Draw.Height)
            tex = new Texture(Draw.Width, Draw.Height);
        Draw.BeginTexture(tex);

        base.Render();

        Draw.EndTexture();
        tex.RemoveAlpha();

        Draw.Save();
        Draw.Scale(2);
        Draw.Align(0.5, 0.5);

        tex.Render();
        if (back != null)
        {
            Draw.Color(1, 1, 1, t);
            back.Render();
        }

        Draw.Load();
    }
}