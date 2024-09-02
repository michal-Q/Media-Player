// File: CustomSlider.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

public class CustomSlider : Control
{
    private int sliderValue = 0;
    public int MaxValue = 1;
    public bool isDragging = false;
    private Rectangle thumbRect;
    private int thumbSize = 10;
    public bool isMouseOver = false;

    public CustomSlider()
    {
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.Width = 200;
        this.Height = 30;
        this.MouseEnter += new EventHandler(CustomSlider_MouseEnter);
        this.MouseLeave += new EventHandler(CustomSlider_MouseLeave);
    }

    public int Value
    {
        get { return sliderValue; }
        set
        {
            sliderValue = Math.Max(0, Math.Min(MaxValue, value));
            Invalidate();
        }
    }

    private void CustomSlider_MouseEnter(object sender, EventArgs e)
    {
        isMouseOver = true;
        Invalidate();
    }

    private void CustomSlider_MouseLeave(object sender, EventArgs e)
    {
        isMouseOver = false;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Draw the slider track
        int trackHeight = 4;
        Rectangle trackRect = new Rectangle(0, (Height - trackHeight) / 2, Width, trackHeight);
        g.FillRectangle(Brushes.Gray, trackRect);

        // Calculate thumb position
        int thumbX = (Width - thumbSize) * sliderValue / MaxValue;
        thumbRect = new Rectangle(thumbX, (Height - thumbSize) / 2, thumbSize, thumbSize);

        // Draw the progress bar
        Rectangle progressRect = new Rectangle(0, (Height - trackHeight) / 2, thumbX + thumbSize + 1 / 2, trackHeight);
        g.FillRectangle(Brushes.LightGray, progressRect);

        // Draw the thumb only if the mouse is over the slider or if it is being dragged
        if (isMouseOver || isDragging)
        {
            g.FillEllipse(Brushes.LightGray, thumbRect);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (thumbRect.Contains(e.Location))
        {
            isDragging = true;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (isDragging)
        {
            Value = (e.X - thumbSize / 2) * MaxValue / (Width - thumbSize);
            Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        isDragging = false;
    }
}
