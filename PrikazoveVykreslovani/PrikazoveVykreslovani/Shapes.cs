﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrikazoveVykreslovani
{
    //Vycet moznych skupin
    public enum ShapeType
    {
        Rectangle,
        Ellipse,
        Cross,
        Line,
        Triangle,
        Hexagon
    }
    //Abstraktni trida "Shape" ze ktery dedi ostatni obrazce
    public class Shape
    {
        protected Pen visualizePen = new Pen(Color.Black, 3) 
        { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash};

        public Point start;
        public Point end;
        public Color color;
        public int lineWidth = 4;
        public bool filled;

        public string ClassName;
        public string name { get { return this.GetType().Name; } }

        //Naplneni promenych po vytvoreni podle vyctu
        public static Shape CreateShape(string s, Shape origin) {
            var shape = CreateShape(s);
            shape.color = origin.color;
            shape.end = origin.end;
            shape.filled = origin.filled;
            shape.lineWidth = origin.lineWidth;
            shape.start = origin.start;
            return shape;
        }
        //Vytvoreni noveho obrazce podle vlastniho pojmenovani
        public static Shape CreateShape(string s) {
            s = CorrectShapeName(s);
            
            Shape shp = (Shape)Activator.CreateInstance(
                Type.GetType("PrikazoveVykreslovani." + s));
            shp.ClassName = s;
            return shp;
        }

        private static string CorrectShapeName(string s) {
            var names = Enum.GetNames(typeof(ShapeType));
            if (names.Contains(s)) {
                return s;
            } else {
                return "Rectangle";
            }
        }
        //Virtualni predpis tridy na vykreslovani obrazce
        public virtual void Draw(Graphics g) { }
        //Virtualni predpis tridy pro vykreslovani ve skupine na hlavni okno Form1
        public virtual void DrawInSize(Graphics g, Point pos, Size siz)
        {

        }

        //Virtualni trida pro vykresleni obrysu obrazce
        public virtual void Visualize(Graphics g) { }

        public override string ToString() {
            return GetType().Name + start + " " + end;
        }
    }
    //Trida ctverce
    public class Rectangle : Shape
    {
        public override void Draw(Graphics g) {
            if (filled) {
                g.FillRectangle(new SolidBrush(color),
                    start.X, start.Y,
                    end.X - start.X, end.Y - start.Y);
            } else {
                g.DrawRectangle(new Pen(color, lineWidth),
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
            }
        }

        public override void Visualize(Graphics g) {
            g.DrawRectangle(visualizePen,
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
        }

        public override void DrawInSize(Graphics g, Point pos, Size siz)
        {
            float ratioX = (float)siz.Width / 400;
            float ratioY = (float)siz.Height / 400;

            if (filled)
            {
                g.FillRectangle(new SolidBrush(color),
                    pos.X + start.X*ratioX, pos.Y + start.Y*ratioY,
                    (end.X - start.X) * ratioX, (end.Y - start.Y) * ratioY);
            }
            else
            {
                g.DrawRectangle(new Pen(color, lineWidth),
                pos.X + start.X *ratioX, pos.Y + start.Y*ratioY,
                (end.X - start.X)*ratioX, (end.Y - start.Y)*ratioY);
            }
        }
    }
    //Trida Elipsy
    public class Ellipse : Shape
    {
        public override void Draw(Graphics g) {
            if (filled) {
                g.FillEllipse(new SolidBrush(color),
                    start.X, start.Y,
                    end.X - start.X, end.Y - start.Y);
            } else {
                g.DrawEllipse(new Pen(color, lineWidth),
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
            }
        }
        public override void Visualize(Graphics g) {
            g.DrawEllipse(visualizePen,
                start.X, start.Y,
                end.X - start.X, end.Y - start.Y);
        }
        public override void DrawInSize(Graphics g, Point pos, Size siz)
        {
            float ratioX = (float)siz.Width / 400;
            float ratioY = (float)siz.Height / 400;

            if (filled)
            {
                g.FillRectangle(new SolidBrush(color),
                    pos.X + start.X * ratioX, pos.Y + start.Y * ratioY,
                    (end.X - start.X) * ratioX, (end.Y - start.Y) * ratioY);
            }
            else
            {
                g.DrawRectangle(new Pen(color, lineWidth),
                pos.X + start.X * ratioX, pos.Y + start.Y * ratioY,
                (end.X - start.X) * ratioX, (end.Y - start.Y) * ratioY);
            }
        }
    }
    //Trida Krize
    public class Cross : Shape
    {
        public override void Draw(Graphics g) {
            g.DrawLine(new Pen(color, lineWidth), start, end);
            g.DrawLine(new Pen(color, lineWidth), start.X, end.Y, end.X, start.Y);
        }

        public override void Visualize(Graphics g) {
            g.DrawLine(visualizePen, start, end);
            g.DrawLine(visualizePen, start.X, end.Y, end.X, start.Y);
        }
    }
    //Trida Cary
    public class Line : Shape
    {
        public override void Draw(Graphics g) {
            g.DrawLine(new Pen(color, lineWidth), start, end);
        }

        public override void Visualize(Graphics g) {
            g.DrawLine(visualizePen, start, end);
        }
    }
    //Trida trojuhelniku
    public class Triangle : Shape
    {
        public override void Draw(Graphics g) {
            Point[] points = new Point[3] {
                new Point(start.X, end.Y),
                end,
                new Point((end.X + start.X)/2, start.Y)
            };

            if(filled) {
                g.FillPolygon(new SolidBrush(color), points);
            } else {
                g.DrawPolygon(new Pen(color, lineWidth), points);
            }
        }

        public override void Visualize(Graphics g) {
            Point[] points = new Point[3] {
                new Point(start.X, end.Y),
                end,
                new Point((end.X + start.X)/2, start.Y)
            };
            g.DrawPolygon(visualizePen, points);
        }
    }
    //Trida hexagonu
    public class Hexagon : Shape
    {
        public override void Draw(Graphics g) {
            Point[] points = new Point[] {
                new Point(start.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4, end.Y),
                new Point(start.X+(end.X-start.X)/4*3, end.Y),
                new Point(end.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4*3, start.Y),
                new Point(start.X+(end.X-start.X)/4, start.Y)
            };

            if (filled) {
                g.FillPolygon(new SolidBrush(color), points);
            } else {
                g.DrawPolygon(new Pen(color, lineWidth), points);
            }
        }

        public override void Visualize(Graphics g) {
            Point[] points = new Point[] {
                new Point(start.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4, end.Y),
                new Point(start.X+(end.X-start.X)/4*3, end.Y),
                new Point(end.X, (start.Y + end.Y) / 2),
                new Point(start.X+(end.X-start.X)/4*3, start.Y),
                new Point(start.X+(end.X-start.X)/4, start.Y)
            };
            g.DrawPolygon(visualizePen, points);
        }
    }
}
