
using System.Xml.Serialization;


namespace BussolWinForms
{
    public partial class Form1 : Form
    {
        private List<Bussol> ListBussols = new List<Bussol>();
        public Form1()
        {
            InitializeComponent();
            StayOnTop.Checked = false;

            Context.Load();
            ListBussols = Context.Settings.Bussols;
            BussolsCombo.Items.AddRange(ListBussols.ToArray());
            components = new System.ComponentModel.Container();
            panel.Location = Context.Settings.PanelLocation;


        }

        private void button5_Click(object sender, EventArgs e) =>
            this.Close();



        bool movepanel = false;
        Point panloc = new();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            movepanel = true;
            panel.Cursor = Cursors.Hand;
            panloc.X = panel.Location.X - e.Location.X;
            panloc.Y = panel.Location.Y - e.Location.Y;
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            movepanel = false;
            panel.Cursor = Cursors.Default;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (movepanel)
                panel.Location = new Point(panloc.X + e.Location.X, panloc.Y + e.Location.Y);
        }

        private void StayOnTop_CheckStateChanged(object sender, EventArgs e) =>
            this.TopMost = StayOnTop.Checked;

        bool startDrawBussol = false;
        bool mouseStartDrawBussol = false;

        Bussol currBussol = new();
        private void AddBussol_Click(object sender, EventArgs e)
        {
            currBussol = new();
            currBussol.Name = $"Буссоль {ListBussols.Count}";
            BussolsCombo.Items.Add(currBussol);
            BussolsCombo.SelectedItem = currBussol;
            ListBussols.Add(currBussol);
            this.BackColor = SystemColors.Window;
            Opacity = 0.55;
            startDrawBussol = true;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (startDrawBussol && mouseStartDrawBussol)
            {
                using Graphics g = this.CreateGraphics();
                currBussol.EndPoint = e.Location;
                currBussol.DrawRect(g, this.BackColor);
                currBussol.PrepareImage();
                currBussol.Draw(g);
                g.Dispose();
            }
            if (mouseStartDrawScale && addscale)
            {
                using Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                scale.EndPoint = e.Location;
                scale.PrepareImage();
                scale.Draw(g);
                g.Dispose();
            }
            if (mouseStartDrawMesure && addmesure)
            {
                using Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                mesure.EndPoint = e.Location;
                mesure.PrepareImage();
                mesure.Draw(g);
                g.Dispose();
                CalcMesure();
            }
        }
        bool mouseStartDrawScale = false;
        bool mouseStartDrawMesure = false;
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (startDrawBussol)
                {
                    currBussol.StartPoint = e.Location;
                    mouseStartDrawBussol = true;
                }
                if (addscale)
                {
                    mouseStartDrawScale = true;
                    scale.StartPoint = e.Location;
                }
                if (addmesure)
                {
                    mouseStartDrawMesure = true;
                    mesure.StartPoint = e.Location;
                }
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (startDrawBussol)
            {
                startDrawBussol = false;
                mouseStartDrawBussol = false;
                this.BackColor = Color.Green;
                Opacity = 1;
                Refresh();
                RePaintAll();
            }
            if (mouseStartDrawScale)
            {
                addscale = false;
                mouseStartDrawScale = false;
                this.BackColor = Color.Green;
                Opacity = 1;
                Refresh();
                RePaintAll();
            }
            if (mouseStartDrawMesure)
            {
                addmesure = false;
                mouseStartDrawMesure = false;
                this.BackColor = Color.Green;
                Opacity = 1;
                Refresh();
                RePaintAll();
            }
        }

        private void RePaint_Click(object sender, EventArgs e)
        {
            Refresh();
            RePaintAll();
        }

        private void RePaintAll()
        {
            using var g = this.CreateGraphics();
            g.Clear(BackColor);
            foreach (var item in ListBussols)
            {
                try
                {
                    item.PrepareImage();
                    item.Draw(g);
                }
                catch { };
            }
            scale?.Draw(g);
            mesure?.Draw(g);
        }

        private void TXTFontSize_TextChanged(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus == null) return;
            int fontsize;
            if (int.TryParse(TXTFontSize.Text, out fontsize))
            {
                if (bus.FontSize == fontsize) return;
                bus.FontSize = fontsize;
                bus.PrepareImage();
                RePaintAll();
            }
        }

        private void BussolsCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus != null)
            {
                TXTZoom.Text = bus.ZOOM.ToString();
                TXTFontSize.Text = bus.FontSize.ToString();
                TXTDistance.Text = bus.Distance.ToString();
                TXTAngle.Text = bus.CamAngle.ToString();
            }
            else
            {
                TXTZoom.Text = string.Empty;
                TXTFontSize.Text = string.Empty;
                TXTDistance.Text = string.Empty;
                TXTAngle.Text = string.Empty;
            }
        }

        private void TXTZoom_TextChanged(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus == null) return;
            float zoom;
            if (float.TryParse(TXTZoom.Text, out zoom))
            {
                if (bus.ZOOM == zoom) return;
                bus.ZOOM = zoom;
                bus.PrepareImage();
                RePaintAll();
            }
        }

        private void TXTDistance_TextChanged(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus == null) return;
            int dist;
            if (int.TryParse(TXTDistance.Text, out dist))
            {
                if (bus.Distance == dist) return;
                bus.Distance = dist;
                bus.PrepareImage();
                RePaintAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus == null) return;
            BussolsCombo.Items.Remove(bus);
            ListBussols.Remove(bus);
            RePaintAll();
        }


        private void TXTAngle_TextChanged(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus == null) return;
            int angle;
            if (int.TryParse(TXTAngle.Text, out angle))
            {
                if (bus.CamAngle == angle) return;
                bus.CamAngle = angle;
                bus.PrepareImage();
                RePaintAll();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Context.Settings.PanelLocation = panel.Location;
            Context.Settings.Bussols = ListBussols;
            Context.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
            RePaintAll();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            BussolsCombo.Items.Clear();
            if (scale != null)
                scale.image = null;
            if (mesure != null)
                mesure.image = null;
            ListBussols.Clear();
            RePaintAll();
        }
        bool addmesure = false;
        Mesure? mesure = null;
        private void button3_Click(object sender, EventArgs e)
        {
            if (scale == null) { BTNAddScale_Click(sender, e); return; }
            addmesure = true;
            if (mesure != null) mesure.Dispose();
            mesure = new Mesure();
            this.BackColor = SystemColors.Window;
            Opacity = 0.55;
        }
        Scale? scale = null;
        bool addscale = false;
        private void BTNAddScale_Click(object sender, EventArgs e)
        {
            addscale = true;
            if (scale != null) scale.Dispose();
            scale = new Scale();
            scale.RealScaleSize = scalerealsize;
            this.BackColor = SystemColors.Window;
            Opacity = 0.55;
        }
        float scalerealsize = 1;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TXTScaleSize.Text, out scalerealsize))
            {
                if (scale == null) return;
                scale.RealScaleSize = scalerealsize;
                CalcMesure();
            }
        }

        private void CalcMesure()
        {
            if (scale == null || mesure == null) return;
            TXTMeasureSize.Text = (scale.Scope * mesure.Width).ToString();
        }

    }
    public class Mesure : DrawObject
    {
        public override string Name { get; set; } = "Mesure";
        public int Width
        {
            get
            {
                if (image == null || image.Width <= 0) return 0;
                return image.Width;
            }
        }
        public int ScaleStep { get; set; } = 2;
        public int ScaleHeight { get; set; } = 10;
        private Brush BrushBlack = Brushes.Black;
        private Brush BrushWhite = Brushes.White;
        private Pen PenBlack = new Pen(Color.Black);
        private Pen PenWhite = new Pen(Color.White);
        public override void PrepareImage()
        {
            var width = GetWidth();
            if (width < 10) return;
            this.Angle = CalcAngle(StartPoint, EndPoint) - 90;
            int x = 0;
            var img = new Bitmap((int)width, (int)(ScaleHeight));
            using var graph = Graphics.FromImage(img);
            graph.Clear(Color.White);
            while (x <= width)
            {
                if (x % 5 == 0) graph.DrawLine(PenBlack, new Point(x, 0), new Point(x, 5));
                else
                    graph.DrawLine(PenBlack, new Point(x, 0), new Point(x, 2));
                x = x + ScaleStep;
            }
            image = img;
        }
        public override void Draw(Graphics graphics)
        {
            if (image == null) return;
            graphics.ResetTransform();
            graphics.TranslateTransform(StartPoint.X, StartPoint.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            graphics.RotateTransform((float)Angle);
            graphics.DrawImage(image, new Point(0, 0));
        }
    }
    public class Scale : DrawObject
    {
        public override string Name { get; set; } = "Scale";
        public double Scope
        {
            get
            {
                if (image == null || image.Width <= 0) return 0;
                return RealScaleSize / image.Width;
            }
        }
        public float RealScaleSize { get; set; } = 1;
        public float ScaleRectSize { get; set; } = 10;
        private Brush PenBlack = Brushes.Black;
        private Brush PenWhite = Brushes.White;
        public int PixelWidth { get { return image == null ? image.Width : -1; } }
        public override void PrepareImage()
        {
            var width = GetWidth();
            if (width < 10) return;
            this.Angle = CalcAngle(StartPoint, EndPoint) - 90;
            double x = 0;
            var img = new Bitmap((int)width, (int)(ScaleRectSize * 2));

            using var graph = Graphics.FromImage(img);
            bool flag = true;
            while (x <= width)
            {

                if (flag)
                {
                    graph.FillRectangle(PenBlack, new Rectangle(new Point((int)x, 0),
                        new Size((int)ScaleRectSize, (int)ScaleRectSize)));
                    graph.FillRectangle(PenWhite, new Rectangle(new Point((int)x, (int)ScaleRectSize),
                        new Size((int)ScaleRectSize, (int)ScaleRectSize)));
                }
                else
                {
                    graph.FillRectangle(PenWhite, new Rectangle(new Point((int)x, 0),
                        new Size((int)ScaleRectSize, (int)ScaleRectSize)));
                    graph.FillRectangle(PenBlack, new Rectangle(new Point((int)x, (int)ScaleRectSize),
                        new Size((int)ScaleRectSize, (int)ScaleRectSize)));
                }
                flag = !flag;
                x = x + (double)ScaleRectSize;
            }
            image = img;
        }
        public override void Draw(Graphics graphics)
        {
            if (image == null) return;
            graphics.ResetTransform();
            graphics.RotateTransform((float)Angle);
            graphics.TranslateTransform(StartPoint.X, StartPoint.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            graphics.DrawImage(image, new Point(0, 0));
        }
    }
    [Serializable]
    public class Bussol : DrawObject
    {
        public override string Name { get; set; } = "Bussol";
        public float ZOOM { get; set; } = 1;
        public int FontSize { get; set; } = 7;
        public int Distance { get; set; } = 4000;
        public int CamAngle { get; set; } = 60;
        private Pen PenRect = new Pen(Color.Red, 2);

        public void DrawRect(Graphics graph, Color backColor)
        {
            graph.Clear(backColor);
            var rect = new Rectangle(
                        Math.Min(EndPoint.X, StartPoint.X),
                        Math.Min(EndPoint.Y, StartPoint.Y),
                        Math.Abs(EndPoint.X - StartPoint.X),
                        Math.Abs(EndPoint.Y - StartPoint.Y)
                    );
            graph.DrawRectangle(PenRect, rect);
        }

        public override void PrepareImage()
        {
            try
            {
                var x = Math.Abs(EndPoint.X - StartPoint.X);
                var y = Math.Abs(EndPoint.Y - StartPoint.Y);
                if (x <= 0) x = 1; if (y <= 0) y = 1;
                image = new Bitmap(x, y);
                DrawBussolToImage(image);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        public override void Draw(Graphics graphics)
        {
            if (image?.Width < 20 || image?.Height < 10)
                return;
            graphics.DrawImage(image, StartPoint);
        }

        public void DrawBussolToImage(Image im)
        {
            if (im == null) return;
            using var graph = Graphics.FromImage(im);
            var w = im.Width / 2;
            var h = im.Height / 2;
            Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 1);
            Font font = new Font("Arial UI", FontSize);
            float verstep = h / 10;
            float horstep = w / 10;
            double horraz = (double)CamAngle / 10 / 2 / (double)ZOOM;
            double verraz = (double)CamAngle / 16 * 9 / 10 / 2 / (double)ZOOM;
            graph.DrawLine(pen, new PointF() { X = w - 6, Y = h }, new PointF() { X = w + 6, Y = h });
            graph.DrawLine(pen, new PointF() { X = w, Y = h - 6 }, new PointF() { X = w, Y = h + 6 });


            for (var i = 1; i < 10; i++)
            {
                string ht = string.Format("{0:.##}", horraz * i);
                graph.DrawLine(pen, new PointF() { X = w - 4, Y = h + verstep * i }, new PointF() { X = w + 4, Y = h + verstep * i });

                graph.DrawLine(pen, new PointF() { X = w - horstep * i, Y = h - 4 }, new PointF() { X = w - horstep * i, Y = h + 4 });
                graph.DrawLine(pen, new PointF() { X = w + horstep * i, Y = h - 4 }, new PointF() { X = w + horstep * i, Y = h + 4 });
                StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                graph.DrawString(ht, font, Brushes.Red, new PointF(w - horstep * i - 5, h - 20));
                graph.DrawString(ht, font, Brushes.Red, new PointF(w + horstep * i - 5, h - 20));
                var radh = horraz * i * (Math.PI / 180);
                var razmh = Math.Tan(radh) * Distance;

                var th = string.Format("{0:0}", razmh);
                graph.DrawString(th, font, Brushes.Red, new PointF(w - horstep * i - 5, h + 8), drawFormat);
                graph.DrawString(th, font, Brushes.Red, new PointF(w + horstep * i - 5, h + 8), drawFormat);

            }
        }

    }
    public class DrawObject : IDisposable
    {
        public virtual string Name { get; set; } = "Scale";
        [XmlIgnore]
        public Bitmap? image { get; set; } = null;
        public double Angle { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public virtual void Draw(Graphics graphics)
        {
            if (image?.Width < 10 || image?.Height < 10)
                return;
            graphics.DrawImage(image, StartPoint);
        }
        public virtual void PrepareImage() { }
        public double GetWidth()
        {
            return Math.Sqrt((StartPoint.X - EndPoint.X) * (StartPoint.X - EndPoint.X) +
                (StartPoint.Y - EndPoint.Y) * (StartPoint.Y - EndPoint.Y));
        }

        public double CalcAngle(Point first, Point second)
        {
            double x = second.X - first.X;
            double y = second.Y - first.Y;
            double res = Math.Atan2(y, x) * 180 / Math.PI + 90;
            if (res < 0) res = 360 + res;
            return res;
        }
        public override string ToString()
        {
            return Name;
        }
        public void Dispose()
        {
            if (image != null) image.Dispose();
        }
    }

}

