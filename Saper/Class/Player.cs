using System.Drawing;
using System.Windows.Forms;

namespace Saper
{
    public static class Player
    {
        public static void OnButtonPressedMouse(object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;
            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton);
                    break;
            }
        }

        private static void OnRightButtonPressed(Button pressedButton)
        {
            MapController.currentPictureToSet++;
            int posX = 0;
            int posY = 0;
            switch (MapController.currentPictureToSet)
            {
                case 0:
                    posX = 0;
                    posY = 0;
                    break;
                case 1:
                    posX = 0;
                    posY = 2;
                    break;
            }
            pressedButton.Image = MapController.FindNeededImage(posX, posY);
            MapController.currentPictureToSet %= 2;
        }
    

        private static void OnLeftButtonPressed(Button pressedButton)
        {
            pressedButton.Enabled = false;
            int iButton = pressedButton.Location.Y / MapController.cellSize;
            int jButton = pressedButton.Location.X / MapController.cellSize;
            if (MapController.isFirstStep)
            {
                MapController.firstCoord = new Point(jButton, iButton);
                MapController.SeedMap();
                MapController.CountCellBomb();
                MapController.isFirstStep = false;
            }
            MapController.OpenCells(iButton, jButton);

            if (MapController.map[iButton, jButton] == -1)
            {
                MapController.ShowAllBombs(iButton, jButton);
                MessageBox.Show("Поражение!");
                MapController.form.Controls.Clear();
                MapController.Init(MapController.form);
            }

            if (MapController.openMap == MapController.mapSize * MapController.mapSize - MapController.countTraps)
            {
                MessageBox.Show("Победа!");
                MapController.form.Controls.Clear();
                MapController.Init(MapController.form);
            }
        }
    }
}
