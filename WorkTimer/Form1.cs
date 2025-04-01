using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading; //Работа с потоками

namespace WorkTimer
{
    public partial class MainForm : Form
    {

        #region Задаем переменные
        DateTime _dt = DateTime.Now;
        Thread _trd;
        IntPtr hwnd;
        #endregion

        #region Задаем переменные для графики
        int locWSz = 8;   //Блок - ширина (расстояние = 1 блок; квадратик = 4 блока)
        int locHSz = 8;   //Блок - высота
        int locX0 = 0;    //Начальная позиция - горизонталь
        int locY0 = 0;    //Начальная позиция - вертикаль
        int locXH1 = 8;   //8
        int locXH2 = 48;  //8+32+8
        int locXM1 = 112; //8+32+8+32+32
        int locXM2 = 152; //8+32+8+32+32+32+8
        int locXS1 = 216; //8+32+8+32+32+32+8+32+32
        int locXS2 = 256; //8+32+8+32+32+32+8+32+32+32+8
        int locY8 = 8;    //8
        int locY4 = 48;   //8+32+8
        int locY2 = 88;   //8+32+8+32+8
        int locY1 = 128;  //8+32+8+32+8+32+8
        //------------------------------------------------------
        Color _brBig = Color.Black; //Цвет фона
        SolidBrush _brSm1 = new SolidBrush(Color.DimGray);     //DimGray,      LightSlateGray   //Цвет неактивного квадратика
        SolidBrush _brSm2 = new SolidBrush(Color.SpringGreen); //SpringGreen,  DeepSkyBlue      //Цвет активного квадратика
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        //================================================================ ОСНОВНЫЕ ПРОЦЕДУРЫ

        #region Паузы между оотрисовкой
        private void TimeStep()
        {
            //if ((_dt.Day == 8) && (_dt.Month == 8)) { _brSm1.Color = Color.LightSlateGray; _brSm2.Color = Color.DeepSkyBlue; } //В день рождения изменяется цветовая схема
            this.cbUpdt.Invoke((MethodInvoker)delegate { if (cbUpdt.Checked) cbUpdt.Checked = false; else cbUpdt.Checked = true; });
            Thread.Sleep(999-DateTime.Now.Millisecond);
            while (true)
            {
                this.cbUpdt.Invoke((MethodInvoker)delegate { if (cbUpdt.Checked) cbUpdt.Checked = false; else cbUpdt.Checked = true; });
                Thread.Sleep(1000);
            }
        }
        #endregion

