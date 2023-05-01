using Entidades.Notificacoes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades
{
    [Table("TB_TURMA")]
    public class Turma : Notifica
    {
        [Key]
        [Column("TRM_ID")]
        public int Id { get; set; }

        [Column("TRM_NUMERO")]
        public int Numero { get; set; }

        [Column("TRM_ANO_LETIVO")]
        public DateTime AnoLetivo { get; set; }

    }
}
