using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIFILMES.Models
{
    [Table("tb_filme_ator")]
    [Index("IdAtor", Name = "fk_tb_filme_ator_tb_ator1_idx")]
    [Index("IdFilme", Name = "fk_tb_filme_ator_tb_filme1_idx")]
    public partial class TbFilmeAtor
    {
        [Key]
        [Column("id_filme_ator")]
        public int IdFilmeAtor { get; set; }
        [Column("nm_personagem")]
        [StringLength(45)]
        public string? NmPersonagem { get; set; }
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("id_filme")]
        public int IdFilme { get; set; }

        [ForeignKey("IdAtor")]
        [InverseProperty("TbFilmeAtors")]
        public virtual TbAtor IdAtorNavigation { get; set; } = null!;
        [ForeignKey("IdFilme")]
        [InverseProperty("TbFilmeAtors")]
        public virtual TbFilme IdFilmeNavigation { get; set; } = null!;
    }
}
