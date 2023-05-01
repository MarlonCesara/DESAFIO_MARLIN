using Entidades.Notificacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades
{
    [Table("TB_ALUNO")]
    public class Aluno : Notifica
    {
        [Key]
        [Column("ALN_ID")]
        public int Id { get; set; }

        [Column("ALN_CPF")]
        public string CPF { get; set; }

        [Column("ALN_EMAIL")]
        public string Email { get; set; }

        [Column("ALN_NOME")]
        public string Nome { get; set; }

    }
}
