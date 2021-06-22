using System.Windows.Forms;

namespace Saper
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Play_Click(object sender, System.EventArgs e)
        {
            MapController.Init(this);
            Exit.Visible = false;
            Play.Visible = false;
            Rules.Visible = false;
        }

        private void Rules_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Сапер — это простая, но в то же время очень интересная игра-головоломка. В начале игры открывается поле, разделенное на ровные клетки, на котором спрятаны мины. Когда игрок кликает мышкой по произвольной клетке на поле, то в этой клетке появляется цифра, показывающая сколько мин спрятано по соседству. Анализируя эти цифры, можно понять, где спрятаны следующие мины. Затем на клетке (в которой игрок предполагает, что спрятана мина) ставится флажок для наглядного обозначения мины.");
        }
    }
}
