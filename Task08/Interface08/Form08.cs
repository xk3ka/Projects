using Implementation08;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface08
{
    public partial class Form08 : Form
    {
        //private ClassLooker _classLooker;
        private Emulator _emulator;
        private Thread _repaintThread = null;
        private List<Type> _types = new List<Type>();
        //private Type _choosedType;

        public Form08()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;

            //_classLooker = new ClassLooker(@"A:\source\ISIT\Task08\Interface08\bin\Debug\Implementation08.dll");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (_repaintThread == null)
            {
                List<Operator> allOperators = new List<Operator>();
                int Step = 2;
                for (int i = 0; i < (int)numericUpDown2.Value; i++)
                {
                    Quadrocopter q = new Quadrocopter(new Route(
                        new List<Coord>(){
                            new Coord(4, 4 + 100 * i, Step),
                            new Coord(panel1.Width - 110, 4 + 100 * i, Step),
                        }), new Coord(100, 100, 5), (int)numericUpDown1.Value);
                    Operator op1 = new Operator(q);
                    allOperators.Add(op1);
                }

                Step *= 5;
                IMechanic mechanic = new MechanicDefault(new Coord(panel1.Width / 2, panel1.Height / 2, Step), (new Coord(panel1.Width / 2, panel1.Height / 2, Step)));
                _emulator = new Emulator(allOperators, mechanic);
                _emulator.Start();
                _repaintThread = new Thread(PanelRepaint);
                _repaintThread.Start();
                button1.Text = @"Stop";
            }
            else
            {
                _emulator.Stop();
                _repaintThread.Abort();
                _repaintThread = null;
                button1.Text = @"Start";
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            if (_emulator == null)
            {
                return;
            }

            _emulator.Mechanic.Paint(g);

            foreach (var emulatorOp in _emulator.Operators)
            {
                emulatorOp.Paint(g);
                emulatorOp.Quadrocopter.Paint(g);
            }

        }
        private void PanelRepaint()
        {
            while (true)
            {
                Thread.Sleep(50);
                panel1.Invalidate();
            }
        }

        private void Form08_Load(object sender, EventArgs e)
        {
            _emulator?.Stop();
            _repaintThread?.Abort();
        }
    }
}
