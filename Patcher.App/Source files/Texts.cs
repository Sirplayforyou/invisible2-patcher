using System.Collections.Generic;

namespace Patcher.App.Source_files
{
    class Texts
    {
        public enum Keys
        {
            UNKNOWNERROR,
            MISSINGBINARY,
            CANNOTSTART,
            NONETWORK,
            CONNECTING,
            LISTDOWNLOAD,
            CHECKFILE,
            DOWNLOADFILE,
            COMPLETEPROGRESS,
            CURRENTPROGRESS,
            CHECKCOMPLETE,
            DOWNLOADCOMPLETE,
            DOWNLOADSPEED
        }

        private static Dictionary<Keys, string> Text = new Dictionary<Keys, string>
        {
            {Keys.UNKNOWNERROR,                         "Ein unbekannter, aber kritischer Fehler ist aufgetreten...Fehlermeldung, die zur Lösung des Problems beitragen kann: \n{0}"},
            {Keys.MISSINGBINARY,                        "Das Spiel kann nicht gestartet werden, weil die {0} fehlt."},
            {Keys.CANNOTSTART,                          "Das Spiel kann nicht gestartet werden, weil {0} nicht erreichbar ist."},
            {Keys.NONETWORK,                            "Verbindung zum Server kann nicht hergestellt werden, bitte überprüfen Sie Ihr Netzwerk und versuchen Sie es erneut."},
            {Keys.CONNECTING,                           "Mit dem Server verbinden..."},
            {Keys.LISTDOWNLOAD,                         "Prüfe auf Updates..."},
            {Keys.CHECKFILE,                            "{0} überprüfen..."},
            {Keys.DOWNLOADFILE,                         "{0} herunterladen... {1}/ {2}"},
            {Keys.COMPLETEPROGRESS,                     "Kompletter Fortschritt: {0}%"},
            {Keys.CURRENTPROGRESS,                      "Fortschritt der aktuellen Datei: {0}%  |  {1} kb/s"},
            {Keys.CHECKCOMPLETE,                        "Jede Datei wurde ordnungsgemäß geprüft"},
            {Keys.DOWNLOADCOMPLETE,                     "Alle erforderlichen Dateien wurden ordnungsgemäß heruntergeladen."},
            {Keys.DOWNLOADSPEED,                        "{0} kb/s"}
        };

        public static string GetText(Keys Key, params object[] Arguments)
        {
            foreach (KeyValuePair<Keys, string> currentItem in Text)
            {
                if (currentItem.Key == Key)
                {
                    return string.Format(currentItem.Value, Arguments);
                }
            }

            return null;
        }
    }
}
