using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using Sys = Cosmos.System;

namespace Firo_OS
{
    public class Kernel : Sys.Kernel
    {
        public static VBECanvas canvas = new VBECanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
        [ManifestResourceStream(ResourceName = "Firo_OS.b931f81734269.57b74717dcbe7.bmp")] public static byte[] cursor;
        public static Bitmap curs = new Bitmap(cursor);
        protected override void BeforeRun()
        {
           
            
            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
            MouseManager.X = 1920 / 2;
            MouseManager.Y = 1080 / 2;
        }

        protected override void Run()
        {
            canvas.DrawFilledRectangle(new Pen(Color.Firebrick), 0, 0, 1920, 1080);
            canvas.DrawFilledRectangle(new Pen(Color.WhiteSmoke), 0, 0, 1920, 35);
            canvas.DrawString(DateTime.Now, Sys.Graphics.Fonts.PCScreenFont);
            canvas.DrawString()
            canvas.DrawImageAlpha(curs, (int)MouseManager.X, (int)MouseManager.Y);

            Heap.Collect();
            canvas.Display();

        }
        
    }
}
