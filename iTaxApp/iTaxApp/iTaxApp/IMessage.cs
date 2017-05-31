using iTaxApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace iTaxApp

{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
