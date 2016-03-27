using System;
using System.Diagnostics;
using System.Windows;

namespace KnolwdgeBase.Infrastructure
{
    public static class Logger
    {
        public enum Level
        {
            Info,
            Error,
            Exception,
            Debug            
        };

        public static void Log(Level lvl,String classname, String msg)
        {
            //Debug.Print("------------{0}------------", classname);
            //Debug.Print(msg);
            //return;
            
            switch (lvl)
            {
                case Level.Info:
                    MessageBox.Show(msg, "Info " + classname, MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case Level.Debug:
                    Debug.Print(classname +"->"+ msg);
                    break;
                case Level.Error:                  
                case Level.Exception:
                    MessageBox.Show(msg, "Exception " + classname, MessageBoxButton.OK, MessageBoxImage.Error);                    
                    break;                
                default:
                    MessageBox.Show(msg, "Default " + classname, MessageBoxButton.OK,MessageBoxImage.Warning);
                    break;
            }
        }
    }
}
