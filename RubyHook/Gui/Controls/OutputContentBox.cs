﻿// Retoolkit - Scripting-based reverse engineering toolkit for Windows OS'es
// Copyright (C) 2010  James Leskovar
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Retoolkit.Gui.Controls
{
  public partial class OutputContentBox : DockContent
  {
    public OutputContentBox()
    {
      InitializeComponent();
    }

    public void AppendText(string text)
    {
      this.Invoke(new Action<string>(_AppendText), text);
    }

    public void Clear()
    {
      this.Invoke(new Action(_Clear));
    }

    private void _AppendText(string text)
    {
      scintilla.Caret.Goto(scintilla.TextLength);
      scintilla.AppendText(text);
    }

    private void _Clear()
    {
      scintilla.Text = "";
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
    }
  }
}
