using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WM.App.ViewModels
{
    public class AnuncioViewModel
    {
        public int ID { get; set; }

        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Make { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Model { get; set; }


        [DisplayName("Versão")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Version { get; set; }

        [DisplayName("Ano")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public int Year { get; set; }

        [DisplayName("Quilometragem")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(0, 9999999999999999.99, ErrorMessage = "{0} não pode ser menor que zero")]
        public int KM { get; set; }


        [DisplayName("Observação")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Obs { get; set; }
    }
}
