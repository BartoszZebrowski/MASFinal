using MASFinal.Backend.Models;
using System;

using System.Windows;
using System.Windows.Controls;

namespace MASFinal.Views.Common
{
    public class VehicleTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BusTemplate { get; set; }
        public DataTemplate CamperTemplate { get; set; }
        public DataTemplate AmphibianTemplate { get; set; }
        public DataTemplate BoatTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var vehicle = item as IVehicle;
            if (vehicle != null)
            {
                switch (vehicle.Type)
                {
                    case "Bus":
                        return BusTemplate;
                    case "Camper":
                        return CamperTemplate;
                    case "Amphibian":
                        return AmphibianTemplate;
                    case "Boat":
                        return BoatTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
