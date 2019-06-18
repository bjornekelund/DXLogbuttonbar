﻿using System;
using System.Drawing;

namespace DXLog.net
{
    public partial class DXLbuttonbar : KForm
    {
        public static String CusWinName
        {
            get { return "CW button bar"; }
        }

        public static Int32 CusFormID
        {
            get { return 1004; }
        }
        
        private ContestData _cdata = null;
        private Font _windowFont = new Font("Courier New", 10, FontStyle.Regular);

        private FrmMain mainForm = null;

        private delegate void newQsoSaved(DXQSO qso);

        public DXLbuttonbar()
        {
            InitializeComponent();
        }

        public DXLbuttonbar(ContestData cdata)
        {
            InitializeComponent();
            ColorSetTypes = new String[] { "Background", "Color", "Header back color", "Header color", "Footer back color", "Footer color", "Final score color", "Selection back color", "Selection color" };
            DefaultColors = new Color[] { Color.Turquoise, Color.Black, Color.Gray, Color.Black, Color.Silver, Color.Black, Color.Blue, Color.SteelBlue, Color.White };
            _cdata = cdata;
            this.FormLayoutChangeEvent += new FormLayoutChange(handle_FormLayoutChangeEvent);
        }

        private void handle_FormLayoutChangeEvent()
        {
            InitializeLayout();
        }

        public override void InitializeLayout()
        {
            base.InitializeLayout(_windowFont);
            if (base.FormLayout.FontName.Contains("Courier"))
                _windowFont = new Font(base.FormLayout.FontName, base.FormLayout.FontSize, FontStyle.Regular);
            else
                _windowFont = Helper.GetSpecialFont(FontStyle.Regular, base.FormLayout.FontSize);

            if (mainForm == null)
            {
                mainForm = (FrmMain)(this.ParentForm == null ? this.Owner : this.ParentForm);
            }
        }

        private bool RunMode()
        {
            return (_cdata.FocusedRadio == 1) ? _cdata.RadioModePrimary == 0 : _cdata.RadioModeSecondary == 0;
        }

        private void F1_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage1 : _cdata.dalHeader.SP_CWMessage1, _cdata.FocusedRadio, true);
        }

        private void F2_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage2 : _cdata.dalHeader.SP_CWMessage2, _cdata.FocusedRadio, true);
        }

        private void F3_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage3 : _cdata.dalHeader.SP_CWMessage3, _cdata.FocusedRadio, true);
        }

        private void F4_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage4 : _cdata.dalHeader.SP_CWMessage4, _cdata.FocusedRadio, true);
        }

        private void F5_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage5 : _cdata.dalHeader.SP_CWMessage5, _cdata.FocusedRadio, true);
        }

        private void F6_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage6 : _cdata.dalHeader.SP_CWMessage6, _cdata.FocusedRadio, true);
        }

        private void F7_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessage7 : _cdata.dalHeader.SP_CWMessage7, _cdata.FocusedRadio, true);
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            mainForm.SendCW(RunMode() ? _cdata.dalHeader.CWMessagePLUS : _cdata.dalHeader.SP_CWMessagePLUS, _cdata.FocusedRadio, true);
        }
    }
}