        #region Отрисовка времени
        private void TimeOut(int _h1, int _h2, int _m1, int _m2, int _s1, int _s2)
        {
            Graphics myGraph = Graphics.FromHwnd(Handle);
            //
            if (_h1 >= 8) { myGraph.FillRectangle(_brSm2, locXH1, locY8, locWSz * 4, locHSz * 4); _h1 = _h1 - 8; } else myGraph.FillRectangle(_brSm1, locXH1, locY8, locWSz * 4, locHSz * 4);
            if (_h1 >= 4) { myGraph.FillRectangle(_brSm2, locXH1, locY4, locWSz * 4, locHSz * 4); _h1 = _h1 - 4; } else myGraph.FillRectangle(_brSm1, locXH1, locY4, locWSz * 4, locHSz * 4);
            if (_h1 >= 2) { myGraph.FillRectangle(_brSm2, locXH1, locY2, locWSz * 4, locHSz * 4); _h1 = _h1 - 2; } else myGraph.FillRectangle(_brSm1, locXH1, locY2, locWSz * 4, locHSz * 4);
            if (_h1 >= 1) { myGraph.FillRectangle(_brSm2, locXH1, locY1, locWSz * 4, locHSz * 4); _h1 = _h1 - 1; } else myGraph.FillRectangle(_brSm1, locXH1, locY1, locWSz * 4, locHSz * 4);
            //
            if (_h2 >= 8) { myGraph.FillRectangle(_brSm2, locXH2, locY8, locWSz * 4, locHSz * 4); _h2 = _h2 - 8; } else myGraph.FillRectangle(_brSm1, locXH2, locY8, locWSz * 4, locHSz * 4);
            if (_h2 >= 4) { myGraph.FillRectangle(_brSm2, locXH2, locY4, locWSz * 4, locHSz * 4); _h2 = _h2 - 4; } else myGraph.FillRectangle(_brSm1, locXH2, locY4, locWSz * 4, locHSz * 4);
            if (_h2 >= 2) { myGraph.FillRectangle(_brSm2, locXH2, locY2, locWSz * 4, locHSz * 4); _h2 = _h2 - 2; } else myGraph.FillRectangle(_brSm1, locXH2, locY2, locWSz * 4, locHSz * 4);
            if (_h2 >= 1) { myGraph.FillRectangle(_brSm2, locXH2, locY1, locWSz * 4, locHSz * 4); _h2 = _h2 - 1; } else myGraph.FillRectangle(_brSm1, locXH2, locY1, locWSz * 4, locHSz * 4);
            //
            if (_m1 >= 8) { myGraph.FillRectangle(_brSm2, locXM1, locY8, locWSz * 4, locHSz * 4); _m1 = _m1 - 8; } else myGraph.FillRectangle(_brSm1, locXM1, locY8, locWSz * 4, locHSz * 4);
            if (_m1 >= 4) { myGraph.FillRectangle(_brSm2, locXM1, locY4, locWSz * 4, locHSz * 4); _m1 = _m1 - 4; } else myGraph.FillRectangle(_brSm1, locXM1, locY4, locWSz * 4, locHSz * 4);
            if (_m1 >= 2) { myGraph.FillRectangle(_brSm2, locXM1, locY2, locWSz * 4, locHSz * 4); _m1 = _m1 - 2; } else myGraph.FillRectangle(_brSm1, locXM1, locY2, locWSz * 4, locHSz * 4);
            if (_m1 >= 1) { myGraph.FillRectangle(_brSm2, locXM1, locY1, locWSz * 4, locHSz * 4); _m1 = _m1 - 1; } else myGraph.FillRectangle(_brSm1, locXM1, locY1, locWSz * 4, locHSz * 4);
            //
            if (_m2 >= 8) { myGraph.FillRectangle(_brSm2, locXM2, locY8, locWSz * 4, locHSz * 4); _m2 = _m2 - 8; } else myGraph.FillRectangle(_brSm1, locXM2, locY8, locWSz * 4, locHSz * 4);
            if (_m2 >= 4) { myGraph.FillRectangle(_brSm2, locXM2, locY4, locWSz * 4, locHSz * 4); _m2 = _m2 - 4; } else myGraph.FillRectangle(_brSm1, locXM2, locY4, locWSz * 4, locHSz * 4);
            if (_m2 >= 2) { myGraph.FillRectangle(_brSm2, locXM2, locY2, locWSz * 4, locHSz * 4); _m2 = _m2 - 2; } else myGraph.FillRectangle(_brSm1, locXM2, locY2, locWSz * 4, locHSz * 4);
            if (_m2 >= 1) { myGraph.FillRectangle(_brSm2, locXM2, locY1, locWSz * 4, locHSz * 4); _m2 = _m2 - 1; } else myGraph.FillRectangle(_brSm1, locXM2, locY1, locWSz * 4, locHSz * 4);
            //
            if (_s1 >= 8) { myGraph.FillRectangle(_brSm2, locXS1, locY8, locWSz * 4, locHSz * 4); _s1 = _s1 - 8; } else myGraph.FillRectangle(_brSm1, locXS1, locY8, locWSz * 4, locHSz * 4);
            if (_s1 >= 4) { myGraph.FillRectangle(_brSm2, locXS1, locY4, locWSz * 4, locHSz * 4); _s1 = _s1 - 4; } else myGraph.FillRectangle(_brSm1, locXS1, locY4, locWSz * 4, locHSz * 4);
            if (_s1 >= 2) { myGraph.FillRectangle(_brSm2, locXS1, locY2, locWSz * 4, locHSz * 4); _s1 = _s1 - 2; } else myGraph.FillRectangle(_brSm1, locXS1, locY2, locWSz * 4, locHSz * 4);
            if (_s1 >= 1) { myGraph.FillRectangle(_brSm2, locXS1, locY1, locWSz * 4, locHSz * 4); _s1 = _s1 - 1; } else myGraph.FillRectangle(_brSm1, locXS1, locY1, locWSz * 4, locHSz * 4);
            //
            if (_s2 >= 8) { myGraph.FillRectangle(_brSm2, locXS2, locY8, locWSz * 4, locHSz * 4); _s2 = _s2 - 8; } else myGraph.FillRectangle(_brSm1, locXS2, locY8, locWSz * 4, locHSz * 4);
            if (_s2 >= 4) { myGraph.FillRectangle(_brSm2, locXS2, locY4, locWSz * 4, locHSz * 4); _s2 = _s2 - 4; } else myGraph.FillRectangle(_brSm1, locXS2, locY4, locWSz * 4, locHSz * 4);
            if (_s2 >= 2) { myGraph.FillRectangle(_brSm2, locXS2, locY2, locWSz * 4, locHSz * 4); _s2 = _s2 - 2; } else myGraph.FillRectangle(_brSm1, locXS2, locY2, locWSz * 4, locHSz * 4);
            if (_s2 >= 1) { myGraph.FillRectangle(_brSm2, locXS2, locY1, locWSz * 4, locHSz * 4); _s2 = _s2 - 1; } else myGraph.FillRectangle(_brSm1, locXS2, locY1, locWSz * 4, locHSz * 4);
        }
        #endregion

