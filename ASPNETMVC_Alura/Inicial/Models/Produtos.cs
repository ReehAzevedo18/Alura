using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inicial.Models
{
    public class Produtos
    {
        public int Id { get; set; }

        [Required, StringLength(20)] //model validation só será gravado se não estiver nulo e for menor que 20 caracteres
        public String Nome { get; set; }
        public float Preco { get; set; }
        public CategoriaDeProduto CategoriaId { get; set; }
        public int? CategoriaId { get; set; }
        public String Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}