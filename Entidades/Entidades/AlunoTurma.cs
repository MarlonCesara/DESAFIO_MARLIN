using Entidades.Notificacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades
{
    [Table("TB_ALUNO_TURMA")]
    public class AlunoTurma : Notifica
    {
        [Key]
        [Column("ALT_ID")]
        public int Id { get; set; }

        [ForeignKey("Aluno")]
        [Column("ALN_ID", Order = 1)]
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        [ForeignKey("Turma")]
        [Column("TRM_ID", Order = 2)]
        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; }

    }
}
