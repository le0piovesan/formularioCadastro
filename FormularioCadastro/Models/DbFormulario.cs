using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormularioCadastro.Models
{
    [Table("formulario", Schema = "public")]

    public class DbFormulario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime data_nascimento { get; set; }
        public string rua { get; set; }
        public string num { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string mensagem { get; set; }
    }
}

//CREATE TABLE formulario(
//	id_usuario serial not null primary key,
//    nome varchar(80) not null,
//	email varchar(40) not null,
//	data_nascimento date not null,
//    rua varchar(50) not null,
//	num char(10) not null,
//	cidade varchar(50) not null,
//	uf char(2) not null,
//	mensagem varchar(300) not null
//);