using System.Drawing;
using System.Windows.Forms;
namespace Session5
{
    public interface IMyGraphics
    {
        void SetRectangleParms(int width, int height);
        void DrawRectangle(Form f);
        void DrawButton(Form f);
    }    
    public class MyGraphics : Control , IMyGraphics//or Form
    {
        public int x,y,width, height;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public void SetRectangleParms(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void DrawRectangle(Form f)
        {
            Graphics g = f.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            Rectangle rect = new Rectangle(x, y, width, height);
            g.DrawRectangle(pen, rect);
            Brush brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, rect);
            Font font = new Font("Arial", 16);
            string text = "My Rectangle";
            SizeF textSize = g.MeasureString(text, font);
            float textX = x + (width - textSize.Width) / 2;
            float textY = y + (height - textSize.Height) / 2;
            g.DrawString(text, font, Brushes.White, textX, textY);
            g.Dispose();
        }
        public void DrawButton(Form f)
        {
           Button myButton = new Button();
            myButton.Name = "myButton";
            myButton.Text = "myButton";
            myButton.Location = new System.Drawing.Point(230, 68);
            myButton.Size = new System.Drawing.Size(75, 23);
            f.Controls.Add(myButton);
        }
    }
}
