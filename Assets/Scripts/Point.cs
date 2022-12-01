using UnityEngine;

/// <summary>
/// Hilfsklasse um Objekte in einzele Punkte zu packen
/// </summary>
[System.Serializable]
public class Point
{
    public int x;
    public int y;

    public Point(int nx, int ny)
    {
        x = nx;
        y = ny;
    }

    public void mult(int m)
    {
        x *= m;
        y *= m;
    }

    public void add(Point p)
    {
        x += p.x;
        y += p.y;
    }

    public Vector2 ToVector()
    {
        return new Vector2(x, y);
    }

    public bool Equals(Point p)
    {
        return (x == p.x && y == p.y);
    }

    public static Point fromVector(Vector2 v)
    {
        return new Point((int)v.x, (int)v.y);
    }

    public static Point fromVector(Vector3 v)
    {
        return new Point((int)v.x, (int)v.y);
    }

    /// <summary>
    /// Static Methode, um die Chebyshev Distanz zwischen zwei Punkten zu ermitteln.
    /// </summary>
    /// <param name="p">Erster Point</param>
    /// <param name="o">Zweiter Point</param>
    /// <returns>Distanz als Int</returns>
    public static int DistanceBetween(Point p, Point o)
    {
        //Chebyshev Distance
        int distance = Mathf.Max(Mathf.Abs(o.x - p.x), Mathf.Abs(o.y - p.y));
        return distance;
    }

    public static Point mult(Point p, int m)
    {
        return new Point(p.x * m, p.y * m);
    }

    public static Point add(Point p, Point o)
    {
        return new Point(p.x + o.x, p.y + o.y);
    }

    /// <summary>
    /// Methode, um einen Punkt zu klonen. Einfach so.
    /// </summary>
    /// <param name="p">Zuklonender Punkt</param>
    /// <returns>Geklonter Punkt</returns>
    public static Point clone(Point p)
    {
        return new Point(p.x, p.y);
    }

    /// <summary>
    /// Punkt mit den Koordinaten(0,0).
    /// </summary>
    public static Point zero
    {
        get { return new Point(0, 0); }
    }
    /// <summary>
    /// Punkt mit den Koordinaten(1,1).
    /// </summary>
    public static Point one
    {
        get { return new Point(1, 1); }
    }
    public static Point up
    {
        get { return new Point(0, 1); }
    }
    public static Point down
    {
        get { return new Point(0, -1); }
    }
    public static Point right
    {
        get { return new Point(1, 0); }
    }
    public static Point left
    {
        get { return new Point(-1, 0); }
    }
}
