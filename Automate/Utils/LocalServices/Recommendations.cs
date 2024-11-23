using Automate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Utils.LocalServices
{
    public class Recommendations
    {
        const string DEFAULT_MESSAGE = "Les conditions sont dans les barêmes";
        public List<string> Messages { get; set; }
        private OutsideConditions currentConditions;

        public Recommendations(OutsideConditions conditions)
        {
            Messages = new List<string>();
            currentConditions = conditions;
            CheckForProblems();
            if (Messages.Count <= 0)
                Messages.Add(DEFAULT_MESSAGE);
        }

        public void CheckForProblems()
        {
            CheckTemp();
            CheckHumidity();
            CheckLighting();
        }

        public void CheckTemp()
        {
            if (currentConditions.Temperature > 27)
                Messages.Add("Température supérieure à 27 °C, Veuillez ouvrir les fenêtres");

            else if (currentConditions.Temperature < 18)
                Messages.Add("Température inférieure à 18 °C, Veuillez fermer les fenêtres");

        }

        public void CheckHumidity()
        {
            if (currentConditions.Humidity > 80)
                Messages.Add("Humidité supérieure à 80%, Veuillez lancer la ventilation");

            else if (currentConditions.Humidity < 60)
                Messages.Add("Humidité inférieure à 60%, Veuillez arrêter la ventilation");
        }

        public void CheckLighting()
        {
            if (currentConditions.Lighting > 7000)
                Messages.Add("Luminosité supérieure à 7000 lux, Veuillez fermer les lumières");

            else if (currentConditions.Lighting < 3000)
                Messages.Add("Luminosité inférieure à 3000 lux, Veuillez ouvrir les lumières");
        }
    }
}
