using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIFILMES.Models
{
    [Table("tb_filme")]
    [Index("IdDiretor", Name = "fk_tb_filme_tb_diretor_idx")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbFilmeAtors = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("nm_filme")]
        [StringLength(100)]
        public string NmFilme { get; set; } = null!;
        [Column("ds_genero")]
        [StringLength(100)]
        public string DsGenero { get; set; } = null!;
        [Column("nr_duracao")]
        public int? NrDuracao { get; set; }
        [Column("vl_avaliacao")]
        [Precision(10, 2)]
        public decimal? VlAvaliacao { get; set; }
        [Column("bt_disponivel")]
        public bool? BtDisponivel { get; set; }
        [Column("dt_lancamento")]
        public DateTime? DtLancamento { get; set; }
        [Column("id_diretor")]
        public int? IdDiretor { get; set; }

        [ForeignKey("IdDiretor")]
        [InverseProperty("TbFilmes")]
        public virtual TbDiretor? IdDiretorNavigation { get; set; }
        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtors { get; set; }
    }
}
