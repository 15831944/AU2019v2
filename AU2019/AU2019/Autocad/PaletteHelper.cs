using Autodesk.AutoCAD.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms.Integration;

namespace AU2019.Autocad
{
    /// <summary>
    /// Class for working with Palettes
    /// </summary>
    public static class PaletteHelper
    {
        static PaletteSet _ps = null;

        public static void ShowPalette(string setName, string paletteName, System.Drawing.Size size, UIElement wpfUI)
        {
            GetPaletteSet(setName, size);
            if (!IsPalette(paletteName))
            {
                ElementHost host = new ElementHost()
                {
                    AutoSize = true,
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    Child = wpfUI
                };
                Palette palette = _ps.Add(paletteName, host);
            }

            var index = GetPaletteIndex(paletteName);
            _ps.Activate(index);
            _ps.Visible = true;
            _ps.Size = size;
        }

        public static PaletteSet GetPaletteSet(string name, System.Drawing.Size size)
        {
            if (_ps == null)
            {
                _ps = new PaletteSet(name)
                {
                    Size = size,
                    DockEnabled = (DockSides)((int)DockSides.Left + (int)DockSides.Right)
                };
            }

            return _ps;
        }

        private static bool IsPalette(string paletteName)
        {
            if (_ps.Count == 0)
                return false;

            IEnumerator palettes = _ps.GetEnumerator();
            while (palettes.MoveNext())
            {
                if (((Palette)palettes.Current).Name == paletteName)
                    return true;
            }

            return false;
        }

        private static int GetPaletteIndex(string paletteName)
        {
            var cnt = 0;
            IEnumerator palettes = _ps.GetEnumerator();
            while (palettes.MoveNext())
            {
                if (((Palette)palettes.Current).Name == paletteName)
                    break;

                cnt++;
            }

            return cnt;
        }

        public static void DockPaletteSet(DockSides dockSides)
        {
            if (_ps != null)
            {
                _ps.Dock = dockSides;
            }
        }
    }
}