        #region Конвертер
        private int ConvertCHtoINT(char _ch)
        {
            if (_ch == '1') return 1;
            if (_ch == '2') return 2;
            if (_ch == '3') return 3;
            if (_ch == '4') return 4;
            if (_ch == '5') return 5;
            if (_ch == '6') return 6;
            if (_ch == '7') return 7;
            if (_ch == '8') return 8;
            if (_ch == '9') return 9;
            return 0;
        }
        #endregion

        //================================================================ СОБЫТИЯ ЭЛЕМЕНТОВ ФОРМЫ

        #region Двойной щелчок по иконке в системном лотке
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }
        #endregion

        #region Событие при изменении статуса ЧекБокса
        private void cbUpdt_CheckedChanged(object sender, EventArgs e)
        {
            _dt = DateTime.Now;
            TimeOut(ConvertCHtoINT(_dt.Hour.ToString("00")[0]), ConvertCHtoINT(_dt.Hour.ToString("00")[1]), ConvertCHtoINT(_dt.Minute.ToString("00")[0]), ConvertCHtoINT(_dt.Minute.ToString("00")[1]), ConvertCHtoINT(_dt.Second.ToString("00")[0]), ConvertCHtoINT(_dt.Second.ToString("00")[1]));
        }
        #endregion

        //================================================================ БЛОК УПРАВЛЕНИЯ КРИТИЧНЫМИ ПРОЦЕДУРАМИ

        //================================================================ СОБЫТИЯ ФОРМЫ

        #region Событие при загрузке формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            hwnd = this.Handle;
            _trd = new Thread(new ThreadStart(TimeStep));
            _trd.Start();
        }
        #endregion

        #region Событие возникает при первом отображении формы
        private void MainForm_Shown(object sender, EventArgs e)
        {
            MainForm.ActiveForm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - MainForm.ActiveForm.Size.Width - 100, 100);
            MainForm.ActiveForm.BackColor = _brBig;
        }
        #endregion

        #region Событие перед закрытием формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _trd.Abort();
        }
        #endregion

        #region Событие после закрытия формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        #endregion

        #region Событие при изменение размера формы
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (MainForm.ActiveForm.WindowState != FormWindowState.Minimized)
            {
                locWSz = MainForm.ActiveForm.Width / 37;
                locHSz = (MainForm.ActiveForm.Height - 25) / 21;
                locX0  = 0;
                locY0  = 0;
                locXH1 = locX0 + locWSz;
                locXH2 = locX0 + locWSz * 6;
                locXM1 = locX0 + locWSz * 14;
                locXM2 = locX0 + locWSz * 19;
                locXS1 = locX0 + locWSz * 27;
                locXS2 = locX0 + locWSz * 32;
                locY8 = locY0 + locHSz;
                locY4 = locY0 + locHSz * 6;
                locY2 = locY0 + locHSz * 11;
                locY1 = locY0 + locHSz * 16;
                Graphics myGraph = Graphics.FromHwnd(Handle);
                myGraph.FillRectangle(new SolidBrush(_brBig), locX0, locY0, MainForm.ActiveForm.Width, MainForm.ActiveForm.Height - 25);
                TimeOut(ConvertCHtoINT(_dt.Hour.ToString("00")[0]), ConvertCHtoINT(_dt.Hour.ToString("00")[1]), ConvertCHtoINT(_dt.Minute.ToString("00")[0]), ConvertCHtoINT(_dt.Minute.ToString("00")[1]), ConvertCHtoINT(_dt.Second.ToString("00")[0]), ConvertCHtoINT(_dt.Second.ToString("00")[1]));
            }
        }
        #endregion
    }
}
