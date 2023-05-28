using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace BussolWinForms
{
    public partial class Form1 : Form
    {
        private List<Bussol> ListBussols = new List<Bussol>();
        public Form1()
        {
            InitializeComponent();
            // StayOnTop.Checked = true;
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

        private async void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (startDrawBussol && mouseStartDrawBussol)
            {
                using Graphics g = this.CreateGraphics();
                currBussol.EndPoint = e.Location;
                currBussol.DrawRect(g, this.BackColor);
                currBussol.PrepareImage();
                currBussol.DrawBussol(g);
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (startDrawBussol)
                {
                    currBussol.StartPoint = e.Location;
                    mouseStartDrawBussol = true;
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
                RePaintAllBussols();
            }
        }

        private void RePaint_Click(object sender, EventArgs e)
        {
            Refresh();
            RePaintAllBussols();
        }

        private void RePaintAllBussols()
        {
            using var g = this.CreateGraphics();
            g.Clear(BackColor);
            foreach (var item in ListBussols)
            {
                try
                {
                    item.PrepareImage();
                    item.DrawBussol(g);
                }
                catch { };
            }
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
                RePaintAllBussols();
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
                RePaintAllBussols();
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
                RePaintAllBussols();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bus = BussolsCombo.SelectedItem as Bussol;
            if (bus == null) return;
            BussolsCombo.Items.Remove(bus);
            ListBussols.Remove(bus);
            RePaintAllBussols();
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
                RePaintAllBussols();
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
            RePaintAllBussols();

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            BussolsCombo.Items.Clear();
            ListBussols.Clear();    
            RePaintAllBussols() ;
        }
    }
    [Serializable]
    public class Bussol
    {
        public string Name { get; set; } = "Bussol";
        public Point StartPoint { get; set; } = new();
        public Point EndPoint { get; set; } = new();
        public float ZOOM { get; set; } = 1;
        public int FontSize { get; set; } = 7;
        public int Distance { get; set; } = 4000;
        public int CamAngle { get; set; } = 60;
        private Pen PenRect = new Pen(Color.Red, 2);
        private Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 1);
        [XmlIgnore]
        public Bitmap imagebussol;
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

        public void PrepareImage()
        {
            try
            {
                var x = Math.Abs(EndPoint.X - StartPoint.X);
                var y = Math.Abs(EndPoint.Y - StartPoint.Y);
                if (x <= 0) x = 1; if (y <= 0) y = 1;
                imagebussol = new Bitmap(x, y);
                DrawBussolToImage(imagebussol);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        public void DrawBussol(Graphics graphics)
        {
            if (imagebussol.Width < 20 || imagebussol.Height < 10)
                return;
            graphics.DrawImage(imagebussol, StartPoint);
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
        public override string ToString()
        {
            return Name;
        }

    }
}

