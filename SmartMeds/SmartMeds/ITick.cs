using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMeds
{
    interface ITick
    {
        void MinuteTickEvent(object sender, EventArgs e);
    }
}
