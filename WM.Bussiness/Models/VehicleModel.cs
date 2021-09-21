using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WM.Bussiness.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public MakeModel make { get; set; }
        public ModelModel modelo { get; set; }
        public VersionModel model { get; set; }
        public string image { get; set; }
        public double km { get; set; }
        public decimal price { get; set; }
        public int yearModel { get; set; }
        public int yearFab { get; set; }
        public string color { get; set; }
        /*
    "ID": 1,
    "Make": "Honda",
    "Model": "City",
    "Version": "2.0 EXL 4X4 16V GASOLINA 4P AUTOMÁTICO",
    "Image": "http://desafioonline.webmotors.com.br/content/img/01.jpg",
    "KM": 0,
    "Price": "59000,00",
    "YearModel": 2018,
    "YearFab": 2017,
    "Color": "Azul"
        */
    }
}
