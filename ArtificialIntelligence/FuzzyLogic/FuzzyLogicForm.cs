using MathObjects;
using System.ComponentModel;

namespace ArtificialIntelligence.FuzzyLogic
{
    public partial class FuzzyLogicForm : Form
    {
        private Graphics g;

        private FuzzyLogicRobotController? ctrl;
        private ObstacleMap? map;
        private Image? mapImage = null;

        private Vector? spawnPosition;
        private bool simulation;

        public FuzzyLogicForm()
        {
            InitializeComponent();

            g = mapPictureBox.CreateGraphics();
            ofd.InitialDirectory = @"..\..\..\Resources\RobotMaps\";
            ofd.FileOk += OnFileSelected;

            loadMapButton.Click += (object sender, EventArgs e) => ofd.ShowDialog();
            launchRobot.Click += SetupRobot;

            simulation = false;
        }

        private async void SetupRobot(object sender, EventArgs e)
        {
            g = mapPictureBox.CreateGraphics();
            simulation = true;
            launchRobot.Text = "Stop";
            launchRobot.Click -= SetupRobot;
            launchRobot.Click += StopRobot;

            loadMapButton.Enabled = false;
            generateRandomMap.Enabled = false;

            await Task.Run(() =>
            {
                while (spawnPosition is null) if (!simulation) return;
                ctrl = new(spawnPosition, 0.3, map!);
                Vector realRobotSize = new(0.3 * map.PreferredSize.Width / map.ActualSize.Width, 0.3 * map.PreferredSize.Height / map.ActualSize.Height);

                while (simulation)
                {
                    Vector drawRobotPosition = new Vector(ctrl.RobotPosition[0] * map.PreferredSize.Width / map.ActualSize.Width, ctrl.RobotPosition[1] * map.PreferredSize.Height / map.ActualSize.Height) - realRobotSize * 0.5;

                    g.Clear(Color.White);
                    g.DrawImage(mapImage!, 0, 0, map.PreferredSize.Width, map.PreferredSize.Height);
                    g.FillEllipse(new SolidBrush(Color.Red), (float)drawRobotPosition[0], (float)drawRobotPosition[1], (float)realRobotSize[0], (float)realRobotSize[1]);

                    ctrl.MakeOneIteration();
                    Thread.Sleep(100);
                }
            });

            spawnPosition = null;
        }

        private void StopRobot(object sender, EventArgs e)
        {
            simulation = false;
            launchRobot.Text = "Launch Robot";
            launchRobot.Click += SetupRobot;
            launchRobot.Click -= StopRobot;

            loadMapButton.Enabled = true;
            generateRandomMap.Enabled = true;
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            if (!(simulation && spawnPosition == null)) return;

            int cX = 10, cY = 40;
            Point mainFormLocation = Parent.Location;
            if (Parent is GroupBox)
            {
                mainFormLocation = new(Parent.Location.X + ((Form)Parent.Parent).Location.X, Parent.Location.Y + ((Form)Parent.Parent).Location.Y);
            }

            Point resultPos = new(Cursor.Position.X - Location.X - mainFormLocation.X - mapPictureBox.Location.X - cX, Cursor.Position.Y - Location.Y - mainFormLocation.Y - mapPictureBox.Location.Y - cY);

            spawnPosition = new((double)resultPos.X * map.ActualSize.Width / map.PreferredSize.Width, (double)resultPos.Y * map.ActualSize.Height / map.PreferredSize.Height);
        }

        private void OnFileSelected(object sender, CancelEventArgs e) => SetMap(ObstacleMap.LoadFromFile(ofd.FileName));

        private void GenerateRandomMapButton(object sender, EventArgs e) => SetMap(ObstacleMap.GenerateRandom(8, 8, 0.3));

        private void SetMap(ObstacleMap map)
        {
            this.map = map;
            launchRobot.Enabled = true;
            map.PreferredSize = mapPictureBox.Size;
            mapPictureBox.Image = mapImage = map.Draw();
        }

        private void OnPictureBoxResize(object sender, EventArgs e)
        {
            if (map is null) return;
            map.PreferredSize = mapPictureBox.Size;
        }
    }
}
